using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Text
{

    public static class Strings
    {

        public static string Combine(string string1, string string2)
        {

            StringBuilder SB = new StringBuilder();

            SB.Append(string1).Append(string2);

            return SB.ToString();

        }

        public static string Combine(string string1, string string2, string string3)
        {

            StringBuilder SB = new StringBuilder();

            SB.Append(string1).Append(string2).Append(string3);

            return SB.ToString();

        }

        public static string Combine(string string1, string string2, string string3, string string4)
        {

            StringBuilder SB = new StringBuilder();

            SB.Append(string1).Append(string2).Append(string3).Append(string4);

            return SB.ToString();

        }

        public static string Combine(params string[] strings)
        {

            StringBuilder SB = new StringBuilder();

            foreach(var item in strings)
                SB.Append(item);

            return SB.ToString();

        }

        public static StringBuilder StartCombine(string string1, string string2)
        {

            StringBuilder SB = new StringBuilder();

            SB.Append(string1).Append(string2);

            return SB;

        }

        public static StringBuilder StartCombine(string string1, string string2, string string3)
        {

            StringBuilder SB = new StringBuilder();

            SB.Append(string1).Append(string2).Append(string3);

            return SB;

        }

        public static StringBuilder StartCombine(string string1, string string2, string string3, string string4)
        {

            StringBuilder SB = new StringBuilder();

            SB.Append(string1).Append(string2).Append(string3).Append(string4);

            return SB;

        }

        public static StringBuilder StartCombine(params string[] strings)
        {

            StringBuilder SB = new StringBuilder();

            foreach(var item in strings)
                SB.Append(item);

            return SB;

        }

    }

}
