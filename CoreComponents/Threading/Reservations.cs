using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;
using CoreComponents.Items;

namespace CoreComponents.Threading
{

    public class Reservations<T>
    {

        public const int NoThread = -1;

        readonly T myResource;

        readonly SConcurrentQueue<int> myQueue = new SConcurrentQueue<int>();

        int myHasRightOfWay = NoThread;

        public Reservations(T resource)
        {

            myResource = resource;

        }

        protected bool CheckAndEnqueue()
        {

            int currentTHId = Thread.CurrentThread.ManagedThreadId;

            int currentROW = Volatile.Read(ref myHasRightOfWay);

            if(currentROW == NoThread)
            {

                lock(myQueue)
                {

                    if(Volatile.Read(ref myHasRightOfWay) == NoThread)
                    {

                        int result;

                        if(myQueue.TryDequeue(out result))
                        {

                            Volatile.Write(ref myHasRightOfWay, result);

                            currentROW = result;

                        }
                        else
                            return false;

                    }

                }

            }

            if(currentROW != currentTHId)
            {

                if(!myQueue.Contains(currentTHId))
                    myQueue.Enqueue(Thread.CurrentThread.ManagedThreadId);

                return false;

            }

            return true;

        }

        protected void TryDequeueNext()
        {

            int result;

            if(myQueue.TryDequeue(out result))
            {

                Volatile.Write(ref myHasRightOfWay, result);

            }
            else
            {

                Volatile.Write(ref myHasRightOfWay, NoThread);

            }

        }

        public bool TryDo(Action<T> action)
        {

            if(!CheckAndEnqueue())
                return false;

            try
            {

                action(myResource);

            }
            finally
            {

                TryDequeueNext();

            }

            return true;

        }

        public bool TryDo<TResult>(Func<T, TResult> func, out TResult result)
        {

            if(!CheckAndEnqueue())
            {

                result = default(TResult);

                return false;

            }

            try
            {

                result = func(myResource);

            }
            finally
            {

                TryDequeueNext();

            }

            return true;

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

        public void UnClog()
        {

            //May look up all programme threads in the future.

            lock(myQueue)
            {

                int result;

                while(myQueue.TryDequeue(out result))
                {
                }

                Volatile.Write(ref myHasRightOfWay, NoThread);

            }

        }

    }

}
