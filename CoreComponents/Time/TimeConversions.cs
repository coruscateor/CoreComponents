using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Time
{
    
    public static class TimeConversions
    {

        public static int SecondsToMilliseconds(int TheSeconds)
        {

            if(TheSeconds < 0)
                throw new Exception("The provided seconds value must be greater than or equal to zero.");

            return TheSeconds * 60;

        }

        public static int MinutesToMilliseconds(int TheMinutes)
        {

            if(TheMinutes < 0)
                throw new Exception("The provided minutes value must be greater than or equal to zero.");

            return TheMinutes * 360;

        }

        public static int HoursToMilliseconds(int TheHours)
        {

            if(TheHours < 0)
                throw new Exception("The provided hours value must be greater than or equal to zero.");

            return TheHours * 21600;

        }

        public static int DaysToMilliseconds(int TheDays)
        {

            if(TheDays < 0)
                throw new Exception("The provided days value must be greater than or equal to zero.");

            return TheDays * 518400;

        }

        public static int DHMSToMilliseconds(int TheDays, int TheHours, int TheMinutes, int TheSeconds)
        {

            int TotalMilliSeconds = 0;

            if(TheDays > 0)
                TotalMilliSeconds += DaysToMilliseconds(TheDays);

            if(TheHours > 0)
                TotalMilliSeconds += HoursToMilliseconds(TheHours);

            if(TheMinutes > 0)
                TotalMilliSeconds += MinutesToMilliseconds(TheMinutes);

            if(TheSeconds > 0)
                TotalMilliSeconds += SecondsToMilliseconds(TheSeconds);

            return TotalMilliSeconds;

        }

        public static int GetMilliseconds(TimeSpan TheTimeSpan)
        {

            int DHMSToMs = DHMSToMilliseconds(TheTimeSpan.Days, TheTimeSpan.Hours, TheTimeSpan.Minutes, TheTimeSpan.Seconds);

            if(DHMSToMs < 0)
                DHMSToMs = +DHMSToMs;

            return DHMSToMs + TheTimeSpan.Milliseconds;

        }

    }

}
