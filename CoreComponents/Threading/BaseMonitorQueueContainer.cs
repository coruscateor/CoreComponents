using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    public abstract class BaseMonitorQueueContainer<T> : IItemSet
    {

        protected object myLockObject;

        protected Queue<T> myQueue; //= new Queue<T>();

        public BaseMonitorQueueContainer(Queue<T> TheQueue, object TheLockObject)
        {

            myQueue = TheQueue;

            myLockObject = TheLockObject;

        }

        public int Count
        {

            get
            {

                return myQueue.Count;

            }

        }

        public bool IsEmpty
        {

            get
            {

                return myQueue.Count < 1;

            }

        }


    }

}
