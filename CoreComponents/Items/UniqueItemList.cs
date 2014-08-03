using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Items
{

    public class UniqueItemList<T> : IUniqueItemList<T>, IListSource<T>, IToArray<T>, IEnumerable<T>
    {

        protected List<T> myItems;

        public UniqueItemList()
        {

            myItems = new List<T>();

        }

        public UniqueItemList(IEnumerable<T> TheItems)
        {

            myItems = new List<T>();

            foreach(var Item in TheItems)
            {

                if(!myItems.Contains(Item))
                    myItems.Add(Item);

            }

        }

        public int IndexOf(T item)
        {

            return myItems.IndexOf(item);

        }


        public void Insert(int index, T item)
        {

            if(!myItems.Contains(item))
            {

                myItems.Insert(index, item);

                return;

            }

            throw new ItemIsAlreadyPresentException<T>(item);

        }

        public bool TryInsert(int index, T item)
        {

            if(!myItems.Contains(item))
            {

                myItems.Insert(index, item);

                return true;

            }

            return false;

        }

        public void RemoveAt(int index)
        {

            myItems.RemoveAt(index);

        }

        public T this[int index]
        {
            get
            {

                return myItems[index];

            }
            set
            {

                if(!myItems.Contains(value))
                    myItems[index] = value;
                else
                    throw new Exception("Value already exists");

            }

        }

        public bool TryGet(int TheIndex, out T TheItem)
        {

            if(myItems.Count > 0)
            {

                if(TheIndex > -1)
                {

                    if(myItems.Count < TheIndex)
                    {

                        TheItem = myItems[TheIndex];

                        return true;

                    }

                }

            }

            TheItem = default(T);

            return false;

        }

        public bool TrySet(int TheIndex, T TheItem)
        {

            if(myItems.Count > 0)
            {

                if(TheIndex > -1)
                {

                    if(myItems.Count < TheIndex)
                    {

                        myItems[TheIndex] = TheItem;

                        return true;

                    }

                }

            }

            return false;

        }

        public void Add(T item)
        {

            if(!myItems.Contains(item))
            {

                myItems.Add(item);

                return;

            }

            throw new ItemIsAlreadyPresentException<T>(item);
            
        }

        public bool TryAdd(T item)
        {

            if(!myItems.Contains(item))
            {

                myItems.Add(item);

                return true;

            }

            return false;

        }

        public void AddRange(IEnumerable<T> TheItems)
        {

            foreach(var Item in TheItems)
            {

                if(!myItems.Contains(Item))
                {

                    myItems.Add(Item);

                }

            }

        }

        public void Clear()
        {

            myItems.Clear();

        }

        public bool Contains(T item)
        {

            return myItems.Contains(item);

        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            
            myItems.CopyTo(array, arrayIndex);

        }

        public int Count
        {

            get
            {
                
                return myItems.Count;
            
            }

        }

        public bool IsReadOnly
        {

            get
            {
                
                return false;
            
            }

        }

        public int MoveUp(T TheItem)
        {

            int Index = myItems.IndexOf(TheItem);

            if(Index < 1)
                return -1;

            if(Index > 0)
            {

                --Index;

                myItems.Remove(TheItem);

                myItems.Insert(Index, TheItem);

            }

            return Index;

        }

        public int MoveDown(T TheItem)
        {

            int Index = myItems.IndexOf(TheItem);

            if(Index < 1)
                return -1;

            int LastIndex = myItems.Count - 1;

            if(Index < myItems.Count)
            {

                ++Index;

                myItems.Remove(TheItem);

                --LastIndex;

                if(Index >= LastIndex)
                {

                    myItems.Add(TheItem);

                }
                else
                {

                    myItems.Insert(Index, TheItem);

                }

            }

            return Index;

        }

        public bool Remove(T item)
        {

            return myItems.Remove(item);

        }

        public IEnumerator<T> GetEnumerator()
        {
            
            return myItems.GetEnumerator();

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {

            return myItems.GetEnumerator();

        }
        
        public List<T> ToList()
        {

            return new List<T>(myItems);

        }

        public T[] ToArray()
        {

            return myItems.ToArray();

        }

    }

}
