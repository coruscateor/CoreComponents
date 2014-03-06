using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;

namespace CoreComponents.Data.Tables.Npgsql
{
    public interface INpgsqlTableManager
    {

        NpgsqlCommand Command
        {

            get;
            set;

        }

        NpgsqlConnection Connection
        {

            get;

        }

        NpgsqlParameterCollection CommandParameters
        {

            get;

        }
    }
}
