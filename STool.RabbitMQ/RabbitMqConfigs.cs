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
    public class RabbitMqSettings : Dictionary<string, RabbitMqSettingGroup>
    {
        public RabbitMqSettingGroup GetOrDefault(string name="Default")
        {
            if (TryGetValue(name, out var config))
            {
                return config;
            }
            else
            {
                throw new Exception($"RabbitMQ Config setting {name} is not exist");
            }

        }
    }

    public class RabbitMqSettingGroup
    {
        public RabbitMqBasicConfigs Consumers { get; set; }
        public RabbitMqBasicConfigs Producters { get; set; }
    }


    public class RabbitMqBasicConfig
    {
        public ExchangeDeclareConfiguration Exchange { get; set; }
        public QueueDeclareConfiguration Queue { get; set; }
        public string RoutingKey { get; set; }
        public bool SecondaryRouting { get; set; }
    }

    [Serializable]
    public class RabbitMqBasicConfigs: Dictionary<string, RabbitMqBasicConfig>
    {
        public const string DefaultConfigName = "Default";

        [NotNull]
        public RabbitMqBasicConfig Default
        {
            get => this[DefaultConfigName];
            set
            {
                if (value == null) throw new ArgumentNullException("RabbitMqBasicConfig");
                this[DefaultConfigName] = value;
            }
        }

        public RabbitMqBasicConfigs()
        {
            Default = new RabbitMqBasicConfig();
        }
        public RabbitMqBasicConfig GetOrDefault(string name="Default")
        {
            if (TryGetValue(name, out var basicConfig))
            {
                return basicConfig;
            }

            return Default;
        }
    }
}
