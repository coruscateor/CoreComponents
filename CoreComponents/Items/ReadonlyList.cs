using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Items
{

    public class ReadonlyList<T> : IToArray<T>, ICloneable<ReadonlyList<T>>, IEnumerable<T>
    {

        protected T[] myItems;

        public ReadonlyList(T[] TheItems)
        {

            long LongLength = TheItems.LongLength;

            myItems = new T[LongLength];

            for(long i = 0; i < LongLength; ++i)
            {

                myItems[i] = TheItems[i];

            }

        }

        public ReadonlyList(List<T> TheItems)
        {

            int Count = TheItems.Count;

            myItems = new T[Count];

            for(int i = 0; i < Count; ++i)
            {

                myItems[i] = TheItems[i];

            }

        }

        public ReadonlyList(ReadonlyList<T> TheItems)
        {

            long LongCount = TheItems.LongCount;

            myItems = new T[LongCount];

            for(long i = 0; i < LongCount; ++i)
            {

                myItems[i] = TheItems[i];

            }

        }

        public ReadonlyList(IEnumerable<T> TheItems)
        {

            T[] ExtractedItems = new T[long.MaxValue];

            long i = 0L;

            foreach(var Item in TheItems)
            {

                ExtractedItems[i] = Item;

                ++i;

            }

            if(i < ExtractedItems.LongLength)
            {

                T[] myItems = new T[i];

                for(long y = 0; i < LongCount; ++y)
                {

                    myItems[y] = ExtractedItems[y];

                }

            }
            else
            {

                myItems = ExtractedItems;

            }

        }

        public T this[int TheIndex]
        {

            get
            {

                return myItems[TheIndex];

            }

        }

        public T this[long TheIndex]
        {

            get
            {

                return myItems[TheIndex];

            }

        }

        public int Count
        {

            get
            {

                return myItems.Length;

            }

        }

        public long LongCount
        {

            get
            {

                return myItems.LongLength;

            }

        }


        public IEnumerator<T> GetEnumerator()
        {

            for(long i = 0; i < myItems.LongLength; ++i)
            {

                yield return myItems[i];

            } 

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {

            return GetEnumerator();

        }

        public T[] ToArray()
        {

            long LongLength = myItems.LongLength;

            T[] NewItems = new T[LongLength];

            for(long i = 0; i < LongLength; ++i)
            {

                NewItems[i] = myItems[i];

            }

            return NewItems;

        }

        ReadonlyList<T> ICloneable<ReadonlyList<T>>.Clone()
        {

            return new ReadonlyList<T>(this);

        }

        object ICloneable.Clone()
        {

            return new ReadonlyList<T>(this);

        }

    }

}
