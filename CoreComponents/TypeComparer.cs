using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    public static class TypeComparer
    {

        public static bool Equals(object Object1, object Object2)
        {

            return Object1.GetType() == Object2.GetType();

        }

        public static bool Equals<T>(object TheObject)
        {

            return typeof(T) == TheObject.GetType();

        }

    }

}
