using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Items
{

    public static class ArrayValueChecker
    {

        public static bool Contains(object[] TheArray, object TheValue)
        {

            for(long i = 0; i < TheArray.LongLength; i++)
            {

                if(TheArray[i] == TheValue)
                    return true;

            }

            return false;

        }

        public static bool Contains(int[] TheArray, int TheValue)
        {

            for(long i = 0; i < TheArray.LongLength; i++)
            {

                if(TheArray[i] == TheValue)
                    return true;

            }

            return false;

        }

        public static bool Contains(char[] TheArray, char TheValue)
        {

            for(long i = 0; i < TheArray.LongLength; i++)
            {

                if(TheArray[i] == TheValue)
                    return true;

            }

            return false;

        }

        public static bool Contains<TValue>(TValue[] TheArray, TValue TheValue)
        {

            for(long i = 0; i < TheArray.LongLength; i++)
            {

                if(TheArray[i].Equals(TheValue))
                    return true;

            }

            return false;

        }

    }

    public static class ArrayValueChecker<TValue>
    {

        public static bool Contains(TValue[] TheArray, TValue TheValue)
        {

            for(long i = 0; i < TheArray.LongLength; i++)
            {

                if(TheArray[i].Equals(TheValue))
                    return true;

            }

            return false;

        }

        public static bool ValuesEqual(TValue[] TheArray1, TValue[] TheArray2)
        {

            if(TheArray1.LongLength != TheArray2.LongLength)
                return false;

            for(long i = 0; i < TheArray1.LongLength; i++)
            {

                if(!TheArray1[i].Equals(TheArray2[i]))
                    return false;

            }

            return true;

        }

    }

}
