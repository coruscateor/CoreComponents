using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements.SQL
{

    public interface IAlterTableStatementWriter : ITerminateStatement
    {

        string ReNameTable(DbTable TheTable);

        string AddColumn(DbColumn TheColumn);

    }

}
