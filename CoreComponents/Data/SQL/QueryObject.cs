using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SQL
{
    public class QueryObject : SelectStatementObject //, IQueryObject
    {

        protected TableObject myFromTable; //TableObject

        protected OrderBy myOrderBy;

        public QueryObject(string TheValue, TableObject TheFromTable, string TheAlias = "", OrderBy TheOrderBy = OrderBy.Null) 
        {

            myValue = TheValue;

            myFromTable = TheFromTable;

            myAlias = TheAlias;

            myOrderBy = TheOrderBy;

        }

        /*
        public override string ToString()
        {

            if (HasAlias) 
            {

                return myName + " AS " + myAlias; 

            }

            return myName;
        }
        */


        public virtual bool IsTypeof<TQueryObject>() where TQueryObject : IQueryObject
        {

            return GetType() == typeof(TQueryObject);

        }


        public TableObject FromTable
        {
            get 
            {
 
                return myFromTable;

            }

        }
    }

    public enum OrderBy 
    {

        Null,
        ASC,
        DESC

    }

}
