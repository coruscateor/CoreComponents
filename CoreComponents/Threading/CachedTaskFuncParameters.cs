using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreComponents.Items;

namespace CoreComponents.Threading
{

    public sealed class CachedTaskFuncParameters<T, TResult> : BaseTaskFuncParameters<T, TResult>, IReset
    {

        public SConcurrentQueue<CachedTaskFuncParameters<T, TResult>> Queue
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

    public sealed class CachedTaskFuncParameters<T1, T2, TResult> : BaseTaskFuncParameters<T1, T2, TResult>, IReset
    {

        public SConcurrentQueue<CachedTaskFuncParameters<T1, T2, TResult>> Queue
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

    public sealed class CachedTaskFuncParameters<T1, T2, T3, TResult> : BaseTaskFuncParameters<T1, T2, T3, TResult>, IReset
    {

        public SConcurrentQueue<CachedTaskFuncParameters<T1, T2, T3, TResult>> Queue
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

    public sealed class CachedTaskFuncParameters<T1, T2, T3, T4, TResult> : BaseTaskFuncParameters<T1, T2, T3, T4, TResult>, IReset
    {

        public SConcurrentQueue<CachedTaskFuncParameters<T1, T2, T3, T4, TResult>> Queue
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
