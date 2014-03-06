using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Time
{

    public static class UnixTime
    {

        static readonly DateTime myEpoch = new DateTime(1970, 1, 1);

        public static DateTime Epoch
        {

            get
            {

                return myEpoch;

            }

        }

        public static TimeSpan SinceEpoch(DateTime TheValue)
        {

            return TheValue - myEpoch;

        }

        public static TimeSpan SinceEpoch()
        {

            return SinceEpoch(DateTime.Now);

        }

        public static double SecondsSinceEpochExact(DateTime TheValue)
        {

            return SinceEpoch(TheValue).TotalSeconds;

        }

        public static double SecondsSinceEpochExactUtc(DateTime TheValue)
        {

            return SinceEpoch(TheValue.ToLocalTime()).TotalSeconds;

        }

        public static int SecondsSinceEpoch(DateTime TheValue)
        {

            return Convert.ToInt32(SecondsSinceEpochExact(TheValue));

        }

        public static int SecondsSinceEpochUtc(DateTime TheValue)
        {

            return Convert.ToInt32(SecondsSinceEpochExact(TheValue.ToLocalTime()));

        }

        public static double SecondsSinceEpochExact()
        {

            return SecondsSinceEpochExact(DateTime.Now);

        }

        public static int SecondsSinceEpoch()
        {

            return SecondsSinceEpoch(DateTime.Now);

        }

    }

}
