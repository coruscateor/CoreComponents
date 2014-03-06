using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents;
using CoreComponents.Caching;

namespace CoreComponents.Data.Schema
{

    public class TableList : ParentedList<DbDatabase, DbTable> //UniqueParentedNamedList<DbSchema, DbTable>
    {

        public TableList(DbDatabase Parent) 
            : base(Parent)
        {
        }

    }

    public class ViewList : ParentedList<DbDatabase, DbView> //UniqueParentedNamedList<DbSchema, DbView>
    {

        public ViewList(DbDatabase Parent)
            : base(Parent)
        {
        }

    }

    public class ProceduresList : ParentedList<DbDatabase, DbProcedure>  //UniqueParentedNamedList<DbSchema, DbProcedure>
    {

        public ProceduresList(DbDatabase Parent)
            : base(Parent)
        {
        }

    }

    public class SequencesList : ParentedList<DbDatabase, DbSequence> //UniqueParentedNamedList<DbSchema, DbProcedure>
    {

        public SequencesList(DbDatabase Parent)
            : base(Parent)
        {
        }

    }

    //Orignally Called DbSchema
    public class DbDatabase : DbOwned, IChild<DbSchema>
    {

        protected ChildToParentAdapter<DbSchema, DbDatabase, IParentedList<DbSchema, DbDatabase>> myAdapter;

        TableList myTables;

        ViewList myViews;

        ProceduresList myProcedures;

        SequencesList mySequences;
		
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

            mySequences = new SequencesList(this);

            myAdapter = new ChildToParentAdapter<DbSchema, DbDatabase, IParentedList<DbSchema, DbDatabase>>(this, "Databases");
			
		}
		
		public bool HasName()
		{
			
			return myName.Length == 0; 
			
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

        public SequencesList Sequences
		{
			get
			{
				return mySequences;
			}
		}
		
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
