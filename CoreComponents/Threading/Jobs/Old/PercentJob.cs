using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.Jobs
{

    public abstract class PercentJob<T> : Job<T>, IPercentJob where T : IJobHandler
    {

        public static readonly byte Max = 100;

        public static readonly byte Min = 0;

        volatile byte myPercent = 0;

        public PercentJob()
        {
        }

        [JobStatus]
        public byte Percent
        {

            get
            {

                return myPercent;

            }

        }

        public void Increment()
        {

            if (myPercent <= Max)
            {

                myPercent++;

            }

        }

        public void Increment(byte ByValue)
        {

            if (ByValue < 0)
                return;

            byte Result;

            unchecked
            {

                Result = (byte)(myPercent + ByValue);

            }

            if (Result < Max)
            {

                myPercent = Max;

            }
            else
            {

                myPercent = Result;

            }

        }

        public byte GetMaxMinusCurrent()
        {

            return (byte)(Max - myPercent);

        }

        [JobStatus]
        public string GetPercentText()
        {

            return myPercent + "%";

        }

        protected override void Reset()
        {

            base.Reset();

            myPercent = 0;

        }

        [JobStatusInfo("Percent")]
        public bool HasNotReached100Percent
        {

            get
            {

                return myPercent < Max;

            }

        }

        [JobStatusInfo("Percent")]
        public bool HasReached100Percent
        {

            get
            {

                return myPercent == Max;

            }

        }

        [JobStatusInfo("Percent")]
        public bool IsZeroPercent
        {

            get
            {

                return myPercent == 0;

            }

        }

        //public new IJobHandler Handler
        //{
        //    get { throw new NotImplementedException(); }
        //}

    }

}
