using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading.Parallel
{

    public class WaitHandleRegestered : IDisposable
    {

        protected RegisteredWaitHandle myRWH;

        protected WaitHandle myWaitHandle;

        protected Exception myException;

        protected SpinLock mySpinLock;

        public WaitHandleRegestered()
        {
        }

        public WaitHandleRegestered(RegisteredWaitHandle TheRWH)
        {

            myRWH = TheRWH;

        }

        public WaitHandleRegestered( WaitHandle TheWaitHandle)
        {

            myWaitHandle = TheWaitHandle;

        }

        public WaitHandleRegestered(RegisteredWaitHandle TheRWH, WaitHandle TheWaitHandle)
        {

            myRWH = TheRWH;

            myWaitHandle = TheWaitHandle;

        }

        public RegisteredWaitHandle RegisteredWaitHandle
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    mySpinLock.Enter(ref LockTaken);

                    return myRWH;

                }
                finally
                {

                    if(LockTaken)
                        mySpinLock.Exit();

                }

            }
            set
            {


                bool LockTaken = false;

                mySpinLock.Enter(ref LockTaken);

                myRWH = value;

                if(LockTaken)
                    mySpinLock.Exit();

            }

        }

        public bool HasUnregesteredRWH
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    mySpinLock.Enter(ref LockTaken);

                    return myRWH == null;

                }
                finally
                {

                    if(LockTaken)
                        mySpinLock.Exit();

                }

            }

        }

        public bool TryGetRWH(out RegisteredWaitHandle TheRWH)
        {

            RegisteredWaitHandle RWH = RegisteredWaitHandle;

            if(RWH != null)
            {

                TheRWH = RWH;

                return true;

            }

            TheRWH = null;

            return false;

        }

        public WaitHandle WaitHandle
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    mySpinLock.Enter(ref LockTaken);

                    return myWaitHandle;

                }
                finally
                {

                    if(LockTaken)
                        mySpinLock.Exit();

                }

            }
            set
            {
                
                bool LockTaken = false;

                mySpinLock.Enter(ref LockTaken);

                myWaitHandle = value;

                if(LockTaken)
                    mySpinLock.Exit();

            }

        }

        public bool HasDisposedWH
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    mySpinLock.Enter(ref LockTaken);

                    return myWaitHandle != null;
                
                }
                finally
                {

                    if(LockTaken)
                        mySpinLock.Exit();

                }

            }

        }

        public bool TryGetWH(out WaitHandle TheWH)
        {

            WaitHandle WH = WaitHandle;

            if(WH != null)
            {

                TheWH = WH;

                return true;

            }

            TheWH = null;

            return false;

        }

        public Exception Exception
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    mySpinLock.Enter(ref LockTaken);

                    return myException;

                }
                finally
                {

                    if(LockTaken)
                        mySpinLock.Exit();

                }

            }
            set
            {

                bool LockTaken = false;

                mySpinLock.Enter(ref LockTaken);

                myException = value;

                if(LockTaken)
                    mySpinLock.Exit();

            }

        }

        public bool HasException
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    mySpinLock.Enter(ref LockTaken);

                    return myException != null;

                }
                finally
                {

                    if(LockTaken)
                        mySpinLock.Exit();

                }

            }

        }

        public bool TryGetException(out Exception TheEx)
        {

            Exception Ex = Exception;

            if(Ex != null)
            {

                TheEx = Ex;

                return true;

            }

            TheEx = null;

            return false;

        }

        //Unregesters the semaphore

        public void Unregseter()
        {

            if(myRWH != null)
            {

                myRWH.Unregister(myWaitHandle);

                myRWH = null;

            }

        }

        //Disposes the semaphore

        public void Dispose()
        {

            if(myWaitHandle != null)
            {

                myWaitHandle.Dispose();

                myWaitHandle = null;

            }

        }

        public bool TryGetTypeofWaitHandle(out Type TheType)
        {

            if(myWaitHandle != null)
            {

                TheType = myWaitHandle.GetType();

                return true;

            }

            TheType = null;

            return false;

        }

    }

}
