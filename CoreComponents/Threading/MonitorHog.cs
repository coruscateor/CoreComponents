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

                if(Volatile.Read(ref myHasEntered))
                    throw new Exception("The lock is currently held");

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

                return Volatile.Read(ref myHasEntered);

            }

        }

        protected void ThrowIfHeld()
        {

            if(Volatile.Read(ref myHasEntered))
                throw new Exception("The lock is currently held");

        }

        protected void ThrowIfNotHeld()
        {

            if(!Volatile.Read(ref myHasEntered))
                throw new Exception("The lock is currently not held");

        }

        public void Enter()
        {

            ThrowIfHeld();

            Monitor.Enter(myLockObject);

            Volatile.Write(ref myHasEntered, true);

        }

        public void Enter(ref bool lockTaken)
        {

            ThrowIfHeld();

            bool LockTaken = false;

            Monitor.Enter(myLockObject, ref LockTaken);

            Volatile.Write(ref myHasEntered, LockTaken);

        }

        public void Exit()
        {

            if(Volatile.Read(ref myHasEntered))
            {

                Monitor.Exit(myLockObject);

                Volatile.Write(ref myHasEntered, false);

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

            ThrowIfNotHeld();

            Monitor.Pulse(myLockObject);

        }

        public void PulseAll()
        {

            ThrowIfNotHeld();

            Monitor.PulseAll(myLockObject);

        }

        public bool TryEnter()
        {

            ThrowIfHeld();

            bool LockTaken = Monitor.TryEnter(myLockObject);

            Volatile.Write(ref myHasEntered, LockTaken);

            return LockTaken;

        }

        public bool TryEnter(int MillisecondsTimeout)
        {

            ThrowIfHeld();

            if(Monitor.TryEnter(myLockObject, MillisecondsTimeout))
            {

                Volatile.Write(ref myHasEntered, true);

                return true;

            }

            return false;

        }


        public bool TryEnterThenExit(int MillisecondsTimeout)
        {

            ThrowIfHeld();

            if(Monitor.TryEnter(myLockObject, MillisecondsTimeout))
            {

                Volatile.Write(ref myHasEntered, true);

                Monitor.Exit(myLockObject);

                Volatile.Write(ref myHasEntered, false);

                return true;

            }

            return false;

        }

        public bool TryEnterThenExit(int MillisecondsTimeout, int MillisecondsWait)
        {

            ThrowIfHeld();

            if(Monitor.TryEnter(myLockObject, MillisecondsTimeout))
            {

                try
                {

                    Volatile.Write(ref myHasEntered, true);

                    Thread.Sleep(MillisecondsWait);

                }
                finally
                {

                    Monitor.Exit(myLockObject);

                    Volatile.Write(ref myHasEntered, false);

                }

                return true;

            }

            return false;

        }

        public void TryEnter(ref bool LockTaken)
        {

            ThrowIfHeld();

            bool LockIsTaken = false;

            Monitor.TryEnter(myLockObject, ref LockIsTaken);

            if(LockIsTaken)
            {

                Volatile.Write(ref myHasEntered, true);

                LockTaken = true;

            }

        }

        public bool TryEnter(TimeSpan Timeout)
        {

            ThrowIfHeld();

            if(Monitor.TryEnter(Timeout))
            {

                Volatile.Write(ref myHasEntered, true);

                return true;

            }

            return false;

        }

        public bool TryEnterThenExit(TimeSpan Timeout)
        {

            ThrowIfHeld();

            if(Monitor.TryEnter(Timeout))
            {

                Volatile.Write(ref myHasEntered, true);

                Monitor.Exit(myLockObject);

                Volatile.Write(ref myHasEntered, false);

                return true;

            }

            return false;

        }

        public bool TryEnterThenExit(TimeSpan Timeout, TimeSpan WaitTimeout)
        {

            ThrowIfHeld();

            if(Monitor.TryEnter(myLockObject, Timeout))
            {

                try
                {

                    Volatile.Write(ref myHasEntered, true);

                    Thread.Sleep(WaitTimeout);

                }
                finally
                {

                    Monitor.Exit(myLockObject);

                    Volatile.Write(ref myHasEntered, false);

                }

                return true;

            }

            return false;

        }

        public void TryEnter(int MillisecondsTimeout, ref bool LockTaken)
        {

            ThrowIfHeld();

            bool LockIsTaken = false;

            Monitor.TryEnter(myLockObject, MillisecondsTimeout, ref LockIsTaken);

            if(LockIsTaken)
            {

                LockTaken = true;

                Volatile.Write(ref myHasEntered, true);

            }
            
        }

        public void TryEnter(TimeSpan Timeout, ref bool LockTaken)
        {

            ThrowIfHeld();

            bool LockIsTaken = false;

            Monitor.TryEnter(myLockObject, Timeout, ref LockIsTaken);

            if(LockIsTaken)
            {

                LockTaken = true;

                Volatile.Write(ref myHasEntered, true);

            }

        }

        public bool Wait()
        {

            ThrowIfNotHeld();

            Volatile.Write(ref myHasEntered, false);

            try
            {

                return Monitor.Wait(myLockObject);

            }
            finally
            {

                Volatile.Write(ref myHasEntered, true);

            }

        }

        public bool Wait(int MillisecondsTimeout)
        {

            ThrowIfNotHeld();

            Volatile.Write(ref myHasEntered, false);

            try
            {

                return Monitor.Wait(myLockObject, MillisecondsTimeout);

            }
            finally
            {

                Volatile.Write(ref myHasEntered, true);

            }

        }

        public bool Wait(TimeSpan Timeout)
        {

            ThrowIfNotHeld();

            Volatile.Write(ref myHasEntered, false);

            try
            {

                return Monitor.Wait(myLockObject, Timeout);

            }
            finally
            {

                Volatile.Write(ref myHasEntered, true);

            }

        }

        public bool Wait(int MillisecondsTimeout, bool ExitContext)
        {

            ThrowIfNotHeld();

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

            ThrowIfNotHeld();

            Volatile.Write(ref myHasEntered, false);

            try
            {

                return Monitor.Wait(myLockObject, Timeout, ExitContext);

            }
            finally
            {

                Volatile.Write(ref myHasEntered, true);

            }

        }

        public void Dispose()
        {

            Exit();

        }

    }

}
