using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreComponents.Threading
{

    public sealed class TLAsyncAction<T> : BaseTLAsyncActionFunc<TaskActionParameters<T>>, ICopy<TLAsyncAction<T>>, IDisposable
    {

        readonly Action<T> myAction;

        public TLAsyncAction(Action<T> action, bool tackAllValues = false)
            : base(() => { return new TaskActionParameters<T>(); }, tackAllValues)
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

        public Task Async(T p)
        {

            return ParamTasks.Async(myTL.Value, myAction, p);

        }

        public Task Async(T p, TaskCreationOptions ceationOptions)
        {

            return ParamTasks.Async(myTL.Value, myAction, p, ceationOptions);

        }

        public Task Async(T p, CancellationToken cancellationToken)
        {

            return ParamTasks.Async(myTL.Value, myAction, p, cancellationToken);

        }

        public Task Async(T p, CancellationToken cancellationToken, TaskCreationOptions ceationOptions, TaskScheduler scheduler)
        {

            return ParamTasks.Async(myTL.Value, myAction, p, cancellationToken, ceationOptions, scheduler);

        }

        public TLAsyncAction<T> Copy()
        {

            return new TLAsyncAction<T>(myAction);

        }

        public TLAsyncAction<T> Copy(bool tackAllValues)
        {

            return new TLAsyncAction<T>(myAction, tackAllValues);

        }

        object ICopy.Copy()
        {

            return Copy();

        }

    }

    public sealed class TLAsyncAction<T1, T2> : BaseTLAsyncActionFunc<TaskActionParameters<T1, T2>>, ICopy<TLAsyncAction<T1, T2>>, IDisposable
    {

        readonly Action<T1, T2> myAction;

        public TLAsyncAction(Action<T1, T2> action, bool tackAllValues = false)
            : base(() => { return new TaskActionParameters<T1, T2>(); }, tackAllValues)
        {

            myAction = action;

        }

        public Action<T1, T2> Action
        {

            get
            {

                return myAction;

            }

        }

        public Task Async(T1 p1, T2 p2)
        {

            return ParamTasks.Async(myTL.Value, myAction, p1, p2);

        }

        public Task Async(T1 p1, T2 p2, TaskCreationOptions ceationOptions)
        {

            return ParamTasks.Async(myTL.Value, myAction, p1, p2, ceationOptions);

        }

        public Task Async(T1 p1, T2 p2, CancellationToken cancellationToken)
        {

            return ParamTasks.Async(myTL.Value, myAction, p1, p2, cancellationToken);

        }

        public Task Async(T1 p1, T2 p2, CancellationToken cancellationToken, TaskCreationOptions ceationOptions, TaskScheduler scheduler)
        {

            return ParamTasks.Async(myTL.Value, myAction, p1, p2, cancellationToken, ceationOptions, scheduler);

        }

        public TLAsyncAction<T1, T2> Copy()
        {

            return new TLAsyncAction<T1, T2>(myAction);

        }

        public TLAsyncAction<T1, T2> Copy(bool tackAllValues)
        {

            return new TLAsyncAction<T1, T2>(myAction, tackAllValues);

        }

        object ICopy.Copy()
        {

            return Copy();

        }

    }

    public sealed class TLAsyncAction<T1, T2, T3> : BaseTLAsyncActionFunc<TaskActionParameters<T1, T2, T3>>, ICopy<TLAsyncAction<T1, T2, T3>>, IDisposable
    {

        readonly Action<T1, T2, T3> myAction;

        public TLAsyncAction(Action<T1, T2, T3> action, bool tackAllValues = false)
            : base(() => { return new TaskActionParameters<T1, T2, T3>(); }, tackAllValues)
        {

            myAction = action;

        }

        public Action<T1, T2, T3> Action
        {

            get
            {

                return myAction;

            }

        }

        public Task Async(T1 p1, T2 p2, T3 p3)
        {

            return ParamTasks.Async(myTL.Value, myAction, p1, p2, p3);

        }

        public Task Async(T1 p1, T2 p2, T3 p3, TaskCreationOptions ceationOptions)
        {

            return ParamTasks.Async(myTL.Value, myAction, p1, p2, p3, ceationOptions);

        }

        public Task Async(T1 p1, T2 p2, T3 p3, CancellationToken cancellationToken)
        {

            return ParamTasks.Async(myTL.Value, myAction, p1, p2, p3, cancellationToken);

        }

        public Task Async(T1 p1, T2 p2, T3 p3, CancellationToken cancellationToken, TaskCreationOptions ceationOptions, TaskScheduler scheduler)
        {

            return ParamTasks.Async(myTL.Value, myAction, p1, p2, p3, cancellationToken, ceationOptions, scheduler);

        }

        public TLAsyncAction<T1, T2, T3> Copy()
        {

            return new TLAsyncAction<T1, T2, T3>(myAction);

        }

        public TLAsyncAction<T1, T2, T3> Copy(bool tackAllValues)
        {

            return new TLAsyncAction<T1, T2, T3>(myAction, tackAllValues);

        }

        object ICopy.Copy()
        {

            return Copy();

        }

    }

    public sealed class TLAsyncAction<T1, T2, T3, T4> : BaseTLAsyncActionFunc<TaskActionParameters<T1, T2, T3, T4>>, ICopy<TLAsyncAction<T1, T2, T3, T4>>, IDisposable
    {

        readonly Action<T1, T2, T3, T4> myAction;

        public TLAsyncAction(Action<T1, T2, T3, T4> action, bool tackAllValues = false)
            : base(() => { return new TaskActionParameters<T1, T2, T3, T4>(); }, tackAllValues)
        {

            myAction = action;

        }

        public Action<T1, T2, T3, T4> Action
        {

            get
            {

                return myAction;

            }

        }

        public Task Async(T1 p1, T2 p2, T3 p3, T4 p4)
        {

            return ParamTasks.Async(myTL.Value, myAction, p1, p2, p3, p4);

        }

        public Task Async(T1 p1, T2 p2, T3 p3, T4 p4, TaskCreationOptions ceationOptions)
        {

            return ParamTasks.Async(myTL.Value, myAction, p1, p2, p3, p4, ceationOptions);

        }

        public Task Async(T1 p1, T2 p2, T3 p3, T4 p4, CancellationToken cancellationToken)
        {

            return ParamTasks.Async(myTL.Value, myAction, p1, p2, p3, p4, cancellationToken);

        }

        public Task Async(T1 p1, T2 p2, T3 p3, T4 p4, CancellationToken cancellationToken, TaskCreationOptions ceationOptions, TaskScheduler scheduler)
        {

            return ParamTasks.Async(myTL.Value, myAction, p1, p2, p3, p4, cancellationToken, ceationOptions, scheduler);

        }

        public TLAsyncAction<T1, T2, T3, T4> Copy()
        {

            return new TLAsyncAction<T1, T2, T3, T4>(myAction);

        }

        public TLAsyncAction<T1, T2, T3, T4> Copy(bool tackAllValues)
        {

            return new TLAsyncAction<T1, T2, T3, T4>(myAction, tackAllValues);

        }

        object ICopy.Copy()
        {

            return Copy();

        }

    }

}
