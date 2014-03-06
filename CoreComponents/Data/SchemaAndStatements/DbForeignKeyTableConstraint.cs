using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements
{
    
    public class DbForeignKeyTableConstraint
    {

        protected List<DbColumn> myColumns = new List<DbColumn>();

        protected ForeignKeyMatching myForeignKeyMatching = ForeignKeyMatching.Default;

        protected RowChangeAction myRowChangeAction = RowChangeAction.Default;

        protected Deferablity myDeferablity = Deferablity.Default;

        public DbForeignKeyTableConstraint()
        {
        }

        public DbForeignKeyTableConstraint(IEnumerable<DbColumn> TheColumns)
        {

            myColumns.AddRange(TheColumns);

        }

        public DbForeignKeyTableConstraint(params DbColumn[] TheColumns)
        {

            myColumns.AddRange(TheColumns);

        }

        public List<DbColumn> Columns
        {

            get
            {

                return myColumns;

            }

        }

        public bool HasColumns
        {

            get
            {

                return myColumns.Count > 0;

            }

        }

        public ForeignKeyMatching ForeignKeyMatching
        {

            get
            {

                return myForeignKeyMatching;

            }

        }

        public RowChangeAction RowChangeAction
        {

            get
            {

                return myRowChangeAction;

            }

        }

        public Deferablity Deferablity
        {

            get
            {

                return myDeferablity;

            }

        }

    }

}
