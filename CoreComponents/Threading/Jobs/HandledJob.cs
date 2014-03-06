using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading.Jobs
{

    public abstract class HandledJob<TJobHandler> : Job, IHandledJob<TJobHandler> where TJobHandler : IJobHandler
    {

        protected TJobHandler myHandler;

        protected bool myReportProgress;

        public HandledJob()
        {
        }

        public HandledJob(TJobHandler TheHandler)
        {

            myHandler = TheHandler;

        }

        public bool ReportProgress
        {

            get
            {

                //Thread.MemoryBarrier();

                return myReportProgress;

            }
            set
            {

                myReportProgress = value;
                
                //Thread.MemoryBarrier();

            }

        }

        public void DoReportProgress()
        {

            myReportProgress = true;

            //Thread.MemoryBarrier();

        }

        public TJobHandler Handler
        {

            get
            {

                return myHandler;

            }

        }

        IJobHandler IHandledJob.Handler
        {

            get
            {
                
                return myHandler;
            
            }

        }

    }

}
