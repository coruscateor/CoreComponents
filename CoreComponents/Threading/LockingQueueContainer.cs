using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    public class LockingQueueContainer<T> : IInputOutputQueue<T>
    {

        protected object myLockObject;

        protected Queue<T> myQueue;

        public LockingQueueContainer(Queue<T> TheQueue, object TheLockObject)
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

                return myQueue.Count > 0;
            
            }

        }

        public void Enqueue(T item)
        {

            lock (myLockObject)
            {

                myQueue.Enqueue(item);

            }

        }

        public bool TryDequeue(out T item)
        {

            lock (myLockObject)
            {

                if (myQueue.Count > 0)
                {

                    item = myQueue.Dequeue();

                    return true;

                }

                item = default(T);

            }

            return false;

        }

        //public IEnumerator<T> GetEnumerator()
        //{

        //    return myQueue.GetEnumerator();

        //}

        //System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        //{

        //    return myQueue.GetEnumerator();

        //}
        
        public bool PeekType(Type TheType)
        {

            lock (myLockObject)
            {

                if (myQueue.Count > 0)
                {

                    TheType = myQueue.Peek().GetType();

                    return true;

                }

            }

            return false;

        }

        public bool PeekNextType(Action<Type> TheTypeAction)
        {

            lock (myLockObject)
            {

                if (myQueue.Count > 0)
                {

                    TheTypeAction(myQueue.Peek().GetType());

                    return true;

                }

            }

            return false;

        }

        public bool PeekNextIsType<TType>()
        {

            lock (myLockObject)
            {          

                if (myQueue.Count > 0)
                    return typeof(TType) == myQueue.Peek().GetType();

            }

            return false;

        }

        public bool PeekNextIsType(Type TheType)
        {

            lock (myLockObject)
            {

                if (myQueue.Count > 0)
                    return TheType == myQueue.Peek().GetType();

            }

            return false;

        }

    }

}
