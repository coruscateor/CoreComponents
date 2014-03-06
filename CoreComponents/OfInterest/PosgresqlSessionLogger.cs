/*
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
//using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;
//using Npgsql;

/// <summary>
/// Summary description for PosgresqlSessionLogger
/// </summary>
public class PosgresqlSessionLogger : ISessionLogger
{
    string UserHostAddress;
    string Browser;
    string BrowserVersion;
    bool IsCrawler;
    string Platform;
    DateTime Timestamp;
    string Application;

    public PosgresqlSessionLogger()
    {
    }

    public void ExtractItems(HttpContext context)
    {

        UserHostAddress = context.Request.UserHostAddress;
        Browser = context.Request.Browser.Browser;
        BrowserVersion = context.Request.Browser.Version;
        IsCrawler = context.Request.Browser.Crawler;
        Platform = context.Request.Browser.Platform;
        Timestamp = context.Timestamp;
		
		
        string path = context.Request.Path;

		try
		{
		
        path = path.Remove(path.IndexOf('/'), 1);

        int SecondIndex = path.IndexOf('/');

        int Remainder = path.Length - SecondIndex;

        path = path.Remove(SecondIndex, Remainder);
			
		} 
		catch
		{
		
			path = "Total";
			
		}
		
        Application = path;

    }

    public List<string> Items()
    {
        List<string> TheItems = new List<string>();

        TheItems.Add(UserHostAddress);
        TheItems.Add(Browser);
        TheItems.Add(BrowserVersion);
        TheItems.Add(IsCrawler.ToString());
        TheItems.Add(Platform);
        TheItems.Add(Timestamp.ToString());
        TheItems.Add(Application);

        return TheItems;

    }

    public void Log()
    {
        Configuration rootWebConfig = WebConfigurationManager.OpenWebConfiguration("/" + Application);

        ConnectionStringSettings CS = rootWebConfig.ConnectionStrings.ConnectionStrings["LocalPosgresqlServer"];

        NpgsqlConnection conn = new NpgsqlConnection(CS.ConnectionString);

        try
        {

            NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO workwebsite.simpleaspsessionlist (userhostaddress, browser, browserversion, iscrawler, platform, timestamp, application) VALUES ( @UserHostAddress, @Browser, @BrowserVersion, @IsCrawler, @Platform, @Timestamp, @Application)", conn);

            conn.Open();

            cmd.Parameters.Add("@UserHostAddress", UserHostAddress);
            cmd.Parameters.Add("@Browser", Browser);
            cmd.Parameters.Add("@BrowserVersion", BrowserVersion);
            cmd.Parameters.Add("@IsCrawler", IsCrawler);
            cmd.Parameters.Add("@Platform", Platform);
            cmd.Parameters.Add("@Timestamp", Timestamp);
            cmd.Parameters.Add("@Application", Application);

            cmd.Prepare();

            cmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
        }
        finally
        {

            conn.Close();
        }
    }
}
*/