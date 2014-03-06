using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    public static class ThreadingExtensionMethods
    {

        public static IEnumerable<TType> TryDequeueAll<TType>(this IOutputQueue<TType> TheQueue)
        {

            int MaxOf = TheQueue.Count;

            if (MaxOf > 0)
            {

                List<TType> Items = new List<TType>();

                for (; MaxOf > 0; MaxOf--)
                {

                    TType TheItem;

                    if (TheQueue.TryDequeue(out TheItem))
                    {

                        Items.Add(TheItem);

                    }

                }

                return Items;

            }

            return new TType[0];

        }

        public static void TryDequeueInto<TType>(this IOutputQueue<TType> TheQueue, ICollection<TType> TheExistingCollection, int MaxOf = 0)
        {

            if (MaxOf < 1)
            {

                MaxOf = TheQueue.Count;

            }

            if (MaxOf > 0)
            {

                for (; MaxOf > 0; MaxOf--)
                {

                    TType TheItem;

                    if (TheQueue.TryDequeue(out TheItem))
                    {

                        TheExistingCollection.Add(TheItem);

                    }
                    else
                    {

                        return;

                    }

                }

            }

        }

        public static void Enqueue<TType>(this IInputQueue<TType> TheQueue, IEnumerable<TType> TheItems)
        {

            foreach (TType Item in TheItems)
            {

                TheQueue.Enqueue(Item);

            }

        }

    }

}
