using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public class LockHog : IDisposable
    {

        protected object myLockObject;

        protected bool myHasEntered;

        public LockHog()
        {
        }

        public LockHog(object TheLockHog)
        {

            TheLockHog = myLockObject;

        }

        public object LockObject
        {

            get
            {

                return myLockObject;

            }
            set
            {

                if(myHasEntered)
                    throw new Exception("The lock is currently being held by this LockHog");

                myLockObject = value;

            }

        }

        public bool TryGetLockObject(out object TheLockObject)
        {

            if(myLockObject != null)
            {

                TheLockObject = myLockObject;

                return true;

            }

            TheLockObject = null;

            return false;

        }

        public bool HasEntered
        {

            get
            {

                return myHasEntered;

            }

        }

        public void Enter()
        {

            Monitor.Enter(myLockObject);

            myHasEntered = true;

        }

        public void Enter(ref bool lockTaken)
        {

            bool LockTaken = false;

            Monitor.Enter(myLockObject, ref LockTaken); 

            myHasEntered = LockTaken;

        }

        public void Exit()
        {

            if(myHasEntered)
            {

                Monitor.Exit(myLockObject);

                myHasEntered = false;

            }

        }

        public void EnterThenExit()
        {

            Enter();

            Exit();

        }

        public void EnterThenExit(int MillisecondsTimeout)
        {

            try
            {

                Enter();

                Thread.Sleep(MillisecondsTimeout);

            }
            finally
            {

                Exit();

            }

        }

        public void EnterThenExit(TimeSpan Timeout)
        {

            try
            {

                Enter();

                Thread.Sleep(Timeout);

            }
            finally
            {

                Exit();

            }

        }

        public void BusyEnterThenExit(int Iterations)
        {

            try
            {

                Enter();

                Thread.SpinWait(Iterations);

            }
            finally
            {

                Exit();

            }

        }

        public void EnterThenExit(Action TheAction)
        {

            try
            {

                Enter();

                TheAction();

            }
            finally
            {

                Exit();

            }

        }

        public bool IsEntered()
        {

            return Monitor.IsEntered(myLockObject);

        }

        public void Pulse()
        {

            Monitor.Pulse(myLockObject);

        }

        public void PulseAll()
        {

            Monitor.PulseAll(myLockObject);

        }

        public bool TryEnter()
        {

            bool LockTaken = Monitor.TryEnter(myLockObject);

            myHasEntered = LockTaken;

            return LockTaken;

        }

        public bool TryEnter(int MillisecondsTimeout)
        {

            bool LockTaken = Monitor.TryEnter(myLockObject, MillisecondsTimeout);

            if(LockTaken)
            {

                myHasEntered = true;

                return true;

            }

            return false;

        }


        public bool TryEnterThenExit(int MillisecondsTimeout)
        {

            bool LockTaken = Monitor.TryEnter(myLockObject, MillisecondsTimeout);

            if(LockTaken)
            {

                myHasEntered = true;

                Monitor.Exit(myLockObject);

                myHasEntered = false;

                return true;

            }

            return false;

        }

        public bool TryEnterThenExit(int MillisecondsTimeout, int MillisecondsWait)
        {

            bool LockTaken = Monitor.TryEnter(myLockObject, MillisecondsTimeout);

            if(LockTaken)
            {

                try
                {

                    myHasEntered = true;

                    Thread.Sleep(MillisecondsWait);

                }
                finally
                {

                    Monitor.Exit(myLockObject);

                    myHasEntered = false;

                }

                return true;

            }

            return false;

        }

        public void TryEnter(ref bool LockTaken)
        {

            bool LockIsTaken = false;

            Monitor.TryEnter(myLockObject, ref LockIsTaken);

            if(LockIsTaken)
            {

                myHasEntered = true;

                LockTaken = LockIsTaken;

            }

        }

        public bool TryEnter(TimeSpan Timeout)
        {

            bool LockTaken = Monitor.TryEnter(Timeout);

            if(LockTaken)
            {

                myHasEntered = true;

                return true;

            }

            return false;

        }

        public bool TryEnterThenExit(TimeSpan Timeout)
        {

            bool LockTaken = Monitor.TryEnter(Timeout);

            if(LockTaken)
            {

                myHasEntered = true;

                Monitor.Exit(myLockObject);

                myHasEntered = false;

                return true;

            }

            return false;

        }

        public bool TryEnterThenExit(TimeSpan Timeout, TimeSpan WaitTimeout)
        {

            bool LockTaken = Monitor.TryEnter(myLockObject, Timeout);

            if(LockTaken)
            {

                try
                {

                    myHasEntered = true;

                    Thread.Sleep(WaitTimeout);

                }
                finally
                {

                    Monitor.Exit(myLockObject);

                    myHasEntered = false;

                }

                return true;

            }

            return false;

        }

        public void TryEnter(int MillisecondsTimeout, ref bool LockTaken)
        {

            bool LockIsTaken = false;

            Monitor.TryEnter(myLockObject, MillisecondsTimeout, ref LockIsTaken);

            if(LockIsTaken)
                LockTaken = true;
            
        }

        public void TryEnter(TimeSpan Timeout, ref bool LockTaken)
        {

            bool LockIsTaken = false;

            Monitor.TryEnter(myLockObject, Timeout, ref LockIsTaken);

            if(LockIsTaken)
                LockTaken = true;

        }

        public bool Wait()
        {

            if(!myHasEntered)
                throw new Exception("Lock has not been entered");

            myHasEntered = false;

            try
            {

                return Monitor.Wait(myLockObject);

            }
            finally
            {

                myHasEntered = true;

            }

        }

        public bool Wait(int MillisecondsTimeout)
        {

            if(!myHasEntered)
                throw new Exception("Lock has not been entered");

            myHasEntered = false;

            try
            {

                return Monitor.Wait(myLockObject, MillisecondsTimeout);

            }
            finally
            {

                myHasEntered = true;

            }

        }

        public bool Wait(TimeSpan Timeout)
        {

            if(!myHasEntered)
                throw new Exception("Lock has not been entered");

            myHasEntered = false;

            try
            {

                return Monitor.Wait(myLockObject, Timeout);

            }
            finally
            {

                myHasEntered = true;

            }

        }

        public bool Wait(int MillisecondsTimeout, bool ExitContext)
        {

            if(!myHasEntered)
                throw new Exception("Lock has not been entered");

            myHasEntered = false;

            try
            {

                return Monitor.Wait(myLockObject, MillisecondsTimeout, ExitContext);

            }
            finally
            {

                myHasEntered = true;

            }

        }

        public bool Wait(TimeSpan Timeout, bool ExitContext)
        {

            if(!myHasEntered)
                throw new Exception("Lock has not been entered");

            myHasEntered = false;

            try
            {

                return Monitor.Wait(myLockObject, Timeout, ExitContext);

            }
            finally
            {

                myHasEntered = true;

            }

        }

        public void Dispose()
        {

            Exit();

        }

    }

}
