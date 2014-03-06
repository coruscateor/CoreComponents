using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading.SubThreading
{

    [Infrastructure]
    public class IsolatedWaitForSingleObjectComponents<TTimeoutInterval>
    {

        private bool myIsActive;

        private SpinLock myIsActiveSpinLock;

        private RegisteredWaitHandle myRegisteredWaitHandle;

        private SpinLock myRegisteredWaitHandleSpinLock;

        private Semaphore mySemaphore;

        private bool myExecuteOnlyOnce;

        private TTimeoutInterval myTimeoutInterval;

        private Action myThreadMain;

        private Func<RegisteredWaitHandle> myRegisterWaitForSingleObject;

        private bool myStopRequeseted;

        private SpinLock myStopRequesetedSpinLock;

        public IsolatedWaitForSingleObjectComponents(Action TheThreadMain, Func<RegisteredWaitHandle> TheRegisterWaitForSingleObject)
        {

            mySemaphore = new Semaphore(1, 1);

            myThreadMain = TheThreadMain;

            myRegisterWaitForSingleObject = TheRegisterWaitForSingleObject;

        }

        public Semaphore Semaphore
        {

            get
            {

                return mySemaphore;

            }

        }

        public bool ExecuteOnlyOnce
        {

            get
            {

                return myExecuteOnlyOnce;

            }
            set
            {
                
                if(IsActive)
                    throw new Exception("IsolatedWaitForSingleObject is still active");

                myExecuteOnlyOnce = value;

            }

        }

        public TTimeoutInterval TimeoutInterval
        {

            get
            {

                return myTimeoutInterval;

            }
            set
            {

                if(IsActive)
                    throw new Exception("IsolatedWaitForSingleObject is still active");

                myTimeoutInterval = value;

            }

        }

        public void Start()
        {

            if(IsActive)
                return;

            bool LockTaken = false;

            myStopRequesetedSpinLock.Enter(ref LockTaken);

            if(myStopRequeseted)
                myStopRequeseted = false;

            if(LockTaken)
            {

                myStopRequesetedSpinLock.Exit();

                LockTaken = false;

            }

            myIsActiveSpinLock.Enter(ref LockTaken);

            myIsActive = true;

            if(LockTaken)
            {

                myIsActiveSpinLock.Exit();

                LockTaken = false;

            }

            if(myRegisteredWaitHandle != null)
            {

                myRegisteredWaitHandle.Unregister(mySemaphore);

            }

            myRegisteredWaitHandle = myRegisterWaitForSingleObject();

        }

        public void Run(object TheState, bool HasTimedOut)
        {

            bool LockTaken = false;

            if(!HasTimedOut)
            {

                RegisteredWaitHandle RWaitHandle = null;

                myRegisteredWaitHandleSpinLock.Enter(ref LockTaken);

                try
                {

                    if(myRegisteredWaitHandle != null)
                    {

                        RWaitHandle = myRegisteredWaitHandle;

                        myRegisteredWaitHandle = null;

                    }
                    else
                    {

                        return;

                    }

                }
                finally
                {

                    if(LockTaken)
                        myRegisteredWaitHandleSpinLock.Exit();

                }

                RWaitHandle.Unregister(mySemaphore);

                return;

            }

            myThreadMain();

            myRegisteredWaitHandleSpinLock.Enter(ref LockTaken);

            RegisteredWaitHandle RWH = myRegisteredWaitHandle;

            myRegisteredWaitHandle = null;

            if(LockTaken)
                myRegisteredWaitHandleSpinLock.Exit();

            RWH.Unregister(mySemaphore);

        }

        public bool IsActive
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    myIsActiveSpinLock.Enter(ref LockTaken);

                    return myIsActive;

                }
                finally
                {

                    if(LockTaken)
                        myIsActiveSpinLock.Exit();

                }

            }

        }

        public void Stop()
        {

            bool LockTaken = false;

            myRegisteredWaitHandleSpinLock.Enter(ref LockTaken);

            RegisteredWaitHandle RWH = myRegisteredWaitHandle;

            if(LockTaken)
            {

                myRegisteredWaitHandleSpinLock.Exit();

                LockTaken = false;

            }

            if(RWH != null)
            {

                myRegisteredWaitHandleSpinLock.Enter(ref LockTaken);

                myRegisteredWaitHandle = null;

                if(LockTaken)
                {

                    myRegisteredWaitHandleSpinLock.Exit();

                    LockTaken = false;

                }

                RWH.Unregister(mySemaphore);

                myIsActiveSpinLock.Enter(ref LockTaken);

                myIsActive = false;

                if(LockTaken)
                    myIsActiveSpinLock.Exit();

            }

        }

        public bool StopRequested
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    myStopRequesetedSpinLock.Enter(ref LockTaken);

                    return myStopRequeseted;

                }
                finally
                {

                    if(LockTaken)
                        myStopRequesetedSpinLock.Exit();

                }

            }

        }

    }

}
