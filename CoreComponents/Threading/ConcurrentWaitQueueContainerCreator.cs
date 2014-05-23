using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    [Serializable]
    public class ConcurrentWaitQueueContainerCreator<T> : BaseConcurrentQueueContainer<T>, IOutputQueue<T>, IInputQueue<T>
    {

        protected WaitWatcher myWaitWatcher;

        public ConcurrentWaitQueueContainerCreator()
            : base(new ConcurrentQueue<T>())
        {
        }

        public ConcurrentOutputWaitQueueContainer<T> CreateConcurrentOutputWaitQueueContainer()
        {

            return new ConcurrentOutputWaitQueueContainer<T>(myQueue, myWaitWatcher);

        }

        public ConcurrentInputWaitQueueContainer<T> CreateConcurrentInputWaitQueueContainer()
        {

            return new ConcurrentInputWaitQueueContainer<T>(myQueue, myWaitWatcher);

        }

        public bool TryDequeue(out T TheItem)
        {

            if(myWaitWatcher.Engaged)
            {

                myWaitWatcher.Wait();

                return myQueue.TryDequeue(out TheItem);

            }

            bool ValueRetrived = myQueue.TryDequeue(out TheItem);

            if(ValueRetrived)
                return ValueRetrived;

            myWaitWatcher.Wait();

            return myQueue.TryDequeue(out TheItem);

        }

        public void Enqueue(T TheItem)
        {

            myQueue.Enqueue(TheItem);

            myWaitWatcher.SetIfEngaged();

        }

    }

}
