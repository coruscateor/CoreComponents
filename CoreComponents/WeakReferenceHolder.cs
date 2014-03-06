using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    [Serializable]
    public abstract class WeakReferenceHolder<TItem> : IWeakReferenceHolder
    {

        protected WeakReference myInputQueueReference;

        public WeakReferenceHolder(TItem TheItem) 
        {

            myInputQueueReference = new WeakReference(TheItem);

        }

        public WeakReferenceHolder(WeakReference TheWeakReference)
        {

            myInputQueueReference = TheWeakReference;

        }

        public WeakReferenceHolder(TItem TheItem, WeakReference TheWeakReference)
        {

            myInputQueueReference = TheWeakReference;

            myInputQueueReference.Target = TheItem;

        }

        //True - The InputQueue<T> object reference has been successfully retreived and TheAction has been called. False - The InputQueue<T> object has been collected and TheAction was not called.

        protected bool FetchReferenceAndDo(Action<TItem> TheAction)
        {

            TItem TheInputQueue = (TItem)myInputQueueReference.Target;

            if (TheInputQueue != null)
            {

                TheAction(TheInputQueue);

                return true;

            }

            return false;

        }

        public bool HasReference
        {

            get
            {

                return myInputQueueReference.Target != null;

            }

        }

    }

}
