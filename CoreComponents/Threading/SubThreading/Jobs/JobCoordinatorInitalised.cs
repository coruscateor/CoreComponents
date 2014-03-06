using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Threading.Jobs;

namespace CoreComponents.Threading.SubThreading.Jobs
{

    public abstract class JobCoordinatorInitalised<TJobExecutor> : JobCoordinator<TJobExecutor> where TJobExecutor : IJobExecutor, new()
    {

        public JobCoordinatorInitalised()
        {

            Initaise();

        }

        protected void Initaise()
        {

            if (myJobExecutor == null)
                myJobExecutor = new TJobExecutor();
            else
                throw new Exception("JobExecutor is already initalised");

        }

    }

}

