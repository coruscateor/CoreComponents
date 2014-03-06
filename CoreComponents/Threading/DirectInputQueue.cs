using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    [Serializable]
    public class DirectInputQueue<T> : WeakReferenceHolder<IInputQueue<T>>, IDirectInputQueue<T>
    {

        public DirectInputQueue(IInputQueue<T> TheInputQueue) : base (TheInputQueue)
        {
        }

        public DirectInputQueue(IInputQueue<T> TheInputQueue, WeakReference TheWeakReference)
            : base(TheInputQueue, TheWeakReference)
        {
        }

        public bool Enqueue(T TheItem)
        {

            return FetchReferenceAndDo((IInputQueue<T> TheInputQueue) => { TheInputQueue.Enqueue(TheItem); });

        }

        public bool GetCount(ref int TheCount)
        {

            int Count;

            if (FetchReferenceAndDo((IInputQueue<T> TheInputQueue) => { Count = TheInputQueue.Count; }))
            {

                Count = TheCount;

                return true;

            }

            return false;

        }

        public bool IsEmpty(ref bool IsEmpty)
        {

            bool IsEmptyLocal = false;

            if (FetchReferenceAndDo((IInputQueue<T> TheInputQueue) => { IsEmptyLocal = TheInputQueue.IsEmpty; }))
            {

                IsEmpty = IsEmptyLocal;

                return true;

            }

            return false;

        }

    }

}
