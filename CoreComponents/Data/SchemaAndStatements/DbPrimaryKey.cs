using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements
{

    public class DbPrimaryKey : IEnumerable<DbColumn>
    {

        protected DbTable myTable;

        protected List<DbColumn> myColumns = new List<DbColumn>();

        protected bool myAutoIncrement;

        public DbPrimaryKey(DbTable TheTable)
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

        public bool AutoIncrement
        {

            get
            {

                return myAutoIncrement;

            }
            set
            {

                myAutoIncrement = value;

            }

        }

        public bool IsInteger
        {

            get
            {

                if (myColumns.Count == 1)
                {

                    DbColumn PrimaryKey = myColumns[0];

                    return PrimaryKey.Type == SystemTypes.Short || PrimaryKey.Type == SystemTypes.Ushort || PrimaryKey.Type == SystemTypes.Int || PrimaryKey.Type == SystemTypes.Uint || PrimaryKey.Type == SystemTypes.Long || PrimaryKey.Type == SystemTypes.Ulong;


                }

                return false;

            }

        }

        public int IndexOf(DbColumn item)
        {

            return myColumns.IndexOf(item);

        }

        public bool Insert(int index, DbColumn item)
        {

            if (myTable.Columns.Contains(item) && !myColumns.Contains(item))
            {

                myColumns.Insert(index, item);

                return true;

            }

            return false;

        }

        public void RemoveAt(int index)
        {

            myColumns.RemoveAt(index);
            
        }

        public DbColumn this[int index]
        {

            get
            {

                return myColumns[index];

            }
            set
            {

                if (myTable.Columns.Contains(value) && !myColumns.Contains(value))
                {

                    myColumns[index] = value;

                }

            }

        }

        public bool Add(DbColumn item)
        {

            if (myTable.Columns.Contains(item) && !myColumns.Contains(item) && HasChars(item.Name))
            {

                myColumns.Add(item);

                return true;

            }

            return false;

        }

        public void Clear()
        {

            myColumns.Clear();
            
        }

        public bool Contains(DbColumn item)
        {

            return myColumns.Contains(item);

        }

        public int Count
        {

            get 
            {
                
                return myColumns.Count;
            
            }

        }

        public bool IsComposite
        {

            get
            {

                return myColumns.Count > 0;

            }

        }

        public bool Remove(DbColumn item)
        {

            return myColumns.Remove(item);
            
        }

        public void TrimExcess()
        {

            myColumns.TrimExcess();

        }

        public void Validate()
        {

            if (myColumns.Count == 1)
            {

                if (!myTable.Columns.Contains(myColumns[0]))
                    myColumns.RemoveAt(0);
                    
            }
            else if (myColumns.Count > 1)
            {

                Queue<DbColumn> ColumnsToRemove = new Queue<DbColumn>();

                foreach (DbColumn Item in myColumns)
                {

                    if (!myTable.Columns.Contains(Item))
                        ColumnsToRemove.Enqueue(Item);

                }

                while (ColumnsToRemove.Count > 0)
                {

                    myColumns.Remove(ColumnsToRemove.Dequeue());

                }

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

    }

}
