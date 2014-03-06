using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Text
{
    
    public static class StringCopier
    {

        //public StringCopier()
        //{ 
        //}

        public static void Copy(string StringFrom, out string StringTo)
        {

            StringTo = new string(StringFrom.ToCharArray());

        }

        public static void Copy(string StringFrom, int StartIndex, out string StringTo)
        {

            StringTo = new string(StringFrom.ToCharArray(StartIndex, StringFrom.Length - (StartIndex + 1)));

        }

        public static void Copy(string StringFrom, int StartIndex, int Length, out string StringTo)
        {

            StringTo = new string(StringFrom.ToCharArray(StartIndex, Length));

        }

        public static string Clone(string StringFrom)
        {

            return new string(StringFrom.ToCharArray());

        }

        public static string CastClone(string StringFrom)
        {

            return (string)StringFrom.Clone();

        }

    }

}
