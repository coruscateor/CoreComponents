
using System;

namespace CoreComponents.Data.Schema
{
	
	
	public abstract class DbOwned : DbEntity, IAmOwned
	{
		
		protected DbOwner myOwner;

        public DbOwned()
        {
        }
		
		
		public DbOwned(DbOwner Owner)
		{
			
			myOwner = Owner;
			
		}
		
		public DbOwner Owner
        {

            get
            {

                return myOwner;

            }
            set
            {

                myOwner = value;

            }

        }
		
		public bool HasOwner()
        {

            if (myOwner != null)
            {

                if(myOwner.Name.Length > 0) {

                    return true; 
                }

            }

            return false;

        }
		
	}
}
