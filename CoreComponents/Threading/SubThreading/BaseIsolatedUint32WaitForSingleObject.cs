using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading.SubThreading
{

    public abstract class BaseIsolatedUint32WaitForSingleObject : IIsolatedWaitForSingleObject<uint>
    {

        protected IsolatedWaitForSingleObjectComponents<uint> myBase;

        public BaseIsolatedUint32WaitForSingleObject()
        {

            Initalise();

        }

        public BaseIsolatedUint32WaitForSingleObject(uint TheTimeoutInterval)
        {

            Initalise();

            myBase.TimeoutInterval = TheTimeoutInterval;

        }

        public BaseIsolatedUint32WaitForSingleObject(uint TheTimeoutInterval, bool ExecuteOnce)
        {

            Initalise();

            myBase.TimeoutInterval = TheTimeoutInterval;

            myBase.ExecuteOnlyOnce = ExecuteOnce;

        }

        private void Initalise()
        {

            myBase = new IsolatedWaitForSingleObjectComponents<uint>(ThreadMain, () => { return ThreadPool.RegisterWaitForSingleObject(myBase.Semaphore, myBase.Run, null, myBase.TimeoutInterval, myBase.ExecuteOnlyOnce); });

        }

        protected abstract void ThreadMain();

        public uint TimeoutInterval
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
