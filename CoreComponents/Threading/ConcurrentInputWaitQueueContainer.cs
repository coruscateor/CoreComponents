using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    [Serializable]
    public class ConcurrentInputWaitQueueContainer<TType> : BaseConcurrentQueueContainer<TType>, IInputQueue<TType>, IDisposable
    {

        protected WaitWatcher myWaitWatcher;

        public ConcurrentInputWaitQueueContainer(ConcurrentQueue<TType> TheQueue, WaitWatcher TheWaitWatcher)
            : base(TheQueue)
        {

            myWaitWatcher = TheWaitWatcher;

        }

        public void Enqueue(TType TheItem)
        {

            myQueue.Enqueue(TheItem);

            myWaitWatcher.SetIfEngaged();

        }

        public void Dispose()
        {

            myWaitWatcher.Dispose();

        }

    }

}
