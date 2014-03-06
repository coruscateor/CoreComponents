using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements
{

    public interface ISystemDatabaseTypes
    {

        Type GetSystemType(string TheDatabaseType);

        string GetDatabaseType(Type TheDatabaseType);

        string GetDatabaseType(DbColumn TheColumn);

    }

}
