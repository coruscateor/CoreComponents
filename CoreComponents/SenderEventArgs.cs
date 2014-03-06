using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    public class SenderEventArgs<TSender> : EventArgs, ISenderEventArgs<TSender>
    {

        protected TSender mySender;

        public SenderEventArgs(TSender sender)
        {

            mySender = sender;
    
        }

        public virtual TSender Sender
        {

            get
            {

                return mySender;

            }

        }

    }

    public class SenderEventArgs
    {

        protected object mySender;

        public SenderEventArgs(object TheSender)
        {

            mySender = TheSender;

        }

        public virtual object Sender
        {

            get
            {

                return mySender;

            }

        }

    }

}
