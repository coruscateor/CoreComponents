using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public class WaitableClicker : Clicker, IWaitableClicker, IDisposable
    {

        protected ManualResetEventSlim myResetEvent = new ManualResetEventSlim();

        public WaitableClicker()
        {
        }

        public WaitableClicker(bool UsesMemoryBarrier) : base(UsesMemoryBarrier)
        {
        }

        public override void Click()
        {

            base.Click();

            myResetEvent.Set();
        }

        public override void Reset()
        {

            base.Reset();

            myResetEvent.Reset();

        }

        public void Wait()
        {

            myResetEvent.Wait();

        }

        public void Wait(CancellationToken CancellationToken)
        {

            myResetEvent.Wait(CancellationToken);

        }

        public bool Wait(int MillisecondsTimeout)
        {

            return myResetEvent.Wait(MillisecondsTimeout);

        }

        public bool Wait(TimeSpan Timeout)
        {

            return myResetEvent.Wait(Timeout);

        }

        public bool Wait(int MillisecondsTimeout, CancellationToken CancellationToken)
        {

            return myResetEvent.Wait(MillisecondsTimeout, CancellationToken);

        }

        public bool Wait(TimeSpan Timeout, CancellationToken CancellationToken)
        {

            return myResetEvent.Wait(Timeout, CancellationToken);

        }

        public void Wait(Action TheAction)
        {

            myResetEvent.Wait();

            TheAction();

        }

        public bool Wait(CancellationToken CancellationToken, Action TheAction)
        {

            myResetEvent.Wait(CancellationToken);

            if(!CancellationToken.IsCancellationRequested)
            {

                TheAction();

                return true;

            }

            return false;

        }

        public bool Wait(int MillisecondsTimeout, Action TheAction)
        {

            bool Result = myResetEvent.Wait(MillisecondsTimeout);

            if(Result)
                TheAction();

            return Result;

        }

        public bool Wait(TimeSpan Timeout, Action TheAction)
        {

            bool Result = myResetEvent.Wait(Timeout);

            if(Result)
                TheAction();

            return Result;

        }

        public bool Wait(int MillisecondsTimeout, CancellationToken CancellationToken, Action TheAction)
        {

            bool Result = myResetEvent.Wait(MillisecondsTimeout, CancellationToken);

            if(Result)
                TheAction();

            return Result;

        }

        public bool Wait(TimeSpan Timeout, CancellationToken CancellationToken, Action TheAction)
        {

            bool Result = myResetEvent.Wait(Timeout, CancellationToken);

            if(Result)
                TheAction();

            return Result;

        }

        public void Dispose()
        {

            myResetEvent.Dispose();

        }

    }

}
