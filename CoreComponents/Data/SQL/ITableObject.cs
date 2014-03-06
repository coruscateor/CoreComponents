using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SQL
{
    public interface ITableObject : ISelectStatementObject
    {

        string TableSetName
        {

            get;

        }

    }
}
