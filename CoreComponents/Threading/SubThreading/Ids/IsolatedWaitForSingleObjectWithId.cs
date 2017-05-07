using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading.SubThreading.Ids
{

    public abstract class IsolatedWaitForSingleObjectWithId<TID> : BaseIsolatedWaitForSingleObjectWithId<TID>, IIsolatedThreadWithId<TID>, IIsolatedThread
    {

        InputQueue myInputQueue;

        ConcurrentQueue<object> myQueue;

        public IsolatedWaitForSingleObjectWithId(TID TheId)
            : base(TheId)
        {

            SetupQueue();

        }

        public IsolatedWaitForSingleObjectWithId(TID TheId, object LObj)
            : base(TheId, LObj)
        {

            SetupQueue();

        }

        public IsolatedWaitForSingleObjectWithId(TID TheId, long TheTimeoutInterval)
            : base(TheId, TheTimeoutInterval)
        {

            SetupQueue();

        }

        public IsolatedWaitForSingleObjectWithId(TID TheId, long TheTimeoutInterval, object LObj)
            : base(TheId, TheTimeoutInterval, LObj)
        {

            SetupQueue();

        }

        public IsolatedWaitForSingleObjectWithId(TID TheId, long TheTimeoutInterval, bool ExecuteOnce)
            : base(TheId, TheTimeoutInterval, ExecuteOnce)
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
