using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents
{
    
    public class InfrastructureAttribute : Attribute
    {

        protected string myMessage;

        public InfrastructureAttribute()
        {

            myMessage = "";

        }

        public InfrastructureAttribute(string TheMessage)
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
