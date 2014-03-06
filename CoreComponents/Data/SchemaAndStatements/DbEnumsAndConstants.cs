using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements
{

    public enum ConstraintType
    {

        Column,
        Table,
        Both

    }

    public static class ColumnNames
    {

        public const string Id = "Id";

        public const string Name = "Name";

    }

}
