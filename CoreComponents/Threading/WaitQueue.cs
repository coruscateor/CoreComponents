using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public class WaitQueue<T> : IDisposable
    {

        protected readonly ConcurrentQueue<T> myQueue;

        protected readonly ManualResetEventSlim myResetEvent;

        public WaitQueue()
        {

            myQueue = new ConcurrentQueue<T>();

            myResetEvent = new ManualResetEventSlim();

        }

        public WaitQueue(ICollection<T> items)
        {

            myQueue = new ConcurrentQueue<T>(items);

            myResetEvent = new ManualResetEventSlim();

        }

        public WaitQueue(ManualResetEventSlim ResetEvent)
        {

            myQueue = new ConcurrentQueue<T>();

            myResetEvent = ResetEvent;

        }

        public WaitQueue(ManualResetEventSlim ResetEvent, ICollection<T> items)
        {

            myQueue = new ConcurrentQueue<T>(items);

            myResetEvent = ResetEvent;

        }

        public void Enqueue(T item)
        {

            myQueue.Enqueue(item);

            myResetEvent.Set();

        }

        public bool TryDequeue(out T item)
        {

            int waits = 0;

            bool result = myQueue.TryDequeue(out item);

            while(!result && waits < 2)
            {

                if(myQueue.IsEmpty)
                {

                    myResetEvent.Reset();

                    myResetEvent.Wait();

                    ++waits;

                }

                result = myQueue.TryDequeue(out item);

            }

            return result;

        }

        public bool TryDequeue(out T item, CancellationToken ct)
        {

            int waits = 0;

            bool result = myQueue.TryDequeue(out item);

            while(!result && waits < 2)
            {

                if(myQueue.IsEmpty)
                {

                    myResetEvent.Reset();

                    myResetEvent.Wait(ct);

                    ++waits;

                }

                result = myQueue.TryDequeue(out item);

            }

            return result;

        }

        public bool TryDequeue(out T item, int ms)
        {

            int waits = 0;

            bool result = myQueue.TryDequeue(out item);

            while(!result && waits < 2)
            {

                if(myQueue.IsEmpty)
                {

                    myResetEvent.Reset();

                    myResetEvent.Wait(ms);

                    ++waits;

                }

                result = myQueue.TryDequeue(out item);

            }

            return result;

        }

        public bool TryDequeue(out T item, TimeSpan ts)
        {

            int waits = 0;

            bool result = myQueue.TryDequeue(out item);

            while(!result && waits < 2)
            {

                if(myQueue.IsEmpty)
                {

                    myResetEvent.Reset();

                    myResetEvent.Wait(ts);

                    ++waits;

                }

                result = myQueue.TryDequeue(out item);

            }

            return result;

        }

        public bool TryDequeue(out T item, int ms, CancellationToken ct)
        {

            int waits = 0;

            bool result = myQueue.TryDequeue(out item);

            while(!result && waits < 2)
            {

                if(myQueue.IsEmpty)
                {

                    myResetEvent.Reset();

                    myResetEvent.Wait(ms, ct);

                    ++waits;

                }

                result = myQueue.TryDequeue(out item);

            }

            return result;

        }

        public bool TryDequeue(out T item, TimeSpan ts, CancellationToken ct)
        {

            int waits = 0;

            bool result = myQueue.TryDequeue(out item);

            while(!result && waits < 2)
            {

                if(myQueue.IsEmpty)
                {

                    myResetEvent.Reset();

                    myResetEvent.Wait(ts, ct);

                    ++waits;

                }

                result = myQueue.TryDequeue(out item);

            }

            return result;

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

            if(!myQueue.IsEmpty)
                myResetEvent.Set();

        }

        public void Dispose()
        {

            myResetEvent.Dispose();
            
        }

    }

}
