using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data
{
    public class SQLParameter
    {

        protected string myName;

        protected object myValue;

        public SQLParameter(string TheName, object TheValue) 
        {

            myName = TheName;

            myValue = TheValue;

        }

        public string Name
        {

            get 
            {

                return myName;

            }

        }

        public object Value 
        {

            get 
            {

                return myValue;

            }

        }

    }
}
