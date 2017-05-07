using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Items
{

    public sealed class ImmutableArray<T> : IEnumerable<T>, IToArray<T>, ICloneable<ImmutableArray<T>>
    {

        readonly T[] myArray;

        public ImmutableArray()
        {

            myArray = new T[0];

        }

        public ImmutableArray(T[] array, bool copy = true)
        {

            if(copy)
            {

                myArray = Copy(array);

            }
            else
            {

                myArray = array;

            }

        }

        public ImmutableArray(IEnumerable<T> items)
        {

            myArray = items.ToArray();

        }

        public ImmutableArray(IList<T> list)
        {

            int listCount = list.Count;

            T[] newArray = new T[listCount];

            for(int i = 0; i < listCount; i++)
                newArray[i] = list[i];

            myArray = newArray;

        }

        static T[] Copy(T[] array)
        {

            int arrayLength = array.Length;

            T[] newArray = new T[arrayLength];

            for(int i = 0; i < arrayLength; i++)
                newArray[i] = array[i];

            return newArray;

        }

        public int Length
        {

            get
            {
                
                return myArray.Length;

            }

        }

        public long LongLength
        {

            get
            {

                return myArray.LongLength;

            }

        }

        public int Rank
        {

            get
            {

                return myArray.Rank;

            }

        }

        public T this[int index]
        {

            get
            {

                return myArray[index];

            }

        }

        public T this[long index]
        {

            get
            {

                return myArray[index];

            }

        }

        public bool Contains(T theItem)
        {

            foreach(var item in myArray)
            {

                if(object.Equals(item, theItem))
                    return true;

            }

            return false;

        }

        public bool Contains(T theItem, Func<T, T, bool> comparator)
        {

            foreach(var item in myArray)
            {

                if(comparator(item, theItem))
                    return true;

            }

            return false;

        }

        public bool Contains(T theItem, IComparer<T> comparator)
        {

            foreach(var item in myArray)
            {

                //Less than zero - x < y

                //Zero - x == y

                //Greater than Zero x > y

                if(comparator.Compare(item, theItem) == 0)
                    return true;

            }

            return false;

        }

        public ImmutableArray<T> Clone()
        {

            return new ImmutableArray<T>(myArray);

        }

        public IEnumerator<T> GetEnumerator()
        {

            foreach(var item in myArray)
                yield return item;

        }

        public T[] ToArray()
        {

            return Copy(myArray);

        }

        object ICloneable.Clone()
        {

            return Clone();

        }

        IEnumerator IEnumerable.GetEnumerator()
        {

            return GetEnumerator();

        }

        object[] IToArray.ToArray()
        {

            var array = myArray;

            int arrayLength = array.Length;

            object[] newArray = new object[arrayLength];

            for(int i = 0; i < arrayLength; i++)
                newArray[i] = array[i];

            return newArray;

        }

    }

}
