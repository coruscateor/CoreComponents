using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading.AccessIndication
{

    public class WaitAccessIndicatorInternals : AccessIndicatorInternals, IAccessIndicatorInternals, IDisposable
    {

        protected Semaphore mySemaphore;

        protected int myCurrentCount = -1;

        public WaitAccessIndicatorInternals()
        {

            mySemaphore = new Semaphore(0, 1);

        }

        public int CurrentCount
        {

            get
            {

                return myCurrentCount;

            }

        }

        public bool IsNotWaiting
        {

            get
            {

                return myCurrentCount < 1;

            }

        }

        public bool IsNotBeingAccessedAndNotWaiting
        {

            get
            {

                return myCurrentThreadId > 0 && myCurrentCount < 1;

            }

        }

        public bool Wait()
        {

            ++myCurrentCount;

            try
            {

                return mySemaphore.WaitOne();

            }
            finally
            {

                --myCurrentCount;

            }

        }

        public bool Wait(int TheMillisecondsTimeout)
        {

            ++myCurrentCount;

            try
            {

                return mySemaphore.WaitOne(TheMillisecondsTimeout);

            }
            finally
            {

                --myCurrentCount;

            }

        }

        public bool Wait(TimeSpan TheTimeout)
        {

            ++myCurrentCount;

            try
            {

                return mySemaphore.WaitOne(TheTimeout);

            }
            finally
            {

                --myCurrentCount;

            }

        }

        public bool Wait(int TheMillisecondsTimeout, bool TheExitContext)
        {

            ++myCurrentCount;

            try
            {

                return mySemaphore.WaitOne(TheMillisecondsTimeout, TheExitContext);

            }
            finally
            {

                --myCurrentCount;

            }

        }

        public bool Wait(TimeSpan TheTimeout, bool TheExitContext)
        {

            ++myCurrentCount;

            try
            {

                return mySemaphore.WaitOne(TheTimeout, TheExitContext);

            }
            finally
            {

                --myCurrentCount;

            }

        }

        public override void Reset()
        {

            base.Reset();

            mySemaphore.Release();

        }
        
        public void Dispose()
        {

            mySemaphore.Dispose();

        }

    }

    public class WaitAccessIndicatorInternals<T> : WaitAccessIndicatorInternals, IAccessIndicatorInternals<T>, IDisposable
    {

        protected T myItem;

        public WaitAccessIndicatorInternals(T TheItem)
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
