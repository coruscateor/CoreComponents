using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    [Serializable]
    public class ConcurrentOutputQueueContainer<TType> : BaseConcurrentQueueContainer<TType>, IOutputQueue<TType>
    {

        public ConcurrentOutputQueueContainer(ConcurrentQueue<TType> TheQueue)
            : base(TheQueue)
        {
        }

        public bool TryDequeue(out TType TheItem)
        {

            return myQueue.TryDequeue(out TheItem);

        }

    }

}
