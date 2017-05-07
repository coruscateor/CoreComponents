using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Items
{
    /// <summary>
    /// For cycling though items when inserted.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CycleArray<T> : IEnumerable<T>
    {

        protected T[] myItems;

        protected int myCurrentIndex;

        public CycleArray(int length = 0)
        {

            myItems = new T[length];

        }

        public CycleArray(IEnumerable<T> items)
        {

            int length = items.Count();

            myItems = new T[length];

            int current = 0;

            foreach(var item in items)
            {

                myItems[current] = item;

                current++;

            }

        }

        public CycleArray(T[] items)
        {

            int length = items.Length;

            myItems = new T[length];

            for(int i = 0; i < length; i++)
            {

                myItems[length] = items[length];

            }

        }

        public CycleArray(List<T> items)
        {

            int length = items.Count;

            myItems = new T[length];

            for(int i = 0; i < length; i++)
            {

                myItems[length] = items[length];

            }

        }

        public T this[int index]
        {

            get
            {

                return myItems[index];

            }

        }

        public int Count
        {

            get
            {

                return myItems.Length;

            }

        }

        public void Insert(T item)
        {

            myItems[myCurrentIndex] = item;

            int ceiling = myItems.Length - 1;

            if(myCurrentIndex < ceiling)
                myCurrentIndex++;
            else
                myCurrentIndex = 0;

        }

        public void Clear()
        {

            for(int i = 0; i < myItems.Length; i++)
            {

                myItems[i] = default(T);

            }

            myCurrentIndex = 0;

        }

        public bool Contains(T item)
        {

            for(int i = 0; i < myItems.Length; i++)
            {

                //EqualityComparer

                if(object.Equals(myItems[i], item))
                    return true;

            }

            return false;

        }

        public IEnumerator<T> GetEnumerator()
        {

            return (IEnumerator<T>)myItems.GetEnumerator();

        }

        public int IndexOf(T item)
        {

            for(int i = 0; i < myItems.Length; i++)
            {

                //EqualityComparer

                if(object.Equals(myItems[i], item))
                    return i;

            }

            return -1;

        }

        public void Insert(int index, T item)
        {

            myItems[index] = item;

        }

        public void Remove(T item)
        {

            myItems[myCurrentIndex] = default(T);

        }

        public void RemoveAt(int index)
        {

            myItems[index] = default(T);

        }

        public void Resize(int size)
        {

            T[] NewItems = new T[size];

            for(int i = 0; i < NewItems.Length; i++)
            {

                if(i == size)
                    break;

                NewItems[i] = myItems[i];

            }

            myItems = NewItems;

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {

            return myItems.GetEnumerator();

        }

    }

}
