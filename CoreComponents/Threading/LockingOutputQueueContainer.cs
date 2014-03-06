using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    public class LockingOutputQueueContainer<T> : BaseLockingQueueContainer<T>, IOutputQueue<T>
    {

        public LockingOutputQueueContainer(Queue<T> TheQueue, object TheLockObject)
            : base(TheQueue, TheLockObject)
        {
        }

        public bool TryDequeue(out T TheItem)
        {

            lock (myLockObject)
            {

                if (myQueue.Count > 0)
                {

                    TheItem = myQueue.Dequeue();

                    return true;

                }

                TheItem = default(T);

            }

            return false;

        }

    }

}
