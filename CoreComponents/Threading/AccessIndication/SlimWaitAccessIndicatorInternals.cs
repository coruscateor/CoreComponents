using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading.AccessIndication
{

    public class SlimWaitAccessIndicatorInternals : AccessIndicatorInternals, IAccessIndicatorInternals, IDisposable
    {

        protected SemaphoreSlim mySemaphoreSlim;

        protected int myCurrentCount = -1;

        public SlimWaitAccessIndicatorInternals()
        {

            mySemaphoreSlim = new SemaphoreSlim(0, 1);

        }

        public int CurrentCount
        {

            get
            {

                bool LockTaken = true;

                try
                {

                    mySpinLock.Enter(ref LockTaken);

                    return myCurrentCount;

                }
                finally
                {

                    if(LockTaken)
                        mySpinLock.Exit();

                }

            }

        }

        public bool IsNotWaiting
        {

            get
            {

                bool LockTaken = true;

                try
                {

                    mySpinLock.Enter(ref LockTaken);

                    return myCurrentCount < 1;

                }
                finally
                {

                    if(LockTaken)
                        mySpinLock.Exit();

                }


            }

        }

        public bool IsNotBeingAccessedAndNotWaiting
        {

            get
            {
                
                bool LockTaken = true;

                try
                {

                    mySpinLock.Enter(ref LockTaken);

                    return myCurrentThreadId > 0 && myCurrentCount < 1;

                }
                finally
                {

                    if(LockTaken)
                        mySpinLock.Exit();

                }

            }

        }

        public void Wait()
        {

            bool LockTaken = true;

            try
            {

                mySpinLock.Enter(ref LockTaken);

                ++myCurrentCount;

             }
             finally
             {

                 if(LockTaken)
                 {
                    
                    mySpinLock.Exit();

                    LockTaken = false;

                 }
            
            }

            try
            {

                mySemaphoreSlim.Wait();

            }
            finally
            {

                try
                {

                    mySpinLock.Enter(ref LockTaken);

                    --myCurrentCount;


                }
                finally
                {

                    if(LockTaken)
                        mySpinLock.Exit();

                }

            }

        }

        public void Wait(CancellationToken TheCancellationToken)
        {

            bool LockTaken = true;

            try
            {

                mySpinLock.Enter(ref LockTaken);

                ++myCurrentCount;

            }
            finally
            {

                if(LockTaken)
                {

                    mySpinLock.Exit();

                    LockTaken = false;

                }

            }

            try
            {

                mySemaphoreSlim.Wait(TheCancellationToken);

            }
            finally
            {

                try
                {

                    mySpinLock.Enter(ref LockTaken);

                    --myCurrentCount;

                }
                finally
                {

                    if(LockTaken)
                        mySpinLock.Exit();

                }

            }

        }

        public bool Wait(int TheMillisecondsTimeout)
        {

            bool LockTaken = true;

            try
            {

                mySpinLock.Enter(ref LockTaken);

                ++myCurrentCount;

            }
            finally
            {

                if(LockTaken)
                {

                    mySpinLock.Exit();

                    LockTaken = false;

                }

            }

            try
            {

                return mySemaphoreSlim.Wait(TheMillisecondsTimeout);

            }
            finally
            {

                try
                {

                    mySpinLock.Enter(ref LockTaken);

                    --myCurrentCount;

                }
                finally
                {

                    if(LockTaken)
                        mySpinLock.Exit();

                }

            }

        }

        public bool Wait(TimeSpan TheTimeout)
        {

            bool LockTaken = true;

            try
            {

                mySpinLock.Enter(ref LockTaken);

                ++myCurrentCount;

            }
            finally
            {

                if(LockTaken)
                {

                    mySpinLock.Exit();

                    LockTaken = false;

                }

            }

            try
            {

                return mySemaphoreSlim.Wait(TheTimeout);

            }
            finally
            {

                try
                {

                    mySpinLock.Enter(ref LockTaken);

                    --myCurrentCount;


                }
                finally
                {

                    if(LockTaken)
                        mySpinLock.Exit();

                }

            }

        }

        public bool Wait(int TheMillisecondsTimeout, CancellationToken TheCancellationToken)
        {

            bool LockTaken = true;

            try
            {

                mySpinLock.Enter(ref LockTaken);

                ++myCurrentCount;

            }
            finally
            {

                if(LockTaken)
                {

                    mySpinLock.Exit();

                    LockTaken = false;

                }

            }

            try
            {

                return mySemaphoreSlim.Wait(TheMillisecondsTimeout, TheCancellationToken);

            }
            finally
            {

                try
                {

                    mySpinLock.Enter(ref LockTaken);

                    --myCurrentCount;

                }
                finally
                {

                    if(LockTaken)
                        mySpinLock.Exit();

                }

            }

        }

        public bool Wait(TimeSpan TheTimeout, CancellationToken TheCancellationToken)
        {

            bool LockTaken = true;

            try
            {

                mySpinLock.Enter(ref LockTaken);

                ++myCurrentCount;

            }
            finally
            {

                if(LockTaken)
                {

                    mySpinLock.Exit();

                    LockTaken = false;

                }

            }

            try
            {

                return mySemaphoreSlim.Wait(TheTimeout, TheCancellationToken);

            }
            finally
            {

                try
                {

                    mySpinLock.Enter(ref LockTaken);

                    --myCurrentCount;

                }
                finally
                {

                    if(LockTaken)
                        mySpinLock.Exit();

                }

            }

        }

        public override void Reset()
        {

            base.Reset();

            mySemaphoreSlim.Release();

        }
        
        public void Dispose()
        {

            mySemaphoreSlim.Dispose();

        }

    }

    public class SlimWaitAccessIndicatorInternals<T> : SlimWaitAccessIndicatorInternals, IAccessIndicatorInternals<T>, IDisposable
    {

        protected T myItem;

        public SlimWaitAccessIndicatorInternals(T TheItem)
        {

            myItem = TheItem;

        }

        public T Item
        {

            get
            {

                return myItem;

            }

        }

    }

}
