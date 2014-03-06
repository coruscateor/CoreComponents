using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.ComponentModel;
using CoreComponents.Items;

namespace CoreComponents.Data
{
    public interface ICommandProperties
    {

        string CommandText { get; }

        int CommandTimeout { get; }

        CommandType CommandType { get; }

        //public IDbConnection Connection { get; }

        //public IDataParameterCollection ParameterCollection { get; }

        //public ReadOnlyList<object> ParameterCollection { get; }

        //object[] ParameterCollection { get; }

        Dictionary<string,  object> ParameterCollection { get; }

        //public IDbTransaction Transaction { get; }

        UpdateRowSource UpdatedRowSource { get; }

        CommandResultType CommandResultType { get; }

        CommandBehavior CommandBehavior { get; }

    }
}
