using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace STool.RabbitMQ
{
    public class QueueDeclareConfiguration
    {
        [NotNull] public string QueueName { get; }

        public bool Durable { get; set; }

        public bool Exclusive { get; set; }

        public bool AutoDelete { get; set; }

        public ushort? PrefetchCount { get; set; }

        public IDictionary<string, object> Arguments
        {
            get
            {
                return GetArguments();
            }
            set
            {
                _arguments = value;
            }
        }


        IDictionary<string, object> _arguments;
        public QueueDeclareConfiguration(
            [NotNull] string queueName,
            bool durable = true,
            bool exclusive = false,
            bool autoDelete = false,
            ushort? prefetchCount = null)
        {
            QueueName = queueName;
            Durable = durable;
            Exclusive = exclusive;
            AutoDelete = autoDelete;
            _arguments = new Dictionary<string, object>();
            PrefetchCount = prefetchCount;
        }

        public virtual QueueDeclareOk Declare(IModel channel)
        {
            return channel.QueueDeclare(
                queue: QueueName,
                durable: Durable,
                exclusive: Exclusive,
                autoDelete: AutoDelete,
                arguments: Arguments
            );
        }

        private IDictionary<string, object> GetArguments()
        {
            IDictionary<string, object> res = new Dictionary<string, object>();
            foreach (var arg in _arguments)
            {
                if(arg.Value is JsonElement)
                {
                    var ele = (JsonElement)arg.Value;
                    if (ele.ValueKind == JsonValueKind.Number)
                    {
                        res.Add(arg.Key, ele.GetUInt32());
                    }
                    else
                    {
                        res.Add(arg.Key, ele.GetString());
                    }
                }
            
            }
            return res;
        }
    }

}