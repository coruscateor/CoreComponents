using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{
    
    public class ConcurrentVisitingContainer<T> : ConcurrentValueContainer<T>, IDisposable
    {

        protected bool myHasBeenSet;

        protected SpinLock myHasBeenSetSpinlock;

        protected ManualResetEventSlim myManualResetEvent = new ManualResetEventSlim();

        public ConcurrentVisitingContainer()
        {
        }

        public ConcurrentVisitingContainer(T TheValue) : base(TheValue)
        {
        }

        public ConcurrentVisitingContainer(bool UsesMemoryBarrier) : base(UsesMemoryBarrier)
        {
        }

        public ConcurrentVisitingContainer(T TheValue, bool UsesMemoryBarrier) : base(TheValue, UsesMemoryBarrier)
        {
        }

        public bool HasBeenSet
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    myHasBeenSetSpinlock.Enter(ref LockTaken);

                    return myHasBeenSet;

                }
                finally
                {

                    if(LockTaken)
                        myHasBeenSetSpinlock.Exit(myUsesMemoryBarrier);

                }

            }

        }

        public override T Value
        {

            get
            {

                return base.Value;

            }
            set
            {

                base.Value = value;

                bool LockTaken = false;

                myHasBeenSetSpinlock.Enter(ref LockTaken);

                myHasBeenSet = true;

                if(LockTaken)
                    myHasBeenSetSpinlock.Exit(myUsesMemoryBarrier);

                myManualResetEvent.Set();

            }

        }

        public void Reset()
        {

            bool LockTaken = false;

            myHasBeenSetSpinlock.Enter(ref LockTaken);

            myHasBeenSet = false;

            if(LockTaken)
                myHasBeenSetSpinlock.Exit(myUsesMemoryBarrier);

            myManualResetEvent.Reset();

        }

        public void Wait()
        {

            myManualResetEvent.Wait();

        }

        public void Wait(CancellationToken TheCancellationToken)
        {

            myManualResetEvent.Wait(TheCancellationToken);

        }

        public bool Wait(int TheMillisecondsTimeout)
        {

            return myManualResetEvent.Wait(TheMillisecondsTimeout);

        }

        public bool Wait(TimeSpan TheTimeout)
        {

            return myManualResetEvent.Wait(TheTimeout);

        }

        public bool Wait(int TheMillisecondsTimeout, CancellationToken TheCancellationToken)
        {

            return myManualResetEvent.Wait(TheMillisecondsTimeout, TheCancellationToken);

        }

        public bool Wait(TimeSpan TheTimeout, CancellationToken TheCancellationToken)
        {

            return myManualResetEvent.Wait(TheTimeout, TheCancellationToken);

        }

        public void Wait(Action<T> TheAction)
        {

            myManualResetEvent.Wait();

            TheAction(Value);

        }

        public void Wait(CancellationToken TheCancellationToken, Action<T> TheAction)
        {

            myManualResetEvent.Wait(TheCancellationToken);

            TheAction(Value);

        }

        public bool Wait(int TheMillisecondsTimeout, Action<T> TheAction)
        {

            if(myManualResetEvent.Wait(TheMillisecondsTimeout))
            {

                TheAction(Value);

                return true;

            }

            return false;

        }

        public bool WaitAndGet(TimeSpan TheTimeout, Action<T> TheAction)
        {

            if(myManualResetEvent.Wait(TheTimeout))
            {

                TheAction(Value);

                return true;

            }

            return false;

        }

        public bool WaitAndGet(int TheMillisecondsTimeout, CancellationToken TheCancellationToken, Action<T> TheAction)
        {

            if(myManualResetEvent.Wait(TheMillisecondsTimeout, TheCancellationToken))
            {

                TheAction(Value);

                return true;

            }

            return false;

        }

        public bool WaitAndGet(TimeSpan TheTimeout, CancellationToken TheCancellationToken, Action<T> TheAction)
        {

            if(myManualResetEvent.Wait(TheTimeout, TheCancellationToken))
            {

                TheAction(Value);

                return true;

            }

            return false;

        }

        public T WaitAndGet()
        {

            myManualResetEvent.Wait();

            return Value;

        }

        public T WaitAndGet(CancellationToken TheCancellationToken)
        {

            myManualResetEvent.Wait(TheCancellationToken);

            return Value;

        }

        public bool WaitAndGet(int TheMillisecondsTimeout, out T TheResult)
        {

            if(myManualResetEvent.Wait(TheMillisecondsTimeout))
            {

                TheResult = Value;

                return true;

            }

            TheResult = default(T);

            return false;

        }

        public bool WaitAndGet(TimeSpan TheTimeout, out T TheResult)
        {

            if(myManualResetEvent.Wait(TheTimeout))
            {

                TheResult = Value;

                return true;

            }

            TheResult = default(T);

            return false;

        }

        public bool WaitAndGet(int TheMillisecondsTimeout, CancellationToken TheCancellationToken, out T TheResult)
        {

            if(myManualResetEvent.Wait(TheMillisecondsTimeout, TheCancellationToken))
            {

                TheResult = Value;

                return true;

            }

            TheResult = default(T);

            return false;

        }

        public bool WaitAndGet(TimeSpan TheTimeout, CancellationToken TheCancellationToken, out T TheResult)
        {

            if(myManualResetEvent.Wait(TheTimeout, TheCancellationToken))
            {

                TheResult = Value;

                return true;

            }

            TheResult = default(T);

            return false;

        }
        
        public void Dispose()
        {

            myManualResetEvent.Dispose();

        }

    }

}
