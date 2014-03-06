using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements
{

    public class DbForeignKeyList : IDictionary<DbColumn, DbColumn>
    {

        Dictionary<DbColumn, DbColumn> myRelatedColumns = new Dictionary<DbColumn, DbColumn>();

        DbTable myParent;

        public DbForeignKeyList(DbTable TheParent)
        {

            myParent = TheParent;

        }

        public void Add(DbColumn key, DbColumn value)
        {

            if (key != value) 
            {

                if (key == null)
                {

                    //Error!

                    return;

                }

                if (value == null)
                {

                    //Error!

                    return;

                }

                if (myParent.Columns.Contains(key) && !myParent.Columns.Contains(value))
                {

                    myRelatedColumns.Add(key, value);

                }
                else
                {

                    //Error!

                }

            }

        }

        public bool ContainsKey(DbColumn key)
        {

            return myRelatedColumns.ContainsKey(key);

        }

        public ICollection<DbColumn> Keys
        {

            get 
            { 
                
                return myRelatedColumns.Keys;
            
            }

        }

        public bool Remove(DbColumn key)
        {

            if (myRelatedColumns.ContainsKey(key))
            {

                return myRelatedColumns.Remove(key);

            }

            //Error!

            return false;

        }

        public bool TryGetValue(DbColumn key, out DbColumn value)
        {

            return myRelatedColumns.TryGetValue(key, out value);

        }

        public ICollection<DbColumn> Values
        {

            get
            { 
                
                return myRelatedColumns.Values;
            
            }

        }

        public DbColumn this[DbColumn key]
        {

            get
            {

                return myRelatedColumns[key];
            }
            set
            {
                if (key != value)
                {

                    if (key == null)
                    {

                        //Error!

                        return;

                    }

                    if (value == null)
                    {

                        //Error!

                        return;

                    }

                    if (!myParent.Columns.Contains(value))
                    {

                        myRelatedColumns[key] = value;

                    }
                    else
                    {

                        //Error!

                    }

                }

            }

        }

        public void Add(KeyValuePair<DbColumn, DbColumn> item)
        {

            if (item.Key == item.Value)
            {

                //Error!

                return;

            }
            
            if (item.Key == null)
            {

                //Error!

                return;

            }

            if (item.Value == null)
            {

                //Error!

                return;

            }

            if (!myRelatedColumns.ContainsKey(item.Key))
            {

                myRelatedColumns.Add(item.Key, item.Value);

            }
            else 
            {

                //Error!

            }

        }

        public void Clear()
        {

            myRelatedColumns.Clear();
            
        }

        public bool Contains(KeyValuePair<DbColumn, DbColumn> item)
        {
            
            return myRelatedColumns.Contains(item);

        }

        public void CopyTo(KeyValuePair<DbColumn, DbColumn>[] array, int arrayIndex)
        {

            throw new NotImplementedException();

        }

        public int Count
        {

            get
            {
                
                return myRelatedColumns.Count;
            
            }

        }

        public bool IsReadOnly
        {

            get
            {

                return false;
            
            }

        }

        public bool Remove(KeyValuePair<DbColumn, DbColumn> item)
        {

            if (myRelatedColumns.ContainsKey(item.Key) && myRelatedColumns.ContainsValue(item.Value))
            {

                return myRelatedColumns.Remove(item.Key);

            }

            //Error!

            return false;

        }

        public void ValidateRelationships()
        {

            Queue<DbColumn> RemoveQueue = null;

            foreach (KeyValuePair<DbColumn, DbColumn> Item in myRelatedColumns)
            {

                if (Item.Key == Item.Value || Item.Key == null || Item.Value == null || myParent.Columns.Contains(Item.Value))
                {

                    if (RemoveQueue == null)
                    {

                        RemoveQueue = new Queue<DbColumn>();

                        RemoveQueue.Enqueue(Item.Key);

                        continue;

                    }

                }

            }

        }

        public IEnumerator<KeyValuePair<DbColumn, DbColumn>> GetEnumerator()
        {

            return myRelatedColumns.GetEnumerator();

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {

            return myRelatedColumns.GetEnumerator();

        }

    }

}
