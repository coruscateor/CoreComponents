using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Items
{

    public class GenericTable<T1, T2>
    {

        List<T1> myColumn1 = new List<T1>();

        List<T2> myColumn2 = new List<T2>();

        public GenericTable()
        {
        }

        public virtual void AddRow(T1 TheValue)
        {

            myColumn1.Add(TheValue);

        }

        public virtual int IndexOf(T1 item)
        {

            return myColumn1.IndexOf(item);

        }

        public virtual void InsertRow(int index, T1 item)
        {

            myColumn1.Insert(index, item);

        }

        public virtual void RemoveRowAt(int index)
        {

            myColumn1.RemoveAt(index);

        }

        //public T this[int index]
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

        //public void Add(T item)
        //{
        //    throw new NotImplementedException();
        //}

        public virtual void Clear()
        {

            myColumn1.Clear();

        }

        //public virtual bool Contains(T item)
        //{
        //    throw new NotImplementedException();
        //}

        //public void CopyTo(T[] array, int arrayIndex)
        //{
        //    throw new NotImplementedException();
        //}

        public int Count
        {

            get
            {
                
                return myColumn1.Count;
            
            }

        }

        //public bool IsReadOnly
        //{
        //    get { throw new NotImplementedException(); }
        //}

        public virtual bool RemoveRow(T1 item)
        {

            return myColumn1.Remove(item);

        }

        //public IEnumerator<T> GetEnumerator()
        //{
        //    throw new NotImplementedException();
        //}

        //System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        //{
        //    throw new NotImplementedException();
        //}

    }

}
