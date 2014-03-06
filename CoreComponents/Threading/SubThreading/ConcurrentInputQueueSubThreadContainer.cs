using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading
{

    public class ConcurrentInputQueueSubThreadContainer<T> : ConcurrentInputQueueContainer<T>, IInputQueueSubThreadContainer<T>
    {

        protected ISubThread mySubThread;

        public ConcurrentInputQueueSubThreadContainer(ConcurrentQueue<T> TheQueue, ISubThread TheSubThread) : base(TheQueue)
        {

            mySubThread = TheSubThread;

        }

        public void EnqueueAndCheck(T TheItem)
        {

            myQueue.Enqueue(TheItem);

            mySubThread.Start();

        }

        public bool SubThreadIsActive
        {

            get
            {

                return mySubThread.IsActive;

            }

        }

    }

}
