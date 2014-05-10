using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Threading.SubThreading;

namespace CoreComponents.Threading.Jobs
{

    public interface IJobIO
    {

        IInputOutputQueue<IJob> Waiting
        {

            get;

        }

        IInputOutputQueue<IJob> Ended
        {

            get;

        }

    }

    public interface IJobIO<TJob> : IJobIO where TJob : IJob
    {

        new IInputOutputQueue<TJob> Waiting
        {

            get;

        }

        new IInputOutputQueue<TJob> Ended
        {

            get;

        }

    }

}
