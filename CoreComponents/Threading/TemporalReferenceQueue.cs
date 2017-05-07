using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public sealed class TemporalReferenceQueue<T> : BaseTemporalReference<T>, ICollection<T>, IEnumerable<T>, IEnumerable
        where T : class
    {

        Queue<CollectionItem<T>> myQueue = new Queue<CollectionItem<T>>();

        public TemporalReferenceQueue()
            : base(false)
        {
        }

        protected override void CheckAndDeReference(object TheState, bool TimedOut)
        {

            if(!TimedOut)
                return;

            lock(myLockObject)
            {

                if(myQueue.Count > 0)
                {

                    int RemoveCount = 0;

                    foreach(var Item in myQueue)
                    {

                        long Result = Item.Time - myTimeOutInterval;

                        if(Result <= 0L)
                            ++RemoveCount;
                        else
                            Item.Time = Result;

                    }

                    while(RemoveCount > 0)
                    {

                        if(IsIDisposable)
                        {

                            var Item = myQueue.Dequeue();

                            Dispose(Item.Value);

                        }
                        else
                            myQueue.Dequeue();

                        --RemoveCount;

                    }

                    if(myQueue.Count < 1)
                        Unregister();

                }
                else
                {

                    Unregister();

                }

            }

        }

        public void Enqueue(T TheItem)
        {

            lock(myLockObject)
            {

                myQueue.Enqueue(new CollectionItem<T>(TheItem, myDefaultTime));

                SetupIfInActive();

            }

        }

        public void Enqueue(T TheItem, long TheTime)
        {

            lock(myLockObject)
            {

                myQueue.Enqueue(new CollectionItem<T>(TheItem, TheTime));

                SetupIfInActive();

            }

        }

        public bool TryDequeue(out T TheItem)
        {

            lock(myLockObject)
            {

                if(myQueue.Count > 0)
                {

                    var Item = myQueue.Dequeue();

                    TheItem = Item.Value;

                    return true;

                }

            }

            TheItem = null;

            return false;

        }

        public bool TryPeek(out T TheItem)
        {

            lock(myLockObject)
            {

                if(myQueue.Count > 0)
                {

                    var Item = myQueue.Peek();

                    TheItem = Item.Value;

                    return true;

                }

            }

            TheItem = null;

            return false;

        }

        public void TrimExcess()
        {

            lock(myLockObject)
            {

                lock(myLockObject)
                {

                    myQueue.TrimExcess();

                }

            }

        }

        public void Add(T item)
        {
            
            Enqueue(item);

        }

        public void Clear()
        {

            lock(myLockObject)
            {

                Unregister();

                foreach(var Item in myQueue)
                {

                    Dispose(Item.Value);

                }

            }

        }

        public bool Contains(T item)
        {

            lock(myLockObject)
            {

                foreach(var ListItem in myQueue)
                {

                    if(object.ReferenceEquals(ListItem.Value, item))
                        return true;

                }

            }

            return false;

        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            
            throw new NotImplementedException();

        }

        public int Count
        {

            get
            {
 
                lock(myLockObject)
                {

                    return myQueue.Count;

                }

            }

        }

        public bool IsReadOnly
        {

            get
            { 
                
                return false;
            
            }

        }

        public bool Remove(T item)
        {

            return false;

        }

        public IEnumerator<T> GetEnumerator()
        {

            lock(myLockObject)
            {

                foreach(var Item in myQueue)
                {

                    yield return Item.Value;

                }

            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {

            return GetEnumerator();

        }

    }

}
