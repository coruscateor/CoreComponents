using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents;
using CoreComponents.Text;
using CoreComponents.Items;

namespace CoreComponents.Data.SQL.pgsql.SubCommands
{
    public class pgsqlWITHSubcommand : SQLSubExpression
    {

        bool myRECURSIVE;

        SubscribeableList<pgsqlWITHQuery> myWITHQuerys;
		
		public pgsqlWITHSubcommand()
		{
			
			myWITHQuerys = new SubscribeableList<pgsqlWITHQuery>();
			
		}

        public bool RECURSIVE
        {

            get
            {

                return myRECURSIVE;

            }
            set
            {

                myRECURSIVE = value;

            }

        }

       	public SubscribeableList<pgsqlWITHQuery> WITHQuerys
        {

            get
            {
                return myWITHQuerys;

            }

        }

        //public override void AppendTo(StringBuilder SB)
        //{

        //    Append(SB);

        //}
		
        protected override void Append(StringBuilder SB)
        {

            //if (myWITHQuery != null)
			if(myWITHQuerys.Count > 0)
            {

                SB.Append("WITH ");

                if (myRECURSIVE)
                {

                    SB.Append("RECURSIVE ");

                }

                //myWITHQuery.AppendTo(SB);
					
                SB.Append("( ON ");

                //foreach (SQLSubExpression WITHQuerys in myWITHQuerys)
                //{

                TextEntityDelimiter.Delimit<SQLSubExpression>(SB, (IList<SQLSubExpression>)myWITHQuerys);

                //}

                //int Place = 1;
					
                //foreach (SQLExpression Expression in myWITHQuerys) {
					
                //    Expression.AppendTo(SB);
						
                //    if(Place < myWITHQuerys.Count) 
                //    {
							
                //        SB.Append(", ");
						
                //        Place++;
						
                //    }
                //}

                SB.Append(") ");
				
            }
        }
    }
}
