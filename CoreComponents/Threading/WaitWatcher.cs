using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public class WaitWatcher
    {

        protected AutoResetEvent myAutoResetEvent;

        protected int myWaitCount;

        protected SpinLock mySpinLock;

        public WaitWatcher()
        {

            myAutoResetEvent = new AutoResetEvent(false);

        }

        public int WaitCount
        {

            get
            {

                bool LockAquired = false;

                try
                {

                    mySpinLock.Enter(ref LockAquired);

                    return myWaitCount;

                }
                finally
                {

                    if(LockAquired)
                        mySpinLock.Exit();

                }

            }

        }

        public bool Engaged
        {

            get
            {

                bool LockAquired = false;

                try
                {

                    mySpinLock.Enter(ref LockAquired);

                    return myWaitCount > 0;

                }
                finally
                {

                    if(LockAquired)
                        mySpinLock.Exit();

                }

            }

        }

        public bool Reset()
        {

            return myAutoResetEvent.Reset();

        }

        public bool Set()
        {

            return myAutoResetEvent.Set();

        }

        public bool SetIfEngaged()
        {

            bool LockAquired = false;

            bool Engaged = false;

            try
            {

                mySpinLock.Enter(ref LockAquired);

                Engaged = myWaitCount > 0;

            }
            finally
            {

                if(LockAquired)
                    mySpinLock.Exit();

            }

            if(Engaged)
                return myAutoResetEvent.Set();

            return false;

        }

        protected void ReInitaliseAutoResetEvent()
        {

            lock(this)
            {

                myAutoResetEvent = new AutoResetEvent(false);;
                
                bool LockAquired = false;

                try
                {

                    mySpinLock.Enter(ref LockAquired);

                    if(myWaitCount != 0)
                        myWaitCount = 0;

                }
                finally
                {

                    if(LockAquired)
                        mySpinLock.Exit();

                }

            }

        }

        public void Wait()
        {

            bool LockAquired = false;

            try
            {

                mySpinLock.Enter(ref LockAquired);

                ++myWaitCount;

            }
            finally
            {

                if(LockAquired)
                    mySpinLock.Exit();

            }

            try
            {

                myAutoResetEvent.WaitOne();

            }
            catch(ObjectDisposedException ODE)
            {

                ReInitaliseAutoResetEvent();

            }
            catch(NullReferenceException NRE)
            {

                ReInitaliseAutoResetEvent();

            }
            finally
            {

                bool LockAquired2 = false;

                try
                {

                    mySpinLock.Enter(ref LockAquired2);

                    --myWaitCount;

                }
                finally
                {

                    if(LockAquired2)
                        mySpinLock.Exit();

                }

            }

        }

        public void Wait(int millisecondsTimeout)
        {

            bool LockAquired = false;

            try
            {

                mySpinLock.Enter(ref LockAquired);

                ++myWaitCount;

            }
            finally
            {

                if(LockAquired)
                    mySpinLock.Exit();

            }

            try
            {

                myAutoResetEvent.WaitOne(millisecondsTimeout);

            }
            catch(ObjectDisposedException ODE)
            {

                ReInitaliseAutoResetEvent();

            }
            catch(NullReferenceException NRE)
            {

                ReInitaliseAutoResetEvent();

            }
            finally
            {

                bool LockAquired2 = false;

                try
                {

                    mySpinLock.Enter(ref LockAquired2);

                    --myWaitCount;

                }
                finally
                {

                    if(LockAquired2)
                        mySpinLock.Exit();

                }

            }

        }

        public void Wait(TimeSpan timeout)
        {

            bool LockAquired = false;

            try
            {

                mySpinLock.Enter(ref LockAquired);

                ++myWaitCount;

            }
            finally
            {

                if(LockAquired)
                    mySpinLock.Exit();

            }

            try
            {

                myAutoResetEvent.WaitOne(timeout);

            }
            catch(ObjectDisposedException ODE)
            {

                ReInitaliseAutoResetEvent();

            }
            catch(NullReferenceException NRE)
            {

                ReInitaliseAutoResetEvent();

            }
            finally
            {

                bool LockAquired2 = false;

                try
                {

                    mySpinLock.Enter(ref LockAquired2);

                    --myWaitCount;

                }
                finally
                {

                    if(LockAquired2)
                        mySpinLock.Exit();

                }

            }

        }

        public void Wait(int millisecondsTimeout, bool exitContext)
        {

            bool LockAquired = false;

            try
            {

                mySpinLock.Enter(ref LockAquired);

                ++myWaitCount;

            }
            finally
            {

                if(LockAquired)
                    mySpinLock.Exit();

            }

            try
            {

                myAutoResetEvent.WaitOne(millisecondsTimeout, exitContext);

            }
            catch(ObjectDisposedException ODE)
            {

                ReInitaliseAutoResetEvent();

            }
            catch(NullReferenceException NRE)
            {

                ReInitaliseAutoResetEvent();

            }
            finally
            {

                bool LockAquired2 = false;

                try
                {

                    mySpinLock.Enter(ref LockAquired2);

                    --myWaitCount;

                }
                finally
                {

                    if(LockAquired2)
                        mySpinLock.Exit();

                }

            }

        }

        public void Wait(TimeSpan timeout, bool exitContext)
        {

            bool LockAquired = false;

            try
            {

                mySpinLock.Enter(ref LockAquired);

                ++myWaitCount;

            }
            finally
            {

                if(LockAquired)
                    mySpinLock.Exit();

            }

            try
            {

                myAutoResetEvent.WaitOne(timeout, exitContext);

            }
            catch(ObjectDisposedException ODE)
            {

                ReInitaliseAutoResetEvent();

            }
            catch(NullReferenceException NRE)
            {

                ReInitaliseAutoResetEvent();

            }
            finally
            {

                bool LockAquired2 = false;

                try
                {

                    mySpinLock.Enter(ref LockAquired2);

                    --myWaitCount;

                }
                finally
                {

                    if(LockAquired2)
                        mySpinLock.Exit();

                }

            }

        }

        public void Dispose()
        {

            if(myAutoResetEvent != null)
            {

                if(Engaged)
                {

                    int CurrentlyWaiting = WaitCount;

                    SpinWait WaitABit = new SpinWait();

                    {

                        if(myAutoResetEvent.Set())
                            --CurrentlyWaiting;

                        WaitABit.SpinOnce();

                    }
                    while(CurrentlyWaiting > 0);

                }

                myAutoResetEvent.Dispose();

                myAutoResetEvent = null;

            }

        }

    }

}
