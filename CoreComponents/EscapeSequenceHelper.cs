using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    public static class EscapeSequenceHelper
    {

        public static string GetOctalASCIICharString(string Value)
        {

            return @"\\" + Value;

        }

        public static string GetOctalASCIICharString(object Value)
        {

            return @"\\" + Value;

        }

        //public string GetOctalASCIICharString(ushort Value)
        //{

        //    return @"\\" + Value;

        //}

        //public char GetOctalASCIIChar(ushort Value)
        //{

        //    return Convert.ToChar(@"\\" + GetOctalASCIICharString(Value));
            
        //}

        public static string GetOctOrHexASCIICharString(string Value)
        {

            return @"\\x" + Value;

        }

        public static string GetOctOrHexASCIICharString(object Value)
        {

            return @"\\x" + Value;

        }

        //public string GetOctOrHexASCIICharString(byte Value)
        //{

        //    return @"\\x" + Value;

        //}

        public static char GetOctOrHexASCIIChar(string Value)
        {

            return Convert.ToChar(@"\\x" + GetOctOrHexASCIICharString(Value));

        }

        public static char GetOctOrHexASCIIChar(object Value)
        {

            return Convert.ToChar(@"\\x" + GetOctOrHexASCIICharString(Value));

        }

    }

}
