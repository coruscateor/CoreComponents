using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.Jobs
{

    public interface IPercentJob : IJob
    {

        [JobStatus]
        byte Percent
        {

            get;

        }

        void Increment();

        void Increment(byte ByValue);

        byte GetMaxMinusCurrent();

        string GetPercentText();

        [JobStatusInfo("Percent")]
        bool HasNotReached100Percent
        {

            get;

        }

        [JobStatusInfo("Percent")]
        bool HasReached100Percent
        {

            get;

        }

        [JobStatusInfo("Percent")]
        bool IsZeroPercent
        {

            get;

        }

    }

    public interface IPercentJob<TJobHandler> : IPercentJob, IJob<TJobHandler> where TJobHandler : IJobHandler
    {
    }

}

