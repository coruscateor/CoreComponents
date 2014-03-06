using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements
{

    public class DbColumnSet : IEnumerable<DbColumn>
    {

        protected DbTable myTable;

        protected List<DbColumn> myColumns = new List<DbColumn>();

        public DbColumnSet(DbTable TheTable)
        {

            myTable = TheTable;

        }

        protected bool HasChars(string Value)
        {

            return (Value != null && Value.Length > 0);

        }

        public DbTable Table
        {

            get
            {

                return myTable;

            }

        }
    
        public bool Add(DbColumn TheDbColumn)
        {

            if (HasChars(TheDbColumn.Name))
            {

                if (!Contains(TheDbColumn))
                {

                    myColumns.Add(TheDbColumn);

                    TheDbColumn.Table = myTable;

                    return true;

                }

            }

            return false;

        }

        public bool Remove(DbColumn TheDbColumn)
        {

            //myTable.PrimaryKey.Remove(TheDbColumn);

            TheDbColumn.Table = null;

            return myColumns.Remove(TheDbColumn);

        }

        public bool Remove(string TheDbColumnName)
        {

            if (HasChars(TheDbColumnName))
            {

                DbColumn ColumnToRemove = null;

                foreach (DbColumn Item in myColumns)
                {

                    if (Item.Name == TheDbColumnName)
                    {

                        ColumnToRemove = Item;

                        //myTable.PrimaryKey.Remove(Item);

                        ColumnToRemove.Table = null;

                        break;

                    }

                }

                if (ColumnToRemove != null)
                    return myColumns.Remove(ColumnToRemove);


            }

            return false;

        }

        public bool Contains(DbColumn TheDbColumn)
        {

            if (HasChars(TheDbColumn.Name))
            {

                
                foreach (DbColumn Item in myColumns)
                {

                    if (Item.Name == TheDbColumn.Name)
                        return true;

                }

            }

            return false;

        }

        public bool ContainsReference(DbColumn TheDbColumn)
        {

            return myColumns.Contains(TheDbColumn);

        }

        public bool Contains(string TheDbColumnName)
        {

            if (HasChars(TheDbColumnName))
            {

                foreach (DbColumn Item in myColumns)
                {

                    if (Item.Name == TheDbColumnName)
                        return true;

                }

            }

            return false;

        }

        public int Count
        {

            get
            {

                return myColumns.Count;

            }

        }

        public void Clear()
        {

            myColumns.Clear();
            
        }

        public int Capacity
        {

            get
            {

                return myColumns.Capacity;

            }

        }

        public DbColumn[] ToArray()
        {

            return (DbColumn[])myColumns.ToArray();
            
        }

        public int GetOrdinalOf(DbColumn TheDbColumn)
        {

            return myColumns.IndexOf(TheDbColumn);

        }

        public bool Insert(int Index, DbColumn TheDbColumn)
        {

            if (HasChars(TheDbColumn.Name))
            {

                if (!Contains(TheDbColumn))
                {

                    myColumns.Insert(Index, TheDbColumn);

                    TheDbColumn.Table = myTable;

                    return true;

                }

            }

            return false;
            
        }

        public void RemoveAt(int index)
        {

            DbColumn ColumnToRemove = myColumns[index];

            //myTable.PrimaryKey.Remove(ColumnToRemove);

            ColumnToRemove.Table = null;

            myColumns.RemoveAt(index);

        } 

        public void Reverse()
        {

            myColumns.Reverse();

        }

        public void Reverse(int indexer, int Count)
        {

            myColumns.Reverse(indexer, Count);

        }

        public void TrimExcess()
        {

            myColumns.TrimExcess();

        }

        public void Validate()
        {

            if (myColumns.Count == 1)
            {

                DbColumn Column = myColumns[0];

                if (Column.Table != myTable || !HasChars(Column.Name))
                    myColumns.Remove(Column);

            }
            else if (myColumns.Count > 1)
            {

                Queue<DbColumn> ColumnsToRemove = new Queue<DbColumn>();

                foreach (DbColumn Item in myColumns)
                {

                    if (Item.Table != myTable || !HasChars(Item.Name))
                    {

                        ColumnsToRemove.Enqueue(Item);

                    }

                }

                while (ColumnsToRemove.Count > 0)
                {

                    myColumns.Remove(ColumnsToRemove.Dequeue());

                }

            }

        }

        public DbColumn this[int index]
        {

            get
            {

                return myColumns[index];

            }

        }

        public IEnumerator<DbColumn> GetEnumerator()
        {

            return myColumns.GetEnumerator();

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {

            return myColumns.GetEnumerator();
            
        }
        
        //public int IndexOf(DbColumn item)
        //{
        //    throw new NotImplementedException();
        //}

        //void IList<DbColumn>.Insert(int index, DbColumn item)
        //{
        //    throw new NotImplementedException();
        //}

        //public DbColumn this[int index]
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

        //void ICollection<DbColumn>.Add(DbColumn item)
        //{
        //    throw new NotImplementedException();
        //}

        //public void CopyTo(DbColumn[] array, int arrayIndex)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool IsReadOnly
        //{
        //    get { throw new NotImplementedException(); }
        //}

    }

}
