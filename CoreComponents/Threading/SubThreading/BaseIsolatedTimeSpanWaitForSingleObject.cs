using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading.SubThreading
{

    public abstract class BaseIsolatedTimeSpanWaitForSingleObject : IIsolatedWaitForSingleObject<TimeSpan>
    {

        protected IsolatedWaitForSingleObjectComponents<TimeSpan> myBase;

        public BaseIsolatedTimeSpanWaitForSingleObject()
        {

            Initalise();

        }

        public BaseIsolatedTimeSpanWaitForSingleObject(TimeSpan TheTimeoutInterval)
        {

            Initalise();

            myBase.TimeoutInterval = TheTimeoutInterval;

        }

        public BaseIsolatedTimeSpanWaitForSingleObject(TimeSpan TheTimeoutInterval, bool ExecuteOnce)
        {

            Initalise();

            myBase.TimeoutInterval = TheTimeoutInterval;

            myBase.ExecuteOnlyOnce = ExecuteOnce;

        }

        private void Initalise()
        {

            myBase = new IsolatedWaitForSingleObjectComponents<TimeSpan>(ThreadMain, () => { return ThreadPool.RegisterWaitForSingleObject(myBase.Semaphore, myBase.Run, null, myBase.TimeoutInterval, myBase.ExecuteOnlyOnce); });

        }

        protected abstract void ThreadMain();

        public TimeSpan TimeoutInterval
        {

            get
            {

                return myBase.TimeoutInterval;

            }
            set
            {

                myBase.TimeoutInterval = value;

            }

        }

        public bool ExecuteOnlyOnce
        {

            get
            {

                return myBase.ExecuteOnlyOnce;

            }
            set
            {

                myBase.ExecuteOnlyOnce = value;

            }

        }

        public void Start()
        {

            myBase.Start();

        }

        public bool IsActive
        {

            get
            {

                return myBase.IsActive;

            }

        }

        public void Stop()
        {
            
            myBase.Stop();

        }

        public bool StopRequested
        {

            get
            {
                
                return myBase.StopRequested;
            
            }

        }

    }

}
