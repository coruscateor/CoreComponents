using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Items;
using CoreComponents.Text;

namespace CoreComponents.Data.SQL.pgsql.SubCommands
{
    public class pgsqlALL_DISTINCT_ON_SubCommand : SQLSubExpression
    {

        ALLorDISTINCT myALLorDISTINCT;

        SubscribeableList<SQLExpression> myExpressions;

        bool myON;

        public pgsqlALL_DISTINCT_ON_SubCommand()
        {

            myALLorDISTINCT = ALLorDISTINCT.DISTINCT;
			
			myExpressions = new SubscribeableList<SQLExpression>();

        }

        public SubscribeableList<SQLExpression> Expressions
        {

            get
            {

                return myExpressions;

            }

        }

        public bool ON
        {

            get
            {

                return myON;

            }
            set
            {

                myON = value;

            }

        }

        protected override void Append(StringBuilder SB)
        {

            switch (myALLorDISTINCT)
            {

                case ALLorDISTINCT.DISTINCT:

                    SB.Append("DISTINCT ");

                    break;

                case ALLorDISTINCT.ALL:

                    SB.Append("ALL ");

                    break;

            }


            if(myON)
            {

                //if (myExpression != null)
				if(myExpressions.Count > 0)
                {
					
                    SB.Append("( ON ");

                    TextEntityDelimiter.Delimit<SQLExpression>(SB, myExpressions);

                    //int Place = 1;
					
                    //foreach (SQLExpression Expression in myExpressions) {
					
                    //    Expression.AppendTo(SB);
						
                    //    if(Place < myExpressions.Count) 
                    //    {
							
                    //        SB.Append(", ");
						
                    //        Place++;
                    //    }
                    //}

                    SB.AppendLine(" )");

                }

            }

            
        }

    }
}
