using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace CoreComponents.Data.Tables.MySql
{
    public interface IMySqlTableManager
    {

        MySqlCommand Command
        {

            get;
            set;

        }

        MySqlConnection Connection
        {

            get;

        }

        MySqlParameterCollection CommandParameters
        {

            get;

        }
    }
}
