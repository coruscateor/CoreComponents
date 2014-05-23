using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public class MonitorHog : IDisposable
    {

        protected object myLockObject;

        protected bool myHasEntered;

        public MonitorHog()
        {
        }

        public MonitorHog(object TheLockHog)
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

            if(Monitor.TryEnter(myLockObject, MillisecondsTimeout))
            {

                myHasEntered = true;

                return true;

            }

            return false;

        }


        public bool TryEnterThenExit(int MillisecondsTimeout)
        {

            if(Monitor.TryEnter(myLockObject, MillisecondsTimeout))
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

            if(Monitor.TryEnter(myLockObject, MillisecondsTimeout))
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

                LockTaken = true;

            }

        }

        public bool TryEnter(TimeSpan Timeout)
        {

            if(Monitor.TryEnter(Timeout))
            {

                myHasEntered = true;

                return true;

            }

            return false;

        }

        public bool TryEnterThenExit(TimeSpan Timeout)
        {

            if(Monitor.TryEnter(Timeout))
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

            if(Monitor.TryEnter(myLockObject, Timeout))
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
            {

                LockTaken = true;

                myHasEntered = true;

            }
            
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
