using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading.Work
{

    public interface IOutputWorkContainer : IWorkContainer
    {

        IOutputQueue<object> InputQueue
        {

            get;

        }

    }

    public interface IOutputWorkContainer<T> : IWorkContainer
    {

        IOutputQueue<T> InputQueue
        {

            get;

        }

    }

}
