using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace CoreComponents.Data
{

    public class ImDataCollection : ICollection<object[]>, IEnumerable<object[]>
    {

        protected object[][] myRows;

        protected int myColumnsCount;

        protected ImDataCollection()
        { 
        }

        public ImDataCollection(IEnumerable<IEnumerable<object>> TheData)
        {

            List<List<object>> Items = new List<List<object>>();

            int LongestSetLength = 0; 

            foreach (var Item in TheData)
            {
                
                List<object> CurrentRow = new List<object>(Item);

                if (CurrentRow.Count > LongestSetLength)
                    LongestSetLength = CurrentRow.Count;

                Items.Add(CurrentRow);

            }

            myRows = new object[Items.Count][];

            for (int i = 0; i < Items.Count; i++)
            {

                var Item = Items[i];

                //if (Item.Count > LongestSetLength)
                //{

                //    int Remainder = Item.Count - LongestSetLength;

                //    for (; Remainder > 0; Remainder--)
                //    {

                //        Item.Add(null);

                //    }

                //}

                myRows[i] = Item.ToArray();

            }

            myColumnsCount = LongestSetLength;

        }

        public ImDataCollection(DataTable TheDataTable)
        {

            myRows = new object[TheDataTable.Rows.Count][];

            for (int i = 0; i < TheDataTable.Rows.Count; i++)
            {

                DataRow Item = TheDataTable.Rows[i];

                myRows[i] = (object[])Item.ItemArray.Clone();

            }

            myColumnsCount = TheDataTable.Rows.Count;

        }

        public ImDataCollection(IDataReader TheDataReader)
        {

            myRows = new object[TheDataReader.FieldCount][];

            object[] Row = null;

            int LongestRowCount = 0;

            for(int i = 0; i < TheDataReader.FieldCount; i++)
            {

                int RowCount = TheDataReader.GetValues(Row);

                if (RowCount > LongestRowCount)
                    LongestRowCount = RowCount;

                myRows[i] = Row;

            }

        }

        public object[] this[int TheRowIndex]
        {

            get
            {

                return (object[])myRows[TheRowIndex].Clone();

            }

        }

        public object this[int TheRowIndex, int TheColumnIndex]
        {

            get
            {

                object[] Row = myRows[TheRowIndex];

                if (TheColumnIndex < Row.Length)
                {

                    return Row[TheColumnIndex];

                }
                else if (TheColumnIndex < myColumnsCount)
                {

                    return null;

                }

                throw new IndexOutOfRangeException("Column index out of range");

            }

        }

        public T GetItem<T>(int TheRowIndex, int TheColumnIndex)
        {

            object Item = this[TheRowIndex, TheColumnIndex];

            if (Item == null)
                return default(T);

            return (T)Item;
 
        }

        public int RowsCount
        {

            get
            {

                return myRows.Length;

            }

        }

        public int ColumnsCount
        {

            get
            {

                return myColumnsCount;

            }

        }

        public void Scan(Func<object, bool> ContinueDelegate)
        {

            foreach (object[] ItemSet in myRows)
            {

                foreach (object Item in ItemSet)
                {

                    if(ContinueDelegate(Item))
                        return;

                }

            }

        }

        public void ScanFromTheEnd(Func<object, bool> ContinueDelegate)
        {

            for (int i = myRows.Length - 1; i > -1; i--)
            {

                object[] ItemSet = myRows[i];

                for (int y = ItemSet.Length - 1; y > -1; y--)
                {

                    object Item = ItemSet[y];

                    if (ContinueDelegate(Item))
                        return;

                }

            }

        }

        public IEnumerator<object[]> GetEnumerator()
        {

            return ((IEnumerator<object[]>)((object[])myRows.Clone()).GetEnumerator());

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {

            return ((object[])myRows.Clone()).GetEnumerator();

        }


        public void Add(object[] item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(object[] item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(object[][] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(object[] item)
        {
            throw new NotImplementedException();
        }
    }

}
