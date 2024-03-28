using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STool.Protocol
{
    public class Header
    {
        public string MESSAGENAME { get; set; }
        public string TRANSACTIONID { get; set; }
        public string TIMESTAMP { get; set; }
        public string TTLCALLBACK { get; set; }
        public string EVENTUSER { get; set; }
        public string ROUTINGKEY { get; set; }
        public string SENDEXCHANGE { get; set; }
        public string SOURCESUBJECTNAME { get; set; }
        public string TARGETSUBJECTNAME { get; set; }
        public string FACTORYNAME { get; set; }

        public Header() { }
        public Header(string messageName)
        {
            MESSAGENAME = messageName;
        }
    }

}
