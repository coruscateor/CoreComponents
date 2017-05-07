using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Extensions
{

    public static class CoreComponentsExtensions
    {

        public static void ReThrow(this Exception ex)
        {

            throw new ReThrownException(ex);

        }

        public static void ReThrow(this Exception ex, string message)
        {

            throw new ReThrownException(ex, message);

        }

        public static void ReThrow(this IEnumerable<Exception> exs)
        {
            
            throw new AggregateException(exs);

        }

        public static void ReThrow(this IEnumerable<Exception> exs, string message)
        {

            throw new AggregateException(message, exs);

        }

        public static void ReThrow(this Exception[] exs)
        {

            throw new AggregateException(exs);

        }

        public static void ReThrow(this Exception[] exs, string message)
        {

            throw new AggregateException(message, exs);

        }

        public static void TryThrow(this IHaveException obj)
        {

            var ex = obj.Exception;

            if(ex != null)
                throw new ReThrownException(ex);

        }

        public static void TryThrow(this IHaveException obj, string message)
        {

            var ex = obj.Exception;

            if(ex != null)
                throw new ReThrownException(ex, message);

        }

        public static void TryThrowAgg(this IHaveException obj)
        {

            var ex = obj.Exception;

            if(ex != null)
                throw new AggregateException(ex);

        }

        public static void TryThrowAgg(this IHaveException obj, string message)
        {

            var ex = obj.Exception;

            if(ex != null)
                throw new AggregateException(message, ex);

        }

        public static void TryThrowNullReferenceException(this object obj)
        {

            if(obj == null)
                throw new NullReferenceException();

        }

        public static void TryThrowNullReferenceException(this object obj, string message)
        {

            if(obj == null)
                throw new NullReferenceException(message);

        }

        public static void TryThrowArgumentNullException(this object obj)
        {

            if(obj == null)
                throw new ArgumentNullException();

        }

        public static void TryThrowArgumentNullException(this object obj, string message)
        {

            if(obj == null)
                throw new ArgumentNullException(message);

        }

        public static void Times(this short value, Action action)
        {

            while(value > 0)
            {

                action();

                --value;

            }

        }

        public static void Times(this short value, Action<short> action)
        {

            while(value > 0)
            {

                action(value);

                --value;

            }

        }

        public static void Times(this ushort value, Action action)
        {

            while(value > 0)
            {

                action();

                --value;

            }

        }

        public static void Times(this ushort value, Action<ushort> action)
        {

            while(value > 0)
            {

                action(value);

                --value;

            }

        }

        public static void Times(this int value, Action action)
        {

            while(value > 0)
            {

                action();

                --value;

            }

        }

        public static void Times(this int value, Action<int> action)
        {

            while(value > 0)
            {

                action(value);

                --value;

            }

        }

        public static void Times(this uint value, Action action)
        {

            while(value > 0u)
            {

                action();

                --value;

            }

        }

        public static void Times(this uint value, Action<uint> action)
        {

            while(value > 0u)
            {

                action(value);

                --value;

            }

        }

        public static void Times(this long value, Action action)
        {

            while(value > 0L)
            {

                action();

                --value;

            }

        }

        public static void Times(this long value, Action<long> action)
        {

            while(value > 0L)
            {

                action(value);

                --value;

            }

        }

        public static void Times(this ulong value, Action action)
        {

            while(value > 0UL)
            {

                action();

                --value;

            }

        }

        public static void Times(this ulong value, Action<ulong> action)
        {

            while(value > 0UL)
            {

                action(value);

                --value;

            }

        }

        public static bool IsEven(this short value)
        {

            return value % 2 == 0;

        }

        public static bool IsEven(this ushort value)
        {

            return value % 2 == 0;

        }

        public static bool IsEven(this int value)
        {

            return value % 2 == 0;

        }

        public static bool IsEven(this uint value)
        {

            return value % 2u == 0u;

        }

        public static bool IsEven(this long value)
        {

            return value % 2L == 0L;

        }

        public static bool IsEven(this ulong value)
        {

            return value % 2UL == 0UL;

        }

        public static TimeSpan Day(this int value)
        {

            return new TimeSpan(value, 0, 0, 0, 0);

        }

        public static TimeSpan Days(this int value)
        {

            return new TimeSpan(value, 0, 0, 0, 0);

        }

        public static TimeSpan Hour(this int value)
        {

            return new TimeSpan(value, 0, 0);

        }

        public static TimeSpan Hours(this int value)
        {

            return new TimeSpan(value, 0, 0);

        }

        public static TimeSpan Minute(this int value)
        {

            return new TimeSpan(0, value, 0);

        }

        public static TimeSpan Minutes(this int value)
        {

            return new TimeSpan(0, value, 0);

        }

        public static TimeSpan Second(this int value)
        {

            return new TimeSpan(0, 0, value);

        }

        public static TimeSpan Seconds(this int value)
        {

            return new TimeSpan(0, 0, value);

        }

        public static TimeSpan Millisecond(this int value)
        {

            return new TimeSpan(0, 0, 0, 0, value);

        }

        public static TimeSpan Milliseconds(this int value)
        {

            return new TimeSpan(0, 0, 0, 0, value);

        }

        public static string Clone(this string str)
        {

            return (string)str.Clone();

        }

        public static string Dup(this string str)
        {

            return (string)str.Clone();

        }

        public static bool IsNull<T>(this T obj)
            where T : class
        {

            return obj == null;

        }

        public static bool IsNull<T>(this T obj, Action<T> action)
            where T : class
        {

            if(obj == null)
                return true;

            action(obj);

            return false;

        }

        public static bool IsNotNull<T>(this T obj)
            where T : class
        {

            return obj != null;

        }

        public static bool IsNotNull<T>(this T obj, Action<T> action)
            where T : class
        {

            if(obj != null)
            {

                action(obj);

                return true;

            }

            return false;

        }

        public static void UpTo(this short value, short upTo, Action action)
        {

            while(value <= upTo)
            {

                action();

                value++;

            }

        }

        public static void UpTo(this short value, short upTo, Action<short> action)
        {

            while(value <= upTo)
            {

                action(value);

                value++;

            }

        }

        public static void UpTo(this ushort value, ushort upTo, Action action)
        {

            while(value <= upTo)
            {

                action();

                value++;

            }

        }

        public static void UpTo(this ushort value, ushort upTo, Action<ushort> action)
        {

            while(value <= upTo)
            {

                action(value);

                value++;

            }

        }

        public static void UpTo(this int value, int upTo, Action action)
        {

            while(value <= upTo)
            {

                action();

                value++;

            }

        }

        public static void UpTo(this int value, int upTo, Action<int> action)
        {

            while(value <= upTo)
            {

                action(value);

                value++;

            }

        }

        public static void UpTo(this uint value, uint upTo, Action action)
        {

            while(value <= upTo)
            {

                action();

                value++;

            }

        }

        public static void UpTo(this uint value, uint upTo, Action<uint> action)
        {

            while(value <= upTo)
            {

                action(value);

                value++;

            }

        }

        public static void UpTo(this long value, long upTo, Action action)
        {

            while(value <= upTo)
            {

                action();

                value++;

            }

        }

        public static void UpTo(this long value, long upTo, Action<long> action)
        {

            while(value <= upTo)
            {

                action(value);

                value++;

            }

        }

        public static void UpTo(this ulong value, ulong upTo, Action action)
        {

            while(value <= upTo)
            {

                action();

                value++;

            }

        }

        public static void UpTo(this ulong value, ulong upTo, Action<ulong> action)
        {

            while(value <= upTo)
            {

                action(value);

                value++;

            }

        }

        //--

        public static void DownTo(this short value, short downTo, Action<short> action)
        {

            while(value >= downTo)
            {

                action(value);

                --value;

            }

        }

        public static void DownTo(this ushort value, ushort downTo, Action action)
        {

            while(value >= downTo)
            {

                action();

                --value;

            }

        }

        public static void DownTo(this ushort value, ushort downTo, Action<ushort> action)
        {

            while(value >= downTo)
            {

                action(value);

                --value;

            }

        }

        public static void DownTo(this int value, int downTo, Action action)
        {

            while(value >= downTo)
            {

                action();

                --value;

            }

        }

        public static void DownTo(this int value, int downTo, Action<int> action)
        {

            while(value >= downTo)
            {

                action(value);

                --value;

            }

        }

        public static void DownTo(this uint value, uint downTo, Action action)
        {

            while(value >= downTo)
            {

                action();

                --value;

            }

        }

        public static void DownTo(this uint value, uint downTo, Action<uint> action)
        {

            while(value >= downTo)
            {

                action(value);

                --value;

            }

        }

        public static void DownTo(this long value, long downTo, Action action)
        {

            while(value >= downTo)
            {

                action();

                --value;

            }

        }

        public static void DownTo(this long value, long downTo, Action<long> action)
        {

            while(value >= downTo)
            {

                action(value);

                --value;

            }

        }

        public static void DownTo(this ulong value, ulong downTo, Action action)
        {

            while(value >= downTo)
            {

                action();

                --value;

            }

        }

        public static void DownTo(this ulong value, ulong downTo, Action<ulong> action)
        {

            while(value >= downTo)
            {

                action(value);

                --value;

            }

        }

        public static bool IsTrue(this short value)
        {

            return value > 0;

        }

        public static bool IsTrue(this ushort value)
        {

            return value > 0;

        }

        public static bool IsTrue(this int value)
        {

            return value > 0;

        }

        public static bool IsTrue(this uint value)
        {

            return value > 0u;

        }

        public static bool IsTrue(this long value)
        {

            return value > 0L;

        }

        public static bool IsTrue(this ulong value)
        {

            return value > 0UL;

        }

        public static bool IsFalse(this short value)
        {

            return value < 1;

        }

        public static bool IsFalse(this ushort value)
        {

            return value < 1;

        }

        public static bool IsFalse(this int value)
        {

            return value < 1;

        }

        public static bool IsFalse(this uint value)
        {

            return value < 1u;

        }

        public static bool IsFalse(this long value)
        {

            return value < 1L;

        }

        public static bool IsFalse(this ulong value)
        {

            return value < 1UL;

        }

        public static string ToStringNu(this object obj)
        {

            if(obj == null)
                return "null";

            return obj.ToString();

        }

        public static string ToStringEm(this object obj)
        {

            if(obj == null)
                return "";

            return obj.ToString();

        }

        public static string TypeToStringNu(this object obj)
        {

            if(obj == null)
                return "null";

            return obj.GetType().ToString();

        }

        public static string TypeToStringEm(this object obj)
        {

            if(obj == null)
                return "";

            return obj.GetType().ToString();

        }

        public static T GetDefault<T>(this T obj)
        {

            return default(T);

        }

        public static string Multiply(this string str, int number)
        {

            if(number < 1 || str == null)
                return "";

            if(number == 1)
                return str;

            if(number == 2)
                return str + str;

            StringBuilder SB = new StringBuilder();

            while(number > 1)
            {

                SB.Append(str);

                number--;

            }

            return SB.ToString();

        }

        public static string Multiply(this string str, int number, string append)
        {

            if(number < 1 || str == null)
                return "";

            if(number == 1)
                return str;

            if(number == 2)
                return str + str;

            StringBuilder SB = new StringBuilder();

            while(number > 1)
            {

                SB.Append(str);

                number--;

            }

            SB.Append(append);

            return SB.ToString();

        }

        //WhileF

        public static void WhileF(this Func<bool> func)
        {

            while(!func())
            {
            }

        }

        public static void WhileF<T>(this Func<T, bool> func, T p)
        {

            while(!func(p))
            {
            }

        }

        public static void WhileF<T1, T2>(this Func<T1, T2, bool> func, T1 p1, T2 p2)
        {

            while(!func(p1, p2))
            {
            }

        }

        public static void WhileF<T1, T2, T3>(this Func<T1, T2, T3, bool> func, T1 p1, T2 p2, T3 p3)
        {

            while(!func(p1, p2, p3))
            {
            }

        }

        public static void WhileF<T1, T2, T3, T4>(this Func<T1, T2, T3, T4, bool> func, T1 p1, T2 p2, T3 p3, T4 p4)
        {

            while(!func(p1, p2, p3, p4))
            {
            }

        }

        //IDoR

        public static void WhileF(this IDoWorkR<bool> dor)
        {

            while(!dor.DoWork())
            {
            }

        }

        public static void WhileF<T>(this IDoWorkR<bool, T> dor, T p)
        {

            while(!dor.DoWork(p))
            {
            }

        }

        public static void WhileF<T1, T2>(this IDoWorkR<bool, T1, T2> dor, T1 p1, T2 p2)
        {

            while(!dor.DoWork(p1, p2))
            {
            }

        }

        public static void WhileF<T1, T2, T3>(this IDoWorkR<bool, T1, T2, T3> dor, T1 p1, T2 p2, T3 p3)
        {

            while(!dor.DoWork(p1, p2, p3))
            {
            }

        }

        public static void WhileF<T1, T2, T3, T4>(this IDoWorkR<bool, T1, T2, T3, T4> dor, T1 p1, T2 p2, T3 p3, T4 p4)
        {

            while(!dor.DoWork(p1, p2, p3, p4))
            {
            }

        }

        //WhileT

        public static void WhileT(this Func<bool> func)
        {

            while(func())
            {
            }

        }

        public static void WhileT<T>(this Func<T, bool> func, T p)
        {

            while(func(p))
            {
            }

        }

        public static void WhileT<T1, T2>(this Func<T1, T2, bool> func, T1 p1, T2 p2)
        {

            while(func(p1, p2))
            {
            }

        }

        public static void WhileT<T1, T2, T3>(this Func<T1, T2, T3, bool> func, T1 p1, T2 p2, T3 p3)
        {

            while(func(p1, p2, p3))
            {
            }

        }

        public static void WhileT<T1, T2, T3, T4>(this Func<T1, T2, T3, T4, bool> func, T1 p1, T2 p2, T3 p3, T4 p4)
        {

            while(func(p1, p2, p3, p4))
            {
            }

        }

        //IDoR

        public static void WhileT(this IDoWorkR<bool> dor)
        {

            while(dor.DoWork())
            {
            }

        }

        public static void WhileT<T>(this IDoWorkR<bool, T> dor, T p)
        {

            while(dor.DoWork(p))
            {
            }

        }

        public static void WhileT<T1, T2>(this IDoWorkR<bool, T1, T2> dor, T1 p1, T2 p2)
        {

            while(dor.DoWork(p1, p2))
            {
            }

        }

        public static void WhileT<T1, T2, T3>(this IDoWorkR<bool, T1, T2, T3> dor, T1 p1, T2 p2, T3 p3)
        {

            while(dor.DoWork(p1, p2, p3))
            {
            }

        }

        public static void WhileT<T1, T2, T3, T4>(this IDoWorkR<bool, T1, T2, T3, T4> dor, T1 p1, T2 p2, T3 p3, T4 p4)
        {

            while(dor.DoWork(p1, p2, p3, p4))
            {
            }

        }

        //

        public static void IfTrue(this bool value, Action act)
        {

            if(value)
                act();

        }

        public static void IfTrue(this bool value, Action actTrue, Action actFalse)
        {

            if(value)
                actTrue();
            else
                actFalse();

        }

        public static void IfTrue<T>(this bool value, Action<T> act, T Item)
        {

            if(value)
                act(Item);

        }

        public static void IfTrue<T>(this bool value, Action<T> actTrue, Action<T> actFalse, T Item)
        {

            if(value)
                actTrue(Item);
            else
                actFalse(Item);

        }

        public static TResult IfTrue<TResult>(this bool value, Func<TResult> func)
        {

            if(value)
               return func();

            return default(TResult);

        }

        public static TResult IfTrue<TResult>(this bool value, Func<TResult> funcTrue, Func<TResult> funcFalse)
        {

            if(value)
                return funcTrue();

            return funcFalse();

        }

        public static TResult IfTrue<T, TResult>(this bool value, Func<T, TResult> func, T Item)
        {

            if(value)
                return func(Item);

            return default(TResult);

        }

        public static TResult IfTrue<T, TResult>(this bool value, Func<T, TResult> funcTrue, Func<T, TResult> funcFalse, T Item)
        {

            if(value)
                return funcTrue(Item);

            return funcFalse(Item);

        }

        public static bool IfTrue<TResult>(this bool value, Func<TResult> func, out TResult result)
        {

            if(value)
            {

                result = func();

                return true;

            }

            result = default(TResult);

            return false;

        }

        public static bool IfTrue<TResult>(this bool value, Func<TResult> funcTrue, Func<TResult> funcFalse, out TResult result)
        {

            if(value)
            {

                result = funcTrue();

                return true;

            }

            result = funcFalse();

            return false;

        }

        public static bool IfTrue<T, TResult>(this bool value, Func<T, TResult> func, T Item, out TResult result)
        {

            if(value)
            {

                result = func(Item);

                return true;

            }

            result = default(TResult);

            return false;

        }

        public static bool IfTrue<T, TResult>(this bool value, Func<T, TResult> funcTrue, Func<T, TResult> funcFalse, T Item, out TResult result)
        {

            if(value)
            {

                result = funcTrue(Item);

                return true;

            }

            result = funcFalse(Item);

            return false;

        }

    }

}
