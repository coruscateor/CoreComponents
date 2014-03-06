using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Items;

namespace CoreComponents.Data.SchemaAndStatements
{

    public class TableList : ParentedList<DbDatabase, DbTable> //UniqueParentedNamedList<DbSchema, DbTable>
    {

        public TableList(DbDatabase Parent)
            : base(Parent)
        {
        }

    }

}
