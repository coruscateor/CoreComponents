using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Data
{

    public class NameAttribute : Attribute
    {

        public NameAttribute(string TheName)
        {

            Name = TheName;

        }

        public string Name
        {

            get;
            protected set;

        }

    }

}
