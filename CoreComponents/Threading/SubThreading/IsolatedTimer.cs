using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading.SubThreading
{

    public abstract class IsolatedTimer : BaseIsolatedTimer, IIsolatedThread, IDisposable
    {

        private InputQueue myInputQueue;

        private ConcurrentQueue<object> myQueue;

        public IsolatedTimer(object lockObject = null)
            : base(lockObject)
        {

            SetupQueue();

        }

        public IsolatedTimer(int TheDueTime, int ThePeriod, object lockObject = null)
            : base(TheDueTime, ThePeriod, lockObject)
        {

            SetupQueue();

        }

        public IsolatedTimer(long TheDueTime, long ThePeriod, object lockObject = null)
            : base(TheDueTime, ThePeriod, lockObject)
        {

            SetupQueue();

        }

        public IsolatedTimer(TimeSpan TheDueTime, TimeSpan ThePeriod, object lockObject = null)
            : base(TheDueTime, ThePeriod, lockObject)
        {

            SetupQueue();

        }

        public IsolatedTimer(uint TheDueTime, uint ThePeriod, object lockObject = null)
            : base(TheDueTime, ThePeriod, lockObject)
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
