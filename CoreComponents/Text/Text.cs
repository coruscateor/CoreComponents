using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Text
{

    public static class Text
    {

        public const char AT = '@';

        public const char SemiColon = ';';

        public const char Colon = ':';

        public const char Quotes = '"';

        public const char Quote = '\'';

        public const char LeftBracket = '(';

        public const char RightBracket = ')';

        public const char LeftCurlyBracket = '{';

        public const char RightCurlyBraket = '}';

        public const char LeftSquareBracket = '[';

        public const char RightSquareBraket = ']';

        public const char Comma = ',';

        public const char Dot = '.';

        public const char QuestionMark = '?';

        public const char LeftLine = '/';

        public const string constQuote = "\"";

        public const string constLine = "\n";

        public const string constLineCr = "\r\n";

        public const char Space = ' ';

        public static string CapitaliseFirstLetter(string TheItem)
        {

            char FirstChar = TheItem[0];

            char FirstCharToUpper = char.ToUpper(FirstChar);

            if(FirstChar == FirstCharToUpper)
                return TheItem;

            if(TheItem.Length < 2)
            {

                return new string(char.ToUpper(FirstCharToUpper), 1);

            }

            StringBuilder SB = StringBuilderPool.FetchOrCreate();

            try
            {

                SB.Append(char.ToUpper(FirstCharToUpper));

                for(int i = 1; i < TheItem.Length; ++i)
                {

                    SB.Append(TheItem[i]);

                }

                return SB.ToString();

            }
            finally
            {

                StringBuilderPool.Put(SB);

            }

        }

    }

}
