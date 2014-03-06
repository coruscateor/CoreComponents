using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    public class ConcurrentQueueContainerCreator<T> : BaseConcurrentQueueContainer<T>, IOutputQueue<T>, IInputQueue<T>
    {

        public ConcurrentQueueContainerCreator() : base(new ConcurrentQueue<T>())
        {
        }

        public ConcurrentOutputQueueContainer<T> CreateCreateOutputQueueContainer()
        {

            return new ConcurrentOutputQueueContainer<T>(myQueue);

        }

        public ConcurrentInputQueueContainer<T> CreateCreateInputQueueContainer()
        {

            return new ConcurrentInputQueueContainer<T>(myQueue);

        }

        public bool TryDequeue(out T TheItem)
        {

            return myQueue.TryDequeue(out TheItem);

        }

        public void Enqueue(T TheItem)
        {
            
            myQueue.Enqueue(TheItem);

        }

    }

}
