using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading
{

    public class DirectQueue<T> : WeakReferenceHolder<T>, IDirectQueue
    {

        public DirectQueue(IOutputQueue<T> TheOutputQueue)
            : base(TheOutputQueue)
        {
        }

    }

}
