using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents;
using CoreComponents.Text;
using CoreComponents.Items;

namespace CoreComponents.Data.SchemaAndStatements
{

    public class DbSequence : DbDatabaseEntity<DbSequence>, IDbDatabaseEntity
	{

		Int64 myIncrement = 1;
        Int64 myMinValue = 1;
		Int64 myMaxValue = Int64.MaxValue;
        Int64 myStart = 1;
        Int64 myCache = 1;
		
		public DbSequence()
		{

            Initalise();

		}

        public DbSequence(string Name)
        {

            Initalise();

            myName = Name;

        }

        public DbSequence(string Name, bool Postpend_Sequence)
        {

            Initalise();

            if (Postpend_Sequence)
            {

                myName = Name + "_Sequence";

            }

            myName = Name;

        }

        protected void Initalise()
        {

            myAdapter = new ChildToParentAdapter<DbDatabase, DbSequence, IParentedList<DbDatabase, DbSequence>>(this, "Sequences");

        }
		
  /*
  CREATE SEQUENCE workwebsite.news_id_seq
  INCREMENT 1
  MINVALUE 1
  MAXVALUE 9223372036854775807
  START 1
  CACHE 1;
  */
		public Int64 Increment
		{
			
			get
			{
				return myIncrement;
			}
			set
			{
				
				if(value > 0) {
					
					myIncrement = value;
					
				}
			}	
		}
		
		public Int64 MinValue
		{
			get
			{
				return myMinValue;
			}
			set
			{

              myMinValue = value;

			}
		}
		
		public Int64 MaxValue
		{
			get 
			{
				return myMaxValue;
			}
			set
			{


				myMaxValue = value;
			}
			
		}
		
		public Int64 Start
		{
			get
			{
				return myStart;
			}
			set
			{
				myStart = value;
			}
		}
		
		public Int64 Cache
		{
			
			get
			{
				return myCache;
			}
			set
			{
				myCache = value;
			}
			
		}
		/*
		public override DbSchema Parent
        {*/
            /*
            get
            {

                return mySchema;

            }*//*
            set
            {

                myAdapter.SetParent(mySchema, value, (IParentedList<DbSchema, DbSequence>)mySchema.Tables);


            }
			
        }
*/
	}
}
