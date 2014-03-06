using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CoreComponents.Data
{

    public class DbTypeTranslator : IDbTypeTranslator
    {

        public DbTypeTranslator()
        {
        }

        public virtual Type GetTypeFor(DbType TheDbType)
        {

            return SystemTypesAndDbTypes.GetTypeFor(TheDbType);

        }

        public virtual DbType GetDbTypeFor<T>()
        {

            return SystemTypesAndDbTypes.GetDbTypeFor<T>();

        }

        public virtual DbType GetDbTypeFor(object TheObject)
        {

            return SystemTypesAndDbTypes.GetDbTypeFor(TheObject);

        }

        public virtual DbType GetDbTypeFor(Type TheType)
        {

            return SystemTypesAndDbTypes.GetDbTypeFor(TheType);

        }

    }

}
