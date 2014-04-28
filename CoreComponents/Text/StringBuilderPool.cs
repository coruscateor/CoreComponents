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

        static ConcurrentQueue<StringBuilder> myQueue = new ConcurrentQueue<StringBuilder>();

        public static StringBuilder FetchOrCreate()
        {
            
            StringBuilder SB;

            if(myQueue.TryDequeue(out SB))
                return SB;

            return new StringBuilder();

        }

        public static void FetchOrCreateAsync(ConcurrentValueContainer<StringBuilder> TheSBContainer, ConcurrentValueContainer<bool> HasBeenSet)
        {

            ThreadPool.QueueUserWorkItem((TheState) =>
            {

                TheSBContainer.Value = FetchOrCreate();

                HasBeenSet.Value = true;

            });

        }
        
        public static void Put(StringBuilder TheSB)
        {

            TheSB.Clear();

            myQueue.Enqueue(TheSB);

        }

        public static void PutAsync(StringBuilder TheSB)
        {

            ThreadPool.QueueUserWorkItem((TheState) =>
            {

                Put(TheSB);

            });

        }

        public static void Clear()
        {

            int SBCount = myQueue.Count;

            while(SBCount > 0)
            {

                StringBuilder SB;

                if(!myQueue.TryDequeue(out SB))
                    break;

                --SBCount;

            }

        }

        public static void ClearAsync()
        {

            ThreadPool.QueueUserWorkItem((TheState) =>
            {

                Clear();

            });

        }

        public static void ReduceTo(int TheCount)
        {

            if(TheCount > 0)
            {

                int SBCount = myQueue.Count - TheCount;

                while(SBCount > 0)
                {

                    if(myQueue.Count >= SBCount)
                    {

                        StringBuilder SB;

                        if(!myQueue.TryDequeue(out SB))
                            break;

                        --SBCount;

                    }
                    else
                    {

                        break;

                    }

                }

            }

        }

        public static void ReduceToAsync(int TheCount)
        {

            ThreadPool.QueueUserWorkItem((TheState) =>
            {

                ReduceTo(TheCount);

            });

        }

        public static void Remove(int TheCount)
        {

            if(TheCount > 0)
            {

                while(TheCount > 0)
                {

                    StringBuilder SB;

                    if(!myQueue.TryDequeue(out SB))
                        break;

                    --TheCount;

                }

            }

        }

        public static void RemoveAsync(int TheCount)
        {

            ThreadPool.QueueUserWorkItem((TheState) =>
            {

                Remove(TheCount);

            });

        }

        public static void Execute(Action<StringBuilder> TheAction)
        {

            StringBuilder SB = FetchOrCreate();

            try
            {

                TheAction(SB);

            }
            finally
            {

                Put(SB);

            }

        }

        public static void ExecuteAsync(Action<StringBuilder> TheAction)
        {

            ThreadPool.QueueUserWorkItem((TheState) =>
            {

                Execute(TheAction);

            });

        }

        public static int Count
        {

            get
            {

                return myQueue.Count;

            }

        }

        public static bool IsEmpty
        {

            get
            {

                return myQueue.IsEmpty;

            }

        }

    }

}
