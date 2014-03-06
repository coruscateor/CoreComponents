using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading.SubThreading
{
    
    public abstract class BaseWaitForSingleObjectSubThread : ISubThread
    {

        public static readonly TimeSpan DefaultTimespan;

        private Semaphore mySemaphore;

        private RegisteredWaitHandle myRegisteredWaitHandle;

        private TimeSpan myTimespan;

        private bool myExecuteOnlyOnce;

        private object myState;

        static BaseWaitForSingleObjectSubThread()
        {

            DefaultTimespan = new TimeSpan(0, 1, 0);

        }

        public BaseWaitForSingleObjectSubThread()
        {

            Initialise();

        }

        public BaseWaitForSingleObjectSubThread(TimeSpan TheTimespan)
        {

            myTimespan = TheTimespan;

            Initialise();

        }

        public BaseWaitForSingleObjectSubThread(bool TheExecuteOnlyOnce)
        {

            myExecuteOnlyOnce = TheExecuteOnlyOnce;

            Initialise();

        }

        public BaseWaitForSingleObjectSubThread(TimeSpan TheTimespan, bool TheExecuteOnlyOnce)
        {

            myTimespan = TheTimespan;

            myExecuteOnlyOnce = TheExecuteOnlyOnce;

            Initialise();

        }

        protected void Initialise()
        {

            mySemaphore = new Semaphore(0, 1);

        }

        public void Start()
        {

            if(!IsActive)
            {

                if(myState != null)
                    myState = null;

                myRegisteredWaitHandle = ThreadPool.RegisterWaitForSingleObject(mySemaphore, new WaitOrTimerCallback(RunThreadMain), null, myTimespan, myExecuteOnlyOnce);

                Thread.MemoryBarrier();

            }

        }

        public void Start(object TheState)
        {

            if(!IsActive)
            {

                myState = TheState;

                myRegisteredWaitHandle = ThreadPool.RegisterWaitForSingleObject(mySemaphore, new WaitOrTimerCallback(RunThreadMain), null, myTimespan, myExecuteOnlyOnce);

                Thread.MemoryBarrier();

            }

        }

        private void RunThreadMain(object TheState, bool TimedOut)
        {

            ThreadMain();

            if(TimedOut)
            {

                myRegisteredWaitHandle = null;

                Thread.MemoryBarrier();

            }

        }

        protected abstract void ThreadMain();

        public bool IsActive
        {

            get
            {

                Thread.MemoryBarrier();

                return myRegisteredWaitHandle != null;
            
            }

        }

        public TimeSpan Timespan
        {

            get
            {

                Thread.MemoryBarrier();

                return myTimespan;

            }
            set
            {

                if(!IsActive)
                {

                    myTimespan = value;

                    Thread.MemoryBarrier();

                }
                else
                {

                    throw new Exception("Timespan cannot be set as the WaitForSingleObjectSubThread is active");

                }

            }

        }

        public bool ExecuteOnlyOnce
        {

            get
            {

                Thread.MemoryBarrier();

                return myExecuteOnlyOnce;

            }
            set
            {

                if(!IsActive)
                {

                    myExecuteOnlyOnce = value;

                    Thread.MemoryBarrier();

                }
                else
                {

                    throw new Exception("ExecuteOnlyOnce cannot be set as the WaitForSingleObjectSubThread is active");

                }

            }

        }

        public void Stop()
        {

            if(!IsActive)
            {

                myRegisteredWaitHandle.Unregister(mySemaphore);

                myRegisteredWaitHandle = null;

                Thread.MemoryBarrier();

            }

        }

        public bool StopRequested
        {

            get
            {

                return false;

            }

        }

    }

}
