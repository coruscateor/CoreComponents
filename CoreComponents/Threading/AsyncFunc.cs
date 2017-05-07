using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreComponents.Threading
{

    public sealed class AsyncFunc<T, TResult> : ICopy<AsyncFunc<T, TResult>>
    {

        readonly Func<T, TResult> myFunc;

        readonly TaskFuncParameters<T, TResult> myTFP;

        public AsyncFunc(Func<T, TResult> func)
        {

            myFunc = func;

            myTFP = new TaskFuncParameters<T, TResult>();

        }

        public Func<T, TResult> Func
        {

            get
            {

                return myFunc;

            }

        }

        public Task Async(T p)
        {

            return ParamTasks.Async(myTFP, myFunc, p);

        }

        public Task Async(T p, TaskCreationOptions ceationOptions)
        {

            return ParamTasks.Async(myTFP, myFunc, p, ceationOptions);

        }

        public Task Async(T p, CancellationToken cancellationToken)
        {

            return ParamTasks.Async(myTFP, myFunc, p, cancellationToken);

        }

        public Task Async(T p, CancellationToken cancellationToken, TaskCreationOptions ceationOptions, TaskScheduler scheduler)
        {

            return ParamTasks.Async(myTFP, myFunc, p, cancellationToken, ceationOptions, scheduler);

        }

        public AsyncFunc<T, TResult> Copy()
        {

            return new AsyncFunc<T, TResult>(myFunc);

        }

        object ICopy.Copy()
        {

            return Copy();

        }

    }

    public sealed class AsyncFunc<T1, T2, TResult> : ICopy<AsyncFunc<T1, T2, TResult>>
    {

        readonly Func<T1, T2, TResult> myFunc;

        readonly TaskFuncParameters<T1, T2, TResult> myTFP;

        public AsyncFunc(Func<T1, T2, TResult> func)
        {

            myFunc = func;

            myTFP = new TaskFuncParameters<T1, T2, TResult>();

        }

        public Func<T1, T2, TResult> Func
        {

            get
            {

                return myFunc;

            }

        }

        public Task Async(T1 p1, T2 p2)
        {

            return ParamTasks.Async(myTFP, myFunc, p1, p2);

        }

        public Task Async(T1 p1, T2 p2, TaskCreationOptions ceationOptions)
        {

            return ParamTasks.Async(myTFP, myFunc, p1, p2, ceationOptions);

        }

        public Task Async(T1 p1, T2 p2, CancellationToken cancellationToken)
        {

            return ParamTasks.Async(myTFP, myFunc, p1, p2, cancellationToken);

        }

        public Task Async(T1 p1, T2 p2, CancellationToken cancellationToken, TaskCreationOptions ceationOptions, TaskScheduler scheduler)
        {

            return ParamTasks.Async(myTFP, myFunc, p1, p2, cancellationToken, ceationOptions, scheduler);

        }

        public AsyncFunc<T1, T2, TResult> Copy()
        {

            return new AsyncFunc<T1, T2, TResult>(myFunc);

        }

        object ICopy.Copy()
        {

            return Copy();

        }

    }

    public sealed class AsyncFunc<T1, T2, T3, TResult> : ICopy<AsyncFunc<T1, T2, T3, TResult>>
    {

        readonly Func<T1, T2, T3, TResult> myFunc;

        readonly TaskFuncParameters<T1, T2, T3, TResult> myTFP;

        public AsyncFunc(Func<T1, T2, T3, TResult> func)
        {

            myFunc = func;

            myTFP = new TaskFuncParameters<T1, T2, T3, TResult>();

        }

        public Func<T1, T2, T3, TResult> Func
        {

            get
            {

                return myFunc;

            }

        }

        public Task Async(T1 p1, T2 p2, T3 p3)
        {

            return ParamTasks.Async(myTFP, myFunc, p1, p2, p3);

        }

        public Task Async(T1 p1, T2 p2, T3 p3, TaskCreationOptions ceationOptions)
        {

            return ParamTasks.Async(myTFP, myFunc, p1, p2, p3, ceationOptions);

        }

        public Task Async(T1 p1, T2 p2, T3 p3, CancellationToken cancellationToken)
        {

            return ParamTasks.Async(myTFP, myFunc, p1, p2, p3, cancellationToken);

        }

        public Task Async(T1 p1, T2 p2, T3 p3, CancellationToken cancellationToken, TaskCreationOptions ceationOptions, TaskScheduler scheduler)
        {

            return ParamTasks.Async(myTFP, myFunc, p1, p2, p3, cancellationToken, ceationOptions, scheduler);

        }

        public AsyncFunc<T1, T2, T3, TResult> Copy()
        {

            return new AsyncFunc<T1, T2, T3, TResult>(myFunc);

        }

        object ICopy.Copy()
        {

            return Copy();

        }

    }

    public sealed class AsyncFunc<T1, T2, T3, T4, TResult> : ICopy<AsyncFunc<T1, T2, T3, T4, TResult>>
    {

        readonly Func<T1, T2, T3, T4, TResult> myFunc;

        readonly TaskFuncParameters<T1, T2, T3, T4, TResult> myTFP;

        public AsyncFunc(Func<T1, T2, T3, T4, TResult> func)
        {

            myFunc = func;

            myTFP = new TaskFuncParameters<T1, T2, T3, T4, TResult>();

        }

        public Func<T1, T2, T3, T4, TResult> Func
        {

            get
            {

                return myFunc;

            }

        }

        public Task Async(T1 p1, T2 p2, T3 p3, T4 p4)
        {

            return ParamTasks.Async(myTFP, myFunc, p1, p2, p3, p4);

        }

        public Task Async(T1 p1, T2 p2, T3 p3, T4 p4, TaskCreationOptions ceationOptions)
        {

            return ParamTasks.Async(myTFP, myFunc, p1, p2, p3, p4, ceationOptions);

        }

        public Task Async(T1 p1, T2 p2, T3 p3, T4 p4, CancellationToken cancellationToken)
        {

            return ParamTasks.Async(myTFP, myFunc, p1, p2, p3, p4, cancellationToken);

        }

        public Task Async(T1 p1, T2 p2, T3 p3, T4 p4, CancellationToken cancellationToken, TaskCreationOptions ceationOptions, TaskScheduler scheduler)
        {

            return ParamTasks.Async(myTFP, myFunc, p1, p2, p3, p4, cancellationToken, ceationOptions, scheduler);

        }

        public AsyncFunc<T1, T2, T3, T4, TResult> Copy()
        {

            return new AsyncFunc<T1, T2, T3, T4, TResult>(myFunc);

        }

        object ICopy.Copy()
        {

            return Copy();

        }

    }

}
