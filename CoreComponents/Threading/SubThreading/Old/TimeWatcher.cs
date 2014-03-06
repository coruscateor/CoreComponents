using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading
{

    public abstract class TimeWatcher : ConditionWatcher
    {

        private DateTime myInitaiatingDateTime;

        public static TimeSpan DefaultTimeSpan = new TimeSpan(1, 0, 0); 

        private TimeSpan myTimeSpan;

        private DateTime myPreviousDateTime;

        private DateTime myNextTime;

        public TimeWatcher()
        {

            myTimeSpan = DefaultTimeSpan;

        }

        public TimeSpan TimeSpan
        {

            get
            {

                return myTimeSpan;

            }
            set
            {

                myTimeSpan = value;

            }

        }

        //protected override bool Check()
        //{

        //    //if(myNextTime;

        //}

        //protected override void ConditionMet()
        //{
        //    throw new NotImplementedException();
        //}

    }

}
