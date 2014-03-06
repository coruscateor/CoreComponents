using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public class WaitCounter
    {

        protected uint myNumber;

        protected SpinLock myWaitSpinlock;

        public WaitCounter()
        {
        }

        public uint Number
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    myWaitSpinlock.Enter(ref LockTaken);

                    return myNumber;

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

                myNumber++;
                    
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
                
                myNumber--;

            }
            finally
            {

                if(LockTaken)
                    myWaitSpinlock.Exit();

            }

        }

        public bool DontWait(Action TheAction, object TheLockObject)
        {

            if(Number == 0)
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

            if(Number < TheLimit)
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

            if(Number == 0)
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

            if(Number < TheLimit)
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
