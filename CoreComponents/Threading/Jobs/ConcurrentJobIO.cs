using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using CoreComponents.Threading.SubThreading;

namespace CoreComponents.Threading.Jobs
{

    public class ConcurrentJobIO : IJobIO //<TJob> where TJob : IJob
    {

        private ConcurrentQueueContainer<IJob> myConcurrentWaitingQueue;

        private ConcurrentQueueContainer<IJob> myConcurrentEndedQueue;

        public ConcurrentJobIO(ConcurrentQueue<IJob> TheInputQueue, ConcurrentQueue<IJob> TheOutputQueue)
        {

            myConcurrentWaitingQueue = new ConcurrentQueueContainer<IJob>(TheInputQueue);

            myConcurrentEndedQueue = new ConcurrentQueueContainer<IJob>(TheOutputQueue);

        }

        public IInputOutputQueue<IJob> Waiting
        {

            get
            {

                return myConcurrentWaitingQueue;

            }

        }

        public IInputOutputQueue<IJob> Ended
        {

            get
            {

                return myConcurrentEndedQueue;

            }

        }

//        IInputOutputQueue<IJob> IJobIO.Waiting
//        {
//
//            get 
//            {
//                
//                return (IInputOutputQueue<IJob>)myConcurrentWaitingQueue;
//            
//            }
//
//        }
//
//        IInputOutputQueue<IJob> IJobIO.Ended
//        {
//
//            get
//            { 
//                
//                return (IInputOutputQueue<IJob>)myConcurrentEndedQueue;
//            
//            }
//
//        }

    }

}
