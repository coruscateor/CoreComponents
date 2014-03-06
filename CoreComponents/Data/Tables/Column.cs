using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents;

namespace CoreComponents.Data.Tables
{

    public class Column<T> : IColumn
    {

        List<ReferenceValueContainer<ValueContainer<T>>> myCells = new List<ReferenceValueContainer<ValueContainer<T>>>();

        public Column()
        { 
        }

        public string Name
        {

            get;
            set;

        }

        public Type TypeOfValue
        {

            get
            {

                return typeof(T);

            }

        }

        public int IndexOf(T TheItem)
        {

            if(myCells.Count > 0)
            {

                int i = 0;

                foreach(var Item in myCells)
                {

                    if(Item != null)
                    {

                        if(object.Equals(Item.Value, TheItem))
                            return i;

                    }

                    i++;

                }

            }

            return -1;

        }

        public void Insert(int TheIndex, object TheItem)
        {

            Insert(TheIndex, (T)TheItem);

        }

        public void Insert(int TheIndex, T TheItem)
        {

            if(TheIndex >= myCells.Count)
                throw new IndexOutOfRangeException();

            ReferenceValueContainer<ValueContainer<T>> ItemAtIndex = myCells[TheIndex];

            if(ItemAtIndex.ValueIsNotNull)
                ItemAtIndex.Value.Value = TheItem;
            else
                ItemAtIndex.Value = new ValueContainer<T>(TheItem);

        }

        public void RemoveAt(int TheIndex)
        {

            if(TheIndex >= myCells.Count)
                throw new IndexOutOfRangeException();

            myCells[TheIndex] = null;

        }

        /*
        public T this[int TheIndex]
        {

            get
            {

                ValueContainer<T> Item = myCells[TheIndex].Value;

                if(Item != null)
                    return Item.Value;

                return default(T);

            }
            set
            {

                Insert(TheIndex, value);

            }

        }
        */

        public Type ValueType
        {

            get
            {

                return typeof(T);

            }

        }

        public void Add()
        {

            myCells.Add(new ReferenceValueContainer<ValueContainer<T>>());

        }

        public void Add(T TheItem)
        {

            myCells.Add(new ReferenceValueContainer<ValueContainer<T>>(new ValueContainer<T>(TheItem)));

        }

        public void Add(object TheItem)
        {

            Add((T)TheItem);

        }

        public void Clear()
        {
            
            myCells.Clear();

        }

        public bool Contains(T TheItem)
        {

            if(myCells.Count > 0)
            {

                foreach(var Item in myCells)
                {

                    if(Item != null)
                    {

                        if(object.Equals(Item.Value, TheItem))
                            return true;

                    }

                }

            }

            return false;

        }
        
        public int Count
        {

            get
            {
                
                return myCells.Count;
            
            }

        }

        public ReferenceValueContainer<ValueContainer<T>> this[int TheIndex]
        {

            get
            {

                if(myCells.Count <= TheIndex)
                    throw new IndexOutOfRangeException();

                ReferenceValueContainer<ValueContainer<T>> FoundReferenceContainer = myCells[TheIndex];

                if(FoundReferenceContainer.ValueIsNotNull)
                {

                    return new ReferenceValueContainer<ValueContainer<T>>(new ValueContainer<T>(FoundReferenceContainer.Value.Value));

                }

                return new ReferenceValueContainer<ValueContainer<T>>();

            }

        }

        public object GetValue(int TheIndex)
        {
            
            ReferenceValueContainer<ValueContainer<T>> ValueContainer = myCells[TheIndex];

            if(ValueContainer.ValueIsNotNull)
            {

                return ValueContainer.Value;

            }

            return null;

        }

        public bool Remove(T TheItem)
        {

            if(myCells.Count > 0)
            {

                int i = 0;

                foreach(var Item in myCells)
                {

                    if(Item != null)
                    {

                        if(object.Equals(Item.Value, TheItem))
                        {

                            myCells[i].Value = null;

                        }

                    }

                    i++;

                }

            }

            return true;
        }

        /*
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        */
        
    }

}
