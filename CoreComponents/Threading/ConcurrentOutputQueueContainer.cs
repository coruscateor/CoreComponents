using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    [Serializable]
    public class ConcurrentOutputQueueContainer<TType> : ConcurrentQueueContainer<TType>, IOutputQueue<TType>
    {

        public ConcurrentOutputQueueContainer(ConcurrentQueue<TType> TheQueue)
            : base(TheQueue)
        {
        }

    }

}
