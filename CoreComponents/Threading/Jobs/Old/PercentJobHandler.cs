using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.Jobs
{

    public abstract class PercentJobHandler<TJob> : JobHandler<TJob> where TJob : IPercentJob
    {

        public PercentJobHandler(TJob TheJob)
            : base(TheJob)
        {
        }

        [JobStatus]
        public byte Percent
        {

            get
            {

                return myJob.Percent;

            }

        }

        [JobStatus]
        public string GetPercentText()
        {

            return myJob.Percent + "%";

        }

        [JobStatus]
        public string GetPercentCompleteText()
        {

            return myJob.Percent + "% Complete";

        }

        public byte GetMaxMinusCurrent()
        {

            return (byte)(myJob.Percent - 100);

        }

        [JobStatusInfo("Percent")]
        public bool HasNotReached100Percent
        {

            get
            {

                return myJob.HasNotReached100Percent;

            }

        }

        [JobStatusInfo("Percent")]
        public bool HasReached100Percent
        {

            get
            {

                return myJob.HasReached100Percent;

            }

        }

        [JobStatusInfo("Percent")]
        public bool IsZeroPercent
        {

            get
            {

                return myJob.IsZeroPercent;

            }

        }

    }

}
