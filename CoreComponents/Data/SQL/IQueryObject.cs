using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SQL
{
    public interface IQueryObject : ISelectStatementObject
    {

        ITableObject FromTable
        {

            get;

        }

        bool IsTypeof<TQueryObject>() where TQueryObject : IQueryObject;

    }
}
