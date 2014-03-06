using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    public class DynamicEventArgs : SenderEventArgs
    {

        protected dynamic myItem;

        public DynamicEventArgs(object TheSender, dynamic TheItem)
            : base(TheSender)
        {

            myItem = TheItem;

        }

        public dynamic Item
        {

            get
            {

                return myItem;

            }

        }

    }

    public class DynamicEventArgs<TSender> : SenderEventArgs<TSender>
    {

        protected dynamic myItem;

        public DynamicEventArgs(TSender TheSender, dynamic TheItem)
            : base(TheSender) 
        {

            myItem = TheItem;

        }

        public dynamic Item
        {

            get
            {

                return myItem;

            }

        }

    }

}
