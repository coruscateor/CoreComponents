using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Caching;

namespace CoreComponents.Data.Schema
{

    public class DatabaseList : ParentedList<DbSchema, DbDatabase> 
    {

        public DatabaseList(DbSchema Parent) : base(Parent)
        {
        }

    }

    public class DbSchema : DbEntity
    {

        protected DatabaseList myDatabaseList; 

        public DbSchema() 
        {

            myDatabaseList = new DatabaseList(this);

        }

        public DatabaseList DatabaseList 
        {

            get 
            {

                return myDatabaseList;

            }

        }

    }

}
