using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    public class DirectReadOnlyStateWatcher<TKey, TValue> : BaseInterThreadStorageWatcher
    {

        public DirectReadOnlyStateWatcher()
        { 
        }

        public IDirectReadOnlyState<TKey, TValue> Assign(IReadOnlyState<TKey, TValue> TheReadOnlyState)
        {

            myWeakReference = new WeakReference(TheReadOnlyState);

            return new DirectReadOnlyState<TKey, TValue>(TheReadOnlyState, myWeakReference);

        }

        public bool IsWatching(IReadOnlyState<TKey, TValue> TheReadOnlyState)
        {

            return myWeakReference.Target == TheReadOnlyState;

        }

    }

}
