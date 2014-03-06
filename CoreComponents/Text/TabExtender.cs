using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Text
{

    public static class TabExtender
    {

        public static string Append(string TheValue)
        {

            return TheValue + "\t";

        }

        public static string Prepend(string TheValue)
        {

            return "\t" + TheValue;

        }

    }

}
