using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements
{

    public class DbUniqueTableConstraint : DbConstraint
    {

        List<DbColumn> myColumns = new List<DbColumn>();

        public DbUniqueTableConstraint()
        { 
        }

        public DbUniqueTableConstraint(IEnumerable<DbColumn> TheColumns)
        {

            myColumns.AddRange(TheColumns);

        }

        public DbUniqueTableConstraint(params DbColumn[] TheColumns)
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

    }

}
