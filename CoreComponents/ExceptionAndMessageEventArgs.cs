using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace CoreComponents
{
    public class ExceptionAndMessageEventArgs<TSender, TException> : ExceptionEventArgs<TSender, TException> where TException : _Exception
    {

        string myMessage;

        public ExceptionAndMessageEventArgs(TSender Sender, TException TheException, string TheMessage) : base(Sender, TheException)
        {

            myMessage = TheMessage;

        }


        public string Message
        {

            get
            {

                return myMessage;

            }

        }

    }
}
