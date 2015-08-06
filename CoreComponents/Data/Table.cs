using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Data
{

    public class Table
    {

        protected string myName;

        protected List<Column> myColumnMeta = new List<Column>();

        protected List<List<object>> myRows = new List<List<object>>();

        protected ColumnsList myColumnsList;

        protected RowsList myRowsList;

        public Table()
        {

            Initialise();

        }

        public Table(string TheName)
        {

            myName = TheName;

            Initialise();

        }

        protected void Initialise()
        {

            myColumnsList = new ColumnsList(myColumnMeta, myRows);

            myRowsList = new RowsList(myColumnMeta, myRows);

        }

        public string Name
        {

            get
            {

                return myName;

            }

        }

        public int ColumnsCount
        {

            get
            {

                return myColumnMeta.Count;

            }

        }

        public int RowsCount
        {

            get
            {

                return myRows.Count;

            }

        }

        public bool Add(Column TheColumn)
        {

            if(myColumnMeta.Contains(TheColumn))
                return false;

            myColumnMeta.Add(TheColumn);

            foreach(var Row in myRows)
            {

                Row.Add(null);

            }

            return true;

        }

        public bool Remove(Column TheColumn)
        {

            return myColumnMeta.Remove(TheColumn);

        }

        public void RemoveColumnAt(int TheColumnIndex)
        {

            myColumnMeta.RemoveAt(TheColumnIndex);

        }

        public bool Add(params object[] TheRowData)
        {

            return Add(TheRowData);

        }

        public bool Add(IEnumerable<object> TheRowData)
        {

            List<object> Items = new List<object>(TheRowData);

            for(int i = 0; i < myColumnMeta.Count; ++i)
            {

                if(i == myColumnMeta.Count || i == Items.Count)
                    break;

                object Item = Items[i];

                if(Item != null)
                {

                    Column ColumnItem = myColumnMeta[i];

                    if(ColumnItem.Type != Item.GetType())
                    {

                        Items[i] = Convert.ChangeType(Item, ColumnItem.Type);

                    }

                }

            }

            if(Items.Count < myColumnMeta.Count)
            {

                for(int i = Items.Count - 1; i < myColumnMeta.Count; ++i)
                {

                    Items.Add(null);

                }

            }
            else if(Items.Count > myColumnMeta.Count)
            {

                int Count = Items.Count - myColumnMeta.Count;

                Items.RemoveRange(Items.Count - Count - 1, Count);

            }

            return true;

        }

        public bool RemoveLastRow()
        {

            if(myRows.Count > 0)
            {

                myRows.RemoveAt(myRows.Count - 1);

                return true;

            }

            return false;

        }

        public class ColumnsList : IList<Column>
        {

            protected List<Column> myColumnMeta = new List<Column>();

            protected List<List<object>> myRows = new List<List<object>>();

            public ColumnsList(List<Column> TheColumnMeta, List<List<object>> TheRows)
            {

                myColumnMeta = TheColumnMeta;

                myRows = TheRows;

            }

            public int IndexOf(Column item)
            {

                return myColumnMeta.IndexOf(item);

            }

            public void Insert(int index, Column item)
            {

                myColumnMeta.Insert(index, item);

                foreach(var Item in myRows)
                {

                    Item.Insert(index, null);

                }

            }

            public void RemoveAt(int index)
            {

                myColumnMeta.RemoveAt(index);

                foreach(var Item in myRows)
                {

                    Item.RemoveAt(index);

                }

            }

            public Column this[int index]
            {

                get
                {

                    return myColumnMeta[index];

                }
                set
                {

                    myColumnMeta[index] = value;

                }

            }

            public void Add(Column item)
            {

                if(!myColumnMeta.Contains(item))
                {

                    myColumnMeta.Add(item);

                    foreach(var Item in myRows)
                    {

                        Item.Add(null);

                    }

                }

            }

            public void Clear()
            {

                myColumnMeta.Clear();

                myRows.Clear();

            }

            public bool Contains(Column item)
            {
                
                return myColumnMeta.Contains(item);

            }

            public void CopyTo(Column[] array, int arrayIndex)
            {

                myColumnMeta.CopyTo(array, arrayIndex);
                
            }

            public int Count
            {

                get
                {
                    
                    return myColumnMeta.Count;
                
                }

            }

            public bool IsReadOnly
            {

                get
                {
                    
                    return false;
                
                }

            }

            public bool Remove(Column item)
            {

                int Index = myColumnMeta.IndexOf(item);

                if(myColumnMeta.Remove(item))
                {

                    foreach(var Item in myRows)
                    {

                        Item.RemoveAt(Index);

                    }

                    return true;

                }

                return false;

            }

            public IEnumerator<Column> GetEnumerator()
            {

                return myColumnMeta.GetEnumerator();

            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {

                return myColumnMeta.GetEnumerator();

            }

        }

        public class RowsList : IList<object[]>
        {

            protected List<Column> myColumnMeta = new List<Column>();

            protected List<List<object>> myRows = new List<List<object>>();

            public RowsList(List<Column> TheColumnMeta, List<List<object>> TheRows)
            {

                myColumnMeta = TheColumnMeta;

                myRows = TheRows;

            }

            public int IndexOf(object[] item)
            {

                if(item.Length != myColumnMeta.Count)
                    return -1;

                for(int i = 0; i < myRows.Count; ++i)
                {

                    List<object> Item = myRows[i]; 

                    int no = Item.Count;

                    for(int y = 0; y < Item.Count; ++y)
                    {

                        if(item[y] == item[y])
                            --no;

                    }

                    if(no == 1)
                        return i;

                }

                return -1;

            }

            public void Insert(int index, object[] item)
            {

                int Difference = myColumnMeta.Count - item.Length;

                int Max = myColumnMeta.Count - Difference;

                Dictionary<int, object> Conversions = null;

                for(int i = 0; i < Max; ++i)
                {

                    object CurrentItem = item[i];

                    if(CurrentItem == null)
                        continue;

                    Type CurrentType = myColumnMeta[i].Type;

                    if(CurrentItem.GetType() != CurrentType)
                    {

                        if(Conversions == null)
                            Conversions = new Dictionary<int, object>();

                        Conversions.Add(i, Convert.ChangeType(CurrentItem, CurrentType));

                    }

                }

                List<object> NextList = new List<object>(item.Length);

                NextList.AddRange(item);

                if(Difference != 0)
                {

                    if(Difference > 0)
                    {

                        while(Difference > 0)
                        {

                            NextList.Add(null);

                            --Difference;

                        }

                    }
                    else
                    {

                        while(Difference < 0)
                        {

                            NextList.RemoveAt(NextList.Count - 1);

                            ++Difference;

                        }


                    }

                }

                if(Conversions != null)
                {

                    foreach(var Item in Conversions)
                    {

                        NextList.Insert(Item.Key, Item.Value);

                    }

                }

                myRows.Insert(index, NextList);
                
            }

            public void RemoveAt(int index)
            {
                
                myRows.RemoveAt(index);

            }

            public object[] this[int index]
            {
                get
                {

                    return myRows[index].ToArray();

                }
                set
                {

                    throw new NotImplementedException();

                }

            }

            public void Add(object[] item)
            {
                throw new NotImplementedException();
            }

            public void Clear()
            {

                myRows.Clear();

            }

            public bool Contains(object[] item)
            {
                throw new NotImplementedException();
            }

            public void CopyTo(object[] array, int arrayIndex)
            {
                throw new NotImplementedException();
            }

            public int Count
            {

                get
                {
                    
                    return myRows.Count;
                
                }

            }

            public bool IsReadOnly
            {

                get
                {

                    return false;

                }

            }

            public bool Remove(object[] item)
            {
                throw new NotImplementedException();
            }

            public IEnumerator<object[]> GetEnumerator()
            {
                throw new NotImplementedException();
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {

                return GetEnumerator();

            }

        }

    }

}
