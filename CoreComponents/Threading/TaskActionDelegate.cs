using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading
{

    internal static class TaskActionDelegate<T>
    {

        internal static readonly Action<object> Action1P;

        static TaskActionDelegate()
        {

            Action1P = ActionMethod;

        }

        internal static void ActionMethod(object obj)
        {

            var param = (TaskActionParameters<T>)obj;

            var action = param.Action;

            var p = param.P;

            action(p);

        }

    }

    internal static class TaskActionDelegate<T1, T2>
    {

        internal static readonly Action<object> Action2P;

        static TaskActionDelegate()
        {

            Action2P = ActionMethod;

        }

        internal static void ActionMethod(object obj)
        {

            var param = (TaskActionParameters<T1, T2>)obj;

            var action = param.Action;

            var p1 = param.P1;

            var p2 = param.P2;

            action(p1, p2);

        }

    }

    internal static class TaskActionDelegate<T1, T2, T3>
    {

        internal static readonly Action<object> Action3P;

        static TaskActionDelegate()
        {

            Action3P = ActionMethod;

        }

        internal static void ActionMethod(object obj)
        {

            var param = (TaskActionParameters<T1, T2, T3>)obj;

            var action = param.Action;

            var p1 = param.P1;

            var p2 = param.P2;

            var p3 = param.P3;

            action(p1, p2, p3);

        }

    }

    internal static class TaskActionDelegate<T1, T2, T3, T4>
    {

        internal static readonly Action<object> Action4P;

        static TaskActionDelegate()
        {

            Action4P = ActionMethod;

        }

        internal static void ActionMethod(object obj)
        {

            var param = (TaskActionParameters<T1, T2, T3, T4>)obj;

            var action = param.Action;

            var p1 = param.P1;

            var p2 = param.P2;

            var p3 = param.P3;

            var p4 = param.P4;

            action(p1, p2, p3, p4);

        }

    }

}
