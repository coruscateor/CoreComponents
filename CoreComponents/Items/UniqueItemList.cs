using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Items
{

    public sealed class UniqueItemList<T> : IEnumerable<T>, IEnumerable, IToArray<T>
    {

        readonly SList<T> myList;

        public UniqueItemList()
        {

            myList = new SList<T>();

        }

        public UniqueItemList(int capacity)
        {

            myList = new SList<T>(capacity);

        }

        public UniqueItemList(IEnumerable<T> collection)
        {

            myList = new SList<T>();

            //myList = new SList<T>(collection.Count());

            foreach(var item in collection)
            {

                if(!myList.Contains(item))
                    myList.Add(item);

            }

        }

        public T this[int index]
        {

            get
            {

                return myList[index];

            }
            set
            {

                if(!myList.Contains(value))
                {

                    myList[index] = value;

                    return;

                }

                throw new Exception("Duplicate item");

            }

        }

        public int Count
        {

            get
            {

                return myList.Count;

            }

        }

        //public bool IsReadOnly
        //{

        //    get
        //    {

        //        return false;

        //    }

        //}

        public bool TryAdd(T item)
        {

            if(myList.Contains(item))
                return false;

            myList.Add(item);

            return false;
            
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

        public IEnumerator<T> GetEnumerator()
        {

            return myList.GetEnumerator();

        }

        public int IndexOf(T item)
        {

            return myList.IndexOf(item);

        }

        //public void Insert(int index, T item)
        //{

        //    if(!myList.Contains(item))
        //    {

        //        myList[index] = item;

        //        return;

        //    }

        //    throw new Exception("Duplicate item");

        //}

        public bool TryInsert(int index, T item)
        {

            if(!myList.Contains(item))
            {

                myList[index] = item;

                return true;

            }

            return false;

        }

        public bool Remove(T item)
        {

            return myList.Remove(item);

        }

        public void RemoveAt(int index)
        {

             myList.RemoveAt(index);

        }

        IEnumerator IEnumerable.GetEnumerator()
        {

            return myList.GetEnumerator();

        }

        //public UniqueItemList(int capacity)
        //{

        //    myList = new SList<T>(capacity);

        //}

        public ImmutableArray<T> ToImmutableArray()
        {

            return new ImmutableArray<T>(myList);

        }

        public void TrimExcess()
        {

            myList.TrimExcess();

        }

        public T[] ToArray()
        {

            return myList.ToArray();

        }

        object[] IToArray.ToArray()
        {

            int count = myList.Count;

            object[] objs = new object[count];

            for(int i = 0; i < count; i++)
            {

                objs[i] = myList[i];

            }

            return objs;

        }

    }

}
