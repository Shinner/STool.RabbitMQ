using RabbitMQ.Client;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Transactions;

namespace STool.RabbitMQ
{
    public class RabbitMqModule : IDisposable
    {
        public IConnectionPool ConnectionPool { get; }
        public IChannelPool ChannelPool { get; }
        public RabbitMqOptions Options { get; }

        public RabbitMqMessageConsumerFactory RabbitMqMessageConsumerFactory { get; }


        private ConcurrentDictionary<string, MessageResponse> _cache { get; set; } = new ConcurrentDictionary<string, MessageResponse>();

        public RabbitMqModule(RabbitMqOptions options)
        {
         
            Options = options;
            foreach (var connectionFactory in options.Connections.Values)
            {
                connectionFactory.DispatchConsumersAsync = true;

            }
            ConnectionPool = new ConnectionPool(options);
            ChannelPool = new ChannelPool(ConnectionPool);
            RabbitMqMessageConsumerFactory = new RabbitMqMessageConsumerFactory(ConnectionPool);
        }


        public IRabbitMqMessageConsumer CreateConsumer(ExchangeDeclareConfiguration exchangeDeclare, QueueDeclareConfiguration queueDeclare, string? connectionName = "Default")
        {
            return RabbitMqMessageConsumerFactory.Create(exchangeDeclare, queueDeclare, connectionName);
        }

        public RabbitMqBasicConfig GetProducterConfig(string serverName = "Default", string producterName = "Default")
        {
            return Options.Settings.GetOrDefault(serverName).Producters.GetOrDefault(producterName);
        }

        public void Publish(string exchangeName,string queueName, string routingKey, string message, string serverName = "Default", string producterName = "Default", string connectionName = "Default")
        {
            var data = Encoding.UTF8.GetBytes(message);
            Publish(exchangeName, queueName, routingKey, data, serverName: serverName, producterName: producterName, connectionName: connectionName);
        }

        public void Publish(string exchangeName,string queueName, string routingKey, byte[] message, bool mandatory = false, IBasicProperties basicProperties = null, string serverName = "Default", string producterName = "Default", string connectionName = "Default")
        {
            try
            {
                using (var channelAccessor = ChannelPool.Acquire(connectionName))
                {
                    var config = GetProducterConfig(serverName, producterName);

                    channelAccessor.Channel.ExchangeDeclare(exchange: exchangeName, type: config.Exchange.Type, config.Exchange.Durable, config.Exchange.AutoDelete, config.Exchange.Arguments);
                    channelAccessor.Channel.QueueDeclare(queueName, config.Queue.Durable, config.Queue.Exclusive, config.Queue.AutoDelete, config.Queue.Arguments);
                    channelAccessor.Channel.QueueBind(queueName, exchange: exchangeName, routingKey: routingKey, config.Queue.Arguments);

                    channelAccessor.Channel.BasicPublish(exchange: exchangeName,
                                             routingKey: routingKey,
                                             mandatory: mandatory,
                                             basicProperties: basicProperties,
                                             body: message);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }

        public Task<MessageResponse> PublishAndWait(string exchangeName,string queueName, string routingKey, string message, string transActionId, string serverName = "Default", string producterName = "Default", string connectionName = "Default")
        {
            try
            {
                Task<MessageResponse> task = new Task<MessageResponse>(() =>
                {
                    Publish(exchangeName, queueName,routingKey, message,serverName, producterName, connectionName);
                    MessageResponse result = new MessageResponse();
                    _cache.TryAdd(transActionId, result);
                    int waitTime = 20;
                    while (waitTime > 0)
                    {
                        _cache.TryGetValue(transActionId, out result);

                        if (result != null && result.Message != null)
                        {
                            return result;
                        }
                        Thread.Sleep(500);
                        waitTime--;
                    }

                    _cache.TryRemove(transActionId, out result);
                    result = new MessageResponse();
                    result.ReturnCode = 99;
                    result.ReturnMessage = "TimeOut";
                    return result;
                });

                task.Start();

                return task;
            }
            catch (Exception ex)
            {
                MessageResponse result = new MessageResponse();
                result.ReturnCode = 99;
                result.ReturnMessage = $"Exception:{ex.Message}";
                return Task.FromResult<MessageResponse>(result);
            }
        }

        public MessageResponse? FindRequestData(string transActionId)
        {
            _cache.TryGetValue(transActionId, out var result);
            return result;
        }

        public void SetResponseData(string transActionId, MessageResponse response)
        {
            _cache.TryAdd(transActionId, response);
        }

        public void Dispose()
        {
            ConnectionPool?.Dispose();
            ChannelPool?.Dispose();
        }
       
    }
}
