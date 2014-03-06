using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements
{
    public class DbBaseOrderBy<TASCDESC> : DbHasExpressions
    {

        protected TASCDESC myAsendingOrDecending;

        public DbBaseOrderBy()
        {
        }

        public TASCDESC AsendingOrDecending
        {

            get
            {

                return myAsendingOrDecending;

            }
            set
            {

                myAsendingOrDecending = value;

            }

        }

    }

}
