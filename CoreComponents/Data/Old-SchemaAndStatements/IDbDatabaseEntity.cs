using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements
{

    public interface IDbDatabaseEntity
    {

        DbDatabase Parent
        {

            get;
            set;

        }

    }

}
