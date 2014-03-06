using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{
    public static class ExceptionMessageStacker
    {

        static int i = 1;

        public static string Stack(Exception e)
        {

            return StackException(e, new StringBuilder()).ToString();

        }

        public static string GetLowest(Exception e)
        {

            if (e != null)
            {

                if (e.InnerException != null)
                {

                    return GetLowest(e.InnerException);

                } else
                {

                    return e.Message;

                }


            } 

        return "null";

        }

        static StringBuilder StackException(Exception e, StringBuilder SB)
        {
            
            if (e != null)
            {

                SB.Append(i + ": " + e.Message + "\r\n\r\n");

                i++;

                StackException(e.InnerException, SB);

            }

            i = 1;

            return SB;

        }

    }
}
