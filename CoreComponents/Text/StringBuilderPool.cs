using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;

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

        public static void Put(StringBuilder TheSB)
        {

            TheSB.Clear();

            myQueue.Enqueue(TheSB);

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
