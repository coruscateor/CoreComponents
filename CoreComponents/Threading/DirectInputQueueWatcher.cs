using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    public class DirectInputQueueWatcher<T> : BaseInterThreadStorageWatcher
    {

        public DirectInputQueueWatcher()
        {
        }

        public IDirectInputQueue<T> Assign(IInputQueue<T> TheOutputQueue)
        {

            myWeakReference = new WeakReference(TheOutputQueue);

            return new DirectInputQueue<T>(TheOutputQueue, myWeakReference);

        }

        public bool IsWatching(IInputQueue<T> TheInputQueue)
        {

            return myWeakReference.Target == TheInputQueue;

        }

    }

}
