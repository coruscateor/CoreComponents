using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Time
{

    public struct WeekTimeSpan : IDatedTimeSpan
    {

        DateTime myStartingDate;

        DateTime myFinishingDate;

        public WeekTimeSpan(DateTime TheDateTime)
        {

            switch (TheDateTime.DayOfWeek)
            {

                case DayOfWeek.Monday:

                    myStartingDate = TheDateTime.Date;

                    myFinishingDate = new DateTime(TheDateTime.Year, TheDateTime.Month, TheDateTime.Day, MaxTimeValues.Hours, MaxTimeValues.MinutesAndSeconds, MaxTimeValues.MinutesAndSeconds, MaxTimeValues.Milliseconds, TheDateTime.Kind).AddDays(6);

                    return;
                case DayOfWeek.Tuesday:

                    myStartingDate = TheDateTime.AddDays(-1).Date;

                    myFinishingDate = new DateTime(TheDateTime.Year, TheDateTime.Month, TheDateTime.Day, MaxTimeValues.Hours, MaxTimeValues.MinutesAndSeconds, MaxTimeValues.MinutesAndSeconds, MaxTimeValues.Milliseconds, TheDateTime.Kind).AddDays(5);

                    return;
                case DayOfWeek.Wednesday:

                    myStartingDate = TheDateTime.AddDays(-2).Date;

                    myFinishingDate = new DateTime(TheDateTime.Year, TheDateTime.Month, TheDateTime.Day, MaxTimeValues.Hours, MaxTimeValues.MinutesAndSeconds, MaxTimeValues.MinutesAndSeconds, MaxTimeValues.Milliseconds, TheDateTime.Kind).AddDays(4);

                    return;
                case DayOfWeek.Thursday:

                    myStartingDate = TheDateTime.AddDays(-3).Date;

                    myFinishingDate = new DateTime(TheDateTime.Year, TheDateTime.Month, TheDateTime.Day, MaxTimeValues.Hours, MaxTimeValues.MinutesAndSeconds, MaxTimeValues.MinutesAndSeconds, MaxTimeValues.Milliseconds, TheDateTime.Kind).AddDays(3);

                    return;
                case DayOfWeek.Friday:

                    myStartingDate = TheDateTime.AddDays(-4).Date;

                    myFinishingDate = new DateTime(TheDateTime.Year, TheDateTime.Month, TheDateTime.Day, MaxTimeValues.Hours, MaxTimeValues.MinutesAndSeconds, MaxTimeValues.MinutesAndSeconds, MaxTimeValues.Milliseconds, TheDateTime.Kind).AddDays(2);

                    return;
                case DayOfWeek.Saturday:

                    myStartingDate = TheDateTime.AddDays(-5).Date;

                    myFinishingDate = new DateTime(TheDateTime.Year, TheDateTime.Month, TheDateTime.Day, MaxTimeValues.Hours, MaxTimeValues.MinutesAndSeconds, MaxTimeValues.MinutesAndSeconds, MaxTimeValues.Milliseconds, TheDateTime.Kind).AddDays(1);

                    return;
                case DayOfWeek.Sunday:

                    myStartingDate = TheDateTime.AddDays(-6).Date;

                    myFinishingDate = new DateTime(TheDateTime.Year, TheDateTime.Month, TheDateTime.Day, MaxTimeValues.Hours, MaxTimeValues.MinutesAndSeconds, MaxTimeValues.MinutesAndSeconds, MaxTimeValues.Milliseconds, TheDateTime.Kind);

                    return;

            }

            myStartingDate = TheDateTime;

            myFinishingDate = TheDateTime;

        }

        public DateTime Starts
        {

            get
            {

                return myStartingDate;

            }

        }

        public DateTime Finishes
        {

            get
            {

                return myFinishingDate;

            }

        }

        public TimeSpan Duration
        {

            get
            {

                return myFinishingDate - myStartingDate;

            }

        }

        public bool IsWithin(DateTime TheDateTime)
        {

            return TheDateTime > myStartingDate && TheDateTime < myFinishingDate;

        }

        public static bool operator ==(WeekTimeSpan LeftWeekTimeSpan, WeekTimeSpan RightWeekTimeSpan)
        {

            return LeftWeekTimeSpan.Starts == RightWeekTimeSpan.Starts && LeftWeekTimeSpan.Finishes == RightWeekTimeSpan.Finishes;

        }

        public static bool operator !=(WeekTimeSpan LeftWeekTimeSpan, WeekTimeSpan RightWeekTimeSpan)
        {

            return LeftWeekTimeSpan.Starts != RightWeekTimeSpan.Starts || LeftWeekTimeSpan.Finishes != RightWeekTimeSpan.Finishes;

        }

        public override bool Equals(object obj)
        {

            if(obj is WeekTimeSpan)
                return ((WeekTimeSpan)obj) == this;

            return base.Equals(obj);

        }

        public override int GetHashCode()
        {

            return base.GetHashCode();

        }

    }

}
