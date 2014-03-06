/*
using System;
//using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;

/// <summary>
/// Summary description for SessionIntTracking
/// </summary>
public class SessionIntTracking : IHttpModule
{

    HttpApplication app;
	
    PosgresqlSessionLogger Logger;

	public SessionIntTracking()
	{
        
	}

    public void Init(HttpApplication context)
    {

        Logger = new PosgresqlSessionLogger();

        app = context;
        app.PreRequestHandlerExecute += new EventHandler(app_PreRequestHandlerExecute);
    }

    void app_PreRequestHandlerExecute(object sender, EventArgs e)
    {

        HttpContext Context = app.Context;

        if (Context.Session != null)
        {

            if (Context.Session.IsNewSession)
            {

                Logger.ExtractItems(Context);

                Logger.Log();

            }

        }
    }

    public void Dispose()
    {

        app.PreRequestHandlerExecute -= (EventHandler)app_PreRequestHandlerExecute;

    }

}
 * */
