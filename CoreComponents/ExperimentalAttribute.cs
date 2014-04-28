using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents
{
    
    public class ExperimentalAttribute : Attribute
    {

        protected string myMessage;

        public ExperimentalAttribute()
        {

            myMessage = "";

        }

        public ExperimentalAttribute(string TheMessage)
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

    }

}
