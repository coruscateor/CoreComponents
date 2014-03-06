using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    public class GotEventArgs<TSender, TGot> : SenderEventArgs<TSender>
    {

        protected TGot myGot;

        public GotEventArgs(TSender Sender, TGot theGot) : base(Sender)
        {

            myGot = theGot;

        }

        public TGot GotThis
        {

            get
            {

                return myGot;

            }

        }

    }

}
