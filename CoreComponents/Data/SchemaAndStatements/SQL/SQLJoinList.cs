using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements.SQL
{

    public class SQLJoinList
    {

        protected DbTable myInitalTable;

        protected List<SQLJoin> myJoins = new List<SQLJoin>();

        public SQLJoinList()
        {
        }

        public DbTable InitalTable
        {

            get
            {

                return myInitalTable;

            }
            set
            {

                myInitalTable = value;

            }
 
        }

        public List<SQLJoin> Joins
        {

            get
            {

                return myJoins;

            }

        }

    }

}
