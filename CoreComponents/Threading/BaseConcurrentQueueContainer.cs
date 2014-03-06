using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    [Serializable]
    public abstract class BaseConcurrentQueueContainer<TType>
    {

        protected ConcurrentQueue<TType> myQueue;

        public BaseConcurrentQueueContainer(ConcurrentQueue<TType> TheQueue)
        {

            myQueue = TheQueue;

        }

        public int Count
        {

            get
            {

                return myQueue.Count;
                
            }

        }

        //public bool HasItems
        //{

        //    get
        //    {

        //        return myQueue.Count > 0;

        //    }

        //}

        public bool IsEmpty
        {
            get
            {

                return myQueue.IsEmpty;

            }

        }

    }

}
