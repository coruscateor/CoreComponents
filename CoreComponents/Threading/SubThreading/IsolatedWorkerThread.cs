using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading.SubThreading
{

    public abstract class IsolatedWorkerThread : BaseIsolatedWorkerThread, IIsolatedThread
    {

        private InputQueue myInputQueue;

        private ConcurrentQueue<object> myQueue;

        public IsolatedWorkerThread()
            : base()
        {

            SetupQueue();

        }

        public IsolatedWorkerThread(object LObject)
            : base(LObject)
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
