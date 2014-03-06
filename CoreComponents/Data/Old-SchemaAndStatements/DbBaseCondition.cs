using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements
{
    public class DbBaseCondition<TOperator>
    {

        protected TOperator myOperator;

        protected object myLeftValue;

        protected object myRightValue;

        public TOperator Operator
        {

            get
            {

                return myOperator;

            }
            set
            {

                myOperator = value;

            }

        }

        public object LeftValue
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

        public bool HasLeftValue
        {

            get
            {

                return myLeftValue != null;

            }

        }

        public object RightValue
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

        public bool HasRightValue
        {

            get
            {

                return myRightValue != null;

            }

        }

        public bool HasBothValues
        {

            get
            {

                return myLeftValue != null && myRightValue != null;

            }

        }

        public override bool Equals(object obj)
        {

            if (obj.GetType() == GetType())
            {

                DbBaseCondition<TOperator> Item = (DbBaseCondition<TOperator>)obj;

                return Item.LeftValue.Equals(myLeftValue) && Item.Operator.Equals(myOperator) && Item.RightValue.Equals(myRightValue);

            }

            return false;
        }

        public static bool operator ==(DbBaseCondition<TOperator> Left, DbBaseCondition<TOperator> Right)
        {

            return Left.Equals(Right);

        }

        public static bool operator !=(DbBaseCondition<TOperator> Left, DbBaseCondition<TOperator> Right)
        {

            return !Left.Equals(Right);

        }

        public override int GetHashCode()
        {

            return base.GetHashCode();

        }

    }
}
