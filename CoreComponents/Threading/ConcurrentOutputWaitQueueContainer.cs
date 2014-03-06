using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    [Serializable]
    public class ConcurrentOutputWaitQueueContainer<TType> : BaseConcurrentQueueContainer<TType>, IOutputQueue<TType>, IDisposable
    {

        protected WaitWatcher myWaitWatcher;

        public ConcurrentOutputWaitQueueContainer(ConcurrentQueue<TType> TheQueue, WaitWatcher TheWaitWatcher)
            : base(TheQueue)
        {

            myWaitWatcher = TheWaitWatcher;

        }

        public bool TryDequeueDontWait(out TType TheItem)
        {

            if(myWaitWatcher.Engaged)
            {

                TheItem = default(TType);

                return false;

            }

            return myQueue.TryDequeue(out TheItem);

        }
        
        public bool TryDequeue(out TType TheItem)
        {

            if(myWaitWatcher.Engaged)
            {

                myWaitWatcher.Wait();

                return myQueue.TryDequeue(out TheItem);

            }

            bool ValueRetrived = myQueue.TryDequeue(out TheItem);

            if(ValueRetrived)
                return ValueRetrived;
            //else
            //    myWaitWatcher.Reset();

            myWaitWatcher.Wait();

            return myQueue.TryDequeue(out TheItem);

        }

        public bool TryDequeue(out TType TheItem, int millisecondsTimeout)
        {

            if(myWaitWatcher.Engaged)
            {

                myWaitWatcher.Wait(millisecondsTimeout);

                return myQueue.TryDequeue(out TheItem);

            }

            bool ValueRetrived = myQueue.TryDequeue(out TheItem);

            if(ValueRetrived)
                return ValueRetrived;
            //else
            //    myWaitWatcher.Reset();

            myWaitWatcher.Wait(millisecondsTimeout);

            return myQueue.TryDequeue(out TheItem);

        }

        public bool TryDequeue(out TType TheItem, TimeSpan timeout)
        {

            if(myWaitWatcher.Engaged)
            {

                myWaitWatcher.Wait(timeout);

                return myQueue.TryDequeue(out TheItem);

            }

            bool ValueRetrived = myQueue.TryDequeue(out TheItem);

            if(ValueRetrived)
                return ValueRetrived;
            //else
            //    myWaitWatcher.Reset();

            myWaitWatcher.Wait(timeout);

            return myQueue.TryDequeue(out TheItem);

        }

        public bool TryDequeue(out TType TheItem, int millisecondsTimeout, bool exitContext)
        {

            if(myWaitWatcher.Engaged)
            {

                myWaitWatcher.Wait(millisecondsTimeout, exitContext);

                return myQueue.TryDequeue(out TheItem);

            }

            bool ValueRetrived = myQueue.TryDequeue(out TheItem);

            if(ValueRetrived)
                return ValueRetrived;
            //else
            //    myWaitWatcher.Reset();

            myWaitWatcher.Wait(millisecondsTimeout, exitContext);

            return myQueue.TryDequeue(out TheItem);

        }

        public bool TryDequeue(out TType TheItem, TimeSpan timeout, bool exitContext)
        {

            if(myWaitWatcher.Engaged)
            {

                myWaitWatcher.Wait(timeout, exitContext);

                return myQueue.TryDequeue(out TheItem);

            }

            bool ValueRetrived = myQueue.TryDequeue(out TheItem);

            if(ValueRetrived)
                return ValueRetrived;
            //else
            //    myWaitWatcher.Reset();

            myWaitWatcher.Wait(timeout, exitContext);

            return myQueue.TryDequeue(out TheItem);

        }

        public void Dispose()
        {

            myWaitWatcher.Dispose();

        }

    }

}
