using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Items;

namespace CoreComponents.Data.SchemaAndStatements
{

    public class ProceduresList : ParentedList<DbDatabase, DbProcedure>  //UniqueParentedNamedList<DbSchema, DbProcedure>
    {

        public ProceduresList(DbDatabase Parent)
            : base(Parent)
        {
        }

    }

}
