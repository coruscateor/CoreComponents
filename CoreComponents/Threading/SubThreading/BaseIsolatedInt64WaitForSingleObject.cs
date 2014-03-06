using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading.SubThreading
{

    public abstract class BaseIsolatedInt64WaitForSingleObject : IIsolatedWaitForSingleObject<long>
    {

        protected IsolatedWaitForSingleObjectComponents<long> myBase;

        public BaseIsolatedInt64WaitForSingleObject()
        {

            Initalise();

        }

        public BaseIsolatedInt64WaitForSingleObject(long TheTimeoutInterval)
        {

            Initalise();

            myBase.TimeoutInterval = TheTimeoutInterval;

        }

        public BaseIsolatedInt64WaitForSingleObject(long TheTimeoutInterval, bool ExecuteOnce)
        {

            Initalise();

            myBase.TimeoutInterval = TheTimeoutInterval;

            myBase.ExecuteOnlyOnce = ExecuteOnce;

        }

        private void Initalise()
        {

            myBase = new IsolatedWaitForSingleObjectComponents<long>(ThreadMain, () => { return ThreadPool.RegisterWaitForSingleObject(myBase.Semaphore, myBase.Run, null, myBase.TimeoutInterval, myBase.ExecuteOnlyOnce); });

        }

        protected abstract void ThreadMain();

        public long TimeoutInterval
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
