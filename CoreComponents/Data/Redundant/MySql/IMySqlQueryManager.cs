using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for ICRUDMySql
/// </summary>
/// 

namespace CoreComponents.Data.Tables.MySql
{


    public interface IMySqlQueryManager : IQueryManager
    {

        MySqlConnection CommandConnection
        {

            get;
            set;

        }

        MySqlCommand Command
        {

            get;
            set;

        }

        MySqlParameterCollection CommandParameters
        {

            get;

        }

        MySqlDataReader GetDataReader();

    }

}
