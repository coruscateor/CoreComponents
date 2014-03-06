using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    //A reference container that gives you a bit longer than the next GC generation.

    public abstract class BaseTemporalReference<TReference, TTimeOutInterval, TTimeSet> where TReference : class
    {

        private TReference myReference;

        private SpinLock myReferenceSpinLock;

        private TTimeOutInterval myTimeOutInterval;

        private SpinLock myTimeOutSpinLock;

        private RegisteredWaitHandle myRegesteredWaitHandle;

        private SpinLock myRegesteredWaitHandleSpinlock;

        protected Semaphore mySemaphore;

        protected TTimeSet myTimeSet;

        public BaseTemporalReference()
        {
        }

        protected void Initalise()
        {

            mySemaphore = new Semaphore(1, 1);

        }

        public bool HasReference
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    myReferenceSpinLock.Enter(ref LockTaken);

                    return myReference != null;

                }
                finally
                {

                    if(LockTaken)
                        myReferenceSpinLock.Exit();

                }

            }

        }

        public bool TryGet(out TReference TheReference)
        {

            bool LockTaken = false;

            try
            {

                myReferenceSpinLock.Enter(ref LockTaken);

                if(myReference != null)
                {

                    TheReference = myReference;

                    return true;

                }

            }
            finally
            {

                if(LockTaken)
                    myReferenceSpinLock.Exit();

            }

            TheReference = null;

            return false;

        }

        public TTimeSet TimeSet
        {

            get
            {

                return myTimeSet;

            }

        }

        public abstract bool TryGetETD(out TTimeOutInterval TheETD);

        protected void DropReference(object TheState, bool TimedOut)
        {

            if(!TimedOut)
                return;

            bool LockTaken = false;

            try
            {

                myReferenceSpinLock.Enter(ref LockTaken);

                myReference = null;

            }
            finally
            {

                if(LockTaken)
                    myReferenceSpinLock.Exit();

            }

            UnregesterRegesteredWaitHandle();

        }

        protected void UnregesterRegesteredWaitHandle()
        {

            bool LockTaken = false;

            myRegesteredWaitHandleSpinlock.Enter(ref LockTaken);

            RegisteredWaitHandle RWH = myRegesteredWaitHandle;

            myRegesteredWaitHandle = null;

            if(LockTaken)
                myRegesteredWaitHandleSpinlock.Exit();

            RWH.Unregister(mySemaphore);

        }

        public void SetRegisteredWaitHandle(RegisteredWaitHandle TheRegisteredWaitHandle)
        {

            bool LockTaken = false;

            myRegesteredWaitHandleSpinlock.Enter(ref LockTaken);

            myRegesteredWaitHandle = TheRegisteredWaitHandle;

            if(LockTaken)
                myRegesteredWaitHandleSpinlock.Exit();

        }

        public bool IsActiveOrWaiting
        {

            get
            {

                bool LockTaken = false;

                myRegesteredWaitHandleSpinlock.Enter(ref LockTaken);

                try
                {

                    return myRegesteredWaitHandle != null;

                }
                finally
                {

                    if(LockTaken)
                        myRegesteredWaitHandleSpinlock.Exit();

                }

            }

        }

        protected void CheckIfActiveOrWaiting()
        {

            if(IsActiveOrWaiting)
                UnregesterRegesteredWaitHandle();

        }

        public TTimeOutInterval TimeOutInterval
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    myTimeOutSpinLock.Enter(ref LockTaken);

                    return myTimeOutInterval;

                }
                finally
                {

                    if(LockTaken)
                        myTimeOutSpinLock.Exit();

                }
                
            }
            protected set
            {


                bool LockTaken = false;

                try
                {

                    myTimeOutSpinLock.Enter(ref LockTaken);

                    myTimeOutInterval = value;

                }
                finally
                {

                    if(LockTaken)
                        myTimeOutSpinLock.Exit();

                }

            }

        }

        public abstract void Set(TReference TheReference, TTimeOutInterval TheMillisecondsTimeoutInterval);

    }

}
