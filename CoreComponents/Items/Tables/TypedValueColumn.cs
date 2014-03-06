using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Items.Tables
{

    public class TypedValueColumn<T> : ITypedColumn<T> where T : struct
    {

        protected string myName;

        protected Type myType;

        protected List<T?> myCells = new List<T?>();

        public TypedValueColumn()
        {

            myType = typeof(T);

        }

        public TypedValueColumn(int TheNumberOfCells)
        {

            myType = typeof(T);

            while(TheNumberOfCells > 0)
            {

                myCells.Add(new Nullable<T>());

                --TheNumberOfCells;

            }

        }

        public TypedValueColumn(string TheName)
        {

            myType = typeof(T);

            myName = TheName;

        }

        public TypedValueColumn(string TheName, int TheNumberOfCells)
        {

            myType = typeof(T);

            myName = TheName;

            while(TheNumberOfCells > 0)
            {

                myCells.Add(new Nullable<T>());

                --TheNumberOfCells;

            }

        }

        public string Name
        {

            get
            {

                return myName;

            }
            set
            {

                myName = value;

            }

        }

        public Type Type
        {

            get
            {

                return myType;

            }

        }

        public bool AddObject(object item)
        {

            if(item is T)
            {

                Add((T)item);

                return true;

            }

            return false;

        }

        public bool RemoveObject(object item)
        {

            if(item is T)
            {

                Remove((T)item);

                return true;

            }

            return false;

        }

        public bool ContainsObject(object item)
        {

            if(item is T)
            {

                Contains((T)item);

                return true;

            }

            return false;

        }

        public bool IndexOfObject(object item, out int index)
        {

            if(item is T)
            {

                index = IndexOf((T)item);

                return true;

            }

            index = -1;

            return false;

        }

        public bool InsertObject(int index, object item)
        {

            if(item is T)
            {

                Insert(index, (T)item);

                return true;

            }

            return false;

        }

        public int IndexOf(T item)
        {
            
            return myCells.IndexOf(new Nullable<T>(item));

        }

        public void Insert(int index, T item)
        {
            
            myCells.Insert(index, new Nullable<T>(item));

        }

        public void RemoveAt(int index)
        {

            myCells.RemoveAt(index);

        }

        public T this[int index]
        {
            get
            {

                return myCells[index].GetValueOrDefault();

            }
            set
            {

                myCells[index] = value;

            }

        }

        public void Add(T item)
        {

            myCells.Add(new Nullable<T>(item));

        }

        public void Clear()
        {

            myCells.Clear();

        }

        public bool Contains(T item)
        {

            return myCells.Contains(item);

        }

        public void CopyTo(T[] array, int arrayIndex)
        {

            T[] NewArray = new T[myCells.Count - arrayIndex];

            int i = 0;

            for(; arrayIndex < myCells.Count; ++arrayIndex)
            {

                NewArray[arrayIndex] = myCells[i].GetValueOrDefault();

                ++arrayIndex;

            }

        }

        public int Count
        {

            get
            {
                
                return myCells.Count;
            
            }

        }

        public bool IsReadOnly
        {

            get
            {
                
                return false;
            
            }

        }

        public bool Remove(T item)
        {

            int index = -1;

            for(int i = 0; i < myCells.Count; ++i)
            {

                Nullable<T> Value = myCells[i];

                if(Value.HasValue)
                {

                    if(Value.Value.Equals(item))
                    {

                        index = i;

                        break;

                    }

                }

            }

            if(index > -1)
            {

                myCells.RemoveAt(index);

                return true;

            }

            return false;

        }

        public CellValue<T> GetValue(int index)
        {

            return new CellValue<T>(myCells[index].GetValueOrDefault());

        }

        public bool TryGetValue(int index, out T Value)
        {

            T? NullableValue = myCells[index];

            Value = NullableValue.GetValueOrDefault();

            return NullableValue.HasValue;

        }

        public IEnumerator<T> GetEnumerator()
        {

            foreach(T? Item in myCells)
            {

                yield return Item.GetValueOrDefault();

            }

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {

            return GetEnumerator();

        }

        public T[] ToArray()
        {

            if(myCells.Count > 0)
            {

                T[] NewArray = new T[myCells.Count];

                for(int i = 0; i < myCells.Count; ++i)
                {

                    NewArray[i] = myCells[i].GetValueOrDefault();

                }

                return NewArray;

            }
            else
            {
 
                return new T[0];

            }

        }

        public T?[] ToNonNullArray()
        {

            return myCells.ToArray();

        }

    }

}
