using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace CoreComponents
{
    public class ExceptionEventArgs<TSender, TException> : SenderEventArgs<TSender> where TException : _Exception
    {

        protected TException myException;

        protected DateTime myDateTime;

        public ExceptionEventArgs(TSender sender, TException TheException)
            : base(sender)
        {

            myDateTime = DateTime.Now;

            myException = TheException;

        }

        public TException Exception
        {

            get
            {

                return myException;

            }

        }

        public virtual bool IsTypeOf<TException>() where TException : _Exception
        {

            if (HasException())
            {

                return myException.GetType() == typeof(TException);

            }

            return false;

        }

        //Approximate time exception caught.
        public DateTime DateTime 
        {

            get 
            {

                return myDateTime;

            }

        }

        public bool HasException()
        {

            return myException != null;

        }

    }

    public class ExceptionEventArgs<TException> : SenderEventArgs where TException : _Exception
    {

        protected TException myException;

        protected DateTime myDateTime;

        public ExceptionEventArgs(object sender, TException TheException)
            : base(sender)
        {

            myDateTime = DateTime.Now;

            myException = TheException;

        }

        public TException Exception
        {

            get
            {

                return myException;

            }

        }

        public virtual bool IsTypeOf<TException>() where TException : _Exception
        {

            if (HasException())
            {

                return myException.GetType() == typeof(TException);

            }

            return false;

        }

        //Approximate time exception caught.
        public DateTime DateTime
        {

            get
            {

                return myDateTime;

            }

        }

        public bool HasException()
        {

            return myException != null;

        }

    }

    public class ExceptionEventArgs : EventArgs
    {

        protected Exception myException;

        public ExceptionEventArgs(Exception TheException)
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

        public virtual bool IsTypeOf<TException>() where TException : _Exception
        {

            if (HasException)
            {

                return myException.GetType() == typeof(TException);

            }

            return false;

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
