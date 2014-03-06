using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.Jobs
{

    public interface IPercentJobHandler : IJobHandler
    {

        [JobStatus]
        byte Percent
        {

            get;

        }

        string GetPercentText();

        string GetPercentCompleteText();

        [JobStatusInfo("Percent")]
        bool HasNotReached100
        {

            get;

        }

        [JobStatusInfo("Percent")]
        bool HasReached100
        {

            get;

        }

        [JobStatusInfo("Percent")]
        bool IsZero
        {

            get;

        }

    }

}
