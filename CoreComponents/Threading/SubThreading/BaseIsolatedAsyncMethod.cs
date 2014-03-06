using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreComponents.Threading.SubThreading
{

    public abstract class BaseIsolatedAsyncMethod : ISubThread
    {

        private bool myIsActive;

        private SpinLock myIsActiveSpinLock;

        private bool myStopRequested;

        private SpinLock myStopRequestedSpinLock;

        private Exception myException;

        private SpinLock myExceptionSpinlock;

        public BaseIsolatedAsyncMethod()
        {
        }

        public Exception Exception
        {

            get
            {

                bool LockTaken = false;

                myExceptionSpinlock.Enter(ref LockTaken);

                try
                {

                    return myException;

                }
                finally
                {

                    if(LockTaken)
                        myExceptionSpinlock.Exit();

                }

            }

        }

        public void Start()
        {

            if(!IsActive)
            {

                bool LockTaken = false;

                myStopRequestedSpinLock.Enter(ref LockTaken);

                if(myStopRequested)
                    myStopRequested = false;

                if(LockTaken)
                {

                    myStopRequestedSpinLock.Exit();

                    LockTaken = false;

                }

                myIsActiveSpinLock.Enter(ref LockTaken);

                myIsActive = true;

                if(LockTaken)
                    myIsActiveSpinLock.Exit();

                RunThreadMain();

            }

        }

        private async void RunThreadMain()
        {

            if(myException != null)
            {
                
                bool ExceptionLockTaken = false;

                myExceptionSpinlock.Enter(ref ExceptionLockTaken);

                myException = null;

                if(ExceptionLockTaken)
                    myExceptionSpinlock.Exit();

            }

            Task TaskToRun = Task.Run((Action)ThreadMain);

            //try
            //{

            await TaskToRun;

            //}
            //catch(Exception e)
            //{

            //    bool ExceptionLockTaken = false;

            //    myExceptionSpinlock.Enter(ref ExceptionLockTaken);

            //    myException = e; ;

            //    if(ExceptionLockTaken)
            //        myExceptionSpinlock.Exit();

            //}

            if(TaskToRun.IsFaulted)
            {

                bool ExceptionLockTaken = false;

                myExceptionSpinlock.Enter(ref ExceptionLockTaken);

                myException = TaskToRun.Exception;

                if(ExceptionLockTaken)
                    myExceptionSpinlock.Exit();

            }

            bool LockTaken = false;

            myIsActiveSpinLock.Enter(ref LockTaken);

            myIsActive = false;

            if(LockTaken)
                myIsActiveSpinLock.Exit();
            

        }

        protected abstract void ThreadMain();

        public bool IsActive
        {

            get
            {

                bool LockTaken = false;

                myIsActiveSpinLock.Enter(ref LockTaken);

                try
                {

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

            if(IsActive)
            {

                bool LockTaken = false;

                myStopRequestedSpinLock.Enter(ref LockTaken);

                myStopRequested = true;

                if(LockTaken)
                    myStopRequestedSpinLock.Exit();

            }

        }

        public bool StopRequested
        {

            get
            {

                bool LockTaken = false;

                myStopRequestedSpinLock.Enter(ref LockTaken);

                try
                {

                    return myStopRequested;

                }
                finally
                {

                    if(LockTaken)
                        myStopRequestedSpinLock.Exit();

                }

            }

        }

    }

}
