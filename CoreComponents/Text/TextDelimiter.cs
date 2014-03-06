using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Text
{
    public static class TextDelimiter
    {

        public const string CommaSpace = ", ";

        public static void Delimit(StringBuilder TheSB, char TheDelimiter, IEnumerable<string> TheExpressions)
        {

            IEnumerator<string> Items = TheExpressions.GetEnumerator();

            if (Items.MoveNext())
            {

                TheSB.Append(Items.Current);

                while (Items.MoveNext())
                {

                    TheSB.Append(TheDelimiter);

                    TheSB.Append(Items.Current);

                }

            }

        }

        public static void Delimit(StringBuilder TheSB, string TheDelimiter, IEnumerable<string> TheExpressions)
        {

            IEnumerator<string> Items = TheExpressions.GetEnumerator();

            if (Items.MoveNext())
            {

                TheSB.Append(Items.Current);

                while (Items.MoveNext())
                {

                    TheSB.Append(TheDelimiter);

                    TheSB.Append(Items.Current);

                }

            }

        }

        public static void CommaSpaceDelimit(StringBuilder TheSB, IEnumerable<string> TheExpressions)
        {

            Delimit(TheSB, CommaSpace, TheExpressions);

        }

        public static string CommaSpaceDelimit(IEnumerable<string> TheExpressions)
        {

            StringBuilder SB = new StringBuilder();

            Delimit(SB, CommaSpace, TheExpressions);

            return SB.ToString();

        }

        public static void CommaSpaceDelimit(StringBuilder TheSB, params string[] TheExpressions)
        {

            Delimit(TheSB, CommaSpace, TheExpressions);

        }

        public static string CommaSpaceDelimit(params string[] TheExpressions)
        {

            StringBuilder SB = new StringBuilder();

            Delimit(SB, CommaSpace, TheExpressions);

            return SB.ToString();

        }

    }

}
