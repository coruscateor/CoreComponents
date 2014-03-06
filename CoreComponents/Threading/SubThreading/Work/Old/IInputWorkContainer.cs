using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading.Work
{

    public interface IInputWorkContainer : IWorkContainer
    {

        IInputQueue<object> InputQueue
        {

            get;

        }

    }

    public interface IInputWorkContainer<T> : IWorkContainer
    {

        IInputQueue<T> InputQueue
        {

            get;

        }

    }

}
