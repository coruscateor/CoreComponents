﻿using System;
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

        public bool Increment()
        {

            bool LockTaken = false;

            try
            {

                myWaitSpinlock.Enter(ref LockTaken);

                if(myCount < uint.MaxValue)
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

                if(myCount > 0u)
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

                if(myCount == 0u)
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

        public bool IncrementIfCountIsLessThan(uint TheLimit)
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

        public bool WaitIfLessThan(uint TheLimit, Action TheAction, object TheLockObject)
        {

            if(IncrementIfCountIsLessThan(TheLimit))
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

        public bool WaitIfLessThan<T>(uint TheLimit, Action<T> TheAction, T TheParameter, object TheLockObject)
        {

            if(IncrementIfCountIsLessThan(TheLimit))
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

    }

}
