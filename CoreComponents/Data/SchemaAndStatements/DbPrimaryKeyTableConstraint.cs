using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements
{

    public class DbPrimaryKeyTableConstraint : DbConstraint
    {

        protected List<DbColumn> myColumns = new List<DbColumn>();

        public DbPrimaryKeyTableConstraint()
        {
        }

        public List<DbColumn> Columns
        {

            get
            {

                return myColumns;

            }

        }

    }

}
