using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements
{
    
    public class DbSelectAllFromTable
    {

        protected DbTable myTable;

        protected List<DbSelectCondition> myConditions;

        public DbSelectAllFromTable()
        {
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

        public void RemoveTable()
        {

            myTable = null;

        }

        public List<DbSelectCondition> Conditions
        {

            get
            {

                return myConditions;

            }

        }

    }

}
