using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Concurrent;

namespace CoreComponents.Items
{

    public sealed class SConcurrentQueue<T> : ConcurrentQueue<T>, IProducerConsumerCollection<T>, IEnumerable<T>, IHasCount, ICollection, IEnumerable
    {

        public SConcurrentQueue()
            : base()
        {
        }

        public SConcurrentQueue(IEnumerable<T> collection)
            : base(collection)
        {
        }

        public bool TryDiscard()
        {

            T result;

            return TryDequeue(out result);

        }

        public void TryDiscard(int number)
        {

            while(number > 0)
            {

                if(!TryDiscard())
                    return;

                number--;

            }

        }

        public void TryClear()
        {

            int count = Count;

            T item;

            while(count > 0 && TryDequeue(out item))
                count--;

        }

    }

}
