using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements
{

    public class DbSelect<TJoinOperation, TCondition> where TCondition : IDbCondition
    {

        protected DistinctOrAll myDistinctOrAll = DistinctOrAll.Default;

        protected List<DbColumn> myQueryColumns = new List<DbColumn>();

        protected TJoinOperation myJoinOperation;

        protected List<TCondition> myConditions;

        protected List<DbColumn> myGroupByList = new List<DbColumn>();

        protected TCondition myHavingCondition;

        public DbSelect()
        {
        }

        public DistinctOrAll DistinctOrAll
        {

            get
            {

                return myDistinctOrAll;

            }
            set
            {

                myDistinctOrAll = value;

            }

        }

        public List<DbColumn> QueryColumns
        {

            get
            {

                return myQueryColumns;

            }

        }

        public bool HasColumns
        {

            get
            {

                return myQueryColumns.Count > 0;

            }

        }

        public TJoinOperation JoinOption
        {

            get
            {

                return myJoinOperation;

            }
            set
            {

                myJoinOperation = value;

            }

        }

        public List<TCondition> Conditions
        {

            get
            {

                return myConditions;

            }

        }

        public List<DbColumn> GroupByList
        {

            get
            {

                return myGroupByList;

            }

        }

        public TCondition HavingCondition
        {

            get
            {

                return myHavingCondition;

            }
            set
            {

                myHavingCondition = value;

            }

        }

        public bool HasHavingCondition
        {

            get
            {

                return !object.Equals(myHavingCondition, default(TCondition));

            }

        }

        public void RemoveHavingCondition()
        {

            myHavingCondition = default(TCondition);

        }

    }

    public enum DistinctOrAll
    {
        Default,
        Distinct,
        All

    }

}
