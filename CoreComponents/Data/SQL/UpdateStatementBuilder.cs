using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace CoreComponents.Data.SQL
{
    public abstract class UpdateStatementBuilder<TParamter> where TParamter : DbParameter
    {

        //public event Action<ErrorEventArgs<object>> Error;

        //protected string myTable;

        protected StringBuilder mySB = new StringBuilder();

        //public const string UPDATE = "UPDATE";

        //public const string SET = "SET";

        //public const string WHERE = "WHERE";

        public UpdateStatementBuilder() 
        {
        }

        protected void OnError(string TheMessage)
        {

            //if (Error != null)
            //{

            //    Error(new ErrorEventArgs<object>(this, TheMessage));

            //}

        }

        public abstract string Update(string TheTable, TParamter[] TheParamters);

        //public abstract string Genrate(string TheTable, IDictionary<string, TParamter> TheAliasesAndParamters);

        //public abstract string Genrate(string TheTable, IDictionary<string, object> TheColumnsAndValues);

    }
}
