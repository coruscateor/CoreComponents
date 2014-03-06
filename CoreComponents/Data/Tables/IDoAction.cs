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

/// <summary>
/// Summary description for IDoAction
/// </summary>
/// 

namespace CoreComponents.Data.Tables
{

    public interface IDoAction
    {

        void DoAction();

        //PageAction ActionType
        //{

        //    get;
        //    set;

        //}
    }

    public enum PageAction
    {

        INSERT,
        UPDATE,
        DROP

    }

}
