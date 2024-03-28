using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STool.RabbitMQ
{

    [Serializable]
    public class RabbitMqConnections : Dictionary<string, ConnectionFactory>
    {
        public const string DefaultConnectionName = "Default";

        [NotNull]
        public ConnectionFactory Default
        {
            get => this[DefaultConnectionName];
            set
            {
                if (value == null) throw new ArgumentNullException("ConnectionFactory");
                this[DefaultConnectionName] = value;
            }
        }

        public RabbitMqConnections()
        {
            Default = new ConnectionFactory();
        }

        public ConnectionFactory GetOrDefault(string connectionName)
        {
            if (TryGetValue(connectionName, out var connectionFactory))
            {
                return connectionFactory;
            }

            return Default;
        }
    }
}
