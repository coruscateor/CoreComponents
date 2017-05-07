using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreComponents.Threading.Extensions
{

    public static class ThreadingExtensions
    {

        public static void Lock<T>(this T obj, Action<T> act)
            where T : class
        {

            lock(obj)
            {

                act(obj);

            }

        }

        public static TResult Lock<T, TResult>(this T obj, Func<T, TResult> func)
            where T : class
        {

            lock(obj)
            {

                return func(obj);

            }

        }

        public static bool LockNow<T>(this T obj, Action<T> act)
            where T : class
        {

            if(!Monitor.TryEnter(obj))
                return false;

            try
            {

                act(obj);

            }
            finally
            {

                Monitor.Exit(obj);

            }

            return true;

        }

        public static bool LockNow<T, TResult>(this T obj, Func<T, TResult> func, out TResult result)
            where T : class
        {

            if(!Monitor.TryEnter(obj))
            {

                result = default(TResult);

                return false;

            }

            try
            {

                result = func(obj);

            }
            finally
            {

                Monitor.Exit(obj);

            }

            return true;

        }

        public static bool Ended(this Task task)
        {

            var status = task.Status;

            return status == TaskStatus.RanToCompletion || status == TaskStatus.Canceled || status == TaskStatus.Faulted;

        }

    }

}
