using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements
{

    public class DbCondition<TComparisonOperators> : IDbCondition
    {

        protected object myLeftValue;

        protected object myRightValue;

        protected TComparisonOperators myComparisonOperator;

        public DbCondition()
        {
        }

        public virtual object LeftValue
        {

            get
            {

                return myLeftValue;

            }
            set
            {

                myLeftValue = value;

            }

        }

        public virtual object RightValue
        {

            get
            {

                return myRightValue;

            }
            set
            {

                myRightValue = value;

            }

        }

        public TComparisonOperators ComparisonOperator
        {

            get
            {

                return myComparisonOperator;

            }
            set
            {

                myComparisonOperator = value;

            }

        }

    }

}
