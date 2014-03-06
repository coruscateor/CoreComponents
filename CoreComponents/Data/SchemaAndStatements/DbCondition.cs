using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Data.SchemaAndStatements.SQL;

namespace CoreComponents.Data.SchemaAndStatements
{

    public class DbCondition : IDbCondition
    {

        protected object myLeftObject;

        protected object myRightObject;

        protected SQLComparasonOperation mySQLComparasonOperation;

        public DbCondition(object TheLeftObject = null, SQLComparasonOperation TheSQLComparasonOperation = SQLComparasonOperation.Equals, object TheRightObject = null)
        {

            myLeftObject = TheLeftObject;

            mySQLComparasonOperation = TheSQLComparasonOperation;

            myRightObject = TheRightObject;

        }

        public object Left
        {

            get
            {

                return myLeftObject;

            }
            set
            {

                myLeftObject = value;

            }

        }

        public bool HasLeftObject
        {

            get
            {

                return myLeftObject != null;

            }

        }

        public bool LeftObjectIsNull
        {

            get
            {

                return myLeftObject == null;

            }

        }

        public bool LeftObjectIsDbColumn
        {

            get
            {

                return myLeftObject.GetType() == typeof(DbColumn);

            }

        }

        public SQLComparasonOperation ComparasonOperation
        {

            get
            {

                return mySQLComparasonOperation;

            }
            set
            {

                mySQLComparasonOperation = value;

            }

        }

        public object Right
        {

            get
            {

                return myRightObject;

            }
            set
            {

                myRightObject = value;

            }

        }

        public bool HasRightObject
        {

            get
            {

                return myRightObject != null;

            }

        }

        public bool RightObjectIsNull
        {

            get
            {

                return myRightObject == null;

            }

        }

        public bool RightObjectIsDbColumn
        {

            get
            {

                return myRightObject.GetType() == typeof(DbColumn);

            }

        }

        public void AppendTo(StringBuilder SB)
        {

            if (myLeftObject == null)
            {

                SB.Append(CommonSQL.NULL);

            }
            if (myLeftObject == typeof(DbColumn))
            {

                SB.Append((myLeftObject as DbColumn).Name);

            }
            else
            {

                SB.Append(myLeftObject.ToString());

            }

            switch (mySQLComparasonOperation)
            {

                case SQLComparasonOperation.Between:

                    SB.Append(CommonSQL._BETWEEN_);

                    break;
                case SQLComparasonOperation.Equals:

                    SB.Append(CommonSQL._DoubleEquals_);

                    break;
                case SQLComparasonOperation.GreaterThan:

                    SB.Append(CommonSQL._GreaterThan_);

                    break;
                case SQLComparasonOperation.GreaterthanOrEqualTo:

                    SB.Append(CommonSQL._GreaterThanOrEqualto_);

                    break;
                case SQLComparasonOperation.In:

                    SB.Append(CommonSQL._IN_);
                    break;
                case SQLComparasonOperation.Is:

                    SB.Append(CommonSQL._IS_);

                    break;
                case SQLComparasonOperation.IsNot:

                    SB.Append(CommonSQL._IS_NOT_);

                    break;
                case SQLComparasonOperation.IsNotEqualTo:

                    SB.Append(CommonSQL._GreaterThanLessThan_);

                    break;
                case SQLComparasonOperation.LessThan:

                    SB.Append(CommonSQL._LessThan_);

                    break;
                case SQLComparasonOperation.LessThanOrEqualTo:

                    SB.Append(CommonSQL._LessThanOrEqualto_);

                    break;
                case SQLComparasonOperation.NotIn:

                    SB.Append(CommonSQL._NOT_IN_);

                    break;

            }

            if (myRightObject == null)
            {

                SB.Append(CommonSQL.NULL);

            }
            if (myRightObject == typeof(DbColumn))
            {

                SB.Append((myLeftObject as DbColumn).Name);

            }
            else
            {

                SB.Append(myRightObject.ToString());

            }

        }

        public string Write()
        {

            StringBuilder SB = new StringBuilder();

            AppendTo(SB);

            return SB.ToString();

        }

    }

    //"=", "==", "<", "<=", ">", ">=", "!=", "<>", "IN", "NOT IN", "BETWEEN", "IS", and "IS NOT"

    public enum SQLComparasonOperation
    {

        Equals,
        LessThan,
        LessThanOrEqualTo,
        GreaterThan,
        GreaterthanOrEqualTo,
        IsNotEqualTo,
        In,
        NotIn,
        Between,
        Is,
        IsNot

    }

}
