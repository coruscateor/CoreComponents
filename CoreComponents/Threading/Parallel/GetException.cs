using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading.Parallel
{
    
    public class GetException
    {

        protected Exception myException;

        protected SpinLock mySpinLock;

        protected bool myIsActive = true;

        public GetException()
        {
        }

        public bool IsActive
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    mySpinLock.Enter(ref LockTaken);

                    return myIsActive;

                }
                finally
                {

                    if(LockTaken)
                        mySpinLock.Exit();

                }

            }

        }

        public bool HasFinished
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    mySpinLock.Enter(ref LockTaken);

                    return !myIsActive;

                }
                finally
                {

                    if(LockTaken)
                        mySpinLock.Exit();

                }

            }

        }

        public Exception Exception
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    mySpinLock.Enter(ref LockTaken);

                    return myException;

                }
                finally
                {

                    if(LockTaken)
                        mySpinLock.Exit();

                }

            }
            set
            {

                bool LockTaken = false;

                try
                {

                    mySpinLock.Enter(ref LockTaken);

                    myException = value;

                    myIsActive = false;

                }
                finally
                {

                    if(LockTaken)
                        mySpinLock.Exit();

                }

            }

        }

        public bool TryGetException(out Exception TheException)
        {

            if(IsActive)
            {

                TheException = null;

                return false;

            }

            Exception CurrentException = Exception;

            if(CurrentException != null)
            {

                TheException = CurrentException;

                return true;

            }

            TheException = null;

            return false;

        }

        public bool CheckException(Action<Exception> TheAction)
        {

            if(IsActive)
                return false;

            Exception CurrentException = Exception;

            if(CurrentException != null)
            {

                TheAction(CurrentException);

                return true;

            }

            return false;

        }

        public virtual void Reset()
        {

            bool LockTaken = false;

            try
            {

                mySpinLock.Enter(ref LockTaken);

                myIsActive = true;

                Exception = null;

            }
            finally
            {

                if(LockTaken)
                    mySpinLock.Exit();

            }

        }

        public virtual void SetInActive()
        {

            bool LockTaken = false;

            try
            {

                mySpinLock.Enter(ref LockTaken);

                myIsActive = false;

            }
            finally
            {

                if(LockTaken)
                    mySpinLock.Exit();

            }

        }

    }

}
