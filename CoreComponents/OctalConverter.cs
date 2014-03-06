using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    public static class OctalConverter
    {

        public static string ToOctalCharString(string TheValue)
        {

            return "\\" + TheValue;

        }

        public static string ToOctalCharString(byte TheValue)
        {

            if(TheValue > 8)
            {

                int NumberOfTens = TheValue / 8;

                int Number = NumberOfTens * 10;

                Number += TheValue % 8;

                return "\\" + Number;

            }
            else
            {

                return "\\" + TheValue;

            }

        }

        public static string ToOctalCharString(int TheValue)
        {

            if(TheValue > 8)
            {

                int NumberOfTens = TheValue / 8;

                int Number = NumberOfTens * 10;

                Number += TheValue % 8;

                return "\\" + Number;

            }
            else
            {

                return "\\" + TheValue;

            }

        }

        public static char ToOctalChar(string TheValue)
        {

            return Convert.ToChar("\\" + TheValue);

        }

        public static char ToOctalChar(byte TheValue)
        {

            return Convert.ToChar(ToOctalCharString(TheValue));

        }

        public static char ToOctalChar(int TheValue)
        {

            return Convert.ToChar(ToOctalCharString(TheValue));

        }

    }

}
