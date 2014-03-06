using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents;
using CoreComponents.Items;

namespace CoreComponents.Data.SchemaAndStatements
{

    //Orignally Called DbSchema
    public class DbDatabase : DbOwned, IChild<DbSchema>
    {

        protected ChildToParentAdapter<DbSchema, DbDatabase, IParentedList<DbSchema, DbDatabase>> myAdapter;

        TableList myTables;

        ViewList myViews;

        ProceduresList myProcedures;

        //SequencesList mySequences;
		
		//DbPrimaryKeyList myPKs = new DbPrimaryKeyList();
		
		//DbForignKeyList myFKs = new DbForignKeyList();
		
		public DbDatabase()
        {

            Initalise();

        }
		
        public DbDatabase(string Name)
        {

            myName = Name;

            Initalise();
        }
		
		void Initalise()
		{

            myTables = new TableList(this);

            myViews = new ViewList(this);

            myProcedures = new ProceduresList(this);

            //mySequences = new SequencesList(this);

            myAdapter = new ChildToParentAdapter<DbSchema, DbDatabase, IParentedList<DbSchema, DbDatabase>>(this, "Databases");
			
		}
		
		public override bool HasName
		{

            get
            {

                return myName != null && myName.Length == 0;

            }
			
		}

        public TableList Tables
		{

			get
			{

				return myTables;

			}

		}

        public ViewList Views
		{

			get
			{

				return myViews;

			}

		}

        public ProceduresList Procedures
		{

			get
			{
				
				return myProcedures;
				
			}

		}

        //public SequencesList Sequences
        //{

        //    get
        //    {
        //        return mySequences;
        //    }

        //}
		
        /*
		public DbPrimaryKeyList PrimaryKeys
		{
			
			get
			{
				return myPKs;
			}
			
		}
		
		public DbForignKeyList ForignKeys
		{
			
			get
			{
				
				return myFKs;
				
			}
			
		}
        */

        public DbSchema Parent
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

    }

}
