using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements
{

    public class DbTable : DbEntityWithConstraints
    {

        protected DbColumnSet myColumns;

        //protected DbForeignKeySet myForeignKeys;

        //protected DbPrimaryKey myPrimaryKey;

        protected bool myIsTemporary;

        protected DbDatabase myDatabase;

        public DbTable()
        {

            Initalise();

        }

        public DbTable(string TheName)
        {

            Initalise();

            myName = TheName;

        }

        protected void Initalise()
        {

            myColumns = new DbColumnSet(this);

            //myForeignKeys = new DbForeignKeySet(this);

            //myPrimaryKey = new DbPrimaryKey(this);

        }

        public DbColumnSet Columns
        {

            get
            {

                return myColumns;

            }

        }

        //public DbForeignKeySet ForeignKeys
        //{

        //    get
        //    {

        //        return myForeignKeys;

        //    }

        //}

        //public bool HasForeignKeys
        //{

        //    get
        //    {

        //        return myForeignKeys.Count > 0;

        //    }

        //}

        //public DbPrimaryKey PrimaryKey
        //{

        //    get
        //    {

        //        return myPrimaryKey;

        //    }

        //}

        //public bool HasPrimaryKey
        //{

        //    get
        //    {

        //        return myPrimaryKey.Count > 0;

        //    }

        //}

        public bool IsTemporary
        {

            get
            {

                return myIsTemporary;

            }
            set 
            {

                myIsTemporary = value;

            }

        }

        public DbDatabase Database
        {

            get
            {

                return myDatabase;

            }
            set
            {

                myDatabase = value;

            }
 
        }

        public bool HasDatabase
        {

            get
            {

                return myDatabase != null && myDatabase.Name != null && myDatabase.Name.Length > 0;

            }

        }

        public bool Validate()
        {

            if (!HasName)
                return false;

            myColumns.Validate();

            //myForeignKeys.Validate();

            return true;

        }

    }

}
