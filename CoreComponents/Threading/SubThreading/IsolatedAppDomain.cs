using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading.SubThreading
{
    
    public abstract class IsolatedAppDomain : BaseIsolatedAppDomain, IIsolatedThread
    {

        private InputQueue myInputQueue;

        private ConcurrentQueue<object> myQueue;

        //public IsolatedAppDomain(TID TheId)
        //    : base(TheId)
        //{

        //    SetupQueue();

        //}

        //public IsolatedAppDomain(TID TheId, string TheName)
        //    : base(TheId, TheName)
        //{

        //    SetupQueue();

        //}

        //public IsolatedAppDomain(TID TheId, object LObj)
        //    : base(TheId, LObj)
        //{

        //    SetupQueue();

        //}

        //public IsolatedAppDomain(TID TheId, string TheName, object LObj)
        //    : base(TheId, TheName, LObj)
        //{

        //    SetupQueue();

        //}

        public IsolatedAppDomain()
            : base()
        {

            SetupQueue();

        }

        public IsolatedAppDomain(string TheName)
            : base(TheName)
        {

            SetupQueue();

        }

        public IsolatedAppDomain(object LObj)
            : base(LObj)
        {

            SetupQueue();

        }

        public IsolatedAppDomain(string TheName, object LObj)
            : base(TheName, LObj)
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
