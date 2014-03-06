using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Items.Tables
{

    public class TypedReferenceColumn<T> : ITypedColumn<T> where T : class
    {

        protected string myName;

        protected Type myType;

        protected List<T> myCells = new List<T>();

        public TypedReferenceColumn()
        {

            myType = typeof(T);

        }

        public TypedReferenceColumn(int TheNumberOfCells)
        {

            myType = typeof(T);

            while(TheNumberOfCells > 0)
            {

                myCells.Add(null);

                --TheNumberOfCells;

            }

        }

        public TypedReferenceColumn(string TheName)
        {

            myType = typeof(T);

            myName = TheName;

        }

        public TypedReferenceColumn(string TheName, int TheNumberOfCells)
        {

            myType = typeof(T);

            myName = TheName;

            while(TheNumberOfCells > 0)
            {

                myCells.Add(null);

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

        public int IndexOf(T item)
        {

            return myCells.IndexOf(item);

        }

        public void Insert(int index, T item)
        {

            myCells.Insert(index, item);

        }

        public void RemoveAt(int index)
        {

            myCells.RemoveAt(index);

        }

        public T this[int index]
        {

            get
            {

                return myCells[index];

            }
            set
            {

                myCells[index] = value;

            }

        }

        public void Add(T item)
        {

            myCells.Add(item);

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

            myCells.CopyTo(array, arrayIndex);

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

            return myCells.Remove(item);

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

        public CellValue<T> GetValue(int index)
        {

            T ValueAtIndex = myCells[index];

            if(ValueAtIndex != null)
            {

                return new CellValue<T>(ValueAtIndex);

            }

            return new CellValue<T>();

        }

        public bool TryGetValue(int index, out T Value)
        {

            if(index < myCells.Count)
            {

                Value = myCells[index];

                return true;

            }

            Value = default(T);

            return false;

        }

        public T[] ToArray()
        {
            
            return myCells.ToArray();

        }

        public IEnumerator<T> GetEnumerator()
        {

            return myCells.GetEnumerator();

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {

            return myCells.GetEnumerator();

        }

        //public T[] ToArray()
        //{

        //    return myCells.ToArray();

        //}

        //public int Add(object value)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool Contains(object value)
        //{
        //    throw new NotImplementedException();
        //}

        //public int IndexOf(object value)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Insert(int index, object value)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool IsFixedSize
        //{
        //    get { throw new NotImplementedException(); }
        //}

        //public void Remove(object value)
        //{
        //    throw new NotImplementedException();
        //}

        //object System.Collections.IList.this[int index]
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }
        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public void CopyTo(Array array, int index)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool IsSynchronized
        //{

        //    get
        //    {
                
        //        return false;
            
        //    }

        //}

        //[NotSupported]
        //public object SyncRoot
        //{

        //    [NotSupported]
        //    get
        //    {
                
        //        throw new NotSupportedException();
            
        //    }

        //}

    }

}
