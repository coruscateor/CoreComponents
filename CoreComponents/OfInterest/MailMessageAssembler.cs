using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using System.Xml.Linq;
using System.Text;

/// <summary>
/// Summary description for MessageProcessor
/// </summary>
///

public class MailMessageAssembler
{

    Dictionary<string, string> Items = new Dictionary<string, string>();

	public MailMessageAssembler()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void Add(string Title, string Contents) 
    {

        Add(Title, Contents, false);
    
    }

    public void Add(string Title, string Contents, bool SupressColon)
    {

        if (SupressColon)
        {

            Items.Add(Title, Contents);

        }
        else {

            Items.Add(Title + ":", Contents);
        
        }

    }

    public bool Remove(string Title)
    {

        return Items.Remove(Title);

    }

    public bool IsUnique(string Title)
    {

        lock (Items) 
        {
            
            int itemcount = 0;

            foreach (KeyValuePair<string, string> Field in Items) 
            {

                if (Title == Field.Key) {

                    itemcount++;

                    if (itemcount == 2)
                        return false;
                
                }
                            
            }

            return true; //Can return false positive if item isnt unique

        }

    }

    public bool IsInMessage(string Title) {

        return Items.ContainsKey(Title);
    
    }

    public override string ToString() {

        StringBuilder MessageContents = new StringBuilder();

        foreach (KeyValuePair<string, string> Field in Items)
        {

            MessageContents.AppendLine(Field.Key);
            MessageContents.AppendLine();
            MessageContents.AppendLine(Field.Value);
            MessageContents.AppendLine();

        }

        return MessageContents.ToString();
    
    }

}
