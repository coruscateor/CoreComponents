using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading.SubThreading
{

    public abstract class BaseIsolatedTimer : IIsolatedThread, IDisposable
    {

        private Timer myTimer;

        private object myLockObject;

        private long myDefaultDueTime;

        private long myDefaultPeriod;

        private bool myLastChangeSuccessful;

        private bool myIsActive;

        private Exception myException;

        public BaseIsolatedTimer(object lockObject = null) 
        {

            myTimer = new Timer(RunThreadMain);

            if(lockObject == null)
                lockObject = new object();
            else
                myLockObject = lockObject;

        }

        public BaseIsolatedTimer(int TheDueTime, int ThePeriod, object lockObject = null)
        {

            myTimer = new Timer(RunThreadMain, null, TheDueTime, ThePeriod);

            myDefaultDueTime = TheDueTime;

            myDefaultPeriod = ThePeriod;

            if(lockObject == null)
                lockObject = new object();
            else
                myLockObject = lockObject;

        }

        public BaseIsolatedTimer(long TheDueTime, long ThePeriod, object lockObject = null)
        {

            myTimer = new Timer(RunThreadMain, null, TheDueTime, ThePeriod);

            myDefaultDueTime = TheDueTime;

            myDefaultPeriod = ThePeriod;

            if(lockObject == null)
                lockObject = new object();
            else
                myLockObject = lockObject;

        }

        public BaseIsolatedTimer(TimeSpan TheDueTime, TimeSpan ThePeriod, object lockObject = null)
        {

            myTimer = new Timer(RunThreadMain, null, TheDueTime, ThePeriod);

            myDefaultDueTime = Convert.ToInt64(TheDueTime.TotalMilliseconds);

            myDefaultPeriod = Convert.ToInt64(ThePeriod.TotalMilliseconds);

            if(lockObject == null)
                lockObject = new object();
            else
                myLockObject = lockObject;

        }

        public BaseIsolatedTimer(uint TheDueTime, uint ThePeriod, object lockObject = null)
        {

            myTimer = new Timer(RunThreadMain, null, TheDueTime, ThePeriod);

            myDefaultDueTime = TheDueTime;

            myDefaultPeriod = ThePeriod;

            if(lockObject == null)
                lockObject = new object();
            else
                myLockObject = lockObject;

        }

        public Exception Exception
        {

            get
            {

                lock(myLockObject)
                {

                    return myException;

                }

            }

        }

        public bool TryGetException(out Exception Ex)
        {

            lock(myLockObject)
            {

                Ex = myException;

            }

            return Ex != null;

        }

        public bool HasException
        {

            get
            {

                lock(myLockObject)
                {

                    return myException != null;

                }

            }

        }

        protected abstract void ThreadMain();

        private void RunThreadMain(object TheState) 
        {

            bool HasLock = Monitor.TryEnter(this);

            if(!HasLock)
            {

                lock(myLockObject)
                {

                    myException = new ReentrancyException("Reentrant call detected");

                }

                return;

            }

            if(!IsActive)
            {

                lock(myLockObject)
                {

                    myIsActive = true;

                    if(myException != null)
                        myException = null;

                }

                try
                {

                    ThreadMain();

                }
                catch(Exception Ex)
                {

                    lock(myLockObject)
                    {

                        myException = Ex;

                    }

                }
                finally
                {

                    IsActive = false;

                }

            }

            Monitor.Exit(this);

        }

        public void Start()
        {

            lock(myLockObject)
            {

                myLastChangeSuccessful = myTimer.Change(myDefaultDueTime, myDefaultPeriod);

            }

        }

        public long DefaultDueTime 
        {

            get
            {

                lock(myLockObject)
                {

                    return myDefaultDueTime;

                }

            }
            set
            {

                lock(myLockObject)
                {

                    myDefaultDueTime = value;

                    myLastChangeSuccessful = myTimer.Change(value, myDefaultPeriod);

                }

            }

        }

        public long DefaultPeriod 
        {

            get
            {

                lock(myLockObject)
                {

                    return myDefaultPeriod;

                }

            }
            set
            {

                lock(myLockObject)
                {

                    myDefaultPeriod = value;

                    myLastChangeSuccessful = myTimer.Change(myDefaultDueTime, value);

                }

            }

        }

        public void GetDefaultDueTimeAndPeriod(out long defaultDueTime, out long defaultPeriod)
        {

            lock(myLockObject)
            {

                defaultDueTime = myDefaultDueTime;

                defaultPeriod = myDefaultPeriod;

            }

        }

        public void SetDefaultDueTimeAndPeriod(long defaultDueTime, long defaultPeriod)
        {

            lock(myLockObject)
            {

                myDefaultDueTime = defaultDueTime;

                myDefaultPeriod = defaultPeriod;

                myLastChangeSuccessful = myTimer.Change(defaultDueTime, defaultPeriod);

            }

        }

        public void Stop()
        {

            lock(myLockObject)
            {

                myLastChangeSuccessful = myTimer.Change(Timeout.Infinite, Timeout.Infinite);

            }

        }

        public bool LastChangeSuccessful 
        {

            get 
            {

                lock(myLockObject)
                {

                    return myLastChangeSuccessful;

                }

            }

        }

        public bool IsActive
        {

            get
            {

                lock(myLockObject)
                {

                    return myIsActive;

                }

            }
            private set
            {

                lock(myLockObject)
                {

                    myIsActive = value;

                }

            }

        }
        
        public bool StopRequested
        {

            get
            {

                return false;

            }

        }

        public void Dispose()
        {

            myTimer.Dispose();

        }

        public void Dispose(WaitHandle TheNotifyObject)
        {

            myTimer.Dispose(TheNotifyObject);

        }
        
    }

}
