using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    public class LockingInputQueueContainer<T> : BaseLockingQueueContainer<T>, IInputQueue<T>
    {

        public LockingInputQueueContainer(Queue<T> TheQueue, object TheLockObject)
            : base(TheQueue, TheLockObject)
        {
        }

        public void Enqueue(T TheItem)
        {

            lock (myLockObject)
            {

                myQueue.Enqueue(TheItem);

            }

        }

    }

}
