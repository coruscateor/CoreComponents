using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public class EggTimer : LockBase
    {

        private RegisteredWaitHandle myRWH;

        private Semaphore mySemaphore;

        private DateTime myTimeout;

        private DateTime myTimedOutAt;

        private bool myHasTimedOut;

        public EggTimer()
            : base()
        {

            Initailse();

        }

        public EggTimer(object LObj)
            : base(LObj)
        {

            Initailse();

        }


        protected void Initailse()
        {

            mySemaphore = new Semaphore(1, 1);

        }

        protected RegisteredWaitHandle CurrentRWH
        {

            get
            {

                lock(myLockObject)
                {

                    return myRWH;

                }

            }
            set
            {

                lock(myLockObject)
                {

                    myRWH = value;

                }

            }

        }

        protected void NoLockReset()
        {

            if(myRWH != null)
            {

                myRWH.Unregister(mySemaphore);

                myRWH = null;

            }

            if(!myHasTimedOut)
                myHasTimedOut = false;

            myTimeout = DateTime.MinValue;

            myTimedOutAt = DateTime.MinValue;

        }

        public void Reset()
        {

            lock(myLockObject)
            {

                NoLockReset();

            }

        }

        public void Set(int MillisecondsTimeout)
        {

            Reset();

            CurrentRWH = ThreadPool.RegisterWaitForSingleObject(mySemaphore, Execute, null, MillisecondsTimeout, true);

            Timeout = DateTime.Now.AddMilliseconds(MillisecondsTimeout);

        }

        public void Set(long MillisecondsTimeout)
        {

            Reset();

            CurrentRWH = ThreadPool.RegisterWaitForSingleObject(mySemaphore, Execute, null, MillisecondsTimeout, true);

            Timeout = DateTime.Now.AddMilliseconds(MillisecondsTimeout);

        }

        public void Set(TimeSpan TSTimeout)
        {

            Reset();

            CurrentRWH = ThreadPool.RegisterWaitForSingleObject(mySemaphore, Execute, null, TSTimeout, true);

            Timeout = DateTime.Now.Add(TSTimeout);

        }

        public void Set(uint MillisecondsTimeout)
        {

            Reset();

            CurrentRWH = ThreadPool.RegisterWaitForSingleObject(mySemaphore, Execute, null, MillisecondsTimeout, true);

            Timeout = DateTime.Now.AddMilliseconds(MillisecondsTimeout);

        }

        protected void Execute(object TheState, bool TimedOut)
        {

            if(TimedOut)
            {

                DateTime Now = DateTime.Now;

                lock(myLockObject)
                {

                    myHasTimedOut = true;

                    myTimedOutAt = Now;

                    NoLockReset();

                }

                //ResetRWH();

            }

        }

        public DateTime Timeout
        {

            get
            {

                lock(myLockObject)
                {

                    return myTimeout;

                }

            }
            protected set
            {

                lock (myLockObject)
                {

                    myTimeout = value;

                }

            }

        }

        public bool TryGetTimeout(out DateTime TheTimeout)
        {

            lock(myLockObject)
            {

                if(myTimeout != DateTime.MinValue)
                {

                    TheTimeout = myTimeout;

                    return true;

                }

            }

            TheTimeout = DateTime.MinValue;

            return false;

        }

        public bool HasTimedOut
        {

            get
            {

                lock (myLockObject)
                {

                    return myHasTimedOut;

                }

            }

        }

        public DateTime TimedOutAt
        {

            get
            {

                lock (myLockObject)
                {

                    return myTimedOutAt;

                }

            }

        }

        public void OnHasTimedOut(Action TheAction)
        {

            if(HasTimedOut)
                TheAction();

        }

        public void OnHasTimedOut(Action<DateTime> TheAction)
        {

            bool CurrentlyHasTimedOut;

            DateTime CurrentlyTimedOutAt;

            lock(myLockObject)
            {

                CurrentlyHasTimedOut = myHasTimedOut;

                CurrentlyTimedOutAt = myTimedOutAt;

            }

            if(CurrentlyHasTimedOut)
                TheAction(CurrentlyTimedOutAt);

        }

        public void OnHasTimedOut(Action<EggTimer> TheAction)
        {

            if(HasTimedOut)
                TheAction(this);

        }

        public bool TryGetTimedOutAt(out DateTime TheTime)
        {

            bool CurrentlyHasTimedOut = false;

            DateTime CurrentlyHasTimedOutAt = DateTime.MinValue;

            lock(myLockObject)
            {

                if(myHasTimedOut)
                {

                    CurrentlyHasTimedOut = myHasTimedOut;

                    CurrentlyHasTimedOutAt = myTimedOutAt;

                }

            }

            if(CurrentlyHasTimedOut)
            {

                TheTime = CurrentlyHasTimedOutAt;

                return true;

            }

            TheTime = DateTime.MinValue;

            return false;

        }

        public bool TryGetTimeoutEstimate(out TimeSpan TheTimeSpan)
        {

            DateTime CurrentTimeout;

            if(TryGetTimeout(out CurrentTimeout))
            {

                TheTimeSpan = DateTime.Now - CurrentTimeout;

                return true;

            }

            TheTimeSpan = TimeSpan.Zero;

            return false;

        }
        
        public bool TryGetTimeoutOverdue(out TimeSpan TheTimeSpan)
        {

            bool HasCurrentlyTimedOut = false;

            DateTime CurrentTimeOut = DateTime.MinValue;

            DateTime CurrentTimeOutAt = CurrentTimeOut;

            lock (myLockObject)
            {

                if(myHasTimedOut)
                {

                    HasCurrentlyTimedOut = true;

                    CurrentTimeOut = myTimeout;

                    CurrentTimeOutAt = myTimedOutAt;

                }

            }

            if(HasCurrentlyTimedOut)
            {

                TheTimeSpan = CurrentTimeOutAt - CurrentTimeOut;

                return true;

            }

            TheTimeSpan = TimeSpan.Zero;

            return false;

        }

    }

}
