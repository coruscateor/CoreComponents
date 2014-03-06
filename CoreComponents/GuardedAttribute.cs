using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property)]
    public class GuardedAttribute : Attribute
    {

        protected string myMessage;

        public GuardedAttribute()
        {

            myMessage = "";

        }

        public GuardedAttribute(string TheMessage)
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