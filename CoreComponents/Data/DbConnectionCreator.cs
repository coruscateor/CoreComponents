using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace CoreComponents.Data
{
    public abstract class DbConnectionCreator
    {

        public DbConnectionCreator() 
        {
        }

        public abstract DbConnection CreateNewDbConnection();

    }
}
