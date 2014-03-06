using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements
{

    public class DbCheckConstraint : DbConstraint
    {

        protected DbCondition myCondition;

        public DbCheckConstraint()
        {
        }

        public DbCheckConstraint(DbCondition TheCondition)
        {

            myCondition = TheCondition;

        }

        public DbCondition Condition
        {

            get
            {

                return myCondition;

            }
            set
            {

                myCondition = value;

            }

        }

        public bool HasCondition
        {

            get
            {

                return myCondition != null;

            }

        }

    }

}
