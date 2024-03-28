using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace STool.RabbitMQ
{
    public class ExchangeDeclareConfiguration
    {
        public string ExchangeName { get; }

        public string Type { get; }

        public bool Durable { get; set; }

        public bool AutoDelete { get; set; }


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

        public ExchangeDeclareConfiguration(
            string exchangeName,
            string type,
            bool durable = false,
            bool autoDelete = false)
        {
            ExchangeName = exchangeName;
            Type = type;
            Durable = durable;
            AutoDelete = autoDelete;
            _arguments = new Dictionary<string, object>();
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
