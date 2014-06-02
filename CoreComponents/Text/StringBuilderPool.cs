using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;
using CoreComponents.Threading;

namespace CoreComponents.Text
{

    public static class StringBuilderPool
    {

        static ConcurrentStringBuilderCache myPool = new ConcurrentStringBuilderCache();

        public static StringBuilder FetchOrCreate()
        {

            return myPool.FetchOrCreate();

        }

        public static void FetchOrCreateAsync(SpinValueContainer<StringBuilder> TheSBContainer, Clicker HasBeenSet)
        {

            myPool.FetchOrCreateAsync(TheSBContainer, HasBeenSet);

        }
        
        public static void Put(StringBuilder TheSB)
        {

            myPool.Put(TheSB);

        }

        public static void PutAsync(StringBuilder TheSB)
        {

            myPool.PutAsync(TheSB);

        }

        public static void Clear()
        {

            myPool.Clear();

        }

        public static void ClearAsync()
        {

            myPool.ClearAsync();

        }

        public static void ReduceTo(int TheCount)
        {

            myPool.ReduceTo(TheCount);

        }

        public static void ReduceToAsync(int TheCount)
        {

            myPool.ReduceToAsync(TheCount);
        }

        public static void Remove(int TheCount)
        {

            myPool.Remove(TheCount);

        }

        public static void RemoveAsync(int TheCount)
        {

            myPool.RemoveAsync(TheCount);

        }

        public static void Execute(Action<StringBuilder> TheAction)
        {

            myPool.Execute(TheAction);

        }

        public static void ExecuteAsync(Action<StringBuilder> TheAction)
        {

            myPool.ExecuteAsync(TheAction);

        }

        public static int Count
        {

            get
            {

                return myPool.Count;

            }

        }

        public static bool IsEmpty
        {

            get
            {

                return myPool.IsEmpty;

            }

        }

        public static string ToString(IAppendTo TheItem)
        {
            
            StringBuilder SB = FetchOrCreate();

            try
            {

                TheItem.AppendTo(SB);

                return SB.ToString();

            }
            finally
            {

                Put(SB);

            }

        }

        public static string ToStringSemiAsync(IAppendTo TheItem)
        {

            StringBuilder SB = FetchOrCreate();

            try
            {

                TheItem.AppendTo(SB);

                return SB.ToString();

            }
            finally
            {

                PutAsync(SB);

            }

        }

    }

}
