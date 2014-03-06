using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    public static class CheckNull
    {

        public static bool Is(object TheValue)
        {

            return TheValue == null;

        }

        public static bool IsNot(object TheValue)
        {

            return TheValue != null;

        }

        public static bool IsDefault<TValue>(TValue TheValue)
        {

            return TheValue.Equals(default(TValue)); 

        }

        public static bool IsNotDefault<TValue>(TValue TheValue)
        {

            return !TheValue.Equals(default(TValue));

        }

        public static bool Is(object TheValue, Action<object> TheAction)
        {

            if(TheValue == null)
            {

                TheAction(TheAction);

                return true;

            }

            return false;

        }

        public static bool IsDefault<TValue>(TValue TheValue, Action<TValue> TheAction)
        {

            if(TheValue.Equals(default(TValue)))
            {

                TheAction(TheValue);

                return true;

            }

            return false;

        }

    }

}
