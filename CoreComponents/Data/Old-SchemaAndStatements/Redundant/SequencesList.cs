using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Items;

namespace CoreComponents.Data.SchemaAndStatements
{

    public class SequencesList : ParentedList<DbDatabase, DbSequence> //UniqueParentedNamedList<DbSchema, DbProcedure>
    {

        public SequencesList(DbDatabase Parent)
            : base(Parent)
        {
        }

    }

}
