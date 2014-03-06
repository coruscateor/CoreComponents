using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements
{

    public class DbDatabase : DbEntity
    {

        public DbDatabase()
        {
        }

        public DbDatabase(string TheName)
            : base(TheName)
        {
        }

    }

}
