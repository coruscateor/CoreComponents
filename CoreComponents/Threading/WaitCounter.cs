using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public class WaitCounter
    {

        protected uint myCount;

        protected SpinLock myWaitSpinlock;

        public WaitCounter()
        {
        }

        public uint Count
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

        public void Increment()
        {

            bool LockTaken = false;

            try
            {

                myWaitSpinlock.Enter(ref LockTaken);

                myCount++;
                    
            }
            finally
            {

                if(LockTaken)
                    myWaitSpinlock.Exit();

            }

        }

        public void Decrement()
        {

            bool LockTaken = false;

            try
            {

                myWaitSpinlock.Enter(ref LockTaken);

                myCount--;

            }
            finally
            {

                if(LockTaken)
                    myWaitSpinlock.Exit();

            }

        }

        public bool DontWait(Action TheAction, object TheLockObject)
        {

            if(Count == 0)
            {
                
                Increment();

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

        public bool WaitIfLessThan(uint TheLimit, Action TheAction, object TheLockObject)
        {

            if(Count < TheLimit)
            {

                Increment();

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

            if(Count == 0)
            {

                Increment();

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

        public bool WaitIfLessThan<T>(uint TheLimit, Action<T> TheAction, T TheParameter, object TheLockObject)
        {

            if(Count < TheLimit)
            {

                Increment();

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
