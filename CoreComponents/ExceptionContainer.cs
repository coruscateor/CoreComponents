using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace CoreComponents
{

    //See: ExceptionEventArgs
    /*
    public class SenderAndStackFrameContainer<TSender>
    {

        protected TSender mySender;

        protected StackFrame myStackFrame;

        protected bool HasPreviousStackFrame;

        protected static StackTrace StackTrace = new StackTrace();

        public SenderAndStackFrameContainer(TSender TheSender)
        {

            mySender = TheSender;

            //StackTrace st = new StackTrace();
            
            try
            {
                //Trys to get the previous frame.
                myStackFrame = StackTrace.GetFrame(1);


            } catch 
            {

                myStackFrame = null;

            }


        }

        public TSender Sender 
        {

            get 
            {

                return mySender;

            }

        }

        public StackFrame StackFrame
        {

            get
            {
                
                return myStackFrame;

            }

        }

        public static StackTrace CurrentStackTrace 
        {
            get 
            {

                return StackTrace;

            }


        }

    }*/
    /*
    public class SenderAndMethodInfoContainer<TSender> : SenderContainer<TSender>
    {


        protected MethodBase myMethodBase;

        public SenderAndMethodInfoContainer(TSender TheSender, MethodBase TheMethodInfo)
            : base(TheSender)
        {

            myMethodBase = TheMethodInfo;

        }

        public MethodBase MethodBase
        {

            get
            {

                return myMethodBase;

            }

        }

    }
    */
    /*
    public class ExceptionContainer<TSender> : SenderAndStackFrameContainer<TSender>
    {

        protected Exception myException;

        public ExceptionContainer(TSender TheSender, StackFrame TheStackFrame, Exception TheException)
            : base(TheSender, TheStackFrame) 
        {

            myException = TheException;

        }

        public Exception Exception 
        {

            get 
            {

                return myException;

            }

        }

    }*/
    /*
    public class ExceptionContainer<TSender, TException> : SenderAndMethodInfoContainer<TSender> where TException : _Exception
    {

        protected TException myException;

        public ExceptionContainer(TSender TheSender, MethodBase TheMethodBase, TException TheException)
            : base(TheSender, TheMethodBase)
        {

            myException = TheException;

        }

        public TException Exception
        {

            get
            {

                return myException;

            }

        }

    }*/
}
