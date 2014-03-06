
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents;
using CoreComponents.Text;
using CoreComponents.Caching;

namespace CoreComponents.Data.Schema
{


    public class DbProcedure : DbDatabaseEntity<DbProcedure>
	{
		
		protected string myProcedure;

        public DbProcedure(string Procedure)
		{
			
			myProcedure = Procedure;

            Initalise();
			
		}

        protected void Initalise()
        {


            myAdapter = new ChildToParentAdapter<DbDatabase, DbProcedure, IParentedList<DbDatabase, DbProcedure>>(this, "Procedures");

        }

        /*
        public override DbSchema Parent
        {
            /*
            get
            {

                return mySchema;

            }*/
        /*
     set
     {
       
         myAdapter.SetParent(mySchema, value, (IParentedList<DbSchema, DbProcedure>)mySchema.Procedures);
  */
        /*
        if(mySchema != value) {
					
            if (mySchema != null) {
						
                mySchema.Procedures.Remove(this);
						
            }
				
            if (value != null) {
						
                value.Procedures.Add(this);
						
            }
            mySchema = value;
					
        }
         * */
        /*
            }
        }
*/
		
		public string Procedure
		{
			
			get
			{
				return myProcedure;
			}
			
			set
			{
				myProcedure = value;
			}
			
		}
		
		
	}
}
