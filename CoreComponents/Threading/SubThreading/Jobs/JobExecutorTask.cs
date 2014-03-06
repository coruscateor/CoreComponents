using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using CoreComponents.Threading.Jobs;

namespace CoreComponents.Threading.SubThreading.Jobs
{

    public abstract class JobExecutorTask : BaseIsolatedTask, IJobExecutor  //<TJob> where TJob : IJob
    {

        private ConcurrentInputQueueContainer<IJob> myWaitingQueueContainer;

        private ConcurrentOutputQueueContainer<IJob> myEndedQueueContainer;

        private ConcurrentJobIO myJobIO;

        public JobExecutorTask()
        {

            ConcurrentQueue<IJob> InputQueue = new ConcurrentQueue<IJob>();

            ConcurrentQueue<IJob> OutputQueue = new ConcurrentQueue<IJob>();

            myWaitingQueueContainer = new ConcurrentInputQueueContainer<IJob>(InputQueue);

            myEndedQueueContainer = new ConcurrentOutputQueueContainer<IJob>(OutputQueue);

            myJobIO = new ConcurrentJobIO(InputQueue, OutputQueue);

        }
        
        protected IJobIO JobIO
        {

            get
            {

                return myJobIO;

            }

        }

        public IInputQueue<IJob> Waiting
        {

            get
            {

                return myWaitingQueueContainer;

            }

        }

        public IOutputQueue<IJob> Ended
        {

            get
            {

                return myEndedQueueContainer;

            }

        }

        protected void ContinueIfMoreJobs()
        {

            if (!myWaitingQueueContainer.IsEmpty)
                Continue();
        }

    }

//    public abstract class JobExecutorTask : JobExecutorTask<IJob>
//    {
//
//        //Will most likely need to initaise the base class
//        public JobExecutorTask()
//        { 
//        }
//
//    }

}
