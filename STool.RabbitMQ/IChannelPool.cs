using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STool.RabbitMQ
{
    public interface IChannelPool : IDisposable
    {
        IChannelAccessor Acquire(string? channelName = null, string? connectionName = null);
    }
}
