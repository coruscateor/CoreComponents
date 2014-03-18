using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public class LongWaitCounter
    {

        protected ulong myCount;

        protected SpinLock myWaitSpinlock;

        public LongWaitCounter()
        {
        }

        public ulong Count
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    myWaitSpinlock.Enter(ref LockTaken);

                    return myCount;

                }
                finally
                {

                    if(LockTaken)
                        myWaitSpinlock.Exit();

                }

            }

        }

        public bool Increment()
        {

            bool LockTaken = false;

            try
            {

                myWaitSpinlock.Enter(ref LockTaken);

                if(myCount < ulong.MaxValue)
                {

                    myCount++;

                    return true;

                }

            }
            finally
            {

                if(LockTaken)
                    myWaitSpinlock.Exit();

            }

            return false;

        }

        public bool Decrement()
        {

            bool LockTaken = false;

            try
            {

                myWaitSpinlock.Enter(ref LockTaken);

                if(myCount > 0L)
                {

                    myCount--;

                    return true;

                }

            }
            finally
            {

                if(LockTaken)
                    myWaitSpinlock.Exit();

            }

            return false;

        }

        public bool IncrementIfCountIsZero()
        {

            bool LockTaken = false;

            try
            {

                myWaitSpinlock.Enter(ref LockTaken);

                if(myCount == 0uL)
                {

                    myCount++;

                    return true;

                }

            }
            finally
            {

                if(LockTaken)
                    myWaitSpinlock.Exit();

            }

            return false;

        }

        public bool IncrementIfCountIsLessThan(ulong TheLimit)
        {

            bool LockTaken = false;

            try
            {

                myWaitSpinlock.Enter(ref LockTaken);

                if(myCount < TheLimit)
                {

                    myCount++;

                    return true;

                }

            }
            finally
            {

                if(LockTaken)
                    myWaitSpinlock.Exit();

            }

            return false;

        }

        public bool DontWait(Action TheAction, object TheLockObject)
        {

            if(IncrementIfCountIsZero())
            {

                try
                {

                    lock(TheLockObject)
                    {

                        TheAction();

                    }

                    return true;

                }
                finally
                {

                    Decrement();

                }

            }

            return false;

        }

        public bool WaitIfLessThan(ulong TheLimit, Action TheAction, object TheLockObject)
        {

            if(IncrementIfCountIsLessThan(TheLimit))
            {

                if(!Increment())
                    return false;

                try
                {

                    lock(TheLockObject)
                    {

                        TheAction();

                    }

                    return true;

                }
                finally
                {

                    Decrement();

                }

            }

            return false;

        }

        public bool DontWait<T>(Action<T> TheAction, T TheParameter, object TheLockObject)
        {

            if(IncrementIfCountIsZero())
            {

                try
                {

                    lock(TheLockObject)
                    {

                        TheAction(TheParameter);

                    }

                    return true;

                }
                finally
                {

                    Decrement();

                }

            }

            return false;

        }

        public bool WaitIfLessThan<T>(ulong TheLimit, Action<T> TheAction, T TheParameter, object TheLockObject)
        {

            if(IncrementIfCountIsLessThan(TheLimit))
            {

                if(!Increment())
                    return false;

                try
                {

                    lock(TheLockObject)
                    {

                        TheAction(TheParameter);

                    }

                    return true;

                }
                finally
                {

                    Decrement();

                }

            }

            return false;

        }

    }

}
