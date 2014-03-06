using System;
using System.Data;
using System.Configuration;
using System.Web.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for WebConnectionStringExtractor
/// </summary>
public class WebConnectionStringExtractor
{

    string _Location;

    string _connstr;

    public WebConnectionStringExtractor() { 
    
    
    }

	public WebConnectionStringExtractor(string Location, string connstr)
	{

        _Location = Location;

        _connstr = connstr;

	}

    public string CfgLocation {

        get {

            return _Location;
        
        }

        set {

            _Location = value;

        }
    
    }

    public string ConString {


        get
        {

            return _connstr;

        }

        set
        {

            _connstr = value;

        }
    
    
    }

    public string fetch() {


//        Configuration rootWebConfig = WebConfigurationManager.OpenWebConfiguration(_Location);
//
//        ConnectionStringSettings CS = rootWebConfig.ConnectionStrings.ConnectionStrings[_connstr];
//
//        return CS.ConnectionString;

		return " ";
    }



}
