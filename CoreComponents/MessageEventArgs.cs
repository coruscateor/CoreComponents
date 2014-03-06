using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    public class MessageEventArgs : EventArgs, IHasMessage
    {

        protected string myContents;

        public MessageEventArgs(string contents)
        {

            myContents = contents;

        }

        public string Contents
        {

            get
            {

                return myContents;

            }

        }

    }

    public class MessageEventArgs<TSender> : SenderEventArgs<TSender>, IHasMessage
    {

        protected string myContents;

        public MessageEventArgs(TSender sender, string contents)
            : base(sender)
        {

            myContents = contents;

        }

        public string Contents
        {

            get
            {

                return myContents;

            }

        }

    }
}
