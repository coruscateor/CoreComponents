using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Items
{

    public class LongList<T> : ILongList<T>, IToArray<T>, ICloneable<LongList<T>>
    {

        protected T[] myItems;

        protected long myFinalIndex = -1;

        public LongList()
        {

            myItems = new T[5];

        }

        public LongList(IEnumerable<T> TheCollection)
        {
            
            myItems = new T[5];

            AddRange(TheCollection);

        }

        public LongList(T[] TheItems)
        {

            myItems = new T[TheItems.LongLength];

            for(long i = 0; i < TheItems.LongLength; ++i)
            {

                myItems[i] = TheItems[i];

            }

        }

        public LongList(ILongList<T> TheItems)
        {

            myItems = new T[TheItems.Count];

            for(long i = 0; i < TheItems.Count; ++i)
            {

                myItems[i] = TheItems[i];

            }

        }

        public LongList(long TheCapacity)
        {

            if(TheCapacity < 1)
                TheCapacity = 5;

            myItems = new T[TheCapacity];

        }

        protected void CheckIndex(long TheIndex)
        {

            if(TheIndex > myFinalIndex && TheIndex < -1)
                throw new ArgumentOutOfRangeException();

        }

        protected void CheckAndExpand()
        {

            if(myItems.Length == myFinalIndex + 1 && myItems.LongLength < long.MaxValue)
            {

                T[] NewItems;

                unchecked
                {

                    NewItems = new T[myItems.LongLength * 2];

                }

                for(long i = 0; i <= myFinalIndex; ++i)
                {

                    NewItems[i] = myItems[i];

                }

                myItems = NewItems;

            }

        }

        protected void CheckExpandAndInsert(long index, T item)
        {

            if(myItems.Length == myFinalIndex + 1 && myItems.LongLength < long.MaxValue)
            {

                ++myFinalIndex;

                T[] NewItems = new T[myItems.LongLength * 2];

                for(long i = 0; i < index; ++i)
                {

                    NewItems[i] = myItems[i];

                }

                myItems[index] = item;

                for(long i = 0; i <= myFinalIndex; ++i)
                {

                    NewItems[i] = myItems[i];

                }

                myItems = NewItems;

            }
            else
            {

                for(long i = myFinalIndex + 1; i > index; ++i)
                {

                    myItems[i + 1] = myItems[i];

                }

                myItems[index] = item;

            }

        }

        protected void Shift(long index, long count)
        {

            long NewSize = myFinalIndex + count + 1;

            if(myItems.Length == NewSize && myItems.LongLength < long.MaxValue)
            {

                long FinalIndex = myFinalIndex + count;

                T[] NewItems = new T[myItems.LongLength * 2];

                for(long i = 0; i < index; ++i)
                {

                    NewItems[i] = myItems[i];

                }

                long OldFinalIndex = myFinalIndex;

                for(; count > 0; --count)
                {

                    NewItems[FinalIndex] = myItems[OldFinalIndex];

                    --FinalIndex;

                    --OldFinalIndex;

                }

                myFinalIndex = FinalIndex;

                myItems = NewItems;

            }
            else
            {

                long FinalIndex = myFinalIndex + count;

                long CurrentFinalIndex = FinalIndex;

                long OldFinalIndex = myFinalIndex;

                for(; count > 0; --count)
                {

                    myItems[FinalIndex] = myItems[OldFinalIndex];

                    --FinalIndex;

                    --OldFinalIndex;

                }

                //for(; index <= CurrentFinalIndex; ++index)
                //{

                //    myItems[index] = default(T);

                //}

                myFinalIndex = FinalIndex;

            }

        }

        public T this[long index]
        {

            get
            {

                CheckIndex(index);

                return myItems[index];

            }
            set
            {

                CheckIndex(index);

                myItems[index] = value;

            }

        }

        public long IndexOf(T item)
        {

            if(myFinalIndex > 0)
            {

                for(long i = 0; i <= myFinalIndex; ++i)
                {

                    if(myItems[i].Equals(item))
                        return i;

                }

            }

            return -1;

        }

        public void Insert(long index, T item)
        {

            CheckIndex(index);

            CheckExpandAndInsert(index, item);

        }

        public void InsertRange(long index, IEnumerable<T> TheValues, long count)
        {

            CheckIndex(index);

            Shift(index, count);

            long FinalIndex = index + count;
            
            foreach(T Item in TheValues)
            {

                myItems[index] = Item;

                ++index;

                if(index == FinalIndex)
                    break;

            }

            if(index < FinalIndex)
            {

                for(; index <= FinalIndex; ++index)
                {

                    myItems[index] = default(T);

                }

            }

        }

        public void InsertRange(long index, T[] item)
        {

            CheckIndex(index);

            Shift(index, item.LongLength);

            long FinalIndex = index + item.LongLength;

            long i = 0;

            for(; index <= FinalIndex; ++index)
            {

                myItems[index] = item[i];

                ++i;

            }

            if(index < FinalIndex)
            {

                for(; index <= FinalIndex; ++index)
                {

                    myItems[index] = default(T);

                }

            }

        }

        public void InsertPadding(long index, long count)
        {

            CheckIndex(index);

            Shift(index, count);

            long FinalIndex = index + count;

            for(; index <= FinalIndex; ++index)
            {

                myItems[index] = default(T);

            }

        }

        public void RemoveAt(long index)
        {

            CheckIndex(index);

            if(myFinalIndex > 0)
            {

                for(; index <= myFinalIndex; ++index)
                {

                    myItems[index] = myItems[index + 1];

                }

            }

            myItems[index] = default(T);

            --myFinalIndex;

        }

        public long Count
        {

            get
            {
                
                return myFinalIndex + 1;
            
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

            CheckAndExpand();

            myItems[++myFinalIndex] = item;

        }

        public void Pad()
        {

            CheckAndExpand();

            myItems[++myFinalIndex] = default(T);

        }

        public void Pad(long count)
        {

            for(; count < 0; --count)
            {

                CheckAndExpand();

                myItems[++myFinalIndex] = default(T);

            }

        }

        public void AddRange(IEnumerable<T> TheCollection)
        {

            IEnumerator<T> TheEnmerator = TheCollection.GetEnumerator();

            if(TheEnmerator.MoveNext())
            {

                for(long i = 0; i < myItems.LongLength; ++i)
                {

                    myItems[i] = TheEnmerator.Current;

                    ++myFinalIndex;

                    if(!TheEnmerator.MoveNext())
                        return;

                }

            }

            do
            {

                CheckAndExpand();

                myItems[++myFinalIndex] = TheEnmerator.Current;

            }
            while(TheEnmerator.MoveNext());

        }

        public void Clear()
        {

            if(myFinalIndex > 0)
            {

                for(long i = 0; i <= myFinalIndex; ++i)
                {

                    myItems[i] = default(T);

                }

                myFinalIndex = -1;

            }

        }

        public bool Contains(T item)
        {

            if(myFinalIndex > 0)
            {

                for(long i = 0; i <= myFinalIndex; ++i)
                {

                    if(myItems[i].Equals(item))
                        return true;

                }

            }

            return false;

        }

        public void CopyTo(T[] array, long arrayIndex)
        {

            if(array == null)
                throw new Exception("The provided array is null");

            if(array.LongLength < 0)
                throw new Exception("The provided array has no length");

            if(arrayIndex < 0)
                throw new Exception("The provided arrayIndex must be greater than one");

            if(array.LongLength <= arrayIndex)
                throw new Exception("arrayIndex is greater than the maximum array index");

            if(myFinalIndex > -1)
            {

                for(long i = 0; i <= myFinalIndex; ++i)
                {

                    array[arrayIndex] = myItems[i];

                    ++arrayIndex;

                }

            }

        }

        public bool Remove(T item)
        {

            long Index = IndexOf(item);

            if(Index > -1)
            {

                RemoveAt(Index);

                return true;

            }

            return false;

        }

        public bool RemoveLast()
        {

            if(myFinalIndex > -1)
            {

                myItems[myFinalIndex] = default(T);

                --myFinalIndex;

                return true;

            }

            return false;

        }

        public IEnumerator<T> GetEnumerator()
        {

            if(myFinalIndex > -1)
            {

                for(long i = 0; i < myFinalIndex + 1; ++i)
                {

                    yield return myItems[i];

                }

            }
            else
            {
 
                yield break;
                
            }

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {

            return GetEnumerator();

        }
        
        public T[] ToArray()
        {

            if(myFinalIndex > 0)
            {

                T[] NewArray = new T[myFinalIndex + 1];

                for(long i = 0; i <= myFinalIndex; ++i)
                {

                    NewArray[i] = myItems[i];

                }

                return NewArray;

            }

            return new T[0];

        }

        public LongList<T> Clone()
        {

            return new LongList<T>(this);

        }

        object ICloneable.Clone()
        {

            return Clone();

        }

    }

}
