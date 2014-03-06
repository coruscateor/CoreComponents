using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    public struct HexadecimalConverter
    {

        public string ToHexadecimalCharString(string TheValue)
        {

            return "\\" + TheValue;

        }

        public string ToHexadecimalCharString(byte TheValue)
        {

            if(TheValue > 8)
            {

                int NumberOfTens = TheValue / 16;

                int Number = NumberOfTens * 10;

                Number += TheValue % 8;

                return "\\" + Number;

            }
            else
            {

                return "\\" + GetHexadeicmal(TheValue); ;

            }

        }

        public string ToHexadecimalCharString(int TheValue)
        {

            if(TheValue > 8)
            {

                int NumberOfTens = TheValue / 16;

                int Number = NumberOfTens * 10;

                Number += TheValue % 16;

                return "\\" + Number;

            }
            else
            {

                return "\\" + GetHexadeicmal((byte)TheValue);

            }

        }

        char GetHexadeicmal(byte TheValue)
        {

            if(TheValue == 0)
            {

                return '0';

            }

            else if(TheValue == 1)
            {

                return '1';

            }
            else if(TheValue == 2)
            {

                return '2';

            }
            else if(TheValue == 3)
            {

                return '3';

            }
            else if(TheValue == 4)
            {

                return '4';

            }
            else if(TheValue == 5)
            {

                return '5';

            }
            else if(TheValue == 6)
            {

                return '6';

            }
            else if(TheValue == 7)
            {

                return '7';

            }
            else if(TheValue == 8)
            {

                return '8';

            }
            else if(TheValue == 9)
            {

                return '9';

            }
            else if(TheValue == 10)
            {

                return 'A';

            }
            else if(TheValue == 11)
            {

                return 'B';

            }
            else if(TheValue == 12)
            {

                return 'C';

            }
            else if(TheValue == 13)
            {

                return 'D';

            }
            else if(TheValue == 14)
            {

                return 'E';

            }
            else if(TheValue == 15)
            {

                return 'F';

            }

            throw new Exception("The provided value is either blow 0 or above 16");

        }

        public char ToHexadecimalChar(string TheValue)
        {

            return Convert.ToChar("\\" + TheValue);

        }

        public char ToHexadecimalChar(byte TheValue)
        {

            return Convert.ToChar(ToHexadecimalCharString(TheValue));

        }

        public char ToHexadecimalChar(int TheValue)
        {

            return Convert.ToChar(ToHexadecimalCharString(TheValue));

        }

    }

}
