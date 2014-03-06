using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading.SubThreading
{

    public abstract class BaseIsolatedThread : ISubThread, IDisposable
    {

        private Thread myThread;

        private object myParameter = null;

        private Exception myException = null;

        private bool myStopRequested;

        private bool mySleepAtEnd;

        private bool myIsSleepingAtEnd;

        private bool myIsActive;

        private bool mySleepingOnSleepEvent;

        private AutoResetEvent mySleepEvent;

        private bool mySleepingOnWaitSleepEvent;

        private ManualResetEvent myWaitSleepEvent;

        public BaseIsolatedThread(bool IsParameterisedThread = false, int TheMaxStackSize = 0, bool TheSleepAtEnd = false) 
        {
            
            if(IsParameterisedThread)
            {

                if(TheMaxStackSize > 0)
                {

                    myThread = new Thread(MainTakingAParameter, TheMaxStackSize);
                    
                }
                else
                {

                    myThread = new Thread(MainTakingAParameter);
                    
                }

            }
            else
            {

                if(TheMaxStackSize > 0)
                {

                    myThread = new Thread(RunThreadMain, TheMaxStackSize);

                }
                else
                {

                    myThread = new Thread(RunThreadMain);

                }

            }

            if(mySleepAtEnd != TheSleepAtEnd)
            {

                mySleepAtEnd = TheSleepAtEnd;

                Thread.MemoryBarrier();

            }

        }

        public void Start()
        {

            if(!myThread.IsAlive)
            {

                myThread.Start();

            }
            else
            {

                Thread.MemoryBarrier();

                if(myIsSleepingAtEnd && !myIsActive)
                {

                    //myThread.Interrupt();

                    Wake();

                }

            }
        }

        public void Start(object TheParameter)
        {

            if(!myThread.IsAlive)
            {

                myThread.Start(TheParameter);

            }
            else
            {

                Thread.MemoryBarrier();

                if(myIsSleepingAtEnd && !myIsActive)
                {

                    //myThread.Interrupt();

                    Wake();

                }

            }

        }

        public void Wake()
        {

            Thread.MemoryBarrier();

            if(mySleepingOnSleepEvent)
            {

                mySleepEvent.Set();

            }

        }

        public void Interrupt()
        {

            if(myThread.ThreadState == ThreadState.WaitSleepJoin)
            {

                myThread.Interrupt();

            }

        }

        public void WakeOrInterrupt()
        {

            Thread.MemoryBarrier();

            if(mySleepingOnSleepEvent)
            {

                mySleepEvent.Set();

            }
            else if(myThread.ThreadState == ThreadState.WaitSleepJoin)
            {

                myThread.Interrupt();

            }

        }

        public ThreadState ThreadState
        {

            get
            {

                return myThread.ThreadState;

            }

        }

        public bool IsSleeping
        {

            get
            {

                return myThread.ThreadState == ThreadState.WaitSleepJoin; 

            }

        }

        public bool WaitingOnSleepEvent
        {

            get
            {

                Thread.MemoryBarrier();

                return mySleepingOnSleepEvent;

            }

        }

        public bool IsWaitingToStart
        {

            get
            {

                return myThread.ThreadState == ThreadState.WaitSleepJoin && !myIsActive;

            }

        }

        public void Abort()
        {

            if(myThread.IsAlive)
            {

                myThread.Abort();

            }

        }

        public bool IsBackground
        {

            get
            {

                return myThread.IsBackground;

            }
            set
            {

                myThread.IsBackground = value;
                
            }

        }

        public bool IsThreadPoolThread
        {

            get
            {

                return myThread.IsThreadPoolThread;
                
            }

        }

        public int ManagedThreadId
        {

            get
            {

                return myThread.ManagedThreadId;
                
            }

        }

        public string Name
        {

            get
            {

                return myThread.Name;
                
            }
            set
            {

                myThread.Name = value;

            }

        }

        public ThreadPriority Priority
        {

            get
            {

                return myThread.Priority;

            }
            set
            {

                myThread.Priority = value;

            }

        }

        public ApartmentState GetApartmentState()
        {

            return myThread.GetApartmentState();

        }

        public void SetApartmentState(ApartmentState TheApartmentState)
        {

            myThread.SetApartmentState(TheApartmentState);

        }

        public bool TrySetApartmentState(ApartmentState TheApartmentState)
        {

            return myThread.TrySetApartmentState(TheApartmentState);

        }

        public void Stop()
        {

            Thread.MemoryBarrier();

            if(myThread.IsAlive && !myStopRequested)
            {

                myStopRequested = true;

                Thread.MemoryBarrier();

            }

        }

        public bool StopRequested
        {

            get
            {

                Thread.MemoryBarrier();
                
                return myStopRequested;
            
            }

        }

        public bool SleepAtEnd
        {

            get
            {

                return mySleepAtEnd;

            }
            set
            {

                mySleepAtEnd = value;

                Thread.MemoryBarrier();

            }

        }

        public bool IsSleepingAtEnd
        {

            get
            {

                return mySleepAtEnd && myThread.ThreadState == ThreadState.WaitSleepJoin;

            }

        }

        public void DisableComObjectEagerCleanup()
        {

            myThread.DisableComObjectEagerCleanup();

        }

        public void Join()
        {

            myThread.Join();

        }

        public void Join(int millisecondsTimeout)
        {

            myThread.Join(millisecondsTimeout);

        }

        public void Join(TimeSpan timeout)
        {

            myThread.Join(timeout);

        }

        private void CheckWaitSleepEvent()
        {

            //Does the ManualResetEventExist?

            Thread.MemoryBarrier();

            if(myWaitSleepEvent == null)
            {

                myWaitSleepEvent = new ManualResetEvent(false);

                Thread.MemoryBarrier();

            }

            //Are there threads waiting?

            Thread.MemoryBarrier();

            if(!mySleepingOnWaitSleepEvent)
            {

                mySleepingOnWaitSleepEvent = true;

                Thread.MemoryBarrier();

            }

        }

        public void WaitJoin()
        {

            if(myThread != Thread.CurrentThread)
            {

                CheckWaitSleepEvent();

                myWaitSleepEvent.WaitOne();

            }

        }

        public void WaitJoin(int millisecondsTimeout)
        {

            if(myThread != Thread.CurrentThread)
            {

                CheckWaitSleepEvent();

                myWaitSleepEvent.WaitOne(millisecondsTimeout);

            }

        }

        public void WaitJoin(TimeSpan timeout)
        {

            if(myThread != Thread.CurrentThread)
            {

                CheckWaitSleepEvent();

                myWaitSleepEvent.WaitOne(timeout);

            }

        }

        public void WaitJoin(int millisecondsTimeout, bool exitContext)
        {

            if(myThread != Thread.CurrentThread)
            {

                CheckWaitSleepEvent();

                myWaitSleepEvent.WaitOne(millisecondsTimeout, exitContext);

            }

        }

        public void WaitJoin(TimeSpan timeout, bool exitContext)
        {

            if(myThread != Thread.CurrentThread)
            {

                CheckWaitSleepEvent();

                myWaitSleepEvent.WaitOne(timeout, exitContext);

            }

        }

        protected abstract void ThreadMain();

        private void RunThreadMain() 
        {

            bool Continue = false;

            do
            {

                myIsActive = true;

                Thread.MemoryBarrier();

                try
                {

                    Thread.MemoryBarrier();

                    if(myException != null)
                    {

                        myException = null;

                        Thread.MemoryBarrier();

                    }

                    Thread.MemoryBarrier();

                    if(myParameter != null)
                    {

                        myParameter = null;

                        Thread.MemoryBarrier();

                    }

                    Thread.MemoryBarrier();

                    if(!myStopRequested)
                    {

                        ThreadMain();

                    }

                }
                catch(Exception e)
                {

                    myException = e;

                    Thread.MemoryBarrier();

                }
                finally
                {

                    Thread.MemoryBarrier();

                    if(myStopRequested)
                    {

                        Thread.MemoryBarrier();

                        if(myWaitSleepEvent != null)
                        {

                            Thread.MemoryBarrier();

                            if(!mySleepingOnWaitSleepEvent)
                                myWaitSleepEvent.Reset();

                        }

                        myStopRequested = false;

                        Thread.MemoryBarrier();

                        if(mySleepAtEnd)
                        {

                            mySleepAtEnd = false;

                            Thread.MemoryBarrier();

                        }

                        if(Continue)
                            Continue = false;

                    }
                    else
                    {

                        Thread.MemoryBarrier();

                        if(mySleepAtEnd)
                        {

                            Thread.MemoryBarrier();

                            if(!myIsSleepingAtEnd)
                            {

                                myIsSleepingAtEnd = true;

                                Thread.MemoryBarrier();

                            }

                            if(!Continue)
                                Continue = true;

                        }

                        myIsActive = false;

                        Thread.MemoryBarrier();

                    }

                }

                Thread.MemoryBarrier();

                if(myIsSleepingAtEnd)
                {

                    Thread.MemoryBarrier();

                    if(myStopRequested)
                    {

                        myIsSleepingAtEnd = false;

                        Thread.MemoryBarrier();

                        break;

                    }

                    Thread.MemoryBarrier();

                    if(myWaitSleepEvent != null)
                    {

                        Thread.MemoryBarrier();

                        if(!mySleepingOnWaitSleepEvent)
                        {

                            try
                            {

                                myWaitSleepEvent.Set();

                            }
                            finally
                            {

                                mySleepingOnWaitSleepEvent = false;

                                Thread.MemoryBarrier();

                            }

                        }

                    }

                    try
                    {

                        Sleep();

                    }
                    catch(Exception e)
                    {

                        myException = e;

                        Thread.MemoryBarrier();

                    }
                    finally
                    {
                        
                        myIsSleepingAtEnd = false;

                        Thread.MemoryBarrier();

                    }

                }
                else
                {

                    if(Continue)
                        Continue = false;

                }

            }
            while(Continue);

            Thread.MemoryBarrier();

            if(myWaitSleepEvent != null)
            {

                Thread.MemoryBarrier();

                if(!mySleepingOnWaitSleepEvent)
                {

                    try
                    {

                        myWaitSleepEvent.Set();

                    }
                    finally
                    {

                        mySleepingOnWaitSleepEvent = false;

                        Thread.MemoryBarrier();

                    }

                }

            }

        }

        protected virtual void MainTakingAParameter(object TheParameter) 
        {
            
            bool Continue = false;

            do
            {

                myIsActive = true;

                Thread.MemoryBarrier();

                try
                {

                    Thread.MemoryBarrier();

                    if(myException != null)
                    {

                        myException = null;

                        Thread.MemoryBarrier();

                    }

                    Thread.MemoryBarrier();

                    if(!myStopRequested)
                    {

                        Thread.MemoryBarrier();

                         if(myWaitSleepEvent != null)
                         {

                             Thread.MemoryBarrier();

                             if(!mySleepingOnWaitSleepEvent)
                                 myWaitSleepEvent.Reset();

                         }

                        Thread.MemoryBarrier();

                        if(myParameter != TheParameter)
                        {

                            myParameter = TheParameter;

                            Thread.MemoryBarrier();

                        }

                        ThreadMain();

                    }

                }
                catch (Exception e)
                {

                    myException = e;

                    Thread.MemoryBarrier();

                }
                finally
                {

                    Thread.MemoryBarrier();

                    if(mySleepAtEnd)
                    {

                        Thread.MemoryBarrier();

                        if(!myIsSleepingAtEnd)
                        {

                            myIsSleepingAtEnd = true;

                            Thread.MemoryBarrier();

                        }

                        if(!Continue)
                            Continue = true;

                    }

                    myIsActive = false;

                    Thread.MemoryBarrier();

                }

                Thread.MemoryBarrier();

                if(myIsSleepingAtEnd)
                {

                    Thread.MemoryBarrier();

                    if(myStopRequested)
                    {

                        myIsSleepingAtEnd = false;

                        Thread.MemoryBarrier();

                        break;

                    }

                    try
                    {

                        Sleep();

                    }
                    catch(Exception e)
                    {

                        myException = e;

                        Thread.MemoryBarrier();

                    }
                    finally
                    {

                        myIsSleepingAtEnd = false;

                        Thread.MemoryBarrier();

                    }

                }
                else
                {

                    if(Continue)
                        Continue = false;

                }

            }
            while(Continue);

            Thread.MemoryBarrier();

            if(myWaitSleepEvent != null)
            {

                Thread.MemoryBarrier();

                if(!mySleepingOnWaitSleepEvent)
                {

                    try
                    {

                        myWaitSleepEvent.Set();

                    }
                    finally
                    {

                        mySleepingOnWaitSleepEvent = false;

                        Thread.MemoryBarrier();

                    }

                }

            }

        }

        public Exception Exception
        {

            get 
            {

                Thread.MemoryBarrier();

                return myException;

            }
        
        }

        public bool CaughtException
        {

            get
            {

                Thread.MemoryBarrier();

                return myException != null;

            }

        }

        public bool IsAlive
        {

            get 
            {

                return myThread.IsAlive;

            }

        }

        //Indicates that ThreadMain is being executed

        public bool IsActive
        {

            get
            {

                Thread.MemoryBarrier();

                return myIsActive;

            }

        }

        protected object Parameter 
        {

            get 
            {

                return myParameter;

            }

        }

        protected bool HasParameter
        {

            get
            {

                return myParameter != null;

            }

        }

        protected void ClearParameter()
        {
            
            myParameter = null;

        }

        private void CheckSetWaitSleepEvent()
        {

            Thread.MemoryBarrier();

            if(myWaitSleepEvent != null)
            {

                Thread.MemoryBarrier();

                if(mySleepingOnWaitSleepEvent)
                {

                    try
                    {

                        myWaitSleepEvent.Set();

                    }
                    finally
                    {

                        mySleepingOnWaitSleepEvent = false;

                        Thread.MemoryBarrier();

                    }

                }

            }

        }

        protected bool Sleep()
        {

            try
            {

                Thread.MemoryBarrier();

                if(mySleepEvent == null)
                {

                    mySleepEvent = new AutoResetEvent(false);

                    Thread.MemoryBarrier();

                }

                mySleepingOnSleepEvent = true;

                Thread.MemoryBarrier();

                CheckSetWaitSleepEvent();

                return mySleepEvent.WaitOne();

            }
            catch(ThreadInterruptedException e)
            {
            }
            finally
            {

                mySleepingOnSleepEvent = false;

                Thread.MemoryBarrier();

            }

            return false;

        }

        protected bool Sleep(Action OnInterrupt)
        {

            try
            {

                Thread.MemoryBarrier();

                if(mySleepEvent == null)
                {

                    mySleepEvent = new AutoResetEvent(false);

                    Thread.MemoryBarrier();

                }

                mySleepingOnSleepEvent = true;

                Thread.MemoryBarrier();

                CheckSetWaitSleepEvent();

                return mySleepEvent.WaitOne();

            }
            catch(ThreadInterruptedException e)
            {

                OnInterrupt();

            }
            finally
            {

                mySleepingOnSleepEvent = false;

                Thread.MemoryBarrier();

            }

            return false;

        }

        protected bool Sleep(Action<ThreadInterruptedException> OnInterrupt)
        {

            try
            {

                Thread.MemoryBarrier();

                if(mySleepEvent == null)
                {

                    mySleepEvent = new AutoResetEvent(false);

                    Thread.MemoryBarrier();

                }

                mySleepingOnSleepEvent = true;

                Thread.MemoryBarrier();

                CheckSetWaitSleepEvent();

                return mySleepEvent.WaitOne();

            }
            catch(ThreadInterruptedException e)
            {

                OnInterrupt(e);

            }
            finally
            {

                mySleepingOnSleepEvent = false;

                Thread.MemoryBarrier();

            }

            return false;

        }

        protected bool Sleep(int Timeout)
        {

            try
            {

                Thread.MemoryBarrier();

                if(mySleepEvent == null)
                {

                    mySleepEvent = new AutoResetEvent(false);

                    Thread.MemoryBarrier();

                }

                mySleepingOnSleepEvent = true;

                Thread.MemoryBarrier();

                CheckSetWaitSleepEvent();

                return mySleepEvent.WaitOne(Timeout);

            }
            catch(ThreadInterruptedException e)
            {
            }
            finally
            {

                mySleepingOnSleepEvent = false;

                Thread.MemoryBarrier();

            }

            return false;

        }

        protected bool Sleep(int Timeout, Action OnInterrupt)
        {

            try
            {

                Thread.MemoryBarrier();

                if(mySleepEvent == null)
                {

                    mySleepEvent = new AutoResetEvent(false);

                    Thread.MemoryBarrier();

                }

                mySleepingOnSleepEvent = true;

                Thread.MemoryBarrier();

                CheckSetWaitSleepEvent();

                return mySleepEvent.WaitOne(Timeout);

            }
            catch(ThreadInterruptedException e)
            {

                OnInterrupt();

            }
            finally
            {

                mySleepingOnSleepEvent = false;

                Thread.MemoryBarrier();

            }

            return false;

        }

        protected bool Sleep(int Timeout, Action<ThreadInterruptedException> OnInterrupt)
        {

            try
            {

                Thread.MemoryBarrier();

                if(mySleepEvent == null)
                {

                    mySleepEvent = new AutoResetEvent(false);

                    Thread.MemoryBarrier();

                }

                mySleepingOnSleepEvent = true;

                Thread.MemoryBarrier();

                CheckSetWaitSleepEvent();

                return mySleepEvent.WaitOne(Timeout);

            }
            catch(ThreadInterruptedException e)
            {

                OnInterrupt(e);

            }
            finally
            {

                mySleepingOnSleepEvent = false;

                Thread.MemoryBarrier();

            }

            return false;

        }

        protected bool Sleep(TimeSpan Timeout)
        {

            try
            {

                Thread.MemoryBarrier();

                if(mySleepEvent == null)
                {

                    mySleepEvent = new AutoResetEvent(false);

                    Thread.MemoryBarrier();

                }

                mySleepingOnSleepEvent = true;

                Thread.MemoryBarrier();

                CheckSetWaitSleepEvent();

                return mySleepEvent.WaitOne(Timeout);

            }
            catch(ThreadInterruptedException e)
            {
            }
            finally
            {

                mySleepingOnSleepEvent = false;

                Thread.MemoryBarrier();

            }

            return false;

        }

        protected bool Sleep(TimeSpan Timeout, Action OnInterrupt)
        {

            try
            {

                Thread.MemoryBarrier();

                if(mySleepEvent == null)
                {

                    mySleepEvent = new AutoResetEvent(false);

                    Thread.MemoryBarrier();

                }

                mySleepingOnSleepEvent = true;

                Thread.MemoryBarrier();

                CheckSetWaitSleepEvent();

                return mySleepEvent.WaitOne(Timeout);

            }
            catch(ThreadInterruptedException e)
            {

                OnInterrupt();

            }
            finally
            {

                mySleepingOnSleepEvent = false;

                Thread.MemoryBarrier();

            }

            return false;

        }

        protected bool Sleep(TimeSpan Timeout, Action<ThreadInterruptedException> OnInterrupt)
        {

            try
            {

                Thread.MemoryBarrier();

                if(mySleepEvent == null)
                {

                    mySleepEvent = new AutoResetEvent(false);

                    Thread.MemoryBarrier();

                }

                mySleepingOnSleepEvent = true;

                Thread.MemoryBarrier();

                CheckSetWaitSleepEvent();

                return mySleepEvent.WaitOne(Timeout);

            }
            catch(ThreadInterruptedException e)
            {

                OnInterrupt(e);

            }
            finally
            {

                mySleepingOnSleepEvent = false;

                Thread.MemoryBarrier();

            }

            return false;

        }

        public void Dispose()
        {

            Thread.MemoryBarrier();

            if(mySleepEvent != null)
            {

                Thread.MemoryBarrier();

                if(myIsActive)
                {

                    if(myThread != Thread.CurrentThread)
                    {

                        lock(myThread)
                        {

                            throw new Exception("Active thread SleepEvent must be disposed by the creating Thread");

                        }

                    }

                }

                Thread.MemoryBarrier();

                if(mySleepingOnSleepEvent)
                {

                    mySleepEvent.Set();

                }

                Thread.MemoryBarrier();

                if(mySleepEvent != null)
                {

                    AutoResetEvent Event = mySleepEvent;

                    mySleepEvent = null;

                    Thread.MemoryBarrier();

                    Event.Dispose();

                }

                Thread.MemoryBarrier();

                if(myWaitSleepEvent != null)
                {

                    ManualResetEvent Event = myWaitSleepEvent;

                    myWaitSleepEvent = null;

                    Thread.MemoryBarrier();

                    Event.Dispose();

                }

            }

        }

    }

}
