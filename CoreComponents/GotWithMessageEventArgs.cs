using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    public class GotWithMessageEventArgs<TSender, TGot> : GotEventArgs<TSender, TGot>, IHasMessage
    {

        protected string myContents;

        public GotWithMessageEventArgs(TSender Sender, TGot theGot, string theContents)
            : base(Sender, theGot)
        {

            myContents = theContents;

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
