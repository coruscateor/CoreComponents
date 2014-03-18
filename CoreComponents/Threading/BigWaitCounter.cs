using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace CoreComponents.Threading
{
    
    public class BigWaitCounter
    {

        protected BigInteger myCount;

        protected object myLockObject;

        public BigWaitCounter()
        {
        }

        public BigInteger Count
        {

            get
            {

                lock(myLockObject)
                {

                    return myCount;

                }

            }

        }

        public void Increment()
        {

            lock(myLockObject)
            {

                myCount++;

            }

        }

        public bool Decrement()
        {

            lock(myLockObject)
            {

                if(myCount > 0)
                {

                    myCount--;

                    return true;

                }

            }

            return false;

        }

        public bool IncrementIfCountIsZero()
        {

            lock(myLockObject)
            {

                if(myCount == 0)
                {

                    myCount++;

                    return true;

                }

            }

            return false;

        }

        public bool IncrementIfCountIsLessThan(BigInteger TheLimit)
        {

            lock(myLockObject)
            {

                if(myCount < TheLimit)
                {

                    myCount++;

                    return true;

                }

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

        public bool WaitIfLessThan(BigInteger TheLimit, Action TheAction, object TheLockObject)
        {

            if(IncrementIfCountIsLessThan(TheLimit))
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

            if(IncrementIfCountIsZero())
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

        public bool WaitIfLessThan<T>(BigInteger TheLimit, Action<T> TheAction, T TheParameter, object TheLockObject)
        {

            if(IncrementIfCountIsLessThan(TheLimit))
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
