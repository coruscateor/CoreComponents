using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents;
using CoreComponents.Data;

namespace CoreComponents.Data.Npgsql
{
    public class NpgsqlChildConnectionStringBuilder : NpgsqlConnectionStringBuilder, IReadonlyChild<IHasAConnectionString>
    {

        IHasAConnectionString _Parent;

        public NpgsqlChildConnectionStringBuilder(IHasAConnectionString TheParent)
        {

            _Parent = TheParent;

        }


        #region IReadOnlyChild<IHasAConnectionString> Members

        public IHasAConnectionString Parent
        {
            get
            {
                return _Parent;
            }
        }

        #endregion

        void SetParentCS()
        {

            _Parent.ConnectionString = ToString();

        }

    }
}
