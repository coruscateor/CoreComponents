using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Time
{

    public static class DateTimeSpan
    {

        public static TimeSpan TheFullExpanseOfTime()
        {

            return DateTime.MaxValue - DateTime.MinValue;

        }

        public static TimeSpan SinceMinValue(DateTime TheValue)
        {

            return TheValue - DateTime.MinValue;

        }

        public static TimeSpan SinceMinValue()
        {

            return SinceMinValue(DateTime.Now);

        }

        public static double SecondsSinceMinValueExact(DateTime TheValue)
        {

            return SinceMinValue(TheValue).TotalSeconds;

        }

        public static double SecondsSinceSinceMinValueExactUtc(DateTime TheValue)
        {

            return SinceMinValue(TheValue.ToLocalTime()).TotalSeconds;

        }

        public static int SecondsSinceMinValue(DateTime TheValue)
        {

            return Convert.ToInt32(SecondsSinceMinValueExact(TheValue));

        }

        public static int SecondsSinceEpochUtc(DateTime TheValue)
        {

            return Convert.ToInt32(SecondsSinceMinValueExact(TheValue.ToLocalTime()));

        }

        public static double SecondsSinceMinValueExact()
        {

            return SecondsSinceMinValueExact(DateTime.Now);

        }

        public static int SecondsSinceMinValue()
        {

            return SecondsSinceMinValue(DateTime.Now);

        }

        public static TimeSpan TimeTillTheEnd(DateTime TheValue)
        {

            return DateTime.MaxValue - TheValue;

        }

    }

}
