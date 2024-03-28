using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STool.RabbitMQ
{
    public class MessageResponse
    {
        public object Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
            }
        }
        public int ReturnCode { get; set; }
        public string ReturnMessage { get; set; }

        private object _message = null;
    }
}
