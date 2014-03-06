using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    public class DirectOutputQueueWatcher<T> : BaseInterThreadStorageWatcher //<IOutputQueue<T>>
    {

        public DirectOutputQueueWatcher()
        {
        }

        public IDirectOutputQueue<T> Assign(IOutputQueue<T> TheOutputQueue)
        {

            myWeakReference = new WeakReference(TheOutputQueue);

            return new DirectOutputQueue<T>(TheOutputQueue, myWeakReference);

        }

        public bool IsWatching(IOutputQueue<T> TheOutputQueue)
        {

            return myWeakReference.Target == TheOutputQueue;

        }

    }

}
