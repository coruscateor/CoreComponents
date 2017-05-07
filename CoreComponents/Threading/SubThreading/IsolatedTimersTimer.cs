using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading.SubThreading
{

    public abstract class IsolatedTimersTimer : BaseIsolatedTimersTimer, IIsolatedThread, IDisposable
    {

        private InputQueue myInputQueue;

        private ConcurrentQueue<object> myQueue;

        public IsolatedTimersTimer()
            : base()
        {

            SetupQueue();

        }

        public IsolatedTimersTimer(object LObj)
            : base(LObj)
        {

            SetupQueue();

        }

        public IsolatedTimersTimer(double Ival)
            : base(Ival)
        {

            SetupQueue();

        }

        public IsolatedTimersTimer( double Ival, object LObj)
            : base(Ival, LObj)
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
