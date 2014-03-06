using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Text;
using CoreComponents.Caching;

namespace CoreComponents.Data.SQL
{
    public class ANSI_SELECT
    {

        protected StringBuilder mySB = new StringBuilder();

        protected SubscribeableList<SQLColumn> myColumns = new SubscribeableList<SQLColumn>();

        protected SubscribeableList<SQLCondition> myConditions = new SubscribeableList<SQLCondition>();

        protected SQLSet mySet;

        protected SQLSet myINTOTable;

        public ANSI_SELECT()
        {
        }

        public SubscribeableList<SQLColumn> Columns
        {

            get
            {

                return myColumns;

            }

        }

        public SubscribeableList<SQLCondition> Conditions
        {

            get
            {

                return myConditions;

            }

        }

        public SQLSet Table
        {

            get
            {

                return mySet;

            }
            set
            {

                mySet = value;

            }

        }

        public SQLSet INTO
        {

            get
            {

                return myINTOTable;

            }
            set
            {

                myINTOTable = value;

            }

        }


        protected void AssembleStatement()
        {

            mySet.Reset();

            TextEntity.Clear(mySB);

            mySB.Append(ANSI_SQL.SELECT);

            TextEntity.AddSpace(mySB);

            if (myColumns.Count > 0)
            {

                mySB.Append(ANSI_SQL.ALL);

            } else
            {

                int colpos = 0;

                foreach (SQLColumn col in myColumns)
                {

                    col.Reset();

                    mySB.Append(col.Resolve());

                    if (colpos < myColumns.Count)
                    {

                        TextEntity.CommaS(mySB);

                        colpos++;

                    }
                }
                
            }

            TextEntity.AddSpace(mySB);

            mySB.Append(ANSI_SQL.FROM);

            mySB.Append(mySet.Resolve());

            if (myConditions.Count > 0)
            {

                TextEntity.AddSpace(mySB);

                mySB.Append(ANSI_SQL.WHERE);

                TextEntity.AddSpace(mySB);

                int colpos = 0;

                foreach (SQLCondition Condition in myConditions)
                {

                    mySB.Append(Condition.ToString());

                    if (colpos < myColumns.Count)
                    {

                        TextEntity.CommaS(mySB);

                        colpos++;

                    }

                }

            }

            mySB.Append(';');

        }

        public override string ToString()
        {
            return mySB.ToString();
        }

    }
}
