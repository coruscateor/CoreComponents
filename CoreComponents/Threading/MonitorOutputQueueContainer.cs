using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    public class MonitorOutputQueueContainer<T> : BaseMonitorQueueContainer<T>, IOutputQueue<T>
    {

        public MonitorOutputQueueContainer(Queue<T> TheQueue, object TheLockObject)
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
