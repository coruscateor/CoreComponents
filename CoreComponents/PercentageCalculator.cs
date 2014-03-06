using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    public static class PercentageCalculator
    {

        public static int GetInt16(short PartialValue, short WholeValue)
        {
            
            return (PartialValue / WholeValue) * 100;

        }

        public static string GetInt16String(short PartialValue, short WholeValue)
        {

            return GetInt16(PartialValue, WholeValue).ToString() + '%';

        }

        public static string GetInt16String(short PartialValue, short WholeValue, IFormatProvider TheFormatProvider)
        {

            return GetInt16(PartialValue, WholeValue).ToString(TheFormatProvider) + '%';

        }

        public static string GetInt16String(short PartialValue, short WholeValue, string TheFormat)
        {

            return GetInt16(PartialValue, WholeValue).ToString(TheFormat) + '%';

        }

        public static float GetSingle(short PartialValue, short WholeValue)
        {

            return (PartialValue / WholeValue) * 100f;

        }

        public static string GetSingleString(short PartialValue, short WholeValue)
        {

            return GetSingle(PartialValue, WholeValue).ToString() + '%';

        }

        public static string GetSingleString(short PartialValue, short WholeValue, IFormatProvider TheFormatProvider)
        {

            return GetSingle(PartialValue, WholeValue).ToString(TheFormatProvider) + '%';

        }

        public static string GetSingleString(short PartialValue, short WholeValue, string TheFormat)
        {

            return GetSingle(PartialValue, WholeValue).ToString(TheFormat) + '%';

        }

        public static int GetInt32(int PartialValue, int WholeValue)
        {

            return (PartialValue / WholeValue) * 100;

        }

        public static string GetInt32String(int PartialValue, int WholeValue)
        {

            return GetInt32(PartialValue, WholeValue).ToString() + '%';

        }

        public static string GetInt32String(int PartialValue, int WholeValue, IFormatProvider TheFormatProvider)
        {

            return GetInt32(PartialValue, WholeValue).ToString(TheFormatProvider) + '%';

        }

        public static string GetInt32String(int PartialValue, int WholeValue, string TheFormat)
        {

            return GetInt32(PartialValue, WholeValue).ToString(TheFormat) + '%';

        }

        public static float GetSingle(int PartialValue, int WholeValue)
        {

            return (PartialValue / WholeValue) * 100f;

        }

        public static string GetSingleString(int PartialValue, int WholeValue)
        {

            return GetSingle(PartialValue, WholeValue).ToString() + '%';

        }

        public static string GetSingleString(int PartialValue, int WholeValue, IFormatProvider TheFormatProvider)
        {

            return GetSingle(PartialValue, WholeValue).ToString(TheFormatProvider) + '%';

        }

        public static string GetSingleString(int PartialValue, int WholeValue, string TheFormat)
        {

            return GetSingle(PartialValue, WholeValue).ToString(TheFormat) + '%';

        }

        public static double GetDouble(int PartialValue, int WholeValue)
        {

            return (PartialValue / WholeValue) * 100;

        }

        public static string GetDoubleString(int PartialValue, int WholeValue)
        {

            return GetDouble(PartialValue, WholeValue).ToString() + '%';

        }

        public static string GetDoubleString(int PartialValue, int WholeValue, IFormatProvider TheFormatProvider)
        {

            return GetDouble(PartialValue, WholeValue).ToString(TheFormatProvider) + '%';

        }

        public static string GetDoubleString(int PartialValue, int WholeValue, string TheFormat)
        {

            return GetDouble(PartialValue, WholeValue).ToString(TheFormat) + '%';

        }

        public static float GetSingle(long PartialValue, long WholeValue)
        {

            return (PartialValue / WholeValue) * 100f;

        }

        public static string GetSingleString(long PartialValue, long WholeValue)
        {

            return GetSingle(PartialValue, WholeValue).ToString() + '%';

        }

        public static string GetSingleString(long PartialValue, long WholeValue, IFormatProvider TheFormatProvider)
        {

            return GetSingle(PartialValue, WholeValue).ToString(TheFormatProvider) + '%';

        }

        public static string GetSingleString(long PartialValue, long WholeValue, string TheFormat)
        {

            return GetSingle(PartialValue, WholeValue).ToString(TheFormat) + '%';

        }

        public static double GetDouble(long PartialValue, long WholeValue)
        {

            return (PartialValue / WholeValue) * 100;

        }

        public static string GetDoubleString(long PartialValue, long WholeValue)
        {

            return GetDouble(PartialValue, WholeValue).ToString() + '%';

        }

        public static string GetDoubleString(long PartialValue, long WholeValue, IFormatProvider TheFormatProvider)
        {

            return GetDouble(PartialValue, WholeValue).ToString(TheFormatProvider) + '%';

        }

        public static string GetDoubleString(long PartialValue, long WholeValue, string TheFormat)
        {

            return GetDouble(PartialValue, WholeValue).ToString(TheFormat) + '%';

        }

    }

}
