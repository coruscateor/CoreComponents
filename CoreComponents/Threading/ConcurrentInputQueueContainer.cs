using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    [Serializable]
    public class ConcurrentInputQueueContainer<TType> : BaseConcurrentQueueContainer<TType>, IInputQueue<TType>
    {

        public ConcurrentInputQueueContainer(ConcurrentQueue<TType> TheQueue)
            : base(TheQueue)
        {
        }

        public void Enqueue(TType TheItem)
        {

            myQueue.Enqueue(TheItem);

        }

    }
    
}
