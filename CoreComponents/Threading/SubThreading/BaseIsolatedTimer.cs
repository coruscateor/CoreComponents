using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading.SubThreading
{

    public abstract class BaseIsolatedTimer : ISubThread, IDisposable
    {

        private Timer myTimer;

        private object myProvidedState;

        private long myDefaultDueTime;

        private long myDefaultPeriod;

        private bool myLastExecutionSuccessful;

        private bool myIsActive;

        //private ConcurrentQueue<KeyValuePair<int, DateTime>> myReentracyAttepts = new ConcurrentQueue<KeyValuePair<int, DateTime>>();

        public BaseIsolatedTimer() 
        {

            myTimer = new Timer(RunThreadMain);
            
        }

        public BaseIsolatedTimer(int TheDueTime, int ThePeriod, object TheProvidedState = null)
        {

            myTimer = new Timer(RunThreadMain, TheProvidedState, TheDueTime, ThePeriod);

            myDefaultDueTime = TheDueTime;

            myDefaultPeriod = ThePeriod;

            myProvidedState = TheProvidedState;

        }

        public BaseIsolatedTimer(long TheDueTime, long ThePeriod, object TheProvidedState = null)
        {

            myTimer = new Timer(RunThreadMain, TheProvidedState, TheDueTime, ThePeriod);

            myDefaultDueTime = TheDueTime;

            myDefaultPeriod = ThePeriod;

            myProvidedState = TheProvidedState;

        }

        public BaseIsolatedTimer(TimeSpan TheDueTime, TimeSpan ThePeriod, object TheProvidedState = null)
        {

            myTimer = new Timer(RunThreadMain, TheProvidedState, TheDueTime, ThePeriod);

            myDefaultDueTime = Convert.ToInt64(TheDueTime.TotalMilliseconds);

            myDefaultPeriod = Convert.ToInt64(ThePeriod.TotalMilliseconds);

            myProvidedState = TheProvidedState;

        }

        public BaseIsolatedTimer(uint TheDueTime, uint ThePeriod, object TheProvidedState = null)
        {

            myTimer = new Timer(RunThreadMain, TheProvidedState, TheDueTime, ThePeriod);

            myDefaultDueTime = TheDueTime;

            myDefaultPeriod = ThePeriod;

            myProvidedState = TheProvidedState;

        }

        protected abstract void ThreadMain();

        private void RunThreadMain(object TheState) 
        {

            Thread.MemoryBarrier();

            if (!myIsActive)
            {

                myIsActive = true;

                Thread.MemoryBarrier();

                try
                {

                    ThreadMain();

                }
                finally
                {

                    myIsActive = false;

                    Thread.MemoryBarrier();

                }

            }
            //else 
            //{

            //    lock (myTimer)
            //    {

            //       KeyValuePair<int, DateTime> ThreadIdAndDateTime =  new KeyValuePair<int, DateTime>(Thread.CurrentThread.ManagedThreadId, DateTime.Now);

            //       myReentracyAttepts.Enqueue(ThreadIdAndDateTime);

            //    }


            //}

        }

        //public Timer TheTimer
        //{

        //    get
        //    {

        //        return myTimer;

        //    }

        //}

        public void Start()
        {

            Thread.MemoryBarrier();

            long CurrentDefaultTime = myDefaultDueTime;

            Thread.MemoryBarrier();

            long CurrentDefaultPeriod = myDefaultPeriod;

            myLastExecutionSuccessful = myTimer.Change(CurrentDefaultTime, CurrentDefaultPeriod);
            
        }

        public long DefaultDueTime 
        {

            get
            {

                Thread.MemoryBarrier();

                return myDefaultDueTime;

            }
            set
            {

                myDefaultDueTime = value;

                Thread.MemoryBarrier();

            }

        }

        public long DefaultPeriod 
        {

            get
            {

                Thread.MemoryBarrier();

                return myDefaultPeriod;

            }
            set
            {

                myDefaultPeriod = value;

                Thread.MemoryBarrier();

            }

        }

        public void Stop()
        {

            myLastExecutionSuccessful = myTimer.Change(Timeout.Infinite, Timeout.Infinite);

        }

        public bool LastExecutionSuccessful 
        {

            get 
            {

                Thread.MemoryBarrier();

                return myLastExecutionSuccessful;

            }

        }

        protected object TheProvidedState 
        {

            get 
            {

                return myProvidedState;

            }

        }

        protected bool HasProvidedState
        {

            get
            {

                return myProvidedState != null;

            }

        }

        public bool IsActive
        {

            get
            {

                Thread.MemoryBarrier();

                return myIsActive;

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

        //public bool HasHadReentrancyAttempts
        //{

        //    get
        //    {

        //        return myReentracyAttepts.Count > 0;

        //    }

        //}

        //public int ReentrancyAttemptCount
        //{

        //    get
        //    {

        //        return myReentracyAttepts.Count;

        //    }

        //}

        //public IEnumerator<KeyValuePair<int, DateTime>> GetReentrancyAttemptsEnumerator()
        //{

        //    return myReentracyAttepts.GetEnumerator();

        //}
        
    }

}
