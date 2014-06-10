using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading.Jobs
{
    
    public abstract class QuickJob : IQuickJob
    {

        protected QuickJobState myState;

        protected SpinLock mySpinlock;

        protected bool myUsesMemoryBarrier;

        protected Exception myException;

        protected string myFailureMessage;

        protected object myFailureData;

        public QuickJob()
        {
        }

        public QuickJob(bool TheUsesMemoryBarrier)
        {

            myUsesMemoryBarrier = TheUsesMemoryBarrier;

        }

        public virtual QuickJobState State
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    mySpinlock.Enter(ref LockTaken);

                    return myState;

                }
                finally
                {

                    if(LockTaken)
                        mySpinlock.Exit(myUsesMemoryBarrier);

                }

            }
            protected set
            {

                bool LockTaken = false;

                mySpinlock.Enter(ref LockTaken);

                myState = value;

                if(LockTaken)
                    mySpinlock.Exit(myUsesMemoryBarrier);

            }

        }

        public string FailureMessage
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    mySpinlock.Enter(ref LockTaken);

                    return myFailureMessage;

                }
                finally
                {

                    if(LockTaken)
                        mySpinlock.Exit(myUsesMemoryBarrier);

                }

            }
            protected set
            {

                bool LockTaken = false;

                mySpinlock.Enter(ref LockTaken);

                myFailureMessage = value;

                if(LockTaken)
                    mySpinlock.Exit(myUsesMemoryBarrier);

            }

        }

        public bool TryGetFailureMessage(out string TheFailureMessage)
        {

            TheFailureMessage = FailureMessage;

            return TheFailureMessage != null;

        }

        public object FailureData
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    mySpinlock.Enter(ref LockTaken);

                    return myFailureData;

                }
                finally
                {

                    if(LockTaken)
                        mySpinlock.Exit(myUsesMemoryBarrier);

                }

            }
            protected set
            {

                bool LockTaken = false;

                mySpinlock.Enter(ref LockTaken);

                myFailureData = value;

                if(LockTaken)
                    mySpinlock.Exit(myUsesMemoryBarrier);

            }

        }

        public bool TryGetFailureData(out object TheFailureData)
        {

            TheFailureData = FailureData;

            return TheFailureData != null;

        }

        public virtual void Reset()
        {

            bool LockTaken = false;

            mySpinlock.Enter(ref LockTaken);

            State = QuickJobState.Pending;

            if(myException != null)
                myException = null;

            if(LockTaken)
                mySpinlock.Exit(myUsesMemoryBarrier);

        }

        public bool IsPending
        {

            get
            {

                return State == QuickJobState.Pending;

            }

        }

        public bool WasSuccessful
        {

            get
            {

                return State == QuickJobState.Success;

            }

        }

        public bool HasFailed
        {

            get
            {

                return State == QuickJobState.Failure;

            }

        }

        public bool ErrorOccured
        {

            get
            {

                return State == QuickJobState.Error;

            }

        }

        public void Failed()
        {

            State = QuickJobState.Failure;

        }

        public void Failed(string TheMessage)
        {

            bool LockTaken = false;

            try
            {

                mySpinlock.Enter(ref LockTaken);

                myState = QuickJobState.Failure;

                myFailureMessage = TheMessage;

            }
            finally
            {

                if(LockTaken)
                    mySpinlock.Exit(myUsesMemoryBarrier);

            }

        }

        public void Failed(string TheMessage, object TheData)
        {

            bool LockTaken = false;

            try
            {

                mySpinlock.Enter(ref LockTaken);

                myState = QuickJobState.Failure;

                myFailureMessage = TheMessage;

                myFailureData = TheData;

            }
            finally
            {

                if(LockTaken)
                    mySpinlock.Exit(myUsesMemoryBarrier);

            }

        }

        public Exception Exception
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    mySpinlock.Enter(ref LockTaken);

                    return myException;

                }
                finally
                {

                    if(LockTaken)
                        mySpinlock.Exit(myUsesMemoryBarrier);

                }

            }
            set
            {

                bool LockTaken = false;

                mySpinlock.Enter(ref LockTaken);

                myException = value;

                myState = QuickJobState.Error;

                if(LockTaken)
                    mySpinlock.Exit(myUsesMemoryBarrier);

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

            TheException = Exception;

            return TheException != null;

        }

        public bool TryGetException(Action<Exception> TheAction)
        {

            Exception CurrentException = Exception;

            if(CurrentException != null)
            {

                TheAction(CurrentException);

                return true;

            }

            return false;

        }

    }

}
