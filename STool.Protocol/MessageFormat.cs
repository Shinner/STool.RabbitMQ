using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace STool.Protocol
{
    [XmlType(AnonymousType = true)]
    [XmlRoot(ElementName = "Message")]
    public class MessageFormat<T> where T : class, new()
    {
        public Header Header { get; set; }
        public T Body { get; set; }
        public Return Return { get; set; }

        public MessageFormat() { }
        public MessageFormat(string messageName, T body)
        {
            Header = new(messageName);
            Body = body;
            Return = new();
        }

        public MessageFormat(string messageName)
        {
            Header = new(messageName);
            Body = new T();
            Return = new();
        }
    }
}
