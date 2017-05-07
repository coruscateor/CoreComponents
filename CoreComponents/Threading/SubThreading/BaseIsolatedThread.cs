using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading.SubThreading
{

    public abstract class BaseIsolatedThread : IIsolatedThread, IDisposable
    {

        private const string CannotWaitExceptionMessage = "Only the thread used by the IsolatedThread can wait on its sleep event";

        private const string ContinueExceptionMessage = "Only the thread contained by the IsolatedThread can set the continue variable";

        private Thread myThread;

        private Exception myException;

        private bool myStopRequested;

        private bool myIsActive;

        //For the thread to sleep on

        private ManualResetEventSlim myWaitSleepEvent;

        private bool myIsWaitingForWake;

        private bool myHasExited;

        //For other threads to sleep on

        private ManualResetEventSlim mySleepEvent;

        private int myMaxStackSize;

        private object myLockObject;

        private bool myIsContinuing;

        public BaseIsolatedThread(int TheMaxStackSize = 0)
        {

            if(TheMaxStackSize > 0)
            {

                myMaxStackSize = TheMaxStackSize;

                myThread = new Thread(RunThreadMain, TheMaxStackSize);

            }
            else
            {

                myThread = new Thread(RunThreadMain);

            }

            myLockObject = new object();

            InitialiseResetEvents();

        }

        public BaseIsolatedThread(object lockObject, int TheMaxStackSize = 0)
        {

            if(TheMaxStackSize > 0)
            {

                myMaxStackSize = TheMaxStackSize;

                myThread = new Thread(RunThreadMain, TheMaxStackSize);

            }
            else
            {

                myThread = new Thread(RunThreadMain);

            }

            myLockObject = lockObject;

            InitialiseResetEvents();

        }

        private void InitialiseResetEvents()
        {
            
            myWaitSleepEvent = new ManualResetEventSlim(false);

            mySleepEvent = new ManualResetEventSlim(true);

        }

        public void Start()
        {

            if(!myThread.IsAlive)
            {

                if(HasExited)
                {

                    Thread OldThread = myThread;

                    if(myMaxStackSize > 0)
                    {

                        myThread = new Thread(RunThreadMain, myMaxStackSize);

                    }
                    else
                    {

                        myThread = new Thread(RunThreadMain);

                    }

                    CopyThreadProperties(OldThread);

                }

                myThread.Start();

            }
            else
            {

                Wake();

            }

        }

        private void CopyThreadProperties(Thread OldThread)
        {

            if(myThread.GetApartmentState() != OldThread.GetApartmentState())
                myThread.SetApartmentState(OldThread.GetApartmentState());

            if(myThread.CurrentCulture != OldThread.CurrentCulture)
                myThread.CurrentCulture = OldThread.CurrentCulture;

            if(myThread.CurrentUICulture != OldThread.CurrentUICulture)
                myThread.CurrentUICulture = OldThread.CurrentUICulture;

            if(myThread.IsBackground != OldThread.IsBackground)
                myThread.IsBackground = OldThread.IsBackground;

            if(myThread.Name != OldThread.Name)
                myThread.Name = OldThread.Name;

            if(myThread.Priority != OldThread.Priority)
                myThread.Priority = OldThread.Priority;

        }

        public bool IsWaitingForWake
        {

            get
            {

                lock(myLockObject)
                {

                    return myIsWaitingForWake;

                }

            }
            private set
            {

                lock(myLockObject)
                {

                    myIsWaitingForWake = value;

                    if(value)
                        myIsActive = false;
                    else
                        myIsActive = true;

                }

            }

        }

        private void IsNowWaitingForWake()
        {

            lock(myLockObject)
            {

                myIsWaitingForWake = true;

                //myIsActive = false;

            }

        }

        private void IsNotWaitingForWake()
        {

            lock(myLockObject)
            {

                myIsWaitingForWake = false;

                //myIsActive = true;

            }

        }

        private bool SetNotWaitingForWake()
        {

            lock(myLockObject)
            {

                if(myIsWaitingForWake)
                {

                    myIsWaitingForWake = false;

                    myIsActive = true;

                    return true;

                }

            }

            return false;

        }

        public void Wake()
        {

            if(SetNotWaitingForWake())
            {

                myWaitSleepEvent.Set();

                myWaitSleepEvent.Reset();

            }

        }

        public int MaxStackSize
        {

            get
            {

                return myMaxStackSize;

            }

        }

        public bool IsContinuing
        {

            get
            {

                lock(myLockObject)
                {

                    return myIsContinuing;

                }

            }
            set
            {

                lock(myLockObject)
                {

                    myIsContinuing = value;

                }

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

            if(SetNotWaitingForWake())
            {

                myWaitSleepEvent.Set();

                myWaitSleepEvent.Reset();

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

        public bool IsThisThread
        {

            get
            {

                return myThread == Thread.CurrentThread;

            }

        }

        public void Abort()
        {

            myThread.Abort();

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

            lock(myLockObject)
            {

                if(myThread.IsAlive && !myStopRequested)
                {

                    myStopRequested = true;

                }

            }

        }

        public bool StopRequested
        {

            get
            {

                lock(myLockObject)
                {

                    return myStopRequested;

                }

            }
            private set
            {

                lock(myLockObject)
                {

                    myStopRequested = value;

                }

            }

        }

        public bool HasExited
        {

            get
            {

                lock(myLockObject)
                {

                    return myHasExited;

                }

            }
            private set
            {

                lock(myLockObject)
                {

                    myHasExited = value;

                }

            }

        }

        public void DisableComObjectEagerCleanup()
        {

            myThread.DisableComObjectEagerCleanup();

        }

        public void JoinExit(bool RethrowInterrupt = false)
        {

            try
            {

                myThread.Join();

            }
            catch(ThreadInterruptedException e)
            {

                if(RethrowInterrupt)
                    throw e;

            }

        }

        public void JoinExit(Action<ThreadInterruptedException> OnInterrupt)
        {

            try
            {

                myThread.Join();

            }
            catch(ThreadInterruptedException e)
            {

                OnInterrupt(e);

            }

        }

        public void JoinExit(int millisecondsTimeout, bool RethrowInterrupt = false)
        {

            try
            {

                myThread.Join(millisecondsTimeout);

            }
            catch(ThreadInterruptedException e)
            {

                if(RethrowInterrupt)
                    throw e;

            }

        }

        public void JoinExit(int millisecondsTimeout, Action<ThreadInterruptedException> OnInterrupt)
        {

            try
            {

                myThread.Join(millisecondsTimeout);

            }
            catch(ThreadInterruptedException e)
            {

                OnInterrupt(e);

            }

        }

        public void JoinExit(TimeSpan timeout, bool RethrowInterrupt = false)
        {
            
            try
            {

                myThread.Join(timeout);

            }
            catch(ThreadInterruptedException e)
            {

                if(RethrowInterrupt)
                    throw e;

            }

        }

        public void JoinExit(TimeSpan timeout, Action<ThreadInterruptedException> OnInterrupt)
        {

            try
            {

                myThread.Join(timeout);

            }
            catch(ThreadInterruptedException e)
            {

                OnInterrupt(e);

            }

        }

        public virtual bool Join(bool RethrowInterrupt = false)
        {

            if(myThread != Thread.CurrentThread)
            {

                try
                {

                    mySleepEvent.Wait();

                }
                catch(ThreadInterruptedException e)
                {

                    if(RethrowInterrupt)
                        throw e;

                }

                return true;

            }

            return false;

        }

        public virtual bool Join(CancellationToken TheCancellationToken, bool RethrowInterrupt = false)
        {

            if(myThread != Thread.CurrentThread)
            {

                try
                {

                    mySleepEvent.Wait(TheCancellationToken);

                    return true;

                }
                catch(ThreadInterruptedException e)
                {

                    if(RethrowInterrupt)
                        throw e;

                }

                return true;

            }

            return false;

        }

        public virtual bool Join(Action<ThreadInterruptedException> OnInterrupt)
        {

            if(myThread != Thread.CurrentThread)
            {

                try
                {

                    mySleepEvent.Wait();

                }
                catch(ThreadInterruptedException e)
                {

                    OnInterrupt(e);

                }

                return true;

            }

            return false;

        }

        public virtual bool Join(CancellationToken TheCancellationToken, Action<ThreadInterruptedException> OnInterrupt)
        {

            if(myThread != Thread.CurrentThread)
            {

                try
                {

                    mySleepEvent.Wait(TheCancellationToken);

                    return true;

                }
                catch(ThreadInterruptedException e)
                {

                    OnInterrupt(e);

                }

                return true;

            }

            return false;

        }

        public virtual bool Join(int MillisecondsTimeout, bool RethrowInterrupt = false)
        {

            if(myThread != Thread.CurrentThread)
            {

                try
                {

                    return mySleepEvent.Wait(MillisecondsTimeout);

                }
                catch(ThreadInterruptedException e)
                {

                    if(RethrowInterrupt)
                        throw e;

                }

                return true;

            }

            return false;

        }

        public virtual bool Join(int MillisecondsTimeout, CancellationToken TheCancellationToken, bool RethrowInterrupt = false)
        {

            if(myThread != Thread.CurrentThread)
            {

                try
                {

                    return mySleepEvent.Wait(MillisecondsTimeout, TheCancellationToken);

                }
                catch(ThreadInterruptedException e)
                {

                    if(RethrowInterrupt)
                        throw e;

                }

                return true;

            }

            return false;

        }

        public virtual bool Join(int MillisecondsTimeout, Action<ThreadInterruptedException> OnInterrupt)
        {

            if(myThread != Thread.CurrentThread)
            {

                try
                {

                    return mySleepEvent.Wait(MillisecondsTimeout);

                }
                catch(ThreadInterruptedException e)
                {

                    OnInterrupt(e);

                }

                return true;

            }

            return false;

        }

        public virtual bool Join(int MillisecondsTimeout, CancellationToken TheCancellationToken, Action<ThreadInterruptedException> OnInterrupt)
        {

            if(myThread != Thread.CurrentThread)
            {

                try
                {

                    return mySleepEvent.Wait(MillisecondsTimeout, TheCancellationToken);

                }
                catch(ThreadInterruptedException e)
                {

                    OnInterrupt(e);

                }

                return true;

            }

            return false;

        }

        public virtual bool Join(TimeSpan Timeout, bool RethrowInterrupt = false)
        {

            if(myThread != Thread.CurrentThread)
            {

                try
                {

                    return mySleepEvent.Wait(Timeout);

                }
                catch(ThreadInterruptedException e)
                {

                    if(RethrowInterrupt)
                        throw e;

                }

                return true;

            }

            return false;

        }

        public virtual bool Join(TimeSpan Timeout, CancellationToken TheCancellationToken, bool RethrowInterrupt = false)
        {

            if(myThread != Thread.CurrentThread)
            {

                try
                {

                    return mySleepEvent.Wait(Timeout, TheCancellationToken);

                }
                catch(ThreadInterruptedException e)
                {

                    if(RethrowInterrupt)
                        throw e;

                }

                return true;

            }

            return false;

        }

        public virtual bool Join(TimeSpan Timeout, Action<ThreadInterruptedException> OnInterrupt)
        {

            if(myThread != Thread.CurrentThread)
            {

                try
                {

                    mySleepEvent.Wait(Timeout);

                }
                catch(ThreadInterruptedException e)
                {

                    OnInterrupt(e);

                }

                return true;

            }

            return false;

        }

        public virtual bool Join(TimeSpan Timeout, CancellationToken TheCancellationToken, Action<ThreadInterruptedException> OnInterrupt)
        {

            if(myThread != Thread.CurrentThread)
            {

                try
                {

                    return mySleepEvent.Wait(Timeout, TheCancellationToken);

                }
                catch(ThreadInterruptedException e)
                {

                    OnInterrupt(e);

                }

                return true;

            }

            return false;

        }

        protected abstract void ThreadMain();

        private void RunThreadMain() 
        {

            lock(myLockObject)
            {

                if(!myHasExited)
                    myHasExited = false;

                if(myStopRequested)
                    myStopRequested = false;

                if(!myIsActive)
                    myIsActive = true;

                if(myException != null)
                    myException = null;

            }

            do
            {

                try
                {

                    mySleepEvent.Reset();

                    ThreadMain();

                }
                catch(Exception e)
                {

                    Exception = e;

                    break;

                }
                finally
                {

                    mySleepEvent.Set();

                }

                if(IsContinuing)
                    continue;

                if(!StopRequested)
                {

                    try
                    {

                        //Sleep rather than exit

                        myWaitSleepEvent.Wait();

                    }
                    catch(ThreadInterruptedException e)
                    {

                        Exception = e;

                    }
                    catch(Exception e)
                    {

                        Exception = e;

                        break;

                    }

                }
                else
                {

                    break;

                }

            }
            while(!StopRequested);

            lock(myLockObject)
            {

                myIsActive = false;

                myHasExited = true;

            }

        }

        public Exception Exception
        {

            get 
            {

                lock(myLockObject)
                {

                    return myException;

                }

            }
            private set
            {

                lock(myLockObject)
                {

                    myException = value;

                }

            }
        
        }

        public bool TryGetException(out Exception Ex)
        {

            lock(myLockObject)
            {

                Ex = myException;

            }

            return Ex != null;

        }
        
        public bool HasException
        {

            get
            {

                lock(myLockObject)
                {

                    return myException != null;

                }

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

                lock(myLockObject)
                {

                    return myIsActive;

                }

            }
            private set
            {

                lock(myLockObject)
                {

                    myIsActive = value;

                }

            }

        }

        protected virtual void Sleep(bool RethrowInterrupt = false)
        {

            if(myThread == Thread.CurrentThread)
            {

                try
                {

                    IsNowWaitingForWake();

                    myWaitSleepEvent.Wait();

                }
                catch(ThreadInterruptedException e)
                {

                    IsNotWaitingForWake();

                    if(RethrowInterrupt)
                        throw e;

                }
                catch(Exception e)
                {

                    IsNotWaitingForWake();

                    throw e;

                }

            }
            else
            {

                throw new CannotWaitException(CannotWaitExceptionMessage);

            }

        }

        protected virtual void Sleep(CancellationToken TheCancellationToken, bool RethrowInterrupt = false)
        {

            if(myThread == Thread.CurrentThread)
            {

                try
                {

                    IsNowWaitingForWake();

                    myWaitSleepEvent.Wait(TheCancellationToken);

                }
                catch(ThreadInterruptedException e)
                {

                    IsNotWaitingForWake();

                    if(RethrowInterrupt)
                        throw e;

                }
                catch(Exception e)
                {

                    IsNotWaitingForWake();

                    throw e;

                }

            }
            else
            {

                throw new CannotWaitException(CannotWaitExceptionMessage);

            }

        }

        protected virtual void Sleep(Action<ThreadInterruptedException> OnInterrupt)
        {

            if(myThread == Thread.CurrentThread)
            {

                ThreadInterruptedException TIE = null;

                try
                {

                    IsNowWaitingForWake();

                    myWaitSleepEvent.Wait();

                }
                catch(ThreadInterruptedException e)
                {

                    IsNotWaitingForWake();

                    TIE = e;

                }
                catch(Exception e)
                {

                    IsNotWaitingForWake();

                    throw e;

                }

                if(TIE != null)
                    OnInterrupt(TIE);

            }
            else
            {

                throw new CannotWaitException(CannotWaitExceptionMessage);

            }

        }

        protected virtual void Sleep(CancellationToken TheCancellationToken, Action<ThreadInterruptedException> OnInterrupt)
        {

            if(myThread == Thread.CurrentThread)
            {

                ThreadInterruptedException TIE = null;

                try
                {

                    IsNowWaitingForWake();

                    myWaitSleepEvent.Wait(TheCancellationToken);

                }
                catch(ThreadInterruptedException e)
                {

                    IsNotWaitingForWake();

                    TIE = e;

                }
                catch(Exception e)
                {

                    IsNotWaitingForWake();

                    throw e;

                }

                if(TIE != null)
                    OnInterrupt(TIE);

            }
            else
            {

                throw new CannotWaitException(CannotWaitExceptionMessage);

            }

        }

        protected virtual void Sleep(int Timeout, bool RethrowInterrupt = false)
        {

            if(myThread == Thread.CurrentThread)
            {

                try
                {

                    IsNowWaitingForWake();

                    myWaitSleepEvent.Wait(Timeout);

                }
                catch(ThreadInterruptedException e)
                {

                    IsNotWaitingForWake();

                    if(RethrowInterrupt)
                        throw e;

                }
                catch(Exception e)
                {

                    IsNotWaitingForWake();

                    throw e;

                }

            }
            else
            {

                throw new CannotWaitException(CannotWaitExceptionMessage);

            }

        }

        protected virtual void Sleep(int Timeout, CancellationToken TheCancellationToken, bool RethrowInterrupt = false)
        {

            if(myThread == Thread.CurrentThread)
            {

                try
                {

                    IsNowWaitingForWake();

                    myWaitSleepEvent.Wait(Timeout, TheCancellationToken);

                }
                catch(ThreadInterruptedException e)
                {

                    IsNotWaitingForWake();

                    if(RethrowInterrupt)
                        throw e;

                }
                catch(Exception e)
                {

                    IsNotWaitingForWake();

                    throw e;

                }

            }
            else
            {

                throw new CannotWaitException(CannotWaitExceptionMessage);

            }

        }

        protected virtual void Sleep(int Timeout, Action<ThreadInterruptedException> OnInterrupt)
        {

            if(myThread == Thread.CurrentThread)
            {

                ThreadInterruptedException TIE = null;

                try
                {

                    IsNowWaitingForWake();

                    myWaitSleepEvent.Wait(Timeout);

                }
                catch(ThreadInterruptedException e)
                {

                    IsNotWaitingForWake();

                    TIE = e;

                }
                catch(Exception e)
                {

                    IsNotWaitingForWake();

                    throw e;

                }

                if(TIE != null)
                    OnInterrupt(TIE);

            }
            else
            {

                throw new CannotWaitException(CannotWaitExceptionMessage);

            }

        }

        protected virtual void Sleep(int Timeout, CancellationToken TheCancellationToken, Action<ThreadInterruptedException> OnInterrupt)
        {

            if(myThread == Thread.CurrentThread)
            {

                ThreadInterruptedException TIE = null;

                try
                {

                    IsNowWaitingForWake();

                    myWaitSleepEvent.Wait(Timeout, TheCancellationToken);

                }
                catch(ThreadInterruptedException e)
                {

                    IsNotWaitingForWake();

                    TIE = e;

                }
                catch(Exception e)
                {

                    IsNotWaitingForWake();

                    throw e;

                }

                if(TIE != null)
                    OnInterrupt(TIE);

            }
            else
            {

                throw new CannotWaitException(CannotWaitExceptionMessage);

            }
            
        }

        protected virtual void Sleep(TimeSpan Timeout, bool RethrowInterrupt = false)
        {

            if(myThread == Thread.CurrentThread)
            {

                try
                {

                    IsNowWaitingForWake();

                    myWaitSleepEvent.Wait(Timeout);

                }
                catch(ThreadInterruptedException e)
                {

                    IsNotWaitingForWake();

                    if(RethrowInterrupt)
                        throw e;

                }
                catch(Exception e)
                {

                    IsNotWaitingForWake();

                    throw e;

                }

            }
            else
            {

                throw new CannotWaitException(CannotWaitExceptionMessage);

            }

        }

        protected virtual void Sleep(TimeSpan Timeout, CancellationToken TheCancellationToken, bool RethrowInterrupt = false)
        {

            if(myThread == Thread.CurrentThread)
            {

                try
                {

                    IsNowWaitingForWake();

                    myWaitSleepEvent.Wait(Timeout, TheCancellationToken);

                }
                catch(ThreadInterruptedException e)
                {

                    IsNotWaitingForWake();

                    if(RethrowInterrupt)
                        throw e;

                }
                catch(Exception e)
                {

                    IsNotWaitingForWake();

                    throw e;

                }

            }
            else
            {

                throw new CannotWaitException(CannotWaitExceptionMessage);

            }

        }

        protected virtual void Sleep(TimeSpan Timeout, Action<ThreadInterruptedException> OnInterrupt)
        {
            
            if(myThread == Thread.CurrentThread)
            {

                ThreadInterruptedException TIE = null;

                try
                {

                    IsNowWaitingForWake();

                    myWaitSleepEvent.Wait(Timeout);

                }
                catch(ThreadInterruptedException e)
                {

                    IsNotWaitingForWake();

                    TIE = e;

                }
                catch(Exception e)
                {

                    IsNotWaitingForWake();

                    throw e;

                }

                if(TIE != null)
                    OnInterrupt(TIE);

            }
            else
            {

                throw new CannotWaitException(CannotWaitExceptionMessage);

            }

        }

        protected virtual void Sleep(TimeSpan Timeout, CancellationToken TheCancellationToken, Action<ThreadInterruptedException> OnInterrupt)
        {

            if(myThread == Thread.CurrentThread)
            {

                ThreadInterruptedException TIE = null;

                try
                {

                    IsNowWaitingForWake();

                    myWaitSleepEvent.Wait(Timeout, TheCancellationToken);

                }
                catch(ThreadInterruptedException e)
                {

                    IsNotWaitingForWake();

                    TIE = e;

                }
                catch(Exception e)
                {

                    IsNotWaitingForWake();

                    throw e;

                }

                if(TIE != null)
                    OnInterrupt(TIE);

            }
            else
            {

                throw new CannotWaitException(CannotWaitExceptionMessage);

            }

        }

        public void TryExit()
        {

            StopRequested = true;

            WakeOrInterrupt();

        }

        public bool HasDisposed
        {

            get
            {

                return myWaitSleepEvent != null;

            }

        }

        public void Dispose()
        {

            if(!myThread.IsAlive)
            {

                myWaitSleepEvent.Set();

                myWaitSleepEvent.Dispose();

                myWaitSleepEvent = null;

                mySleepEvent.Set();

                mySleepEvent.Dispose();

                mySleepEvent = null;

                myThread = null;

            }
            else
            {

                throw new Exception("The thread cannot be disposed as it is still alive");

            }

        }

    }

}
