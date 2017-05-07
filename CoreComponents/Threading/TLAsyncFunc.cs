using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreComponents.Threading
{

    public sealed class TLAsyncFunc<T, TResult> : BaseTLAsyncActionFunc<TaskFuncParameters<T, TResult>>, ICopy<TLAsyncFunc<T, TResult>>, IDisposable
    {

        readonly Func<T, TResult> myFunc;

        public TLAsyncFunc(Func<T, TResult> func, bool tackAllValues = false)
            : base(() => { return new TaskFuncParameters<T, TResult>(); }, tackAllValues)
        {

            myFunc = func;

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

            return ParamTasks.Async(myTL.Value, myFunc, p);

        }

        public Task Async(T p, TaskCreationOptions ceationOptions)
        {

            return ParamTasks.Async(myTL.Value, myFunc, p, ceationOptions);

        }

        public Task Async(T p, CancellationToken cancellationToken)
        {

            return ParamTasks.Async(myTL.Value, myFunc, p, cancellationToken);

        }

        public Task Async(T p, CancellationToken cancellationToken, TaskCreationOptions ceationOptions, TaskScheduler scheduler)
        {

            return ParamTasks.Async(myTL.Value, myFunc, p, cancellationToken, ceationOptions, scheduler);

        }

        public TLAsyncFunc<T, TResult> Copy()
        {

            return new TLAsyncFunc<T, TResult>(myFunc);

        }

        object ICopy.Copy()
        {

            return Copy();

        }

    }

    public sealed class TLAsyncFunc<T1, T2, TResult> : BaseTLAsyncActionFunc<TaskFuncParameters<T1, T2, TResult>>, ICopy<TLAsyncFunc<T1, T2, TResult>>, IDisposable
    {

        readonly Func<T1, T2, TResult> myFunc;

        public TLAsyncFunc(Func<T1, T2, TResult> func, bool tackAllValues = false)
            : base(() => { return new TaskFuncParameters<T1, T2, TResult>(); }, tackAllValues)
        {

            myFunc = func;

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

            return ParamTasks.Async(myTL.Value, myFunc, p1, p2);

        }

        public Task Async(T1 p1, T2 p2, TaskCreationOptions ceationOptions)
        {

            return ParamTasks.Async(myTL.Value, myFunc, p1, p2, ceationOptions);

        }

        public Task Async(T1 p1, T2 p2, CancellationToken cancellationToken)
        {

            return ParamTasks.Async(myTL.Value, myFunc, p1, p2, cancellationToken);

        }

        public Task Async(T1 p1, T2 p2, CancellationToken cancellationToken, TaskCreationOptions ceationOptions, TaskScheduler scheduler)
        {

            return ParamTasks.Async(myTL.Value, myFunc, p1, p2, cancellationToken, ceationOptions, scheduler);

        }

        public TLAsyncFunc<T1, T2, TResult> Copy()
        {

            return new TLAsyncFunc<T1, T2, TResult>(myFunc);

        }

        object ICopy.Copy()
        {

            return Copy();

        }

    }

    public sealed class TLAsyncFunc<T1, T2, T3, TResult> : BaseTLAsyncActionFunc<TaskFuncParameters<T1, T2, T3, TResult>>, ICopy<TLAsyncFunc<T1, T2, T3, TResult>>, IDisposable
    {

        readonly Func<T1, T2, T3, TResult> myFunc;

        public TLAsyncFunc(Func<T1, T2, T3, TResult> func, bool tackAllValues = false)
            : base(() => { return new TaskFuncParameters<T1, T2, T3, TResult>(); }, tackAllValues)
        {

            myFunc = func;

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

            return ParamTasks.Async(myTL.Value, myFunc, p1, p2, p3);

        }

        public Task Async(T1 p1, T2 p2, T3 p3, TaskCreationOptions ceationOptions)
        {

            return ParamTasks.Async(myTL.Value, myFunc, p1, p2, p3, ceationOptions);

        }

        public Task Async(T1 p1, T2 p2, T3 p3, CancellationToken cancellationToken)
        {

            return ParamTasks.Async(myTL.Value, myFunc, p1, p2, p3, cancellationToken);

        }

        public Task Async(T1 p1, T2 p2, T3 p3, CancellationToken cancellationToken, TaskCreationOptions ceationOptions, TaskScheduler scheduler)
        {

            return ParamTasks.Async(myTL.Value, myFunc, p1, p2, p3, cancellationToken, ceationOptions, scheduler);

        }

        public TLAsyncFunc<T1, T2, T3, TResult> Copy()
        {

            return new TLAsyncFunc<T1, T2, T3, TResult>(myFunc);

        }

        object ICopy.Copy()
        {

            return Copy();

        }

    }

    public sealed class TLAsyncFunc<T1, T2, T3, T4, TResult> : BaseTLAsyncActionFunc<TaskFuncParameters<T1, T2, T3, T4, TResult>>, ICopy<TLAsyncFunc<T1, T2, T3, T4, TResult>>, IDisposable
    {

        readonly Func<T1, T2, T3, T4, TResult> myFunc;

        public TLAsyncFunc(Func<T1, T2, T3, T4, TResult> func, bool tackAllValues = false)
            : base(() => { return new TaskFuncParameters<T1, T2, T3, T4, TResult>(); }, tackAllValues)
        {

            myFunc = func;

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

            return ParamTasks.Async(myTL.Value, myFunc, p1, p2, p3, p4);

        }

        public Task Async(T1 p1, T2 p2, T3 p3, T4 p4, TaskCreationOptions ceationOptions)
        {

            return ParamTasks.Async(myTL.Value, myFunc, p1, p2, p3, p4, ceationOptions);

        }

        public Task Async(T1 p1, T2 p2, T3 p3, T4 p4, CancellationToken cancellationToken)
        {

            return ParamTasks.Async(myTL.Value, myFunc, p1, p2, p3, p4, cancellationToken);

        }

        public Task Async(T1 p1, T2 p2, T3 p3, T4 p4, CancellationToken cancellationToken, TaskCreationOptions ceationOptions, TaskScheduler scheduler)
        {

            return ParamTasks.Async(myTL.Value, myFunc, p1, p2, p3, p4,cancellationToken, ceationOptions, scheduler);

        }

        public TLAsyncFunc<T1, T2, T3, T4, TResult> Copy()
        {

            return new TLAsyncFunc<T1, T2, T3, T4, TResult>(myFunc);

        }

        object ICopy.Copy()
        {

            return Copy();

        }

    }

}
