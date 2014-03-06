using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Application.Messaging
{
    public class CacheMessage : ReadonlyCacheMessage
    {


        public CacheMessage()
        {

            InitaliseTime();

        }

        public CacheMessage(string Message) : base(Message)
        {
        }

        public new DateTime TimeStamp
        {

            get
            {

                return myTimeStamp;

            }
            set
            {

                myTimeStamp = value;

            }

        }

        public new string Message
        {

            get
            {

                return myMessage;

            }
            set
            {

                myMessage = value;

            }

        }

        public override string ToString()
        {

            return myTimeStamp.ToString() + statDelimiter + myMessage + "\n";

        }

    }
}
