using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents;
using CoreComponents.Characters;
using CoreComponents.Items;

namespace CoreComponents.Data.SchemaAndStatements
{
    public class DbView : DbDatabaseEntity<DbView>, IDbDatabaseEntity
    {

        protected string myQuery;

        protected List<DbColumn> myColumns;

        public DbView(string Name)
        {

            myName = Name;

            Initalise();

        }

        public DbView(string Name, string Query)
        {

            myName = Name;

            Initalise();

            myAdapter.SetParent(null);

            myQuery = Query;


        }

        public DbView(DbDatabase Schema, string Name)
        {

            myName = Name;

            Initalise();

            myAdapter.SetParent(Schema);
            

        }

        public DbView(DbDatabase Schema, string Name, string Query)
        {

            Initalise();

            myAdapter.SetParent(Schema);

            myQuery = Query;

        }

        public DbView(string Name, IList<DbColumn> Columns)
        {

            myName = Name;

            myColumns = new List<DbColumn>(Columns);

        }
        
        protected void Initalise()
        {

            myColumns = new List<DbColumn>();

            myAdapter = new ChildToParentAdapter<DbDatabase, DbView, IParentedList<DbDatabase, DbView>>(this, "Views");

        }
        /*
		public override DbSchema Parent
        {
            /*
            get
            {

                return myAdapter.OwnersCurrentParent;

            }*/
        /*
     set
     {
 
         myAdapter.SetParent(value);
        */
        /*
        if(mySchema != value) {
					
            if (mySchema != null) {
						
                mySchema.Views.Remove(this);
						
            }
				
            if (value != null) {
						
                value.Views.Add(this);
						
            }
            mySchema = value;
         * */
					/*
				}
            }
*/
        public List<DbColumn> Columns
        {

            get
            {

                return myColumns;

            }

        }

        public string Query
        {

            get
            {

                return myQuery;

            }
            set
            {

                myQuery = value;

            }

        }

        public bool HasColumns()
        {

            if (myColumns != null)
            {

                if (myColumns.Count > 0)
                {

                    return true;

                }

            }

            return false;

        }

        public bool HasQuery()
        {

            return myQuery.Length > 0;

        }

    }

}
