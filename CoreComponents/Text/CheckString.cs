using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Text
{

    public static class CheckString
    {

        public static bool NotNull(string TheValue)
        {

            return TheValue != null && TheValue.Length > 0;

        }

        public static bool NotNull(LongString TheValue)
        {

            return TheValue != null && TheValue.Length > 0;

        }

    }

}
