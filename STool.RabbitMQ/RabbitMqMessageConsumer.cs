using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STool.RabbitMQ
{
    public class RabbitMqMessageConsumer : IRabbitMqMessageConsumer, IDisposable
    {

        protected IConnectionPool ConnectionPool { get; }


        protected Timer Timer { get; }

        protected ExchangeDeclareConfiguration Exchange { get; private set; } = default!;

        protected QueueDeclareConfiguration Queue { get; private set; } = default!;

        protected string? ConnectionName { get; private set; }

        protected ConcurrentBag<Func<IModel, BasicDeliverEventArgs, Task>> Callbacks { get; }

        protected IModel? Channel { get; private set; }

        protected ConcurrentQueue<QueueBindCommand> QueueBindCommands { get; }

        protected object ChannelSendSyncLock { get; } = new object();

        public RabbitMqMessageConsumer(
            IConnectionPool connectionPool)
        {
            ConnectionPool = connectionPool;

            QueueBindCommands = new ConcurrentQueue<QueueBindCommand>();
            Callbacks = new ConcurrentBag<Func<IModel, BasicDeliverEventArgs, Task>>();


            Timer = new Timer(Timer_Elapsed, null, 0, 5000);
        }

        private void Timer_Elapsed(object? state)
        {
            Task.Run(async () =>
            {
                if (Channel == null || Channel.IsOpen == false)
                {
                    await TryCreateChannelAsync();
                    await TrySendQueueBindCommandsAsync();
                }
            });

        }

        public void Initialize(
                [NotNull] ExchangeDeclareConfiguration exchange,
                [NotNull] QueueDeclareConfiguration queue,
                string? connectionName = null)
        {
            Exchange = exchange;
            Queue = queue;
            ConnectionName = connectionName;

        }

        public virtual async Task BindAsync(string routingKey)
        {
            QueueBindCommands.Enqueue(new QueueBindCommand(QueueBindType.Bind, routingKey));
            await TrySendQueueBindCommandsAsync();
        }

        public virtual async Task UnbindAsync(string routingKey)
        {
            QueueBindCommands.Enqueue(new QueueBindCommand(QueueBindType.Unbind, routingKey));
            await TrySendQueueBindCommandsAsync();
        }

        protected virtual async Task TrySendQueueBindCommandsAsync()
        {
            try
            {
                while (!QueueBindCommands.IsEmpty)
                {
                    if (Channel == null || Channel.IsClosed)
                    {
                        return;
                    }

                    lock (ChannelSendSyncLock)
                    {
                        if (QueueBindCommands.TryPeek(out var command))
                        {
                            switch (command.Type)
                            {
                                case QueueBindType.Bind:
                                    Channel.QueueBind(
                                        queue: Queue.QueueName,
                                        exchange: Exchange.ExchangeName,
                                        routingKey: command.RoutingKey
                                    );
                                    break;
                                case QueueBindType.Unbind:
                                    Channel.QueueUnbind(
                                        queue: Queue.QueueName,
                                        exchange: Exchange.ExchangeName,
                                        routingKey: command.RoutingKey
                                    );
                                    break;
                                default:
                                    throw new Exception($"Unknown {nameof(QueueBindType)}: {command.Type}");
                            }

                            QueueBindCommands.TryDequeue(out command);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public virtual void OnMessageReceived(Func<IModel, BasicDeliverEventArgs, Task> callback)
        {
            Callbacks.Add(callback);
        }


        protected virtual async Task TryCreateChannelAsync()
        {
            await DisposeChannelAsync();

            try
            {
                Channel = ConnectionPool
                    .Get(ConnectionName)
                    .CreateModel();

                if (!string.IsNullOrEmpty(Exchange.ExchangeName))
                {
                    Channel.ExchangeDeclare(
                   exchange: Exchange.ExchangeName,
                   type: Exchange.Type,
                   durable: Exchange.Durable,
                   autoDelete: Exchange.AutoDelete,
                   arguments: Exchange.Arguments
               );
                }


                Channel.QueueDeclare(
                    queue: Queue.QueueName,
                    durable: Queue.Durable,
                    exclusive: Queue.Exclusive,
                    autoDelete: Queue.AutoDelete,
                    arguments: Queue.Arguments
                );

                if (Queue.PrefetchCount.HasValue)
                {
                    Channel.BasicQos(0, Queue.PrefetchCount.Value, false);
                }

                var consumer = new AsyncEventingBasicConsumer(Channel);
                consumer.Received += HandleIncomingMessageAsync;

                Channel.BasicConsume(
                    queue: Queue.QueueName,
                    autoAck: false,
                    consumer: consumer
                );

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected virtual async Task HandleIncomingMessageAsync(object sender, BasicDeliverEventArgs basicDeliverEventArgs)
        {
            try
            {
                foreach (var callback in Callbacks)
                {
                    await callback(Channel!, basicDeliverEventArgs);
                }

                Channel?.BasicAck(basicDeliverEventArgs.DeliveryTag, multiple: false);
            }
            catch (Exception ex)
            {
                try
                {
                    Channel?.BasicNack(
                        basicDeliverEventArgs.DeliveryTag,
                        multiple: false,
                        requeue: true
                    );
                }
                // ReSharper disable once EmptyGeneralCatchClause
                catch { }

                Console.WriteLine(ex.Message);
            }
        }

        protected virtual async Task DisposeChannelAsync()
        {
            if (Channel == null)
            {
                return;
            }

            try
            {
                Channel.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected virtual void DisposeChannel()
        {
            if (Channel == null)
            {
                return;
            }

            try
            {
                Channel.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public virtual void Dispose()
        {
            Timer.Dispose();
            DisposeChannel();
        }

        public void Close()
        {
            Timer.Dispose();
            DisposeChannel();
        }

        protected class QueueBindCommand
        {
            public QueueBindType Type { get; }

            public string RoutingKey { get; }

            public QueueBindCommand(QueueBindType type, string routingKey)
            {
                Type = type;
                RoutingKey = routingKey;
            }
        }

        protected enum QueueBindType
        {
            Bind,
            Unbind
        }
    }
}