using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;

namespace CoreComponents.Items
{

    public struct ConcurrentSetEmptier<T>
    {

        public void ClearAll(ConcurrentQueue<T> TheQueue)
        {

            if(!TheQueue.IsEmpty)
            {

                while(true)
                {

                    T Item;

                    if(!TheQueue.TryDequeue(out Item))
                        return;

                }

            }

        }

        public void ClearLimited(ConcurrentQueue<T> TheQueue)
        {

            int Count = TheQueue.Count;

            while(Count > 0)
            {

                T Item;

                if(!TheQueue.TryDequeue(out Item))
                    return;

                Count--;

            }

        }

    }

}
