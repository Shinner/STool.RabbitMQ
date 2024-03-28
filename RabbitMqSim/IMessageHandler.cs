using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMqSim
{
    public delegate void LogDelegate(string msg);

    public interface IMessageHandler:IDisposable
    {
        event LogDelegate LogHandler;
        event LogDelegate ReceivedLogHandler;

        void Send(string text);
        void Start();

        void Close();
    }
}
