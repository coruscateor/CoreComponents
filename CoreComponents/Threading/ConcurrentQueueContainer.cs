using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    [Serializable]
    public class ConcurrentQueueContainer<T> : IInputOutputQueue<T>
    {

        protected ConcurrentQueue<T> myQueue;

        public ConcurrentQueueContainer(ConcurrentQueue<T> TheQueue)
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

        public bool IsEmpty
        {

            get 
            {
                
                return myQueue.IsEmpty;
            
            }

        }

        public void Enqueue(T TheItem)
        {

            myQueue.Enqueue(TheItem);

        }

        //public IEnumerator<T> GetEnumerator()
        //{

        //    return myQueue.GetEnumerator();

        //}

        //System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        //{

        //    return myQueue.GetEnumerator();

        //}

        public bool TryDequeue(out T TheItem)
        {

            return myQueue.TryDequeue(out TheItem);

        }
        
        public bool PeekType(out Type TheType)
        {

            T Result;

            if (myQueue.TryPeek(out Result))
            {

                TheType = Result.GetType();

                return true;

            }

            TheType = null;

            return false;

        }

        public bool PeekNextType(Action<Type> TheTypeAction)
        {

            T Result;

            if(myQueue.TryPeek(out Result))
            {

                TheTypeAction(Result.GetType());

                return true;

            }

            return false;

        }

        public bool PeekNextIsType<TType>()
        {

            T Result;

            if(myQueue.TryPeek(out Result))
                return typeof(TType) == Result.GetType();

            return false;

        }

        public bool PeekNextIsType(Type TheType)
        {

            T Result;

            if(myQueue.TryPeek(out Result))
                return TheType == Result.GetType();

            return false;

        }
        
    }

}
