using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.Jobs
{

    public interface IHandledJob : IJob
    {

        bool ReportProgress
        {

            get;
            set;

        }

        void DoReportProgress();

        IJobHandler Handler
        {

            get;

        }

    }

    public interface IHandledJob<TJobHandler> : IHandledJob where TJobHandler : IJobHandler
    {

        new TJobHandler Handler
        {

            get;

        }

    }

}
