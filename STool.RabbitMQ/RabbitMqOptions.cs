using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STool.RabbitMQ
{
    [Serializable]
    public class RabbitMqOptions
    {
        public RabbitMqConnections Connections { get; set; }

        public RabbitMqSettings Settings { get; set; }

        public RabbitMqOptions()
        {
            Connections = new RabbitMqConnections();
            Settings = new RabbitMqSettings();
        }
    }
}
