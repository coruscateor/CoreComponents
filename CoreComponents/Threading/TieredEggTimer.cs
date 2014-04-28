using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading
{

    public class TieredEggTimer : EggTimer
    {

        protected object myLockObject;

        public TieredEggTimer()
        {

            InitaliseLockObject();

        }

        public TieredEggTimer(object TheLockObject)
        {

            myLockObject = TheLockObject;

        }

        protected void InitaliseLockObject()
        {

            myLockObject = new object();

        }

        public void LockedReset()
        {

            lock(myLockObject)
            {

                Reset();

            }

        }

        public void LockedSet(int MillisecondsTimeout)
        {

            lock(myLockObject)
            {

                Set(MillisecondsTimeout);

            }

        }

        public void LockedSet(long MillisecondsTimeout)
        {

            lock(myLockObject)
            {

                Set(MillisecondsTimeout);

            }

        }

        public void LockedSet(TimeSpan TSTimeout)
        {

            lock(myLockObject)
            {

                Set(TSTimeout);

            }

        }

        public void LockedSet(uint MillisecondsTimeout)
        {

            lock(myLockObject)
            {

                Set(MillisecondsTimeout);

            }

        }

        public DateTime LockedTimeout
        {

            get
            {

                lock(myLockObject)
                {

                    return Timeout;

                }

            }

        }

        public bool LockedTryGetTimeout(out DateTime TheTimeout)
        {

            DateTime TheCurrentTimeout;

            lock(myLockObject)
            {

                if(TryGetTimeout(out TheCurrentTimeout))
                {

                    TheTimeout = TheCurrentTimeout;

                    return true;

                }

            }

            TheTimeout = DateTime.MinValue;

            return false;

        }

        public bool LockedHasTimedOut
        {

            get
            {

                lock(myLockObject)
                {

                    return HasTimedOut;

                }

            }

        }

        public DateTime LockedTimedOutAt
        {

            get
            {

                lock(myLockObject)
                {

                    return TimedOutAt;

                }

            }

        }

        public void LockedOnHasTimedOut(Action TheAction)
        {

            bool CurrentlyHasTimedout;

            lock(myLockObject)
            {

                CurrentlyHasTimedout = HasTimedOut;

            }

            if(CurrentlyHasTimedout)
                TheAction();

        }

        public void LockedOnHasTimedOut(Action<DateTime> TheAction)
        {

            DateTime CurrentlyHasTimedOutAt;

            lock(myLockObject)
            {

                if(!TryGetTimedOutAt(out CurrentlyHasTimedOutAt))
                    return;

            }

            TheAction(CurrentlyHasTimedOutAt);

        }

        public bool LockedTryGetTimedOutAt(out DateTime TheTime)
        {

            DateTime CurrentTime;

            lock(myLockObject)
            {

                if(TryGetTimedOutAt(out CurrentTime))
                {

                    TheTime = CurrentTime;

                    return true;

                }

            }

            TheTime = DateTime.MinValue;

            return false;

        }

        public bool LockedTryGetTimeoutEstimate(out TimeSpan TheTimeSpan)
        {

            TimeSpan CurrentTimeSpan;

            lock(myLockObject)
            {

                if(TryGetTimeoutEstimate(out CurrentTimeSpan))
                {

                    TheTimeSpan = CurrentTimeSpan;

                    return true;

                }

            }

            TheTimeSpan = TimeSpan.Zero;

            return false;

        }

        public bool LockedTryGetTimeoutOverdue(out TimeSpan TheTimeSpan)
        {

            TimeSpan CurrentTimeSpan;

            lock(myLockObject)
            {

                if(TryGetTimeoutOverdue(out CurrentTimeSpan))
                {

                    TheTimeSpan = CurrentTimeSpan;

                    return true;

                }

            }

            TheTimeSpan = TimeSpan.Zero;

            return false;

        }

    }

}
