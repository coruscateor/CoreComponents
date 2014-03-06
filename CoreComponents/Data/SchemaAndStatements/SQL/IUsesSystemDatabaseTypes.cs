using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements.SQL
{

    public interface IUsesSystemDatabaseTypes
    {

        ISystemDatabaseTypes SystemDatabaseTypes
        {

            get;

        }

    }

}
