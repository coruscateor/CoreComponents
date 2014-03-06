using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Text
{
    public static class TextEntityDelimiter
    {

        public static void Delimit(StringBuilder SB, IEnumerable<string> Expressions)
        {

            lock (Expressions)
            {
                lock (SB)
                {

                    int Place = 1;

                    int Total = Expressions.Count();

                    foreach (string Expression in Expressions)
                    {

                        SB.Append(Expression);

                        if (Place < Total)
                        {

                            SB.Append(", ");

                            Place++;
                        }
                    }
                }
            }
        }

        public static void Delimit(StringBuilder SB, IList<string> Expressions)
        {
            lock (Expressions)
            {
                lock (SB)
                {

                    int Place = 1;

                    int Total = Expressions.Count;

                    foreach (string Expression in Expressions)
                    {

                        SB.Append(Expression);

                        if (Place < Total)
                        {

                            SB.Append(", ");

                            Place++;
                        }
                    }
                }
            }
        }

        public static void Delimit<T>(StringBuilder SB, IList<T> Expressions) where T : ITextEntity
        {

            lock (Expressions)
            {
                lock (SB)
                {

                    int Place = 1;

                    int Total = Expressions.Count;

                    foreach (T Expression in Expressions)
                    {

                        Expression.AppendTo(SB);

                        if (Place < Total)
                        {

                            SB.Append(", ");

                            Place++;
                        }
                    }

                }
            }

        }

        public static void DelimitL<T>(StringBuilder SB, IList<T> Expressions, string Indentation) where T : ITextEntity
        {

            lock (Expressions)
            {
                lock (SB)
                {

                    int Place = 1;

                    int Total = Expressions.Count;

                    foreach (T Expression in Expressions)
                    {

                        SB.Append(Indentation);

                        Expression.AppendTo(SB);

                        if (Place < Total)
                        {

                            SB.AppendLine(",");

                            Place++;
                        }
                    }

                    SB.AppendLine();

                }
            }


        }

    }
}
