using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements.SQL
{

    public class SQLJoin
    {

        protected SQLJoinOperation myJoinOperation;

        protected DbTable myTable;

        protected IDbCondition myOnCondition;

        protected IEnumerable<DbColumn> myUsingColumns;

        public SQLJoin()
        {
        }

        public SQLJoinOperation JoinOperation
        {

            get
            {

                return myJoinOperation;

            }

        }

        public DbTable Table
        {

            get
            {

                return myTable;

            }
            set
            {

                myTable = value;

            }

        }

        public bool HasTable
        {

            get
            {

                return myTable != null;

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

    }

}
