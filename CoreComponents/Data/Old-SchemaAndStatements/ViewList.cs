using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Items;

namespace CoreComponents.Data.SchemaAndStatements
{

    public class ViewList : ParentedList<DbDatabase, DbView> //UniqueParentedNamedList<DbSchema, DbView>
    {

        public ViewList(DbDatabase Parent)
            : base(Parent)
        {
        }

    }

}
