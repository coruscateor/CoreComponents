using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Text
{
    
    public static class SpaceExtender
    {

        public static string Append(string TheValue)
        {

            return TheValue + " ";

        }

        public static string Prepend(string TheValue)
        {

            return " " + TheValue;

        }

    }

}
