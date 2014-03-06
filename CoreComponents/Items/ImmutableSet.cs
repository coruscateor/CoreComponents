using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Items
{

    public class ImmutableSet<T> : IEnumerable<T>, IToArray<T>, ICloneable<ImmutableSet<T>>
    {

        public T[] myItems; 

        public ImmutableSet()
        {

            myItems = new T[0];

        }

        public ImmutableSet(T[] TheItems)
        {

            if(TheItems.Length > 0)
            {

                TheItems = new T[myItems.LongLength];

                for(long i = 0; i < myItems.LongLength; ++i)
                {

                    myItems[i] = TheItems[i];

                }

            }
            else
            {

                myItems = new T[0];

            }

        }

        public ImmutableSet(IList<T> TheItems)
        {

            if(TheItems.Count > 0)
            {

                myItems = new T[TheItems.Count];

                for(int i = 0; i < TheItems.Count; ++i)
                {

                    myItems[i] = TheItems[i];

                }

            }
            else
            {

                myItems = new T[0];

            }

        }

        public ImmutableSet(ILongList<T> TheItems)
        {

            if(TheItems.Count > 0)
            {

                myItems = new T[TheItems.Count];

                for(long i = 0; i < myItems.LongLength; ++i)
                {

                    myItems[i] = TheItems[i];

                }

            }
            else
            {

                myItems = new T[0];

            }

        }

        public ImmutableSet(IEnumerable<T> TheItems, long TheCount)
        {

            if(TheCount > 0)
            {

                myItems = new T[TheCount];

                long CurrentIndex = 0;

                foreach(T Item in TheItems)
                {

                    myItems[CurrentIndex] = Item;

                    ++CurrentIndex;

                    if(CurrentIndex >= TheCount)
                        break;

                }

            }
            else
            {

                myItems = new T[0];

            }

        }

        public ImmutableSet(ImmutableSet<T> TheItems)
        {

            if(TheItems.Count > 0)
            {

                myItems = new T[TheItems.Count];

                for(long i = 0; i < myItems.LongLength; ++i)
                {

                    myItems[i] = TheItems[i];

                }

            }
            else
            {

                myItems = new T[0];

            }

        }

        public ImmutableSet(ImmutableSet<T> TheItems1, ImmutableSet<T> TheItems2)
        {

            if(TheItems1.Count > 0)
            {

                myItems = new T[TheItems1.Count + TheItems2.Count];

                long Index = 0;

                for(long i = 0; i < TheItems1.Count; ++i)
                {

                    myItems[Index] = TheItems1[i];

                    ++Index;

                }

                if(TheItems2.Count > 0)
                {

                    for(long i = 0; i < TheItems2.Count; ++i)
                    {

                        myItems[Index] = TheItems2[i];

                        ++Index;

                    }

                }

            }
            else
            {

                myItems = new T[0];

            }

        }

        public long Count
        {

            get
            {

                return myItems.LongLength;

            }

        }

        public int Count32
        {

            get
            {

                return myItems.Length;

            }

        }

        public T this[int Index]
        {

            get
            {

                return myItems[Index];

            }

        }

        public T this[long Index]
        {

            get
            {

                return myItems[Index];

            }

        }

        public bool Contains(T TheItem)
        {

            if(myItems.LongLength > 0)
            {
 
                for(long i = 0; i < myItems.LongLength; ++i)
                {

                    if(myItems[i].Equals(TheItem))
                        return true;

                }

            }

            return true;

        }

        public bool Find(Func<T, bool> ThePredicate)
        {

            if(myItems.LongLength > 0)
            {

                foreach(T Item in myItems)
                {

                    if(ThePredicate(Item))
                        return true;

                }

            }

            return false;

        }

        public long IndexOf(T TheItem)
        {

            if(myItems.LongLength > 0)
            {

                for(long i = 0; i < myItems.LongLength; ++i)
                {

                    if(myItems[i].Equals(TheItem))
                        return i;

                }

            }

            return -1;

        }

        public List<T> ToList()
        {

            return new List<T>(myItems);

        }

        public Queue<T> ToQueue()
        {

            return new Queue<T>(myItems);

        }

        public Stack<T> ToStack()
        {

            return new Stack<T>(myItems);

        }

        public LinkedList<T> ToLinkedList()
        {

            return new LinkedList<T>(myItems);

        }

        public static ImmutableSet<T> operator +(ImmutableSet<T> Left, ImmutableSet<T> Right)
        {

            return new ImmutableSet<T>(Left, Right);

        }

        public bool IsEquivalentTo(ImmutableSet<T> TheSet)
        {

            if(TheSet.Count != myItems.LongLength)
                return false;

            for(long i = 0; i < TheSet.Count; ++i)
            {

                if(!TheSet[i].Equals(myItems[i]))
                    return false;

            }

            return true;

        }

        public bool IsEquivalentTo(T[] TheSet)
        {

            if(TheSet.LongLength != myItems.LongLength)
                return false;

            for(long i = 0; i < TheSet.LongLength; ++i)
            {

                if(!TheSet[i].Equals(myItems[i]))
                    return false;

            }

            return true;

        }

        public bool IsEquivalentTo(List<T> TheSet)
        {

            if(TheSet.Count != myItems.LongLength)
                return false;

            for(int i = 0; i < TheSet.Count; ++i)
            {

                if(!TheSet[i].Equals(myItems[i]))
                    return false;

            }

            return true;

        }

        public bool IsEquivalentTo(Queue<T> TheSet)
        {

            if(TheSet.Count != myItems.LongLength)
                return false;

            int i = 0;

            foreach(T Item in TheSet)
            {

                if(!myItems[i].Equals(Item))
                    return false;

                ++i;

            }

            return true;

        }

        public bool IsEquivalentTo(Stack<T> TheSet)
        {

            if(TheSet.Count != myItems.LongLength)
                return false;

            int i = 0;

            foreach(T Item in TheSet)
            {

                if(!myItems[i].Equals(Item))
                    return false;

                ++i;

            }

            return true;

        }

        public bool IsEquivalentTo(LinkedList<T> TheSet)
        {

            if(TheSet.Count != myItems.LongLength)
                return false;

            int i = 0;

            foreach(T Item in TheSet)
            {

                if(!myItems[i].Equals(Item))
                    return false;

                ++i;

            }

            return true;

        }

        public T[] ToArray()
        {

            T[] NewItem;

            if(myItems.Length > 0)
            {

                NewItem = new T[myItems.LongLength];

                for(long i = 0; i < myItems.LongLength; ++i)
                {

                    NewItem[i] = myItems[i];

                }

            }
            else
            {

                NewItem = new T[0];

            }

            return NewItem;

        }

        public IEnumerator<T> GetEnumerator()
        {

            if(myItems.Length > 0)
            {

                for(long i = 0; i < myItems.LongLength; ++i)
                {

                    yield return myItems[i];

                }

            }
            else
            {

                yield break;

            }

        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {

            return myItems.GetEnumerator();

        }

        public ImmutableSet<T> Clone()
        {

            return new ImmutableSet<T>(myItems);

        }

        object ICloneable.Clone()
        {

            return Clone();

        }

    }

}
