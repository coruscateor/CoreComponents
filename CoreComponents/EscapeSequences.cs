using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    public static class EscapeSequences
    {

        //From: http://msdn.microsoft.com/en-us/library/h21280bw.aspx

        public const string Bell = "\a";

        public const string Backspace = "\b";

        public const string Formfeed = "\f";

        public const string NewLine = "\n";

        public const string CarriageReturn = "\r";

        public const string HorizontalTab = "\t";

        public const string VerticalTab = "\v";

        public const string SingleQuotationMark = "\'";

        public const string DoubleQuotationMark = "\"";

        public const string Backslash = @"\\";

        public const string LiteralQuestionMark = @"\?";

        public const string OctalIndicator = @"\\x";

        //public static string GetOctalASCIICharacter(ushort Value)
        //{

        //    return "\\" + Value;

        //}

        //For ASCII Unicode and hexadecimal notation.

        //public static string GetOctalOrHexadecimalASCIICharacter(string Value)
        //{

        //    return "\\x" + Value;

        //}

    }

}
