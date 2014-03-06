using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    public class DirectOutputQueue<T> : WeakReferenceHolder<IOutputQueue<T>>, IDirectOutputQueue<T>
    {

        public DirectOutputQueue(IOutputQueue<T> TheOutputQueue)
            : base(TheOutputQueue)
        {
        }

        public DirectOutputQueue(IOutputQueue<T> TheOutputQueue, WeakReference TheWeakReference)
            : base(TheOutputQueue, TheWeakReference)
        {
        }

        public bool TryDequeue(ref T TheItem)
        {

            bool Dequeued = false;

            T Item = default(T);

            bool Fetched = FetchReferenceAndDo((IOutputQueue<T> TheOutputQueue) =>
            {

                Dequeued = TheOutputQueue.TryDequeue(out Item);

            });

            if (Fetched && Dequeued)
            {

                TheItem = Item;

                return true;

            }

            return false;

        }
        
        public bool GetCount(ref int TheCount)
        {

            int Count;

            if (FetchReferenceAndDo((IOutputQueue<T> TheOutputQueue) => { Count = TheOutputQueue.Count; }))
            {

                Count = TheCount;

                return true;

            }

            return false;

        }

        public bool IsEmpty(ref bool IsEmpty)
        {

            bool IsEmptyLocal = false;

            if (FetchReferenceAndDo((IOutputQueue<T> TheOutputQueue) => { IsEmptyLocal = TheOutputQueue.IsEmpty; }))
            {

                IsEmpty = IsEmptyLocal;

                return true;

            }

            return false;

        }

    }

}
