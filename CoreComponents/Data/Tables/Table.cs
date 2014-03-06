using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.Tables
{

    public class Table : IHasName //: IList<IColumn>
    {

        protected List<IColumn> myColumns = new List<IColumn>();

        public Table()
        { 
        }

        public string Name
        {

            get;
            set;

        }

        /*
        public int IndexOf(IColumn item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, IColumn item)
        {
            throw new NotImplementedException();
        }
        */

        public void RemoveAt(int index)
        {

            myColumns.RemoveAt(index);

        }

        /*
        public IColumn this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Add(IColumn item)
        {
            throw new NotImplementedException();
        }
        */

        public void Clear()
        {
            
            myColumns.Clear();

        }

        /*
        public bool Contains(IColumn item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(IColumn[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }
        */

        public int ColumnsCount
        {

            get
            {
                
                return myColumns.Count;
            
            }

        }

        public int RowsCount
        {

            get
            {

                if(myColumns.Count > 0)
                {

                    return myColumns[0].Count;

                }

                return 0;

            }

        }

        public void AddRow()
        {

            if(myColumns.Count > 0)
            {

                foreach(var Item in myColumns)
                {

                    Item.Add();

                }

            }
            else
            {

                throw new Exception("No Columns Exist in Table");

            }

        }

        public void Add(object[] TheValues)
        {

            AddRow();

            int LastIndex = RowsCount - 1;

            if(TheValues.Length > 0)
            {

                foreach(var Item in myColumns)
                {

                    if(Item != null)
                        Item.Insert(LastIndex, Item);

                }

            }

            /*
            int i = 0;

            foreach(var Item in myColumns)
            {

                if(i > myColumns.Count)
                    return;

                if(Item != null)
                {
 


                }

                i++;

            }
            */
            
        }

        public object[] GetRow(int TheIndex)
        {

            if(RowsCount <= TheIndex)
                throw new ArgumentOutOfRangeException();

            if(myColumns.Count > 0)
            {

                object[] RetrievedRow = new object[myColumns.Count];

                int RetrievedRowIndex = 0;

                foreach(var Item in myColumns)
                {

                    if(Item.Count <= TheIndex)
                    {

                        ++RetrievedRowIndex;

                        continue;

                    }

                    RetrievedRow[RetrievedRowIndex] = Item.GetValue(TheIndex);

                }

            }

            return new object[0];

        }

        /*
        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(IColumn item)
        {
            throw new NotImplementedException();
        }
        */

        public IEnumerator<IColumn> GetEnumerator()
        {
            
            return myColumns.GetEnumerator();

        }

        //System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        //{

        //    return myColumns.GetEnumerator();

        //}
        
    }

}
