using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Concurrent;

namespace CoreComponents.Items
{

    public sealed class ConcurrentQueueNew<T> : ConcurrentQueue<T>, IProducerConsumerCollection<T>, IEnumerable<T>, IHasCount, ICollection, IEnumerable
        where T : new()
    {

        public ConcurrentQueueNew()
            : base()
        {
        }

        public ConcurrentQueueNew(IEnumerable<T> collection)
            : base(collection)
        {
        }

        public T TryDequeue()
        {

            T result;

            if(TryDequeue(out result))
                return result;

            return new T();

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
