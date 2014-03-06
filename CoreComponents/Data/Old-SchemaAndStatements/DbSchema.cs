using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Items;

namespace CoreComponents.Data.SchemaAndStatements
{

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
