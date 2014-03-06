using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents
{

    public static class DefaultValues
    {

        //http://msdn.microsoft.com/en-us/library/83fhsxwc.aspx

        public static readonly bool Bool = false;

        public static readonly byte Byte = 0;

        public static readonly char Char = '\0';

        public static readonly decimal Decimal = 0.0M;

        public static readonly double Double = 0.0D;

        public static readonly float Float = 0.0F;

        public static readonly int Int = 0;

        public static readonly long Long = 0L;

        public static readonly sbyte Sbyte = 0;

        public static readonly short Short = 0;

        public static readonly uint Uint = 0;

        public static readonly ulong Ulong = 0;

        public static readonly ushort Ushort = 0;

        public static void SetDefault(ref bool TheItem)
        {

            TheItem = Bool;

        }

        public static void SetDefault(ref byte TheItem)
        {

            TheItem = Byte;

        }

        public static void SetDefault(ref char TheItem)
        {

            TheItem = Char;

        }

        public static void SetDefault(ref decimal TheItem)
        {

            TheItem = Decimal;

        }

        public static void SetDefault(ref double TheItem)
        {

            TheItem = Double;

        }

        public static void SetDefault(ref float TheItem)
        {

            TheItem = Float;

        }

        public static void SetDefault(ref int TheItem)
        {

            TheItem = Int;

        }

        public static void SetDefault(ref long TheItem)
        {

            TheItem = Long;

        }

        public static void SetDefault(ref sbyte TheItem)
        {

            TheItem = Sbyte;

        }

        public static void SetDefault(ref short TheItem)
        {

            TheItem = Short;

        }

        public static void SetDefault(ref uint TheItem)
        {

            TheItem = Uint;

        }

        public static void SetDefault(ref ulong TheItem)
        {

            TheItem = Ulong;

        }

        public static void SetDefault(ref ushort TheItem)
        {

            TheItem = Ushort;

        }

    }

}
