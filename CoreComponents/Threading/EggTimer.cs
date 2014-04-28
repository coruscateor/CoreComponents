using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public class EggTimer
    {

        private RegisteredWaitHandle myRWH;

        private SpinLock myRWHSpinLock;

        private bool myUsesMemoryBarrier;

        private Semaphore mySemaphore;

        private DateTime myTimeout;

        private SpinLock myTimeoutSpinLock;

        private bool myHasTimedOut;

        private DateTime myTimedOutAt;

        public EggTimer()
        {

            mySemaphore = new Semaphore(1, 1);

        }

        protected RegisteredWaitHandle CurrentRWH
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    myRWHSpinLock.Enter(ref LockTaken);

                    return myRWH;

                }
                finally
                {

                    if(LockTaken)
                        myRWHSpinLock.Exit(myUsesMemoryBarrier);

                }

            }
            set
            {

                bool LockTaken = false;

                myRWHSpinLock.Enter(ref LockTaken);

                myRWH = value;

                if(LockTaken)
                    myRWHSpinLock.Exit(myUsesMemoryBarrier);

            }

        }

        public bool UsesMemoryBarrier
        {

            get
            {

                return myUsesMemoryBarrier;

            }
            set
            {

                myUsesMemoryBarrier = value;

            }

        }

        protected void ResetRWH()
        {

            RegisteredWaitHandle RWH = null;

            bool LockTaken = false;

            myRWHSpinLock.Enter(ref LockTaken);

            if(myRWH != null)
            {

                RWH = myRWH;

                myRWH = null;

            }

            if(LockTaken)
                myRWHSpinLock.Exit(myUsesMemoryBarrier);

            if(RWH != null)
                RWH.Unregister(mySemaphore);

        }

        public void Reset()
        {

            ResetRWH();

            bool LockTaken = false;

            myTimeoutSpinLock.Enter(ref LockTaken);

            if(!myHasTimedOut)
                myHasTimedOut = false;

            if(myTimedOutAt != DateTime.MinValue)
                myTimedOutAt = DateTime.MinValue;

            if(LockTaken)
                myTimeoutSpinLock.Exit(myUsesMemoryBarrier);

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

                bool LockTaken = false;

                myTimeoutSpinLock.Enter(ref LockTaken);

                myHasTimedOut = true;

                myTimedOutAt = Now;

                if(LockTaken)
                    myTimeoutSpinLock.Exit(myUsesMemoryBarrier);

                ResetRWH();

            }

        }

        public DateTime Timeout
        {

            get
            {

                bool LockTaken = true;

                try
                {

                    myTimeoutSpinLock.Enter(ref LockTaken);

                    return myTimeout;

                }
                finally
                {

                    if(LockTaken)
                        myTimeoutSpinLock.Exit(myUsesMemoryBarrier);

                }

            }
            protected set
            {

                bool LockTaken = true;

                myTimeoutSpinLock.Enter(ref LockTaken);

                myTimeout = value;

                if(LockTaken)
                    myTimeoutSpinLock.Exit(myUsesMemoryBarrier);

            }

        }

        public bool TryGetTimeout(out DateTime TheTimeout)
        {

            bool LockTaken = true;

            try
            {

                myTimeoutSpinLock.Enter(ref LockTaken);

                if(!myHasTimedOut)
                {

                    TheTimeout = myTimeout;

                    return true;

                }

            }
            finally
            {

                if(LockTaken)
                    myTimeoutSpinLock.Exit(myUsesMemoryBarrier);

            }

            TheTimeout = DateTime.MinValue;

            return false;

        }

        public bool HasTimedOut
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    myTimeoutSpinLock.Enter(ref LockTaken);

                    return myHasTimedOut;

                }
                finally
                {

                    if(LockTaken)
                        myTimeoutSpinLock.Exit(myUsesMemoryBarrier);

                }

            }

        }

        public DateTime TimedOutAt
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    myTimeoutSpinLock.Enter(ref LockTaken);

                    return myTimedOutAt;

                }
                finally
                {

                    if(LockTaken)
                        myTimeoutSpinLock.Exit(myUsesMemoryBarrier);

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

            bool LockTaken = false;

            bool CurrentlyHasTimedOut;

            DateTime CurrentlyTimedOutAt;

            myTimeoutSpinLock.Enter(ref LockTaken);

            CurrentlyHasTimedOut = myHasTimedOut;

            CurrentlyTimedOutAt = myTimedOutAt;

            if(LockTaken)
                myTimeoutSpinLock.Exit(myUsesMemoryBarrier);

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

            bool LockTaken = false;

            bool CurrentlyHasTimedOut = false;

            DateTime CurrentlyHasTimedOutAt = DateTime.MinValue;

            myTimeoutSpinLock.Enter(ref LockTaken);

            if(myHasTimedOut)
            {

                CurrentlyHasTimedOut = myHasTimedOut;

                CurrentlyHasTimedOutAt = myTimedOutAt;

            }

            if(LockTaken)
                myTimeoutSpinLock.Exit(myUsesMemoryBarrier);

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

            bool LockTaken = false;

            bool HasCurrentlyTimedOut = false;

            DateTime CurrentTimeOut = DateTime.MinValue;

            DateTime CurrentTimeOutAt = CurrentTimeOut;

            myTimeoutSpinLock.Enter(ref LockTaken);

            if(myHasTimedOut)
            {

                HasCurrentlyTimedOut = true;

                CurrentTimeOut = myTimeout;

                CurrentTimeOutAt = myTimedOutAt;

            }

            if(LockTaken)
                myTimeoutSpinLock.Exit(myUsesMemoryBarrier);

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
