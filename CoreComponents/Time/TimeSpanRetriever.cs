using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Time
{

    public static class TimeSpanRetriever
    {

        static DateTime mySetTime;

        public static void SetNow()
        {

            mySetTime = DateTime.Now;

        }

        public static void SetDateTime(DateTime TheDateTime)
        {

            mySetTime = TheDateTime;

        }

        public static DateTime SetTime
        {

            get
            {

                return mySetTime;

            }

        }

        public static TimeSpan Retrive()
        {

            return DateTime.Now - mySetTime;

        }

        public static ElapsedTimeRetriever.DateTimeAndTimeSpan RetriveWithDateTime()
        {

            DateTime Now = DateTime.Now;

            return new ElapsedTimeRetriever.DateTimeAndTimeSpan(Now, Now - mySetTime);

        }

        public static TimeSpan Retrive(DateTime TheDateTime)
        {

            return TheDateTime - mySetTime;

        }

        public static ElapsedTimeRetriever.DateTimeAndTimeSpan RetriveWithDateTime(DateTime TheDateTime)
        {

            DateTime Now = DateTime.Now;

            return new ElapsedTimeRetriever.DateTimeAndTimeSpan(Now, Now - TheDateTime);

        }

    }

}
