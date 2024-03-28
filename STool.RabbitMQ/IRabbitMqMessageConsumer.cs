using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STool.RabbitMQ
{
    public interface IRabbitMqMessageConsumer
    {
        Task BindAsync(string routingKey);

        Task UnbindAsync(string routingKey);

        void OnMessageReceived(Func<IModel, BasicDeliverEventArgs, Task> callback);

        void Close();
    }
}
