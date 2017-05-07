using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreComponents.Threading
{

    public sealed class AsyncAction<T> : ICopy<AsyncAction<T>>
    {

        readonly Action<T> myAction;

        readonly TaskActionParameters<T> myTAP;

        public AsyncAction(Action<T> action)
        {

            myAction = action;

            myTAP = new TaskActionParameters<T>();

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

            return ParamTasks.Async(myTAP, myAction, p);

        }

        public Task Async(T p, TaskCreationOptions ceationOptions)
        {

            return ParamTasks.Async(myTAP, myAction, p, ceationOptions);

        }

        public Task Async(T p, CancellationToken cancellationToken)
        {

            return ParamTasks.Async(myTAP, myAction, p, cancellationToken);

        }

        public Task Async(T p, CancellationToken cancellationToken, TaskCreationOptions ceationOptions, TaskScheduler scheduler)
        {

            return ParamTasks.Async(myTAP, myAction, p, cancellationToken, ceationOptions, scheduler);

        }

        public AsyncAction<T> Copy()
        {

            return new AsyncAction<T>(myAction);

        }

        object ICopy.Copy()
        {

            return Copy();

        }

    }

    public sealed class AsyncAction<T1, T2> : ICopy<AsyncAction<T1, T2>>
    {

        readonly Action<T1, T2> myAction;

        readonly TaskActionParameters<T1, T2> myTAP;

        public AsyncAction(Action<T1, T2> action)
        {

            myAction = action;

            myTAP = new TaskActionParameters<T1, T2>();

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

            return ParamTasks.Async(myTAP, myAction, p1, p2);

        }

        public Task Async(T1 p1, T2 p2, TaskCreationOptions ceationOptions)
        {

            return ParamTasks.Async(myTAP, myAction, p1, p2, ceationOptions);

        }

        public Task Async(T1 p1, T2 p2, CancellationToken cancellationToken)
        {

            return ParamTasks.Async(myTAP, myAction, p1, p2, cancellationToken);

        }

        public Task Async(T1 p1, T2 p2, CancellationToken cancellationToken, TaskCreationOptions ceationOptions, TaskScheduler scheduler)
        {

            return ParamTasks.Async(myTAP, myAction, p1, p2, cancellationToken, ceationOptions, scheduler);

        }

        public AsyncAction<T1, T2> Copy()
        {

            return new AsyncAction<T1, T2>(myAction);

        }

        object ICopy.Copy()
        {

            return Copy();

        }

    }

    public sealed class AsyncAction<T1, T2, T3> : ICopy<AsyncAction<T1, T2, T3>>
    {

        readonly Action<T1, T2, T3> myAction;

        readonly TaskActionParameters<T1, T2, T3> myTAP;

        public AsyncAction(Action<T1, T2, T3> action)
        {

            myAction = action;

            myTAP = new TaskActionParameters<T1, T2, T3>();

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

            return ParamTasks.Async(myTAP, myAction, p1, p2, p3);

        }

        public Task Async(T1 p1, T2 p2, T3 p3, TaskCreationOptions ceationOptions)
        {

            return ParamTasks.Async(myTAP, myAction, p1, p2, p3, ceationOptions);

        }

        public Task Async(T1 p1, T2 p2, T3 p3, CancellationToken cancellationToken)
        {

            return ParamTasks.Async(myTAP, myAction, p1, p2, p3, cancellationToken);

        }

        public Task Async(T1 p1, T2 p2, T3 p3, CancellationToken cancellationToken, TaskCreationOptions ceationOptions, TaskScheduler scheduler)
        {

            return ParamTasks.Async(myTAP, myAction, p1, p2, p3, cancellationToken, ceationOptions, scheduler);

        }

        public AsyncAction<T1, T2, T3> Copy()
        {

            return new AsyncAction<T1, T2, T3>(myAction);

        }

        object ICopy.Copy()
        {
            
            return Copy();

        }

    }

    public sealed class AsyncAction<T1, T2, T3, T4> : ICopy<AsyncAction<T1, T2, T3, T4>>
    {

        readonly Action<T1, T2, T3, T4> myAction;

        readonly TaskActionParameters<T1, T2, T3, T4> myTAP;

        public AsyncAction(Action<T1, T2, T3, T4> action)
        {

            myAction = action;

            myTAP = new TaskActionParameters<T1, T2, T3, T4>();

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

            return ParamTasks.Async(myTAP, myAction, p1, p2, p3, p4);

        }

        public Task Async(T1 p1, T2 p2, T3 p3, T4 p4, TaskCreationOptions ceationOptions)
        {

            return ParamTasks.Async(myTAP, myAction, p1, p2, p3, p4, ceationOptions);

        }

        public Task Async(T1 p1, T2 p2, T3 p3, T4 p4, CancellationToken cancellationToken)
        {

            return ParamTasks.Async(myTAP, myAction, p1, p2, p3, p4, cancellationToken);

        }

        public Task Async(T1 p1, T2 p2, T3 p3, T4 p4, CancellationToken cancellationToken, TaskCreationOptions ceationOptions, TaskScheduler scheduler)
        {

            return ParamTasks.Async(myTAP, myAction, p1, p2, p3, p4, cancellationToken, ceationOptions, scheduler);

        }

        public AsyncAction<T1, T2, T3, T4> Copy()
        {

            return new AsyncAction<T1, T2, T3, T4>(myAction);
            
        }

        object ICopy.Copy()
        {

            return Copy();

        }

    }

}
