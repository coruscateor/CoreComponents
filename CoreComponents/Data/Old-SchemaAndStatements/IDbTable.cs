using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements
{
    public interface IDbTable
    {

        string Name
        {

            get;
            set;

        }

        string Description
        {

            get;
            set;

        }

        List<DbColumn> Columns
        {
            get;

        }

    }
}