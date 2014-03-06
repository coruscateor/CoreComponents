using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SQL
{
    public class ConditionPair<TArgRight>
    {

        IQueryObject myArgLeft;

        string myOperator;

        TArgRight myArgRight;

        public ConditionPair(IQueryObject TheArgLeft, string TheOperator, TArgRight TheArgRight) 
        {

            myArgLeft = TheArgLeft;

            myOperator = TheOperator;

            myArgRight = TheArgRight;

        }

    }

}
