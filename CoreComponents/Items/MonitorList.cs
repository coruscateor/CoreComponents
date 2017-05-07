using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Items
{

    public sealed class MonitorList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IHasCount, IToArray<T>, IToArray, IToList<T>
    {

        readonly SList<T> myList;

        public MonitorList()
        {

            myList = new SList<T>();

        }

        public MonitorList(IEnumerable<T> collection)
        {

            myList = new SList<T>(collection);

        }

        public MonitorList(int capacity)
        {

            myList = new SList<T>(capacity);

        }

        public MonitorList(T[] items, bool setCapacity = false)
        {

            myList = new SList<T>(items);

            if(setCapacity)
                myList.Capacity = items.Length;

        }

        public MonitorList(IList<T> items, bool setCapacity = false)
        {

            myList = new SList<T>(items);

            if(setCapacity)
                myList.Capacity = items.Count;

        }

        public T this[int index]
        {
            get
            {
                
                lock(myList)
                {

                    return myList[index];

                }

            }
            set
            {

                lock(myList)
                {

                    myList[index] = value;

                }

            }

        }

        public int Count
        {

            get
            {

                lock(myList)
                {

                    return myList.Count;

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

        public void Add(T item)
        {

            lock(myList)
            {

                myList.Add(item);

            }

        }

        public void Add(T item1, T item2)
        {

            lock(myList)
            {

                myList.Add(item1);

                myList.Add(item2);

            }

        }

        public void Add(T item1, T item2, T item3)
        {

            lock(myList)
            {

                myList.Add(item1);

                myList.Add(item2);

                myList.Add(item3);

            }

        }

        public void Add(T item1, T item2, T item3, T item4)
        {

            lock(myList)
            {

                myList.Add(item1);

                myList.Add(item2);

                myList.Add(item3);

                myList.Add(item4);

            }

        }

        public void Add(params T[] items)
        {

            lock(myList)
            {

                myList.AddRange(items);

            }

        }

        public void AddRange(IEnumerable<T> items)
        {

            lock(myList)
            {

                myList.AddRange(items);

            }

        }

        public void Clear()
        {

            lock(myList)
            {

                myList.Clear();

            }

        }

        public bool Contains(T item)
        {

            lock(myList)
            {

                return myList.Contains(item);

            }

        }

        public void CopyTo(T[] array, int arrayIndex)
        {

            lock(myList)
            {

                myList.CopyTo(array, arrayIndex);

            }

        }

        public IEnumerator<T> GetEnumerator()
        {

            lock(myList)
            {

                return (IEnumerator<T>)myList.ToArray().GetEnumerator();

            }

        }

        public int IndexOf(T item)
        {

            lock(myList)
            {

                return myList.IndexOf(item);

            }

        }

        public void Insert(int index, T item)
        {

            lock(myList)
            {

                myList.Insert(index, item);

            }

        }

        public bool Remove(T item)
        {

            lock(myList)
            {

                return myList.Remove(item);

            }

        }

        public void RemoveAt(int index)
        {

            lock(myList)
            {

                myList.RemoveAt(index);

            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {

            return myList.GetEnumerator();

        }

        public void GoThrough(Action<T> action)
        {

            lock(myList)
            {

                foreach(var item in myList)
                {

                    action(item);

                }

            }

        }

        public T[] ToArray()
        {

            lock(myList)
            {

                return myList.ToArray();

            }

        }

        object[] IToArray.ToArray()
        {

            object[] objs;

            lock(myList)
            {

                objs = new object[myList.Count];

                int i = 0;

                foreach(var item in myList)
                {

                    objs[i] = item;

                    i++;

                }

            }

            return objs;

        }

        public IList<T> ToList()
        {

            lock(myList)
            {

                return new SList<T>(myList);

            }

        }

    }

}
