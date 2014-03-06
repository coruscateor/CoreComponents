using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading.Work
{
    public interface IWorkExecution
    {

        //IAsynchronousWorkContainer Work
        //{

        //    get;

        //}

        //Type TypeOfWork
        //{

        //    get;

        //}

        bool IsBusy
        {

            get;

        }

        bool HasWork
        {

            get;

        }

        public bool SetWork(IAsynchronousWorkContainer TheWork);

    }

    public interface IWorkExecution<T> where T : IAsynchronousWorkContainer
    {

        //T TheWork
        //{

        //    get;

        //}

        //Type TypeOfWork
        //{

        //    get;

        //}

        bool IsBusy
        {

            get;

        }

        bool HasWork
        {

            get;

        }

        public bool SetWork(T TheWork);

    }

}
