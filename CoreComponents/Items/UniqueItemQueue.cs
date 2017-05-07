using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Items
{

    public sealed class UniqueItemQueue<T> : IEnumerable<T>, IEnumerable, IToArray<T>
    {

        readonly SQueue<T> myQueue;

        public UniqueItemQueue()
        {

            myQueue = new SQueue<T>();

        }

        public UniqueItemQueue(IEnumerable<T> collection)
        {

            myQueue = new SQueue<T>(collection);

            //myQueue = new SQueue<T>(collection.Count());

            foreach(var item in collection)
            {

                if(!myQueue.Contains(item))
                    myQueue.Enqueue(item);

            }

        }

        public UniqueItemQueue(int capacity)
        {

            myQueue = new SQueue<T>(capacity);

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

        public bool TryEnqueue(T item)
        {

            if(!myQueue.Contains(item))
            {

                myQueue.Enqueue(item);

                return true;

            }

            return false;

        }

        public bool TryPeek(out T item)
        {

            if(!IsEmpty)
            {

                item = myQueue.Peek();

                return true;

            }

            item = default(T);

            return true;

        }

        public bool TryDequeue(out T item)
        {

            if(!IsEmpty)
            {

                item = myQueue.Dequeue();

                return true;

            }

            item = default(T);

            return true;

        }

        public bool Contains(T item)
        {

            return myQueue.Contains(item);

        }

        public void Clear()
        {

            myQueue.Clear();

        }

        public void TrimExcess()
        {

            myQueue.TrimExcess();

        }

        public IEnumerator<T> GetEnumerator()
        {

            return myQueue.GetEnumerator();

        }

        IEnumerator IEnumerable.GetEnumerator()
        {

            return myQueue.GetEnumerator();

        }

        public ImmutableArray<T> ToImmutableArray()
        {

            return new ImmutableArray<T>(myQueue);

        }

        public T[] ToArray()
        {

            return myQueue.ToArray();

        }

        object[] IToArray.ToArray()
        {

            int count = myQueue.Count;

            object[] objs = new object[count];

            int i = 0;

            foreach(var item in myQueue)
            {

                objs[i] = item;

                i++;

            }

            return objs;

        }

    }

}
