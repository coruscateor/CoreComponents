using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements
{

    public interface ITypesAndSystemTypes
    {

        string GetTypeFor<T>();

        string GetTypeFor(Type TheType);

        string GetTypeFor(object TheObject);

        Type GetPreferredTypeFor(string TheDatabaseType);

    }

}
