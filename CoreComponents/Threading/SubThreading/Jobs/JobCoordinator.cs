using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Threading.Jobs;

namespace CoreComponents.Threading.SubThreading.Jobs
{

	public abstract class JobCoordinator<TJobExecutor> where TJobExecutor : IJobExecutor
    {

        protected JobPool myPoolOfJobs = new JobPool();

        protected TJobExecutor myJobExecutor;

        public JobCoordinator()
        { 
        }

        protected void CheckOutputQueue()
        {

            int OutputCount = myJobExecutor.Ended.Count;

            while (OutputCount > 0)
            {
                
                IJob TheItem;

                if(myJobExecutor.Ended.TryDequeue(out TheItem))
                {

                    try
                    {

                        ResetIfDeactivated(TheItem);

                        myPoolOfJobs.Add(TheItem);

                    }
                    catch
                    {
                    }

                    OutputCount--;

                }
                else
                {

                    return;

                }
                
            }

        }

        protected THandledJob FetchOrCreateHandledJob<THandledJob, TJobHandler>()
            where THandledJob : IHandledJob, new()
            where TJobHandler : IJobHandler
        {

            CheckOutputQueue();

            THandledJob NextJob;

            if (!myPoolOfJobs.FetchOut<THandledJob>(out NextJob))
            {

                NextJob = new THandledJob();
                
            }

            //EnqueueAndCheck(NextJob);

            return NextJob;

        }

        protected THandledJob FetchOrCreateHandledJob<THandledJob, TJobHandler>(Func<THandledJob> JobInitaliser)
            where THandledJob : IHandledJob
            where TJobHandler : IJobHandler
        {

            CheckOutputQueue();

            THandledJob NextJob;

            if (!myPoolOfJobs.FetchOut<THandledJob>(out NextJob))
            {

                NextJob = JobInitaliser();

            }

            //EnqueueAndCheck(NextJob);

            return NextJob;

        }

        protected TJob FetchOrCreateJob<TJob>()
            where TJob : IJob, new()
        {

            CheckOutputQueue();

            TJob NextJob;

            if (!myPoolOfJobs.FetchOut<TJob>(out NextJob))
            {

                NextJob = new TJob();

            }

            //EnqueueAndCheck(NextJob);

            return NextJob;

        }

        protected TJob FetchOrCreateJob<TJob>(Func<TJob> JobInitaliser)
            where TJob : IJob
        {

            CheckOutputQueue();

            TJob NextJob;

            if (!myPoolOfJobs.FetchOut<TJob>(out NextJob))
            {

                NextJob = JobInitaliser();

            }

            //EnqueueAndCheck(NextJob);

            return NextJob;

        }

        //protected void EnqueueAndCheck(IJob TheJob)
        //{

        //    CheckIfWaitingToStart(TheJob);

        //    myJobExecutor.Waiting.Enqueue(TheJob);

        //    if (!myJobExecutor.IsActive)
        //        myJobExecutor.Start();

        //}

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

        protected void ResetIfDeactivated(IJob TheJob)
        {

            if (TheJob.IsDeactivated)
                TheJob.WaitingForInput();
 
        }

        //protected void EnqueueOrCreateJob<TJob>() where TJob : IJob, new()
        //{

        //    CheckOutputQueue();

        //    TJob NextJob;

        //    if (!myPoolOfJobs.FetchOut<TJob>(out NextJob))
        //    {

        //        NextJob = new TJob();

        //    }

        //    Enqueue(NextJob);

        //}

        //protected void EnqueueOrCreateJob<TJob>(Func<TJob> JobInitaliser) where TJob : IJob
        //{

        //    CheckOutputQueue();

        //    TJob NextJob;

        //    if (!myPoolOfJobs.FetchOut<TJob>(out NextJob))
        //    {
                
        //        NextJob = JobInitaliser();

        //    }

        //    Enqueue(NextJob);

        //}

        //protected void CheckIfWaitingToStart(IJob TheJob)
        //{

        //    if (!TheJob.IsWaitingToStart)
        //        TheJob.WaitingToStart();

        //}

    }

    public abstract class JobCoordinator : JobCoordinator<IJobExecutor>
    {

        public JobCoordinator()
        { 
        }

    }

}
