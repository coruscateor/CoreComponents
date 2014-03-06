using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements
{

    public class DbDefaultColumnConstraint : DbConstraint
    {

        protected object myValue;

        protected bool myIsExpression;

        public DbDefaultColumnConstraint()
        {
        }

        public DbDefaultColumnConstraint(object TheValue)
        {

            myValue = TheValue;

        }

        public object Value
        {

            get
            {

                return myValue;

            }
            set
            {

                myValue = value;

            }

        }

        public bool HasValue
        {

            get
            {

                return myValue != null;

            }

        }

        public bool IsExpression
        {

            get
            {

                return myIsExpression;

            }
            set
            {

                myIsExpression = value;

            }

        }

    }

}
