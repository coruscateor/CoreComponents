using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreComponents.Threading.Extensions
{

    public static class AsyncFuncDelegates
    {

        //0p

        public static Task<TResult> Async<TResult>(this Func<TResult> func)
        {

            return Task.Factory.StartNew(func);

        }

        public static Task<TResult> Async<TResult>(this Func<TResult> func, TaskCreationOptions creationOptions)
        {

            return Task.Factory.StartNew(func, creationOptions);

        }

        public static Task<TResult> Async<TResult>(this Func<TResult> func, CancellationToken cancellationToken)
        {

            return Task.Factory.StartNew(func, cancellationToken);

        }

        public static Task<TResult> Async<TResult>(this Func<TResult> func, CancellationToken cancellationToken, TaskCreationOptions ceationOptions, TaskScheduler scheduler)
        {

            return Task.Factory.StartNew(func, cancellationToken, ceationOptions, scheduler);

        }

        //1p

        public static Task<TResult> Async<T, TResult>(this Func<T, TResult> func, T p)
        {

            return ParamTasks.Async(func, p);

        }
        
        public static Task<TResult> Async<T, TResult>(this Func<T, TResult> func, T p, TaskCreationOptions creationOptions)
        {

            return ParamTasks.Async(func, p, creationOptions);

        }

        public static Task<TResult> Async<T, TResult>(this Func<T, TResult> func, T p, CancellationToken cancellationToken)
        {

            return ParamTasks.Async(func, p, cancellationToken);

        }

        public static Task<TResult> Async<T, TResult>(this Func<T, TResult> func, T p, CancellationToken cancellationToken, TaskCreationOptions ceationOptions, TaskScheduler scheduler)
        {

            return ParamTasks.Async(func, p, cancellationToken, ceationOptions, scheduler);

        }

        //2p

        public static Task<TResult> Async<T1, T2, TResult>(this Func<T1, T2, TResult> func, T1 p1, T2 p2)
        {

            return ParamTasks.Async(func, p1, p2);

        }

        public static Task<TResult> Async<T1, T2, TResult>(this Func<T1, T2, TResult> func, T1 p1, T2 p2, TaskCreationOptions creationOptions)
        {

            return ParamTasks.Async(func, p1, p2, creationOptions);

        }

        public static Task<TResult> Async<T1, T2, TResult>(this Func<T1, T2, TResult> func, T1 p1, T2 p2, CancellationToken cancellationToken)
        {

            return ParamTasks.Async(func, p1, p2, cancellationToken);

        }

        public static Task<TResult> Async<T1, T2, TResult>(this Func<T1, T2, TResult> func, T1 p1, T2 p2, CancellationToken cancellationToken, TaskCreationOptions ceationOptions, TaskScheduler scheduler)
        {

            return ParamTasks.Async(func, p1, p2, cancellationToken, ceationOptions, scheduler);

        }

        //3p

        public static Task<TResult> Async<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> func, T1 p1, T2 p2, T3 p3)
        {

            return ParamTasks.Async(func, p1, p2, p3);

        }

        public static Task<TResult> Async<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> func, T1 p1, T2 p2, T3 p3,TaskCreationOptions creationOptions)
        {

            return ParamTasks.Async(func, p1, p2, p3, creationOptions);

        }

        public static Task<TResult> Async<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> func, T1 p1, T2 p2, T3 p3, CancellationToken cancellationToken)
        {

            return ParamTasks.Async(func, p1, p2, p3, cancellationToken);

        }

        public static Task<TResult> Async<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> func, T1 p1, T2 p2, T3 p3, CancellationToken cancellationToken, TaskCreationOptions ceationOptions, TaskScheduler scheduler)
        {

            return ParamTasks.Async(func, p1, p2, p3, cancellationToken, ceationOptions, scheduler);

        }

        //4p

        public static Task<TResult> Async<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> func, T1 p1, T2 p2, T3 p3, T4 p4)
        {

            return ParamTasks.Async(func, p1, p2, p3, p4);

        }

        public static Task<TResult> Async<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> func, T1 p1, T2 p2, T3 p3, T4 p4, TaskCreationOptions creationOptions)
        {

            return ParamTasks.Async(func, p1, p2, p3, p4, creationOptions);

        }

        public static Task<TResult> Async<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> func, T1 p1, T2 p2, T3 p3, T4 p4, CancellationToken cancellationToken)
        {

            return ParamTasks.Async(func, p1, p2, p3, p4, cancellationToken);

        }

        public static Task<TResult> Async<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> func, T1 p1, T2 p2, T3 p3, T4 p4, CancellationToken cancellationToken, TaskCreationOptions ceationOptions, TaskScheduler scheduler)
        {

            return ParamTasks.Async(func, p1, p2, p3, p4, cancellationToken, ceationOptions, scheduler);

        }

    }

}
