using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STool.RabbitMQ
{
    public interface IConnectionPool : IDisposable
    {
        IConnection Get(string? connectionName = null);
    }
}
