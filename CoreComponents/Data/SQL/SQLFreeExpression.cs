using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Text;

namespace CoreComponents.Data.SQL
{
    public class SQLFreeExpression : SQLExpression
    {

        string myExpression;

        protected override void Append(StringBuilder SB){

            SB.Append(myExpression);

        }

        public string Expression
        {

            get
            {

                return myExpression;

            }
            set
            {

                myExpression = value;

            }

        }

    }
    
}
