using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Text.Extensions
{

    public static class StringExtensions
    {

        public static string Pluralise(this string str, int number)
        {

            if(number > 1)
            {

                if(!str.EndsWith("s", StringComparison.InvariantCultureIgnoreCase))
                {

                    if(char.IsUpper(str[str.Length - 1]))
                        return str + "S";

                    return str + 's';

                }

            }

            return str;

        }

        public static string UnPluralise(this string str, int number)
        {

            if(number < 2)
            {

                if(str.EndsWith("s", StringComparison.InvariantCultureIgnoreCase))
                {

                    return str.Remove(str.Length - 1);

                }

            }

            return str;

        }

        public static bool IsOnlyUppercase(this string str)
        {

            foreach(var item in str)
            {

                if(char.IsLower(item))
                    return false;

            }

            return true;

        }

    }

}
