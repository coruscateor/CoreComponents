using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CoreComponents.Items;

namespace CoreComponents.Threading
{

    public sealed class RecurAsyncAction<T> : ICopy<AsyncAction<T>>
    {

        readonly Action<T> myAction;

        readonly SConcurrentQueue<CachedTaskActionParameters<T>> myTAPQueue = new SConcurrentQueue<CachedTaskActionParameters<T>>();

        public RecurAsyncAction(Action<T> action)
        {

            myAction = action;

        }

        public Action<T> Action
        {

            get
            {

                return myAction;

            }

        }

        //Setup queuing ParamTasks

        CachedTaskActionParameters<T> Get()
        {

            CachedTaskActionParameters<T> ctap;

            if(myTAPQueue.TryDequeue(out ctap))
                return ctap;

            ctap = new CachedTaskActionParameters<T>();

            ctap.Queue = myTAPQueue;

            return ctap;

        }

        //public Task Async(T p)
        //{

        //    return ParamTasks.Async(Get(), myAction, p);

        //}

        //public Task Async(T p, TaskCreationOptions ceationOptions)
        //{

        //    return ParamTasks.Async(Get(), myAction, p, ceationOptions);

        //}

        //public Task Async(T p, CancellationToken cancellationToken)
        //{

        //    return ParamTasks.Async(Get(), myAction, p, cancellationToken);

        //}

        //public Task Async(T p, CancellationToken cancellationToken, TaskCreationOptions ceationOptions, TaskScheduler scheduler)
        //{

        //    return ParamTasks.Async(Get(), myAction, p, cancellationToken, ceationOptions, scheduler);

        //}

        public AsyncAction<T> Copy()
        {

            return new AsyncAction<T>(myAction);

        }

        object ICopy.Copy()
        {

            return Copy();

        }

    }

}
