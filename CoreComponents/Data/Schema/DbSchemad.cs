using System;
using CoreComponents;
using CoreComponents.Caching;

namespace CoreComponents.Data.Schema
{

    public abstract class DbSchemad<TChild> : DbOwned, IChild<DbSchema> where TChild : IChild<DbSchema>
    {

        protected ChildToParentAdapter<DbSchema, TChild, IParentedList<DbSchema, TChild>> myAdapter;

        public DbSchemad()
        {
        }

        /*
        public DbSchemad(TChild AdapterOwner)
        {

            myAdapter = new ChildToParentAdapter<DbSchema, TChild, IParentedList<DbSchema, TChild>>(AdapterOwner);

        }
        */

        public virtual DbSchema Parent
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

            return myAdapter.OwnersParent == null;

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
        }
    }
//}

