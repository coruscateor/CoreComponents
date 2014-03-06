using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Time
{

    public class ElapsedTimeRetriever
    {

        protected DateTime mySetTime;

        public ElapsedTimeRetriever()
        {

            mySetTime = DateTime.Now;

        }

        public void SetNow()
        {

            mySetTime = DateTime.Now;

        }

        public void SetDateTime(DateTime TheDateTime)
        {

            mySetTime = TheDateTime;

        }

        public DateTime SetTime
        {

            get
            {

                return mySetTime;

            }

        }

        public TimeSpan Retrive()
        {

            return DateTime.Now - mySetTime;

        }

        public DateTimeAndTimeSpan RetriveWithDateTime()
        {

            DateTime Now = DateTime.Now;

            return new DateTimeAndTimeSpan(Now, Now - mySetTime);

        }

        public TimeSpan Retrive(DateTime TheDateTime)
        {

            return TheDateTime - mySetTime;

        }

        public DateTimeAndTimeSpan RetriveWithDateTime(DateTime TheDateTime)
        {

            DateTime Now = DateTime.Now;

            return new DateTimeAndTimeSpan(Now, Now - TheDateTime);

        }

        public struct DateTimeAndTimeSpan
        {

            DateTime myDateTime;

            TimeSpan myTimeSpan;

            public DateTimeAndTimeSpan(DateTime TheDateTime, TimeSpan TheTimeSpan)
            {

                myDateTime = TheDateTime;

                myTimeSpan = TheTimeSpan;

            }

            public DateTime DateTime
            {

                get
                {

                    return myDateTime;

                }

            }

            public TimeSpan TimeSpan
            {

                get
                {

                    return myTimeSpan;

                }

            }

        }

    }

}
