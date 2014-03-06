using System;
using CoreComponents.Threading.Jobs;

namespace CoreComponents.Threading.SubThreading.Jobs
{
	
	public abstract class SimpleJobQueuer<TJobExecutor> where TJobExecutor : IJobExecutor, new()
	{
		
		protected TJobExecutor myJobExecutor;
		
		public SimpleJobQueuer()
		{
		}
		
		protected void Initailse()
		{
			
			myJobExecutor = new TJobExecutor();
			
		}
		
		protected bool EnqueueAndCheck(IJob TheJob)
        {

            if (TheJob.IsWaitingToStart)
            {

                myJobExecutor.Waiting.Enqueue(TheJob);

                if (!myJobExecutor.IsActive)
                    myJobExecutor.Start();

                return true;

            }

            return false;

        }
		
	}
	
}
