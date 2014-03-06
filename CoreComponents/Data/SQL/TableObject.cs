using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SQL
{
    public class TableObject : SelectStatementObject, ITableObject
    {

        //bool IsPartOfTableSet;

        string myTableSetName;

        public TableObject(string TheValue) : base(TheValue) 
        {
        }

        public TableObject(string TheValue, string TheAlias)
            : base(TheValue,TheAlias)
        {
        }

        public TableObject(string TheValue, string TheAlias, string TheTableSetName)
            : base(TheValue, TheAlias)
        {

            myTableSetName = TheTableSetName;

        }

        public string TableSetName 
        {

            get
            {

                return myTableSetName;

            }

        }

        //public string IsSelectStatement

    }
}
