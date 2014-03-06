using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SQL
{
    public interface ISelectStatementObject
    {

        string Value
        {

            get;

        }

        bool IsValid
        {

            get;

        }

        string Alias
        {

            get;

        }

        bool HasAlias
        {

            get;

        }

        bool IsSubQuery
        {

            get;

        }

    }
}
