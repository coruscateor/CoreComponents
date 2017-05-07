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

        static TaskActionParameters<T> Setup<T>(Action<T> action, T p)
        {

            var param = new TaskActionParameters<T>();

            param.Set(action, p);

            return param;

        }

        public static Task Async<T>(Action<T> action, T p)
        {
            
            return Task.Factory.StartNew(TaskActionDelegate<T>.Action1P, Setup(action, p));

        }

        public static Task Async<T>(Action<T> action, T p, TaskCreationOptions ceationOptions)
        {

            return Task.Factory.StartNew(TaskActionDelegate<T>.Action1P, Setup(action, p), ceationOptions);

        }

        public static Task Async<T>(Action<T> action, T p, CancellationToken cancellationToken)
        {

            return Task.Factory.StartNew(TaskActionDelegate<T>.Action1P, Setup(action, p), cancellationToken);

        }

        public static Task Async<T>(Action<T> action, T p, CancellationToken cancellationToken, TaskCreationOptions ceationOptions, TaskScheduler scheduler)
        {

            return Task.Factory.StartNew(TaskActionDelegate<T>.Action1P, Setup(action, p), cancellationToken, ceationOptions, scheduler);

        }

        //

        static TaskActionParameters<T> Setup<T>(TaskActionParameters<T> TAP, Action<T> action, T p)
        {

            TAP.Set(action, p);

            return TAP;

        }

        public static Task Async<T>(TaskActionParameters<T> TAP, Action<T> action, T p)
        {

            return Task.Factory.StartNew(TaskActionDelegate<T>.Action1P, Setup(TAP, action, p));

        }

        public static Task Async<T>(TaskActionParameters<T> TAP, Action<T> action, T p, TaskCreationOptions ceationOptions)
        {

            return Task.Factory.StartNew(TaskActionDelegate<T>.Action1P, Setup(TAP, action, p), ceationOptions);

        }

        public static Task Async<T>(TaskActionParameters<T> TAP, Action<T> action, T p, CancellationToken cancellationToken)
        {

            return Task.Factory.StartNew(TaskActionDelegate<T>.Action1P, Setup(TAP, action, p), cancellationToken);

        }

        public static Task Async<T>(TaskActionParameters<T> TAP, Action<T> action, T p, CancellationToken cancellationToken, TaskCreationOptions ceationOptions, TaskScheduler scheduler)
        {

            return Task.Factory.StartNew(TaskActionDelegate<T>.Action1P, Setup(TAP, action, p), cancellationToken, ceationOptions, scheduler);

        }

        //

        static TaskActionParameters<T1, T2> Setup<T1, T2>(Action<T1, T2> action, T1 p1, T2 p2)
        {

            var param = new TaskActionParameters<T1, T2>();

            param.Set(action, p1, p2);

            return param;

        }

        public static Task Async<T1, T2>(Action<T1, T2> action, T1 p1, T2 p2)
        {

            return Task.Factory.StartNew(TaskActionDelegate<T1, T2>.Action2P, Setup(action, p1, p2));

        }

        public static Task Async<T1, T2>(Action<T1, T2> action, T1 p1, T2 p2, TaskCreationOptions ceationOptions)
        {

            return Task.Factory.StartNew(TaskActionDelegate<T1, T2>.Action2P, Setup(action, p1, p2), ceationOptions);

        }

        public static Task Async<T1, T2>(Action<T1, T2> action, T1 p1, T2 p2, CancellationToken cancellationToken)
        {

            return Task.Factory.StartNew(TaskActionDelegate<T1, T2>.Action2P, Setup(action, p1, p2), cancellationToken);

        }

        public static Task Async<T1, T2>(Action<T1, T2> action, T1 p1, T2 p2, CancellationToken cancellationToken, TaskCreationOptions ceationOptions, TaskScheduler scheduler)
        {

            return Task.Factory.StartNew(TaskActionDelegate<T1, T2>.Action2P, Setup(action, p1, p2), cancellationToken, ceationOptions, scheduler);

        }

        //

        static TaskActionParameters<T1, T2> Setup<T1, T2>(TaskActionParameters<T1, T2> TAP, Action<T1, T2> action, T1 p1, T2 p2)
        {

            TAP.Set(action, p1, p2);

            return TAP;

        }

        public static Task Async<T1, T2>(TaskActionParameters<T1, T2> TAP, Action<T1, T2> action, T1 p1, T2 p2)
        {

            return Task.Factory.StartNew(TaskActionDelegate<T1, T2>.Action2P, Setup(TAP, action, p1, p2));

        }

        public static Task Async<T1, T2>(TaskActionParameters<T1, T2> TAP, Action<T1, T2> action, T1 p1, T2 p2, TaskCreationOptions ceationOptions)
        {

            return Task.Factory.StartNew(TaskActionDelegate<T1, T2>.Action2P, Setup(TAP, action, p1, p2), ceationOptions);

        }

        public static Task Async<T1, T2>(TaskActionParameters<T1, T2> TAP, Action<T1, T2> action, T1 p1, T2 p2, CancellationToken cancellationToken)
        {

            return Task.Factory.StartNew(TaskActionDelegate<T1, T2>.Action2P, Setup(TAP, action, p1, p2), cancellationToken);

        }

        public static Task Async<T1, T2>(TaskActionParameters<T1, T2> TAP, Action<T1, T2> action, T1 p1, T2 p2, CancellationToken cancellationToken, TaskCreationOptions ceationOptions, TaskScheduler scheduler)
        {

            return Task.Factory.StartNew(TaskActionDelegate<T1, T2>.Action2P, Setup(TAP, action, p1, p2), cancellationToken, ceationOptions, scheduler);

        }

        //

        static TaskActionParameters<T1, T2, T3> Setup<T1, T2, T3>(Action<T1, T2, T3> action, T1 p1, T2 p2, T3 p3)
        {

            var param = new TaskActionParameters<T1, T2, T3>();

            param.Set(action, p1, p2, p3);

            return param;

        }

        public static Task Async<T1, T2, T3>(Action<T1, T2, T3> action, T1 p1, T2 p2, T3 p3)
        {

            return Task.Factory.StartNew(TaskActionDelegate<T1, T2>.Action2P, Setup(action, p1, p2, p3));

        }

        public static Task Async<T1, T2, T3>(Action<T1, T2, T3> action, T1 p1, T2 p2, T3 p3, TaskCreationOptions ceationOptions)
        {

            return Task.Factory.StartNew(TaskActionDelegate<T1, T2, T3>.Action3P, Setup(action, p1, p2, p3), ceationOptions);

        }

        public static Task Async<T1, T2, T3>(Action<T1, T2, T3> action, T1 p1, T2 p2, T3 p3, CancellationToken cancellationToken)
        {

            return Task.Factory.StartNew(TaskActionDelegate<T1, T2, T3>.Action3P, Setup(action, p1, p2, p3), cancellationToken);

        }

        public static Task Async<T1, T2, T3>(Action<T1, T2, T3> action, T1 p1, T2 p2, T3 p3, CancellationToken cancellationToken, TaskCreationOptions ceationOptions, TaskScheduler scheduler)
        {

            return Task.Factory.StartNew(TaskActionDelegate<T1, T2, T3>.Action3P, Setup(action, p1, p2, p3), cancellationToken, ceationOptions, scheduler);

        }

        //

        static TaskActionParameters<T1, T2, T3> Setup<T1, T2, T3>(TaskActionParameters<T1, T2, T3> TAP, Action<T1, T2, T3> action, T1 p1, T2 p2, T3 p3)
        {

            TAP.Set(action, p1, p2, p3);

            return TAP;

        }

        public static Task Async<T1, T2, T3>(TaskActionParameters<T1, T2, T3> TAP, Action<T1, T2, T3> action, T1 p1, T2 p2, T3 p3)
        {

            return Task.Factory.StartNew(TaskActionDelegate<T1, T2>.Action2P, Setup(TAP, action, p1, p2, p3));

        }

        public static Task Async<T1, T2, T3>(TaskActionParameters<T1, T2, T3> TAP, Action<T1, T2, T3> action, T1 p1, T2 p2, T3 p3, TaskCreationOptions ceationOptions)
        {

            return Task.Factory.StartNew(TaskActionDelegate<T1, T2, T3>.Action3P, Setup(TAP, action, p1, p2, p3), ceationOptions);

        }

        public static Task Async<T1, T2, T3>(TaskActionParameters<T1, T2, T3> TAP, Action<T1, T2, T3> action, T1 p1, T2 p2, T3 p3, CancellationToken cancellationToken)
        {

            return Task.Factory.StartNew(TaskActionDelegate<T1, T2, T3>.Action3P, Setup(TAP, action, p1, p2, p3), cancellationToken);

        }

        public static Task Async<T1, T2, T3>(TaskActionParameters<T1, T2, T3> TAP, Action<T1, T2, T3> action, T1 p1, T2 p2, T3 p3, CancellationToken cancellationToken, TaskCreationOptions ceationOptions, TaskScheduler scheduler)
        {

            return Task.Factory.StartNew(TaskActionDelegate<T1, T2, T3>.Action3P, Setup(TAP, action, p1, p2, p3), cancellationToken, ceationOptions, scheduler);

        }

        //

        static TaskActionParameters<T1, T2, T3, T4> Setup<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action, T1 p1, T2 p2, T3 p3, T4 p4)
        {

            var param = new TaskActionParameters<T1, T2, T3, T4>();

            param.Set(action, p1, p2, p3, p4);

            return param;

        }

        public static Task Async<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action, T1 p1, T2 p2, T3 p3, T4 p4)
        {

            return Task.Factory.StartNew(TaskActionDelegate<T1, T2, T3, T4>.Action4P, Setup(action, p1, p2, p3, p4));

        }

        public static Task Async<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action, T1 p1, T2 p2, T3 p3, T4 p4, TaskCreationOptions ceationOptions)
        {

            return Task.Factory.StartNew(TaskActionDelegate<T1, T2, T3, T4>.Action4P, Setup(action, p1, p2, p3, p4), ceationOptions);

        }

        public static Task Async<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action, T1 p1, T2 p2, T3 p3, T4 p4, CancellationToken cancellationToken)
        {

            return Task.Factory.StartNew(TaskActionDelegate<T1, T2, T3, T4>.Action4P, Setup(action, p1, p2, p3, p4), cancellationToken);

        }

        public static Task Async<T1, T2, T3, T4>(Action<T1, T2, T3, T4> action, T1 p1, T2 p2, T3 p3, T4 p4, CancellationToken cancellationToken, TaskCreationOptions ceationOptions, TaskScheduler scheduler)
        {

            return Task.Factory.StartNew(TaskActionDelegate<T1, T2, T3, T4>.Action4P, Setup(action, p1, p2, p3, p4), cancellationToken, ceationOptions, scheduler);

        }

        //

        static TaskActionParameters<T1, T2, T3, T4> Setup<T1, T2, T3, T4>(TaskActionParameters<T1, T2, T3, T4> TAP, Action<T1, T2, T3, T4> action, T1 p1, T2 p2, T3 p3, T4 p4)
        {

            TAP.Set(action, p1, p2, p3, p4);

            return TAP;

        }

        public static Task Async<T1, T2, T3, T4>(TaskActionParameters<T1, T2, T3, T4> TAP, Action<T1, T2, T3, T4> action, T1 p1, T2 p2, T3 p3, T4 p4)
        {

            return Task.Factory.StartNew(TaskActionDelegate<T1, T2, T3, T4>.Action4P, Setup(TAP, action, p1, p2, p3, p4));

        }

        public static Task Async<T1, T2, T3, T4>(TaskActionParameters<T1, T2, T3, T4> TAP, Action<T1, T2, T3, T4> action, T1 p1, T2 p2, T3 p3, T4 p4, TaskCreationOptions ceationOptions)
        {

            return Task.Factory.StartNew(TaskActionDelegate<T1, T2, T3, T4>.Action4P, Setup(TAP, action, p1, p2, p3, p4), ceationOptions);

        }

        public static Task Async<T1, T2, T3, T4>(TaskActionParameters<T1, T2, T3, T4> TAP, Action<T1, T2, T3, T4> action, T1 p1, T2 p2, T3 p3, T4 p4, CancellationToken cancellationToken)
        {

            return Task.Factory.StartNew(TaskActionDelegate<T1, T2, T3, T4>.Action4P, Setup(TAP, action, p1, p2, p3, p4), cancellationToken);

        }

        public static Task Async<T1, T2, T3, T4>(TaskActionParameters<T1, T2, T3, T4> TAP, Action<T1, T2, T3, T4> action, T1 p1, T2 p2, T3 p3, T4 p4, CancellationToken cancellationToken, TaskCreationOptions ceationOptions, TaskScheduler scheduler)
        {

            return Task.Factory.StartNew(TaskActionDelegate<T1, T2, T3, T4>.Action4P, Setup(TAP, action, p1, p2, p3, p4), cancellationToken, ceationOptions, scheduler);

        }

    }

}
