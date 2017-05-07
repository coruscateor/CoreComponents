using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public abstract class BaseTemporalReference<T>
        where T : class
    {

        protected object myLockObject;

        protected RegisteredWaitHandle myRegesteredWaitHandle;

        protected Semaphore mySemaphore = new Semaphore(1, 1);

        protected long myDefaultTime;

        protected long myTimeOutInterval;

        protected const long myConstDefaultTime = 500L;

        protected const long myConstTimeOutInterval = 200L;

        bool myIsIDisposable;

        readonly bool myExecuteOnlyOnce;

        public BaseTemporalReference(bool ExOnlyOnce)
        {

            myIsIDisposable = this is IDisposable;

            myExecuteOnlyOnce = ExOnlyOnce;

        }

        public long DefaultTimeLimit
        {

            get
            {

                lock(myLockObject)
                {

                    return myDefaultTime;

                }

            }
            set
            {

                lock(myLockObject)
                {

                    myDefaultTime = value;

                }

            }

        }

        public long TimeOutInterval
        {

            get
            {

                lock(myLockObject)
                {

                    return myTimeOutInterval;

                }

            }
            set
            {

                lock(myLockObject)
                {

                    myTimeOutInterval = value;

                }

            }

        }

        public void Set(long TheDefaultTimeLimit, long TheTimeOutInterval)
        {

            lock(myLockObject)
            {

                myDefaultTime = TheDefaultTimeLimit;

                long CurrentTimeOutInterval = myTimeOutInterval;

                myTimeOutInterval = TheDefaultTimeLimit;

                if(IsRegestered && myTimeOutInterval != CurrentTimeOutInterval)
                {

                    ResetWaitHandle();

                }

            }

        }

        protected bool IsIDisposable
        {

            get
            {

                return myIsIDisposable;

            }

        }

        protected void Unregister()
        {

            myRegesteredWaitHandle.Unregister(mySemaphore);

            myRegesteredWaitHandle = null;

        }

        protected void ResetWaitHandle()
        {

            myRegesteredWaitHandle.Unregister(mySemaphore);

            Setup();

        }

        public void Reset()
        {

            lock(myLockObject)
            {

                if(IsRegestered)
                    ResetWaitHandle();

            }

        }

        public void ResetTimeOutInterval(long TheTimeOutInterval)
        {

            lock(myLockObject)
            {

                myTimeOutInterval = TheTimeOutInterval;

                if(IsRegestered)
                    ResetWaitHandle();

            }

        }

        public void Stop()
        {

            lock(myLockObject)
            {

                if(IsRegestered)
                    Unregister();

            }

        }

        public void Start()
        {

            lock(myLockObject)
            {

                if(!IsRegestered)
                    Setup();

            }

        }

        protected bool IsRegestered
        {

            get
            {

                return myRegesteredWaitHandle != null;

            }

        }

        public bool IsActive
        {

            get
            {

                lock(myLockObject)
                {

                    return IsRegestered;

                }

            }

        }

        protected void Setup()
        {

            //if(IsRegestered)
            //    myRegesteredWaitHandle.Unregister(mySemaphore);

            //myRegesteredWaitHandle = ThreadPooling.RegisterWaitForSingleObject(mySemaphore, CheckAndDeReference, null, myTimeOutInterval, myExecuteOnlyOnce);

        }

        protected void SetupIfInActive()
        {

            if(!IsRegestered)
                Setup();

        }

        protected abstract void CheckAndDeReference(object TheState, bool TimedOut);

        protected void Dispose(T Item)
        {

            IDisposable DisposableItem = Item as IDisposable;

            if(DisposableItem != null)
                DisposableItem.Dispose();

        }

    }

}
