using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading.SubThreading
{

    public interface IInputQueueSubThreadContainer<T> : IInputQueue<T>
    {

        void EnqueueAndCheck(T TheItem);

        bool SubThreadIsActive
        {

            get;

        }

    }

}
