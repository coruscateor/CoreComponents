using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents
{
    
    public class NOTICEAttribute : Attribute
    {

        protected string myMessage;

        public NOTICEAttribute(string TheMessage)
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
