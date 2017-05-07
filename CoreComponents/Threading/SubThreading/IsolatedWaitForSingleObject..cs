using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading.SubThreading
{

    public abstract class IsolatedWaitForSingleObject<TID> : BaseIsolatedWaitForSingleObject, IIsolatedThread
    {

        private InputQueue myInputQueue;

        private ConcurrentQueue<object> myQueue;

        public IsolatedWaitForSingleObject(TID TheId)
            : base(TheId)
        {

            SetupQueue();

        }

        public IsolatedWaitForSingleObject(TID TheId, object LObj)
            : base(LObj)
        {

            SetupQueue();

        }

        public IsolatedWaitForSingleObject(TID TheId, long TheTimeoutInterval)
            : base(TheTimeoutInterval)
        {

            SetupQueue();

        }

        public IsolatedWaitForSingleObject(TID TheId, long TheTimeoutInterval, object LObj)
            : base(TheTimeoutInterval, LObj)
        {

            SetupQueue();

        }

        public IsolatedWaitForSingleObject(TID TheId, long TheTimeoutInterval, bool ExecuteOnce)
            : base(TheTimeoutInterval, ExecuteOnce)
        {

            SetupQueue();

        }

        public IsolatedWaitForSingleObject(TID TheId, long TheTimeoutInterval, bool ExecuteOnce, object LObj)
            : base(TheTimeoutInterval, ExecuteOnce, LObj)
        {

            SetupQueue();

        }

        private void SetupQueue()
        {

            myQueue = new ConcurrentQueue<object>();

            myInputQueue = new InputQueue(this, myQueue);

        }

        public InputQueue InputQueue
        {

            get
            {

                return myInputQueue;

            }

        }

        protected ConcurrentQueue<object> Queue
        {

            get
            {

                return myQueue;

            }

        }

        //protected override void ThreadMain()
        //{

        //    object CurrentResult;

        //    if(myQueue.TryDequeue(out CurrentResult))
        //        DoWork(CurrentResult);
        //    else
        //        DoWork();

        //}

        //protected abstract void DoWork();

        //protected abstract void DoWork(object InputItem);

    }

}
