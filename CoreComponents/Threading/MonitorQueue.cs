using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    [Serializable]
    public class MonitorQueue<T> : IEnumerable<T>, IEnumerable
    {

        protected object myLockObject = new object();

        protected Queue<T> myQueue;

        public MonitorQueue()
        {

            myQueue = new Queue<T>();

        }

        public MonitorQueue(IEnumerable<T> collection)
        {

            myQueue = new Queue<T>(collection);

        }

        public MonitorQueue(int capacity)
        {

            myQueue = new Queue<T>(capacity);

        }
        
        public int Count
        {

            get
            {

                return myQueue.Count;

            }

        }

        public void Clear()
        {

            lock (myLockObject)
            {

                myQueue.Clear();

            }

        }

        public bool Contains(T item)
        {

            lock (myLockObject)
            {

                return myQueue.Contains(item);

            }

        }

        public void CopyTo(T[] array, int arrayIndex)
        {

            lock (myLockObject)
            {

                myQueue.CopyTo(array, arrayIndex);

            }

        }

        public T Dequeue()
        {

            lock (myLockObject)
            {

                return myQueue.Dequeue();

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

        public void Enqueue(T item)
        {

            lock (myLockObject)
            {

                myQueue.Enqueue(item);

            }

        }

        public IEnumerator<T> GetEnumerator()
        {

            return myQueue.GetEnumerator();

        }

        IEnumerator IEnumerable.GetEnumerator()
        {

            return myQueue.GetEnumerator();

        }

        public T Peek()
        {

            lock (myLockObject)
            {

                return myQueue.Peek();

            }

        }

        public bool TryPeek(out T item)
        {

            lock (myLockObject)
            {

                if (myQueue.Count > 0)
                {

                    item = myQueue.Peek();
                    
                    return true;

                }

                item = default(T);

            }

            return false;

        }

        public T[] ToArray()
        {

            lock (myLockObject)
            {

                return myQueue.ToArray();

            }

        }

        public void TrimExcess()
        {

            lock (myLockObject)
            {

                myQueue.TrimExcess();

            }

        }
        
    }

}
