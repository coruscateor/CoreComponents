using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public class MonitorList<T> : IList<T>, IToArray<T>
    {

        protected List<T> myList;

        protected object myLockingObject = new object();

        public MonitorList()
        {

            myList = new List<T>();

        }

        public MonitorList(IEnumerable<T> TheItems)
        {

            myList = new List<T>(TheItems);

        }

        public MonitorList(int TheCapacity)
        {

            myList = new List<T>(TheCapacity);

        }

        public MonitorList(T[] TheItems, bool SetCapacity)
        {

            myList = new List<T>(TheItems);

            if(SetCapacity)
                myList.Capacity = TheItems.Length;

        }

        public MonitorList(IList<T> TheItems, bool SetCapacity)
        {

            myList = new List<T>(TheItems);

            if(SetCapacity)
                myList.Capacity = TheItems.Count;

        }

        public int IndexOf(T item)
        {

            lock(myLockingObject)
            {

                return myList.IndexOf(item);

            }

        }

        public void Insert(int index, T item)
        {

            lock(myLockingObject)
            {

                myList.Insert(index, item);

            }

        }

        public void RemoveAt(int index)
        {

            lock(myLockingObject)
            {

                myList.RemoveAt(index);

            }

        }

        public T this[int index]
        {
            get
            {

                lock(myLockingObject)
                {

                    return myList[index];

                }

            }
            set
            {

                lock(myLockingObject)
                {

                    myList[index] = value;

                }

            }

        }

        public void Add(T item)
        {

            lock(myLockingObject)
            {

                myList.Add(item);

            }

        }

        public void AddRange(IEnumerable<T> TheItems)
        {

            lock(myLockingObject)
            {

                myList.AddRange(TheItems);

            }

        }

        public void Clear()
        {

            lock(myLockingObject)
            {

                myList.Clear();

            }

        }

        public bool Contains(T item)
        {

            lock(myLockingObject)
            {

                return myList.Contains(item);

            }

        }

        public void CopyTo(T[] array, int arrayIndex)
        {

            lock(myLockingObject)
            {

                myList.CopyTo(array, arrayIndex);

            }

        }

        public int Count
        {

            get
            {
                
                lock(myLockingObject)
                {

                    return myList.Count;

                }

            }

        }

        public bool IsEmpty
        {

            get
            {

                lock(myLockingObject)
                {

                    return myList.Count < 1;

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

            lock(myLockingObject)
            {

                return myList.Remove(item);

            }

        }

        public int RemoveAll(Predicate<T> ThePredicate)
        {

            lock(myLockingObject)
            {

                return myList.RemoveAll(ThePredicate);

            }

        }

        public void RemoveRange(int TheIndex, int TheCount)
        {

            lock(myLockingObject)
            {

                myList.RemoveRange(TheIndex, TheCount);

            }

        }

        public T[] ToArray()
        {

            lock(myLockingObject)
            {

                return myList.ToArray();

            }

        }

        public IEnumerator<T> GetEnumerator()
        {

            //lock(myLockingObject)
            //{

            //    for(int i = 0; i < myList.Count; ++i)
            //    {

            //        yield return myList[i];

            //    }

            //}

            //A less naive implentation

            try
            {

                Monitor.Enter(myLockingObject);

                for(int i = 0; i < myList.Count; ++i)
                {

                    T Item = myList[i];

                    Monitor.Exit(myLockingObject);

                    yield return Item;

                    Monitor.Enter(myLockingObject);

                }

            }
            finally
            {

                Monitor.Exit(myLockingObject);

            }

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {

            return GetEnumerator();

        }

        //true canceled partway though, false went right through to the end.

        //public bool Enumerate(Func<T, bool> TheEnumerationFunc)
        //{

        //    lock(myLockingObject)
        //    {

        //        foreach(var Item in myList)
        //        {

        //            if(TheEnumerationFunc(Item))
        //                return true;

        //        }

        //        return false;

        //    }

        //}

        //public int Enumerate(Func<T, int, bool> TheEnumerationFunc)
        //{

        //    lock(myLockingObject)
        //    {

        //        int i = -1;

        //        foreach(var Item in myList)
        //        {

        //            ++i;

        //            if(TheEnumerationFunc(Item, i))
        //                return i;

        //        }
                
        //        return i;

        //    }

        //}

    }

}
