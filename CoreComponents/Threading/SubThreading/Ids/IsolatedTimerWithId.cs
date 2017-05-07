using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading.SubThreading.Ids
{

    public abstract class IsolatedTimerWithId<TID> : BaseIsolatedTimerWithId<TID>, IIsolatedThreadWithId<TID>, IIsolatedThread
    {

        InputQueue myInputQueue;

        ConcurrentQueue<object> myQueue;

        public IsolatedTimerWithId(TID TheId, object lockObject = null)
            : base(TheId, lockObject)
        {

            SetupQueue();

        }

        public IsolatedTimerWithId(TID TheId, int TheDueTime, int ThePeriod, object lockObject = null)
            : base(TheId, TheDueTime, ThePeriod, lockObject)
        {

            SetupQueue();

        }

        public IsolatedTimerWithId(TID TheId, long TheDueTime, long ThePeriod, object lockObject = null)
            : base(TheId, TheDueTime, ThePeriod, lockObject)
        {

            SetupQueue();

        }

        public IsolatedTimerWithId(TID TheId, TimeSpan TheDueTime, TimeSpan ThePeriod, object lockObject = null)
            : base(TheId, TheDueTime, ThePeriod, lockObject)
        {

            SetupQueue();

        }

        public IsolatedTimerWithId(TID TheId, uint TheDueTime, uint ThePeriod, object lockObject = null)
            : base(TheId, TheDueTime, ThePeriod, lockObject)
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
