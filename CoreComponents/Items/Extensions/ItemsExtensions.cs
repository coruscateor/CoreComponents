using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Items.Extensions
{

    public static class ItemsExtensions
    {

        public static bool TryDequeue<T>(this ConcurrentQueue<T> queue)
        {

            T result;

            return queue.TryDequeue(out result);

        }

        public static void TryDequeue<T>(this ConcurrentQueue<T> queue, int number)
        {

            while(number > 0)
            {

                if(!queue.TryDequeue())
                    return;

                number--;

            }

        }

        public static void TryClear<T>(this ConcurrentQueue<T> queue)
        {

            T result;

            while(!queue.IsEmpty)
                queue.TryDequeue(out result);

        }

        public static bool TryRemove<TKey, TValue>(this ConcurrentDictionary<TKey, TValue> dictionary, TKey key)
        {

            TValue value;

            return dictionary.TryRemove(key, out value);

        }

        //IDoWorkR

        public static void WhileT<TDOR>(this TDOR dor)
            where TDOR : IDoWorkR<bool>
        {

            while(dor.DoWork())
            {
            }

        }

        public static void WhileT<TDOR, T>(this TDOR dor, T p)
            where TDOR : IDoWorkR<bool, T>
        {

            while(dor.DoWork(p))
            {
            }

        }

        public static void WhileT<TDOR, T1, T2>(this TDOR dor, T1 p1, T2 p2)
            where TDOR : IDoWorkR<bool, T1, T2>
        {

            while(dor.DoWork(p1, p2))
            {
            }

        }

        public static void WhileT<TDOR, T1, T2, T3>(this TDOR dor, T1 p1, T2 p2, T3 p3)
            where TDOR : IDoWorkR<bool, T1, T2, T3>
        {

            while(dor.DoWork(p1, p2, p3))
            {
            }

        }

        public static void WhileT<TDOR, T1, T2, T3, T4>(this TDOR dor, T1 p1, T2 p2, T3 p3, T4 p4)
            where TDOR : IDoWorkR<bool, T1, T2, T3, T4>
        {

            while(dor.DoWork(p1, p2, p3, p4))
            {
            }

        }

        //IEnumerable Do

        public static void DoWork(this IEnumerable<Action> items)
        {

            foreach(var item in items)
                item();

        }

        public static void WhileF(this IEnumerable<Func<bool>> items)
        {

            foreach(var item in items)
            {

                if(!item())
                    break;

            }

        }

        public static void WhileT(this IEnumerable<Func<bool>> items)
        {

            foreach(var item in items)
            {

                if(item())
                    break;

            }

        }

        public static void DoWork<TDO>(this TDO items)
            where TDO : IEnumerable<IDoWork>
        {

            foreach(var item in items)
                item.DoWork();

        }

        public static void WhileF<TDOR>(this IEnumerable<IDoWorkR<bool>> items)
            where TDOR : IEnumerable<IDoWorkR<bool>>
        {

            foreach(var item in items)
            {

                if(!item.DoWork())
                    break;

            }

        }

        //public static void WhileT<TDOR>(this TDOR items)
        //    where TDOR : IEnumerable<IDoR<bool>>
        //{

        //    foreach(var item in items)
        //    {

        //        if(!item.Do())
        //            break;

        //    }

        //}
        
        public static EqualityFuncComparer<T> ToEqualityComparer<T>(Func<T, T, bool> func)
        {

            return new EqualityFuncComparer<T>(func);

        }

        public static int[] To(this int beginning, int end)
        {

            if(end < beginning)
            {

                int[] result = new int[end - beginning];

                int i = 0;

                while(beginning <= end)
                {

                    result[i] = beginning++;

                }

                return result;

            }
            else if(beginning > end)
            {

                int i = beginning - end;

                int[] result = new int[i];

                while(beginning >= end)
                {

                    result[i] = beginning--;

                }

                return result;

            }

            return new int[] { beginning };

        }

        public static SList<int> ToList(this int beginning, int end)
        {

            if(end < beginning)
            {

                SList<int> result = new SList<int>(end - beginning);

                int i = 0;

                while(beginning <= end)
                {

                    result[i] = beginning++;

                }

                return result;

            }
            else if(beginning > end)
            {

                int i = beginning - end;

                SList<int> result = new SList<int>(i);

                while(beginning >= end)
                {

                    result[i] = beginning--;

                }

                return result;

            }

            return new SList<int>(beginning, false);

        }

        public static TValue Get<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
        {

            TValue value;

            dictionary.TryGetValue(key, out value);

            return value;

        }

        public static IsItNull<TValue> GetRef<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
            where TValue : class
        {

            TValue value;

            dictionary.TryGetValue(key, out value);

            return new IsItNull<TValue>(value);

        }

        public static TValue Get<TKey, TValue>(this ConcurrentDictionary<TKey, TValue> dictionary, TKey key)
        {

            TValue value;

            dictionary.TryGetValue(key, out value);

            return value;

        }

        public static IsItNull<TValue> GetRef<TKey, TValue>(this ConcurrentDictionary<TKey, TValue> dictionary, TKey key)
            where TValue : class
        {

            TValue value;

            dictionary.TryGetValue(key, out value);

            return new IsItNull<TValue>(value);

        }

    }

}
