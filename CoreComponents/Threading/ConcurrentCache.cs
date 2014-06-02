using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{
    
    public class ConcurrentCache<T> where T : new()
    {

        protected ConcurrentQueue<T> myQueue = new ConcurrentQueue<T>();
        
        public ConcurrentCache()
        {
        }

        public T FetchOrCreate()
        {
            
            T Item;

            if(myQueue.TryDequeue(out Item))
                return Item;

            return new T();

        }

        public void FetchOrCreateAsync(SpinValueContainer<T> TheItemContainer, Clicker HasBeenSet)
        {

            HasBeenSet.Reset();

            ThreadPool.QueueUserWorkItem((TheState) =>
            {

                TheItemContainer.Value = FetchOrCreate();

                HasBeenSet.Click();

            });

        }
        
        public virtual void Put(T TheItem)
        {

            myQueue.Enqueue(TheItem);

        }

        public void PutAsync(T TheItem)
        {

            ThreadPool.QueueUserWorkItem((TheState) =>
            {

                Put(TheItem);

            });

        }

        public void Clear()
        {

            int ItemCount = myQueue.Count;

            while(ItemCount > 0)
            {

                T Item;

                if(!myQueue.TryDequeue(out Item))
                    break;

                --ItemCount;

            }

        }

        public void ClearAsync()
        {

            ThreadPool.QueueUserWorkItem((TheState) =>
            {

                Clear();

            });

        }

        public void ReduceTo(int TheCount)
        {

            if(TheCount > 0)
            {

                int ItemCount = myQueue.Count - TheCount;

                while(ItemCount > 0)
                {

                    if(myQueue.Count >= ItemCount)
                    {

                        T Item;

                        if(!myQueue.TryDequeue(out Item))
                            break;

                        --ItemCount;

                    }
                    else
                    {

                        break;

                    }

                }

            }

        }

        public void ReduceToAsync(int TheCount)
        {

            ThreadPool.QueueUserWorkItem((TheState) =>
            {

                ReduceTo(TheCount);

            });

        }

        public void Remove(int TheCount)
        {

            if(TheCount > 0)
            {

                while(TheCount > 0)
                {

                    T Item;

                    if(!myQueue.TryDequeue(out Item))
                        break;

                    --TheCount;

                }

            }

        }

        public void RemoveAsync(int TheCount)
        {

            ThreadPool.QueueUserWorkItem((TheState) =>
            {

                Remove(TheCount);

            });

        }

        public void Execute(Action<T> TheAction)
        {

            T Item = FetchOrCreate();

            try
            {

                TheAction(Item);

            }
            finally
            {

                Put(Item);

            }

        }

        public void ExecuteAsync(Action<T> TheAction)
        {

            ThreadPool.QueueUserWorkItem((TheState) =>
            {

                Execute(TheAction);

            });

        }

        public int Count
        {

            get
            {

                return myQueue.Count;

            }

        }

        public bool IsEmpty
        {

            get
            {

                return myQueue.IsEmpty;

            }

        }

    }

}
