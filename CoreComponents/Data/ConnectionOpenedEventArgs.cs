using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data
{
    public class ConnectionOpenedEventArgs<TSender> : SenderEventArgs<TSender>
    {

        public ConnectionOpenedEventArgs(TSender TheSender) : base(TheSender) 
        {
        }

    }
}
