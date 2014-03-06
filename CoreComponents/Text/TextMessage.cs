using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Text
{

    public interface ITextMessage : IHasMessage
    {

        DateTime LoggedAt
        {

            get;

        }
        
        /*
        string Contents
        {
        	
        	get;
        	
        }
        */

        string GetEntry();

    }

    public class TextMessage : ITextMessage
    {

        protected DateTime myLoggedAt;

        protected string myContents;

        public TextMessage(string theContents)
        {

            myLoggedAt = DateTime.Now;

            myContents = theContents;

        }

        public TextMessage(TextMessage OriginalMessage)
        {

            myLoggedAt = DateTime.Now; 

            myContents = OriginalMessage.Contents;

        }
        
        /*
        public TextMessage(string Message, DateTime LoggedAt)
        {

            myLoggedAt = LoggedAt;

            myContents = Message;

        }
		*/
		
        public DateTime LoggedAt
        {

            get
            {

                return myLoggedAt;

            }

        }

        public string Contents
        {

            get
            {

                return myContents;

            }

        }

        public virtual string GetEntry()
        {

            return myLoggedAt.ToString() + ": " + myContents;

        }

    }
}
