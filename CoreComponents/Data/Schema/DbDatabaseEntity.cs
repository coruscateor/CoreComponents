using System;
using CoreComponents;
using CoreComponents.Caching;

namespace CoreComponents.Data.Schema
{
    
    public abstract class DbDatabaseEntity<TChild> : DbOwned, IChild<DbDatabase> where TChild : IChild<DbDatabase>
    {

        protected ChildToParentAdapter<DbDatabase, TChild, IParentedList<DbDatabase, TChild>> myAdapter;

        public DbDatabaseEntity()
        {
        }

        /*
        public DbDatabaseEntity(TChild AdapterOwner, string IsPartOfList)
        {

            myAdapter = new ChildToParentAdapter<DbDatabase, TChild, IParentedList<DbDatabase, TChild>>(AdapterOwner, IsPartOfList);

        }
        */

        public virtual DbDatabase Parent
        {

            get
            {

                return myAdapter.OwnersParent;

            }
            set
            {

                myAdapter.SetParent(value);

            }

        }

        public bool IsOrphin()
        {

            return myAdapter.OwnerIsOrphin();

        }

        /*
        public bool HasSchema()
        {
        
            if (myAdapter.OwnersParent != null)
            {
            */        /*
                if (myAdapter.OwnersCurrentParent.Name.Length > 0)
                {

                    return false;

                }
                */
                /*
                return true;

            }

            return false;

        }
        */
        //}
    }
}

