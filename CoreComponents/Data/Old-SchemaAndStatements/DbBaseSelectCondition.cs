using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements
{

    public class DbBaseSelectCondition<TLogicalOperators, TOperator> : DbBaseCondition<TOperator>
    {
        
        protected TLogicalOperators myLogicalOperator;

        public DbBaseSelectCondition()
        {
        }

        public TLogicalOperators LogicalOperator
        {

            get
            {

                return myLogicalOperator;

            }
            set
            {

                myLogicalOperator = value;

            }

        }

        public override bool Equals(object obj)
        {

            Type ObjectType = obj.GetType();

            if (ObjectType == GetType())
            {

                DbBaseSelectCondition<TLogicalOperators, TOperator> Item = (DbBaseSelectCondition<TLogicalOperators, TOperator>)obj;

                return Item.LeftValue.Equals(myLeftValue) && Item.Operator.Equals(myOperator) && Item.RightValue.Equals(myRightValue); //&& Item.LogicalOperator.Equals(myRightValue);

            }
            else if (ObjectType == typeof(DbBaseCondition<TOperator>))
            {

                DbBaseCondition<TOperator> Item = (DbBaseCondition<TOperator>)obj;

                return Item.LeftValue.Equals(myLeftValue) && Item.Operator.Equals(myOperator) && Item.RightValue.Equals(myRightValue);

            }
            
            return false;

        }

        public static bool operator ==(DbBaseSelectCondition<TLogicalOperators, TOperator> Left, DbBaseSelectCondition<TLogicalOperators, TOperator> Right)
        {

            return Left.Equals(Right);

        }

        public static bool operator ==(DbBaseSelectCondition<TLogicalOperators, TOperator> Left, DbBaseCondition<TOperator> Right)
        {
            
            return Left.Equals(Right);
           
        }

        public static bool operator !=(DbBaseSelectCondition<TLogicalOperators, TOperator> Left, DbBaseSelectCondition<TLogicalOperators, TOperator> Right)
        {

            return !Left.Equals(Right);

        }

        public static bool operator !=(DbBaseSelectCondition<TLogicalOperators, TOperator> Left, DbBaseCondition<TOperator> Right)
        {

            return !Left.Equals(Right);

        }

        public override int GetHashCode()
        {

            return base.GetHashCode();

        }

    }

    public enum DbCommutativeLogicalOperators
    {

        And,
        Or

    }

    public enum DbBinayOperators
    {

        LessThan,
        GreaterThan,
        LessThanOrEqualTo,
        GreaterThanOrEqualTo,
        Is,
        Not,
        IsNot,
        IsEqualTo,
        IsNotEqualTo,
        Between,
        NotBetween

    }

}
