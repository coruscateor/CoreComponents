using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Text
{
    
    public static class SBsAndArrays //: IToArray<char>
    {

        public static char[] ToArray(StringBuilder TheSB)
        {

            if(TheSB.Length > 0)
            {

                char[] Chars = new char[TheSB.Length];

                for(int i = 0; i < TheSB.Length; ++i)
                {

                    Chars[i] = TheSB[i];

                }

                return Chars;

            }
            else
            {

                return new char[0];

            }

        }

        public static bool ContentEquals(char[] TheChars, StringBuilder TheSB)
        {

            if(TheChars.Length < 1)
                return false;

            if(TheChars.Length == TheSB.Length)
            {

                for(int i = 0; TheChars.Length > 0; ++i)
                {

                    if(TheChars[i] != TheSB[i])
                        return false;

                }

                return true;

            }

            return false;

        }

        public static bool ContentEquals(string TheString, StringBuilder TheSB)
        {

            if(TheString.Length < 1)
                return false;

            if(TheString.Length == TheSB.Length)
            {

                for(int i = 0; TheString.Length > 0; ++i)
                {

                    if(TheString[i] != TheSB[i])
                        return false;

                }

                return true;

            }

            return false;

        }

        public static bool ContentEquals(string TheString, char[] TheChars)
        {

            if(TheString.Length < 1)
                return false;

            if(TheString.Length == TheChars.Length)
            {

                for(int i = 0; TheString.Length > 0; ++i)
                {

                    if(TheString[i] != TheChars[i])
                        return false;

                }

                return true;

            }

            return false;

        }
        
        /*
        public char[] ToArray()
        {

            throw new NotImplementedException();

        }
        */

    }

}
