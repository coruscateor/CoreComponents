using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Threading.Jobs;

namespace CoreComponents.Threading.SubThreading.Jobs
{

    public interface IJobExecutor : ISubThread
    {

        IInputQueue<IJob> Waiting
        {

            get;

        }

        IOutputQueue<IJob> Ended
        {

            get;

        }

    }

//    public interface IJobExecutor<TJob> : ISubThread where TJob : IJob //<out TJob> : IJobExecutor where TJob : IJob
//    {
//
//        new IInputQueue<TJob> Waiting
//        {
//
//            get;
//
//        }
//
//       	new IOutputQueue<TJob> Ended
//        {
//
//            get;
//
//        }
//
//    }

}
