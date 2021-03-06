﻿using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading.SubThreading.Ids
{

    public abstract class IsolatedWorkerThreadWithId<TID> : BaseIsolatedWorkerThreadWithId<TID>, IIsolatedThreadWithId<TID>, IIsolatedThread
    {

        InputQueue myInputQueue;

        ConcurrentQueue<object> myQueue;

        public IsolatedWorkerThreadWithId(TID TheId, int TheMaxStackSize = 0)
            : base(TheId, TheMaxStackSize)
        {

            SetupQueue();

        }

        public IsolatedWorkerThreadWithId(TID TheId, object lockObject, int TheMaxStackSize = 0)
            : base(TheId, lockObject, TheMaxStackSize)
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
