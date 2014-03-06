using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace CoreComponents
{

    public class ErrorEventArgs
    {

        protected string myMessage;

        protected Exception myException;

        protected StackTrace myStackTrace;

        protected Func<string> myMessageDelegate;

        public ErrorEventArgs(string TheMessage, bool FethchCallingStackTrace = false)
        {

            myMessage = TheMessage;

            myMessageDelegate = () => { return myMessage; };

            if (FethchCallingStackTrace)
                myStackTrace = new System.Diagnostics.StackTrace(1, true);

        }

        public ErrorEventArgs(Exception TheException, bool FethchCallingStackTrace = false)
        {

            myException = TheException;

            myMessageDelegate = () => { return myException.Message; };

            if (FethchCallingStackTrace)
                myStackTrace = new System.Diagnostics.StackTrace(1, true);
            //else
            //    myStackTrace = new System.Diagnostics.StackTrace(myException);

        }

        public ErrorEventArgs(string TheMessage, Exception TheException, bool FethchCallingStackFrame = false)
        {

            myException = TheException;

            myException = TheException;

            myMessageDelegate = () => { return myMessage; };

            if (FethchCallingStackFrame)
                myStackTrace = new System.Diagnostics.StackTrace(1, true);
            //else
            //    myStackTrace = new System.Diagnostics.StackTrace(myException);

        }

        public ErrorEventArgs(string TheMessage, StackTrace TheStackFrame)
        {

            myMessage = TheMessage;

            myStackTrace = TheStackFrame;

            myMessageDelegate = () => { return myMessage; };

        }

        public ErrorEventArgs(Exception TheException, StackTrace TheStackFrame)
        {

            myException = TheException;

            myStackTrace = TheStackFrame;

            myMessageDelegate = () => { return myException.Message; };

            //myStackTrace = new System.Diagnostics.StackTrace(myException);

        }

        public ErrorEventArgs(string TheMessage, Exception TheException, StackTrace TheStackFrame)
        {

            myMessage = TheMessage;

            myException = TheException;

            myStackTrace = TheStackFrame;

            myMessageDelegate = () => { return myMessage; };

            //myStackTrace = new System.Diagnostics.StackTrace(myException);

        }

        public string Message
        {

            get 
            {

                return myMessageDelegate();

            }

        }
        
        public bool HasNonExceptionMessage
        {

            get
            {

                return myMessage != null && myMessage.Length > 0;

            }

        }

        public StackTrace StackTrace
        {

            get
            {

                return myStackTrace;
                
            }

        }

        public bool HasStackTrace
        {

            get
            {

                return myStackTrace != null;

            }

        }

        public Exception Exception
        {

            get
            {

                return myException;

            }

        }

        public bool HasException
        {

            get
            {

                return myException != null;

            }

        }

    }

}
