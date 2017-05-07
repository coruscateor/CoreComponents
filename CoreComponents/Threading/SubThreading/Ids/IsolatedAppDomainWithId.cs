using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading.SubThreading.Ids
{

    public abstract class IsolatedAppDomainWithId<TID> : BaseIsolatedAppDomainWithId<TID>, IIsolatedThreadWithId<TID>, IIsolatedThread
    {

        InputQueue myInputQueue;

        ConcurrentQueue<object> myQueue;

        public IsolatedAppDomainWithId(TID TheId)
            : base(TheId)
        {

            SetupQueue();

        }

        public IsolatedAppDomainWithId(TID TheId, string TheName)
            : base(TheId, TheName)
        {

            SetupQueue();

        }

        public IsolatedAppDomainWithId(TID TheId, object LObj)
            : base(TheId, LObj)
        {

            SetupQueue();

        }

        public IsolatedAppDomainWithId(TID TheId, string TheName, object LObj)
            : base(TheId, TheName, LObj)
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
