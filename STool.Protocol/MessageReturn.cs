using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STool.Protocol
{
    public class Return
    {
        public int RETURNCODE { get; set; }
        public string RETURNMESSAGE { get; set; }

        public Return()
        {
            RETURNMESSAGE = string.Empty;
        }

    }
}
