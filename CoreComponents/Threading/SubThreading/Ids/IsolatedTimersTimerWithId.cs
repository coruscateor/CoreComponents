using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading.SubThreading.Ids
{

    public abstract class IsolatedTimersTimerWithId<TID> : BaseIsolatedTimersTimerWithId<TID>, IIsolatedThreadWithId<TID>, IIsolatedThread
    {

        InputQueue myInputQueue;

        ConcurrentQueue<object> myQueue;

        public IsolatedTimersTimerWithId(TID TheId)
            : base(TheId)
        {

            SetupQueue();

        }

        public IsolatedTimersTimerWithId(TID TheId, object LObj)
            : base(TheId, LObj)
        {

            SetupQueue();

        }

        public IsolatedTimersTimerWithId(TID TheId, double Ival)
            : base(TheId, Ival)
        {

            SetupQueue();

        }

        public IsolatedTimersTimerWithId(TID TheId, double Ival, object LObj)
            : base(TheId, Ival, LObj)
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

    }

}
