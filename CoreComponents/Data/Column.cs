using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data
{
    
    public class Column
    {

        protected string myName;

        protected Type myType;

        public static Column Create<T>(string TheName)
        {

            return new Column(TheName, typeof(T));

        }

        public Column(string TheName)
        {

            myName = TheName;

            myType = typeof(object);

        }

        public Column(string TheName, Type TheType)
        {

            myName = TheName;

            myType = TheType;

        }

        public string Name
        {

            get
            {

                return myName;

            }
            set
            {

                myName = value;

            }

        }

        public Type Type
        {

            get
            {

                return myType;

            }
            set
            {

                myType = value;

            }

        }

    }

}
