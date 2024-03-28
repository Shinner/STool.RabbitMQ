using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace STool.Protocol
{
    public static class ProtocalExtensions
    {
        public static Header GetHeader(this XmlDocument xmlDocument)
        {
           return  XmlHelper.DeSerializer<Header>(xmlDocument.SelectSingleNode("Message/Header").OuterXml);
        }

        public static T GetBody<T>(this XmlDocument xmlDocument) where T : class
        {
            return XmlHelper.DeSerializer<T>(xmlDocument.SelectSingleNode("Message/Body").OuterXml);
        }

        public static Return GetReturn(this XmlDocument xmlDocument)
        {
            return XmlHelper.DeSerializer<Return>(xmlDocument.SelectSingleNode("Message/Return").OuterXml);
        }
    }
}
