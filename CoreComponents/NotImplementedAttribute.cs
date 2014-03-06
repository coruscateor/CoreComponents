using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property)]
    public class NotImplementedAttribute : Attribute
    {

        protected string myMessage;

        public NotImplementedAttribute()
        {

            myMessage = "";

        }

        public NotImplementedAttribute(string TheMessage)
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
