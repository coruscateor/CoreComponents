using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements
{

    public class DbOrderBy : DbBaseOrderBy<DbOrderByValues>
    {

        public DbOrderBy()
        {

            myAsendingOrDecending = DbOrderByValues.Default;

        }

    }

    public enum DbOrderByValues
    {

        Ascending,
        Decending,
        Default

    }

}
