using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreComponents.Threading.Extensions
{

    public static class AsyncActionDelegates
    {

        //0p

        public static Task Async(this Action action)
        {

            return Task.Factory.StartNew(action);

        }

        public static Task Async(this Action action, TaskCreationOptions ceationOptions)
        {

            return Task.Factory.StartNew(action, ceationOptions);

        }

        public static Task Async(this Action action, CancellationToken cancellationToken)
        {

            return Task.Factory.StartNew(action, cancellationToken);

        }

        public static Task Async(this Action action, CancellationToken cancellationToken, TaskCreationOptions ceationOptions, TaskScheduler scheduler)
        {

            return Task.Factory.StartNew(action, cancellationToken, ceationOptions, scheduler);

        }

        //1p

        public static Task Async<T>(this Action<T> action, T p)
        {

            return ParamTasks.Async(action, p);

        }

        public static Task Async<T>(this Action<T> action, T p, TaskCreationOptions ceationOptions)
        {

            return ParamTasks.Async(action, p, ceationOptions);

        }

        public static Task Async<T>(this Action<T> action, T p, CancellationToken cancellationToken)
        {

            return ParamTasks.Async(action, p, cancellationToken);

        }

        public static Task Async<T>(this Action<T> action, T p, CancellationToken cancellationToken, TaskCreationOptions ceationOptions, TaskScheduler scheduler)
        {

            return ParamTasks.Async(action, p, cancellationToken, ceationOptions, scheduler);

        }

        //p2

        public static Task Async<T1, T2>(this Action<T1, T2> action, T1 p1, T2 p2)
        {

            return ParamTasks.Async(action, p1, p2);

        }

        public static Task Async<T1, T2>(this Action<T1, T2> action, T1 p1, T2 p2, TaskCreationOptions ceationOptions)
        {

            return ParamTasks.Async(action, p1, p2, ceationOptions);

        }

        public static Task Async<T1, T2>(this Action<T1, T2> action, T1 p1, T2 p2, CancellationToken cancellationToken)
        {

            return ParamTasks.Async(action, p1, p2, cancellationToken);

        }

        public static Task Async<T1, T2>(this Action<T1, T2> action, T1 p1, T2 p2, CancellationToken cancellationToken, TaskCreationOptions ceationOptions, TaskScheduler scheduler)
        {

            return ParamTasks.Async(action, p1, p2, cancellationToken, ceationOptions, scheduler);

        }

        //p3

        public static Task Async<T1, T2, T3>(this Action<T1, T2, T3> action, T1 p1, T2 p2, T3 p3)
        {

            return ParamTasks.Async(action, p1, p2, p3);

        }

        public static Task Async<T1, T2, T3>(this Action<T1, T2, T3> action, T1 p1, T2 p2, T3 p3, TaskCreationOptions ceationOptions)
        {

            return ParamTasks.Async(action, p1, p2, p3, ceationOptions);

        }

        public static Task Async<T1, T2, T3>(this Action<T1, T2, T3> action, T1 p1, T2 p2, T3 p3, CancellationToken cancellationToken)
        {

            return ParamTasks.Async(action, p1, p2, p3, cancellationToken);

        }

        public static Task Async<T1, T2, T3>(this Action<T1, T2, T3> action, T1 p1, T2 p2, T3 p3, CancellationToken cancellationToken, TaskCreationOptions ceationOptions, TaskScheduler scheduler)
        {

            return ParamTasks.Async(action, p1, p2, p3, cancellationToken, ceationOptions, scheduler);

        }

        //p4

        public static Task Async<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action, T1 p1, T2 p2, T3 p3, T4 p4)
        {

            return ParamTasks.Async(action, p1, p2, p3, p4);

        }

        public static Task Async<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action, T1 p1, T2 p2, T3 p3, T4 p4, TaskCreationOptions ceationOptions)
        {

            return ParamTasks.Async(action, p1, p2, p3, p4, ceationOptions);

        }

        public static Task Async<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action, T1 p1, T2 p2, T3 p3, T4 p4, CancellationToken cancellationToken)
        {

            return ParamTasks.Async(action, p1, p2, p3, p4, cancellationToken);

        }

        public static Task Async<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action, T1 p1, T2 p2, T3 p3, T4 p4, CancellationToken cancellationToken, TaskCreationOptions ceationOptions, TaskScheduler scheduler)
        {

            return ParamTasks.Async(action, p1, p2, p3, p4, cancellationToken, ceationOptions, scheduler);

        }

    }

}
