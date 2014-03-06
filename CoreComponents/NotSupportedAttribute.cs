using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property)]
    public class NotSupportedAttribute : Attribute
    {

        protected string myMessage;

        public NotSupportedAttribute()
        {

            myMessage = "";

        }

        public NotSupportedAttribute(string TheMessage)
        {

            myMessage = TheMessage;

        }

        public string Message
        {

            get 
            {

                return myMessage;
                
            }

        }

        public bool HasMessage
        {

            get
            {

                return myMessage.Length > 0;

            }

        }

    }

}
