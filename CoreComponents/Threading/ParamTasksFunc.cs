using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreComponents.Threading
{

    public static partial class ParamTasks
    {

        static TaskFuncParameters<T, TResult> Setup<T, TResult>(Func<T, TResult> func, T p)
        {

            var param = new TaskFuncParameters<T, TResult>();

            param.Set(func, p);

            return param;

        }

        public static Task<TResult> Async<T, TResult>(Func<T, TResult> func, T p)
        {

            return Task.Factory.StartNew(TaskFuncDelegate<T, TResult>.Func1P, Setup(func, p));

        }

        public static Task<TResult> Async<T, TResult>(Func<T, TResult> func, T p, TaskCreationOptions ceationOptions)
        {

            return Task.Factory.StartNew(TaskFuncDelegate<T, TResult>.Func1P, Setup(func, p), ceationOptions);

        }

        public static Task<TResult> Async<T, TResult>(Func<T, TResult> func, T p, CancellationToken cancellationToken)
        {

            return Task.Factory.StartNew(TaskFuncDelegate<T, TResult>.Func1P, Setup(func, p), cancellationToken);

        }

        public static Task<TResult> Async<T, TResult>(Func<T, TResult> func, T p, CancellationToken cancellationToken, TaskCreationOptions ceationOptions, TaskScheduler scheduler)
        {

            return Task.Factory.StartNew(TaskFuncDelegate<T, TResult>.Func1P, Setup(func, p), cancellationToken, ceationOptions, scheduler);

        }

        //

        static TaskFuncParameters<T, TResult> Setup<T, TResult>(TaskFuncParameters<T, TResult> TFP, Func<T, TResult> func, T p)
        {

            TFP.Set(func, p);

            return TFP;

        }

        public static Task<TResult> Async<T, TResult>(TaskFuncParameters<T, TResult> TFP, Func<T, TResult> func, T p)
        {

            return Task.Factory.StartNew(TaskFuncDelegate<T, TResult>.Func1P, Setup(TFP, func, p));

        }

        public static Task<TResult> Async<T, TResult>(TaskFuncParameters<T, TResult> TFP, Func<T, TResult> func, T p, TaskCreationOptions ceationOptions)
        {

            return Task.Factory.StartNew(TaskFuncDelegate<T, TResult>.Func1P, Setup(TFP, func, p), ceationOptions);

        }

        public static Task<TResult> Async<T, TResult>(TaskFuncParameters<T, TResult> TFP, Func<T, TResult> func, T p, CancellationToken cancellationToken)
        {

            return Task.Factory.StartNew(TaskFuncDelegate<T, TResult>.Func1P, Setup(TFP, func, p), cancellationToken);

        }

        public static Task<TResult> Async<T, TResult>(TaskFuncParameters<T, TResult> TFP, Func<T, TResult> func, T p, CancellationToken cancellationToken, TaskCreationOptions ceationOptions, TaskScheduler scheduler)
        {

            return Task.Factory.StartNew(TaskFuncDelegate<T, TResult>.Func1P, Setup(TFP, func, p), cancellationToken, ceationOptions, scheduler);

        }

        //

        static TaskFuncParameters<T1, T2, TResult> Setup<T1, T2, TResult>(Func<T1, T2, TResult> func, T1 p1, T2 p2)
        {

            var param = new TaskFuncParameters<T1, T2, TResult>();

            param.Set(func, p1, p2);

            return param;

        }

        public static Task<TResult> Async<T1, T2, TResult>(Func<T1, T2, TResult> func, T1 p1, T2 p2)
        {

            return Task.Factory.StartNew(TaskFuncDelegate<T1, T2, TResult>.Func2P, Setup(func, p1, p2));

        }

        public static Task<TResult> Async<T1, T2, TResult>(Func<T1, T2, TResult> func, T1 p1, T2 p2, TaskCreationOptions ceationOptions)
        {

            return Task.Factory.StartNew(TaskFuncDelegate<T1, T2, TResult>.Func2P, Setup(func, p1, p2), ceationOptions);

        }

        public static Task<TResult> Async<T1, T2, TResult>(Func<T1, T2, TResult> func, T1 p1, T2 p2, CancellationToken cancellationToken)
        {

            return Task.Factory.StartNew(TaskFuncDelegate<T1, T2, TResult>.Func2P, Setup(func, p1, p2), cancellationToken);

        }

        public static Task<TResult> Async<T1, T2, TResult>(Func<T1, T2, TResult> func, T1 p1, T2 p2, CancellationToken cancellationToken, TaskCreationOptions ceationOptions, TaskScheduler scheduler)
        {

            return Task.Factory.StartNew(TaskFuncDelegate<T1, T2, TResult>.Func2P, Setup(func, p1, p2), cancellationToken, ceationOptions, scheduler);

        }

        //

        static TaskFuncParameters<T1, T2, TResult> Setup<T1, T2, TResult>(TaskFuncParameters<T1, T2, TResult> TFP, Func<T1, T2, TResult> func, T1 p1, T2 p2)
        {

            TFP.Set(func, p1, p2);

            return TFP;

        }

        public static Task<TResult> Async<T1, T2, TResult>(TaskFuncParameters<T1, T2, TResult> TFP, Func<T1, T2, TResult> func, T1 p1, T2 p2)
        {

            return Task.Factory.StartNew(TaskFuncDelegate<T1, T2, TResult>.Func2P, Setup(TFP, func, p1, p2));

        }

        public static Task<TResult> Async<T1, T2, TResult>(TaskFuncParameters<T1, T2, TResult> TFP, Func<T1, T2, TResult> func, T1 p1, T2 p2, TaskCreationOptions ceationOptions)
        {

            return Task.Factory.StartNew(TaskFuncDelegate<T1, T2, TResult>.Func2P, Setup(TFP, func, p1, p2), ceationOptions);

        }

        public static Task<TResult> Async<T1, T2, TResult>(TaskFuncParameters<T1, T2, TResult> TFP, Func<T1, T2, TResult> func, T1 p1, T2 p2, CancellationToken cancellationToken)
        {

            return Task.Factory.StartNew(TaskFuncDelegate<T1, T2, TResult>.Func2P, Setup(TFP, func, p1, p2), cancellationToken);

        }

        public static Task<TResult> Async<T1, T2, TResult>(TaskFuncParameters<T1, T2, TResult> TFP, Func<T1, T2, TResult> func, T1 p1, T2 p2, CancellationToken cancellationToken, TaskCreationOptions ceationOptions, TaskScheduler scheduler)
        {

            return Task.Factory.StartNew(TaskFuncDelegate<T1, T2, TResult>.Func2P, Setup(TFP, func, p1, p2), cancellationToken, ceationOptions, scheduler);

        }

        //

        static TaskFuncParameters<T1, T2, T3, TResult> Setup<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> func, T1 p1, T2 p2, T3 p3)
        {

            var param = new TaskFuncParameters<T1, T2, T3, TResult>();

            param.Set(func, p1, p2, p3);

            return param;

        }

        public static Task<TResult> Async<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> func, T1 p1, T2 p2, T3 p3)
        {

            return Task.Factory.StartNew(TaskFuncDelegate<T1, T2, T3, TResult>.Func3P, Setup(func, p1, p2, p3));

        }

        public static Task<TResult> Async<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> func, T1 p1, T2 p2, T3 p3, TaskCreationOptions ceationOptions)
        {

            return Task.Factory.StartNew(TaskFuncDelegate<T1, T2, T3, TResult>.Func3P, Setup(func, p1, p2, p3), ceationOptions);

        }

        public static Task<TResult> Async<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> func, T1 p1, T2 p2, T3 p3, CancellationToken cancellationToken)
        {

            return Task.Factory.StartNew(TaskFuncDelegate<T1, T2, T3, TResult>.Func3P, Setup(func, p1, p2, p3), cancellationToken);

        }

        public static Task<TResult> Async<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> func, T1 p1, T2 p2, T3 p3, CancellationToken cancellationToken, TaskCreationOptions ceationOptions, TaskScheduler scheduler)
        {

            return Task.Factory.StartNew(TaskFuncDelegate<T1, T2, T3, TResult>.Func3P, Setup(func, p1, p2, p3), cancellationToken, ceationOptions, scheduler);

        }

        //

        static TaskFuncParameters<T1, T2, T3, TResult> Setup<T1, T2, T3, TResult>(TaskFuncParameters<T1, T2, T3, TResult> TFP, Func<T1, T2, T3, TResult> func, T1 p1, T2 p2, T3 p3)
        {

            TFP.Set(func, p1, p2, p3);

            return TFP;

        }

        public static Task<TResult> Async<T1, T2, T3, TResult>(TaskFuncParameters<T1, T2, T3, TResult> TFP, Func<T1, T2, T3, TResult> func, T1 p1, T2 p2, T3 p3)
        {

            return Task.Factory.StartNew(TaskFuncDelegate<T1, T2, T3, TResult>.Func3P, Setup(TFP, func, p1, p2, p3));

        }

        public static Task<TResult> Async<T1, T2, T3, TResult>(TaskFuncParameters<T1, T2, T3, TResult> TFP, Func<T1, T2, T3, TResult> func, T1 p1, T2 p2, T3 p3, TaskCreationOptions ceationOptions)
        {

            return Task.Factory.StartNew(TaskFuncDelegate<T1, T2, T3, TResult>.Func3P, Setup(TFP, func, p1, p2, p3), ceationOptions);

        }

        public static Task<TResult> Async<T1, T2, T3, TResult>(TaskFuncParameters<T1, T2, T3, TResult> TFP, Func<T1, T2, T3, TResult> func, T1 p1, T2 p2, T3 p3, CancellationToken cancellationToken)
        {

            return Task.Factory.StartNew(TaskFuncDelegate<T1, T2, T3, TResult>.Func3P, Setup(TFP, func, p1, p2, p3), cancellationToken);

        }

        public static Task<TResult> Async<T1, T2, T3, TResult>(TaskFuncParameters<T1, T2, T3, TResult> TFP, Func<T1, T2, T3, TResult> func, T1 p1, T2 p2, T3 p3, CancellationToken cancellationToken, TaskCreationOptions ceationOptions, TaskScheduler scheduler)
        {

            return Task.Factory.StartNew(TaskFuncDelegate<T1, T2, T3, TResult>.Func3P, Setup(TFP, func, p1, p2, p3), cancellationToken, ceationOptions, scheduler);

        }

        //

        static TaskFuncParameters<T1, T2, T3, T4, TResult> Setup<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> func, T1 p1, T2 p2, T3 p3, T4 p4)
        {

            var param = new TaskFuncParameters<T1, T2, T3, T4, TResult>();

            param.Set(func, p1, p2, p3, p4);

            return param;

        }

        public static Task<TResult> Async<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> func, T1 p1, T2 p2, T3 p3, T4 p4)
        {

            return Task.Factory.StartNew(TaskFuncDelegate<T1, T2, T3, T4, TResult>.Func4P, Setup(func, p1, p2, p3, p4));

        }

        public static Task<TResult> Async<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> func, T1 p1, T2 p2, T3 p3, T4 p4, TaskCreationOptions ceationOptions)
        {

            return Task.Factory.StartNew(TaskFuncDelegate<T1, T2, T3, T4, TResult>.Func4P, Setup(func, p1, p2, p3, p4), ceationOptions);

        }

        public static Task<TResult> Async<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> func, T1 p1, T2 p2, T3 p3, T4 p4, CancellationToken cancellationToken)
        {

            return Task.Factory.StartNew(TaskFuncDelegate<T1, T2, T3, T4, TResult>.Func4P, Setup(func, p1, p2, p3, p4), cancellationToken);

        }

        public static Task<TResult> Async<T1, T2, T3, T4, TResult>(Func<T1, T2, T3, T4, TResult> func, T1 p1, T2 p2, T3 p3, T4 p4, CancellationToken cancellationToken, TaskCreationOptions ceationOptions, TaskScheduler scheduler)
        {

            return Task.Factory.StartNew(TaskFuncDelegate<T1, T2, T3, T4, TResult>.Func4P, Setup(func, p1, p2, p3, p4), cancellationToken, ceationOptions, scheduler);

        }

        //

        static TaskFuncParameters<T1, T2, T3, T4, TResult> Setup<T1, T2, T3, T4, TResult>(TaskFuncParameters<T1, T2, T3, T4, TResult> TFP, Func<T1, T2, T3, T4, TResult> func, T1 p1, T2 p2, T3 p3, T4 p4)
        {

            TFP.Set(func, p1, p2, p3, p4);

            return TFP;

        }

        public static Task<TResult> Async<T1, T2, T3, T4, TResult>(TaskFuncParameters<T1, T2, T3, T4, TResult> TFP, Func<T1, T2, T3, T4, TResult> func, T1 p1, T2 p2, T3 p3, T4 p4)
        {

            return Task.Factory.StartNew(TaskFuncDelegate<T1, T2, T3, T4, TResult>.Func4P, Setup(TFP, func, p1, p2, p3, p4));

        }

        public static Task<TResult> Async<T1, T2, T3, T4, TResult>(TaskFuncParameters<T1, T2, T3, T4, TResult> TFP, Func<T1, T2, T3, T4, TResult> func, T1 p1, T2 p2, T3 p3, T4 p4, TaskCreationOptions ceationOptions)
        {

            return Task.Factory.StartNew(TaskFuncDelegate<T1, T2, T3, T4, TResult>.Func4P, Setup(TFP, func, p1, p2, p3, p4), ceationOptions);

        }

        public static Task<TResult> Async<T1, T2, T3, T4, TResult>(TaskFuncParameters<T1, T2, T3, T4, TResult> TFP, Func<T1, T2, T3, T4, TResult> func, T1 p1, T2 p2, T3 p3, T4 p4, CancellationToken cancellationToken)
        {

            return Task.Factory.StartNew(TaskFuncDelegate<T1, T2, T3, T4, TResult>.Func4P, Setup(TFP, func, p1, p2, p3, p4), cancellationToken);

        }

        public static Task<TResult> Async<T1, T2, T3, T4, TResult>(TaskFuncParameters<T1, T2, T3, T4, TResult> TFP, Func<T1, T2, T3, T4, TResult> func, T1 p1, T2 p2, T3 p3, T4 p4, CancellationToken cancellationToken, TaskCreationOptions ceationOptions, TaskScheduler scheduler)
        {

            return Task.Factory.StartNew(TaskFuncDelegate<T1, T2, T3, T4, TResult>.Func4P, Setup(TFP, func, p1, p2, p3, p4), cancellationToken, ceationOptions, scheduler);

        }

    }

}
