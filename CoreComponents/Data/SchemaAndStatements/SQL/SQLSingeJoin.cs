using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements.SQL
{

    public class SQLSingeJoin
    {

        protected SQLJoinOperation myJoinOperation;

        protected DbTable myLeftTable;

        protected DbTable myRightTable;

        protected IDbCondition myOnCondition;

        protected IEnumerable<DbColumn> myUsingColumns;

        public SQLSingeJoin()
        {

            myJoinOperation = SQLJoinOperation.Natural;

        }

        public SQLSingeJoin(DbTable TheLeftTable, DbTable TheRightTable, SQLJoinOperation TheJoinOperation = SQLJoinOperation.Natural)
        {

            myLeftTable = TheLeftTable;

            myRightTable = TheRightTable;

            myJoinOperation = TheJoinOperation;

        }

        public SQLJoinOperation JoinOperation
        {

            get
            {

                return myJoinOperation;

            }

        }

        public DbTable LeftTable
        {

            get
            {

                return myLeftTable;

            }

        }

        public bool HasLeftTable
        {

            get
            {

                return myLeftTable != null;

            }

        }

        public DbTable RightTable
        {

            get
            {

                return myRightTable;

            }
 
        }

        public bool HasRightTable
        {

            get
            {

                return myRightTable != null;

            }

        }

        public bool HasLeftAndRightTables
        {

            get
            {

                return myLeftTable != null && myRightTable != null;

            }

        }

        public IDbCondition OnCondition
        {

            get
            {

                return myOnCondition;

            }
            set
            {

                myOnCondition = value;

            }

        }

        public bool HasOnCondition
        {

            get
            {

                return myOnCondition != null;

            }

        }

        public void RemoveOnCondition()
        {

            myOnCondition = null;

        }

        public IEnumerable<DbColumn> UsingColumns
        {

            get
            {

                return myUsingColumns;

            }
            set
            {

                myUsingColumns = value;

            }

        }

        public bool HasUsingColumns
        {

            get
            {

                return myUsingColumns != null;

            }

        }

        public void ClearUsingColumns()
        {

            myUsingColumns = null;

        }

        public int GetUsingColumnCount()
        {

            if (myUsingColumns != null)
            {

                if (myUsingColumns is Array)
                {

                    return (myUsingColumns as Array).Length;

                }
                else if (myUsingColumns is ICollection<DbColumn>)
                {

                    return (myUsingColumns as ICollection<DbColumn>).Count;

                }
                else
                {

                    int i = 0;

                    foreach (DbColumn Item in myUsingColumns)
                    {

                        i++;

                    }

                    return i;

                }

            }

            return 0;

        }

        public bool LeftAndRightColumnsAreEqual
        {

            get
            {

                return myLeftTable == myRightTable;

            }

        }

        public bool LeftAndRightColumnsAreNotEqual
        {

            get
            {

                return myLeftTable != myRightTable;

            }

        }

    }

}
