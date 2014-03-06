using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{
    public class LoadedEventArgs<TSender, TLoaded> : SenderEventArgs<TSender>
    {

        protected TLoaded myLoaded;

        public LoadedEventArgs(TSender Sender, TLoaded theLoaded) : base(Sender)
        {

            myLoaded = theLoaded;

        }

        public TLoaded TheLoaded
        {

            get
            {

                return myLoaded;

            }

        }

    }
}
