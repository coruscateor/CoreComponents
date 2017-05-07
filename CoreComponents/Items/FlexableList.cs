using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Items
{

    /// <summary>
    /// A list that pads when needed and does not throw.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class FlexableList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IHasCount, IEnumerable
    {

        readonly SList<T> myList;

        public FlexableList()
        {

            myList = new SList<T>();

        }

        public FlexableList(int capacity)
        {

            myList = new SList<T>(capacity);

        }

        public FlexableList(IEnumerable<T> collection)
        {

            myList = new SList<T>(collection);

        }

        void TryPad(int index)
        {

            int lastIndex = myList.Count - 1;

            while(index > lastIndex)
            {

                Add(default(T));

            }

        }

        public bool IsOutOfRange(int index)
        {

            return index < 0 || index >= myList.Count;

        }

        public bool TryGet(int index, out T item)
        {

            if(index > -1 && index < myList.Count)
            {

                item = myList[index];

                return true;

            }
            else if(index < 0)
            {

                int fromEnd = myList.Count + index;

                if(fromEnd > 0 || fromEnd < myList.Count)
                {

                    item = myList[fromEnd];

                    return true;

                }

                item = default(T);

            }

            item = default(T);

            return false;

        }

        public void TrimExcess()
        {

            myList.TrimExcess();

        }

        public int Count
        {

            get
            {

                return myList.Count;

            }

        }

        public bool IsReadOnly
        {

            get
            {

                return false;

            }

        }

        public T this[int index]
        {

            get
            {

                if(index >= myList.Count)
                    return default(T);
                else if(index < 0)
                {

                    int fromEnd = myList.Count + index;

                    if(fromEnd > 0 || fromEnd < myList.Count)
                        return myList[fromEnd];

                    return default(T);

                }

                return myList[index];

            }
            set
            {

                TryPad(index);

                myList[index] = value;

            }

        }

        public int IndexOf(T item)
        {

            return myList.IndexOf(item);

        }

        public void Insert(int index, T item)
        {

            if(index < 1)
                return;

            TryPad(index);

            myList.Insert(index, item);

        }

        public void RemoveAt(int index)
        {

            if(IsOutOfRange(index))
                return;

            myList.RemoveAt(index);

        }

        public void Add(T item)
        {

            myList.Add(item);

        }

        public void AddRange(IEnumerable<T> items)
        {

            myList.AddRange(items);

        }

        public void Clear()
        {

            myList.Clear();

        }

        public bool Contains(T item)
        {

            return myList.Contains(item);

        }

        public void CopyTo(T[] array, int arrayIndex)
        {

            myList.CopyTo(array, arrayIndex);

        }

        public bool Remove(T item)
        {

            return myList.Remove(item);

        }

        public IEnumerator<T> GetEnumerator()
        {

            return myList.GetEnumerator();

        }

        IEnumerator IEnumerable.GetEnumerator()
        {

            return myList.GetEnumerator();

        }

    }

}
