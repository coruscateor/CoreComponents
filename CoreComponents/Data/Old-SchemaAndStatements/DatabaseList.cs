using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Items;

namespace CoreComponents.Data.SchemaAndStatements
{

    public class DatabaseList : ParentedList<DbSchema, DbDatabase>
    {

        public DatabaseList(DbSchema Parent)
            : base(Parent)
        {
        }

    }

}
