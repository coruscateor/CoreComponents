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
using Npgsql;

/// <summary>
/// Summary description for ICRUDNpgsql
/// </summary>
/// 

namespace CoreComponents.Data.Tables.Npgsql
{


    public interface INpgsqlQueryManager : IQueryManager
    {

        NpgsqlConnection CommandConnection
        {

            get;
            set;

        }

        NpgsqlCommand Command
        {

            get;
            set;

        }

        NpgsqlParameterCollection CommandParameters
        {

            get;

        }

        NpgsqlDataReader GetDataReader();

    }



    /*
    public interface INpgsqlQueryManager 
        : IQueryManager<NpgsqlDataReader, NpgsqlDataAdapter, NpgsqlCommand, NpgsqlConnection, NpgsqlParameter, NpgsqlParameterCollection>
    {

        //NpgsqlDataReader GetDataReader();

    }
    */
}
