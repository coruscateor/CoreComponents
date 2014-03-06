using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CoreComponents.Data.SchemaAndStatements
{

    public interface IDbTypeTranslator
    {

        Type GetTypeFor(DbType TheDbType);

        DbType GetDbTypeFor<T>();

        DbType GetDbTypeFor(object TheObject);

        DbType GetDbTypeFor(Type TheType);

    }

}
