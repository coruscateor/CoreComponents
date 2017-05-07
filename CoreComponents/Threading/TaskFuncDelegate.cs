using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading
{

    internal static class TaskFuncDelegate<T, TResult>
    {

        internal static readonly Func<object, TResult> Func1P;

        static TaskFuncDelegate()
        {

            Func1P = FuncMethod;

        }

        internal static TResult FuncMethod(object obj)
        {

            var param = (TaskFuncParameters<T, TResult>)obj;

            var func = param.Func;

            var p = param.P;
            
            return func(p);

        }

    }

    internal static class TaskFuncDelegate<T1, T2, TResult>
    {

        internal static readonly Func<object, TResult> Func2P;

        static TaskFuncDelegate()
        {

            Func2P = FuncMethod;

        }

        internal static TResult FuncMethod(object obj)
        {

            var param = (TaskFuncParameters<T1, T2, TResult>)obj;

            var func = param.Func;

            var p1 = param.P1;

            var p2 = param.P2;

            return func(p1, p2);

        }

    }

    internal static class TaskFuncDelegate<T1, T2, T3, TResult>
    {

        internal static readonly Func<object, TResult> Func3P;

        static TaskFuncDelegate()
        {

            Func3P = FuncMethod;

        }

        internal static TResult FuncMethod(object obj)
        {

            var param = (TaskFuncParameters<T1, T2, T3, TResult>)obj;

            var func = param.Func;

            var p1 = param.P1;

            var p2 = param.P2;

            var p3 = param.P3;

            return func(p1, p2, p3);

        }

    }

    internal static class TaskFuncDelegate<T1, T2, T3, T4, TResult>
    {

        internal static readonly Func<object, TResult> Func4P;

        static TaskFuncDelegate()
        {

            Func4P = FuncMethod;

        }

        internal static TResult FuncMethod(object obj)
        {

            var param = (TaskFuncParameters<T1, T2, T3, T4, TResult>)obj;

            var func = param.Func;

            var p1 = param.P1;

            var p2 = param.P2;

            var p3 = param.P3;

            var p4 = param.P4;

            return func(p1, p2, p3, p4);

        }

    }

}
