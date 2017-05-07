using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreComponents.Threading.SubThreading
{

    public abstract class BaseIsolatedWaitForSingleObject : IIsolatedThread
    {

        private bool myIsActive;

        private RegisteredWaitHandle myRegisteredWaitHandle;

        private Semaphore mySemaphore = new Semaphore(1, 1);

        private bool myExecuteOnlyOnce;

        private long myTimeoutInterval;

        //private RegisteredWaitHandle myRegisterWaitForSingleObject;

        private bool myStopRequested;

        private Exception myException;

        private object myLockObject;

        //Signaling is regarded as cancellation

        public BaseIsolatedWaitForSingleObject()
        {

            myLockObject = new object();

        }

        public BaseIsolatedWaitForSingleObject(object LObj)
        {
            
            myLockObject = LObj;

        }

        public BaseIsolatedWaitForSingleObject(long TheTimeoutInterval)
        {

            myTimeoutInterval = TheTimeoutInterval;

            myLockObject = new object();

        }

        public BaseIsolatedWaitForSingleObject(long TheTimeoutInterval, object LObj)
        {

            myTimeoutInterval = TheTimeoutInterval;

            myLockObject = LObj;

        }

        public BaseIsolatedWaitForSingleObject(long TheTimeoutInterval, bool ExecuteOnce)
        {

            myTimeoutInterval = TheTimeoutInterval;

            myExecuteOnlyOnce = ExecuteOnce;

            myLockObject = new object();

        }

        public BaseIsolatedWaitForSingleObject(long TheTimeoutInterval, bool ExecuteOnce, object LObj)
        {

            myTimeoutInterval = TheTimeoutInterval;

            myExecuteOnlyOnce = ExecuteOnce;

            myLockObject = LObj;

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
        
        public bool ExecuteOnlyOnce
        {

            get
            {

                lock(myLockObject)
                {

                    return myExecuteOnlyOnce;

                }

            }
            set
            {

                lock(myLockObject)
                {

                    if(IsActive)
                        throw new Exception("IsolatedWaitForSingleObject is still active");

                    myExecuteOnlyOnce = value;

                }

            }

        }

        public bool TrySetExecuteOnlyOnce(bool ExOnOnce)
        {

            lock(myLockObject)
            {

                if(!myIsActive)
                {

                    myExecuteOnlyOnce = ExOnOnce;

                    return true;

                }

                return false;

            }

        }

        public long TimeoutInterval
        {

            get
            {

                lock(myLockObject)
                {

                    return myTimeoutInterval;

                }

            }
            set
            {

                lock(myLockObject)
                {

                    if(IsActive)
                        throw new Exception("IsolatedWaitForSingleObject is still active");

                    myTimeoutInterval = value;

                }

            }

        }

        public bool TrySetTimeoutInterval(long TiIn)
        {

            lock(myLockObject)
            {

                if(!myIsActive)
                {

                    myTimeoutInterval = TiIn;

                    return true;

                }

                return false;

            }

        }

        public void Start()
        {

            lock(myLockObject)
            {

                if(myIsActive)
                    return;

                myIsActive = true;

                if(myStopRequested)
                    myStopRequested = false;

                if(myExecuteOnlyOnce)
                    myRegisteredWaitHandle = ThreadPool.RegisterWaitForSingleObject(mySemaphore, RunOnce, null, myTimeoutInterval, myExecuteOnlyOnce);
                else
                    myRegisteredWaitHandle = ThreadPool.RegisterWaitForSingleObject(mySemaphore, Run, null, myTimeoutInterval, myExecuteOnlyOnce);

            }

        }

        private void Run(object TheState, bool HasTimedOut)
        {

            if(!HasTimedOut)
                return;

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

            lock(myLockObject)
            {

                if(myStopRequested)
                {

                    if(myRegisteredWaitHandle != null)
                    {

                        myRegisteredWaitHandle.Unregister(mySemaphore);
                        
                        myRegisteredWaitHandle = null;

                    }

                    myStopRequested = false;

                    myIsActive = false;

                }   

            }

        }

        private void RunOnce(object TheState, bool HasTimedOut)
        {

            if(!HasTimedOut)
                return;

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

            lock(myLockObject)
            {

                if(myRegisteredWaitHandle != null)
                {

                    myRegisteredWaitHandle.Unregister(mySemaphore);

                    myRegisteredWaitHandle = null;

                }

                if(myStopRequested)
                    myStopRequested = false;
                    
                myIsActive = false;

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

        }

        public void Stop()
        {

            lock(myLockObject)
            {

                if(myRegisteredWaitHandle != null)
                {

                    myRegisteredWaitHandle.Unregister(mySemaphore);

                    myRegisteredWaitHandle = null;

                    myStopRequested = true;

                }

            }

        }

        public bool StopRequested
        {

            get
            {

                lock(myLockObject)
                {

                    return myStopRequested;

                }

            }

        }

    }

}
