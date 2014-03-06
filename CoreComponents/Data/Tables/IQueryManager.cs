using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Summary description for ICRUDManager
/// </summary>
/// 

namespace CoreComponents.Data
{


    public interface IQueryManager
    {

        DataTable GetTable();

        int CommandTimeOut
        {
            get;
            set;
        }

        int ExecuteNonQuery();

        T ExecuteScalar<T>();

    }

}







