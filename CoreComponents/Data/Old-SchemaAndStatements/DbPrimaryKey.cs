using System;
using System.Collections.Generic;
using System.Data.Common;
using CoreComponents;
using CoreComponents.Data;
using CoreComponents.Items;

namespace CoreComponents.Data.SchemaAndStatements
{

    public class DbPrimaryKey : ICollection<DbColumn>
	{

		List<DbColumn> myList = new List<DbColumn>();

        bool myIsUnique;

        DbTable myParent;

        public DbPrimaryKey(DbTable TheParent)
		{

            myParent = TheParent;

		}
		
        public bool IsComposite
        {

            get
            {

                return myList.Count > 0;

            }

        }

        public DbTable Parent
        {

            get 
            {

                return myParent;

            }

        }
            
        public void Add(DbColumn item)
        {

            if(myParent.Columns.Contains(item) && !myList.Contains(item))
            {

                myList.Add(item);

                //return true;

            }

            //return false;

        }

        public void Clear()
        {

            myList.Clear();

        }

        public bool Contains(DbColumn item)
        {

            return myList.Contains(item);

        }

        public void CopyTo(DbColumn[] array, int arrayIndex)
        {

            myList.CopyTo(array, arrayIndex);

        }

        public int Count
        {

            get 
            {
                
                return myList.Count;
            
            }

        }

        public bool IsReadOnly
        {

            get 
            {
                
                return false;
            
            }

        }

        public bool Remove(DbColumn item)
        {

            return myList.Remove(item);

        }

        public IEnumerator<DbColumn> GetEnumerator()
        {

            return myList.GetEnumerator();

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {

            return myList.GetEnumerator();

        }
        
    }

    //public class DbPrimaryKeyList
    //{
		
    //    List<DbPrimaryKey> myList = new List<DbPrimaryKey>();

    //    public DbPrimaryKeyList()
    //    {
    //    }
		
    //    public List<DbPrimaryKey> List
    //    {
			
    //        get
    //        {
    //            return myList;
    //        }
			
    //    }
		
    //}
}
