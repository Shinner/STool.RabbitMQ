using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STool.RabbitMQ
{
    public class RabbitMqMessageConsumerFactory : IRabbitMqMessageConsumerFactory
    {
        protected IConnectionPool ConnectionPool { get; }
        public RabbitMqMessageConsumerFactory(IConnectionPool connectionPool)
        {
            ConnectionPool = connectionPool;
        }

        public IRabbitMqMessageConsumer Create(
            ExchangeDeclareConfiguration exchange,
            QueueDeclareConfiguration queue,
            string? connectionName = null)
        {
            var consumer = new RabbitMqMessageConsumer(ConnectionPool);
            consumer.Initialize(exchange, queue, connectionName);
            return consumer;
        }
    }
}
