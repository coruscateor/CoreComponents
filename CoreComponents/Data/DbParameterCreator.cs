using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace CoreComponents.Data
{

    public abstract class DbParameterCreator
    {

        public DbParameterCreator() 
        {
        }

        public abstract DbParameter CreateNewDbParameter();

        //public abstract DbParameter CreateNewDbParameter(string ParameterName, object Value);

        //DbType DbType
        //ParameterDirection Direction
        //bool IsNullable
        //string ParameterName
        //int Size
        //string SourceColumn
        //bool SourceColumnNullMapping
        //DataRowVersion SourceVersion 
        //object Value

    }

}
