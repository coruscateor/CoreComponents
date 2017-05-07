using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreComponents.Items;

namespace CoreComponents.Threading
{

    public sealed class CachedTaskActionParameters<T> : BaseTaskActionParameters<T>, IReset
    {

        public SConcurrentQueue<CachedTaskActionParameters<T>> Queue
        {

            get;
            set;

        }

        public void Enqueue()
        {

            Reset();

            Queue.Enqueue(this);

        }

    }

    public sealed class CachedTaskActionParameters<T1, T2> : BaseTaskActionParameters<T1, T2>, IReset
    {

        public SConcurrentQueue<CachedTaskActionParameters<T1, T2>> Queue
        {

            get;
            set;

        }

        public void Enqueue()
        {

            Reset();

            Queue.Enqueue(this);

        }

    }

    public sealed class CachedTaskActionParameters<T1, T2, T3> : BaseTaskActionParameters<T1, T2, T3>, IReset
    {

        public SConcurrentQueue<CachedTaskActionParameters<T1, T2, T3>> Queue
        {

            get;
            set;

        }

        public void Enqueue()
        {

            Reset();

            Queue.Enqueue(this);

        }

    }

    public sealed class CachedTaskActionParameters<T1, T2, T3, T4> : BaseTaskActionParameters<T1, T2, T3, T4>, IReset
    {

        public SConcurrentQueue<CachedTaskActionParameters<T1, T2, T3, T4>> Queue
        {

            get;
            set;

        }

        public void Enqueue()
        {

            Reset();

            Queue.Enqueue(this);

        }

    }

}
