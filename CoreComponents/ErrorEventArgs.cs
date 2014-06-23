using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace CoreComponents
{

    public class ErrorEventArgs
    {

        protected string myMessage;

        protected Exception myException;

        protected StackTrace myStackTrace;

        protected Func<string> myMessageDelegate;

        public ErrorEventArgs(string TheMessage, bool FetchCallingStackTrace = false)
        {

            myMessage = TheMessage;

            myMessageDelegate = () => { return myMessage; };

            if(FetchCallingStackTrace)
                myStackTrace = new StackTrace(1, true);

        }

        public ErrorEventArgs(Exception TheException, bool FetchCallingStackTrace = false)
        {

            myException = TheException;

            myMessageDelegate = () => { return myException.Message; };

            if (FetchCallingStackTrace)
                myStackTrace = new StackTrace(1, true);

        }

        public ErrorEventArgs(string TheMessage, Exception TheException, bool FetchCallingStackTrace = false)
        {

            myException = TheException;

            myMessageDelegate = () => { return myMessage; };

            if(FetchCallingStackTrace)
                myStackTrace = new StackTrace(1, true);

        }

        public ErrorEventArgs(string TheMessage, StackTrace TheStackTrace)
        {

            myMessage = TheMessage;

            myStackTrace = TheStackTrace;

            myMessageDelegate = () => { return myMessage; };

        }

        public ErrorEventArgs(Exception TheException, StackTrace TheStackTrace)
        {

            myException = TheException;

            myStackTrace = TheStackTrace;

            myMessageDelegate = () => { return myException.Message; };

        }

        public ErrorEventArgs(string TheMessage, Exception TheException, StackTrace TheStackTrace)
        {

            myMessage = TheMessage;

            myException = TheException;

            myStackTrace = TheStackTrace;

            myMessageDelegate = () => { return myMessage; };

        }

        public string Message
        {

            get 
            {

                return myMessageDelegate();

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

        public bool TryGetStackTrace(out StackTrace TheStackTrace)
        {

            if(myStackTrace != null)
            {

                TheStackTrace = myStackTrace;

                return true;

            }

            TheStackTrace = null;

            return false;

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

        public bool TryGetException(out Exception TheException)
        {

            if(myException != null)
            {

                TheException = myException;

                return true;

            }

            TheException = null;

            return false;

        }

    }

}
