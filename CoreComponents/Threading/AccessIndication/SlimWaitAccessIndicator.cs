using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading.AccessIndication
{
    
    public class SlimWaitAccessIndicator
    {

        protected SlimWaitAccessIndicatorInternals myInternals;

        protected SlimWaitAccessHandler myToken;

        protected SpinLock myChangeAccessLock;

        public SlimWaitAccessIndicator()
        {

            Initalise();

        }

        public SlimWaitAccessIndicator(bool Access)
        {

            Initalise();

            if(Access)
                myInternals.SetCurrentThread();

        }

        protected void Initalise()
        {

            myInternals = new SlimWaitAccessIndicatorInternals();

            myToken = new SlimWaitAccessHandler(myInternals);

        }

        public bool IsBeingAccessed
        {

            get
            {

                return myInternals.IsBeingAccessed;

            }

        }

        public bool IsNotBeingAccessed
        {

            get
            {

                return myInternals.IsNotBeingAccessed;

            }

        }

        public bool IsBeingAccessedByThisThead
        {

            get
            {

                return myInternals.IsBeingAccessedByThisThead;

            }

        }

        public bool IsNotBeingAccessedByThisThead
        {

            get
            {

                return myInternals.IsNotBeingAccessedByThisThead;

            }

        }

        public bool TryAccess(out SlimWaitAccessHandler TheAccessHandler)
        {

            bool LockTaken = false;

            try
            {

                myChangeAccessLock.Enter(ref LockTaken);

                if(myInternals.IsNotBeingAccessedAndNotWaiting)
                {

                    myInternals.SetCurrentThread();

                    TheAccessHandler = myToken;

                    return true;

                }

                TheAccessHandler = null;

                return false;

            }
            finally
            {

                if(LockTaken)
                    myChangeAccessLock.Exit();

            }

        }
        
        protected bool TryAccessAfterWait(out SlimWaitAccessHandler TheAccessHandler)
        {

            bool LockTaken = false;

            try
            {

                myChangeAccessLock.Enter(ref LockTaken);

                if(myInternals.IsNotBeingAccessed)
                {

                    myInternals.SetCurrentThread();

                    TheAccessHandler = myToken;

                    return true;

                }

                TheAccessHandler = null;

                return false;

            }
            finally
            {

                if(LockTaken)
                    myChangeAccessLock.Exit();

            }

        }

        public bool TryAccessOrWait(out SlimWaitAccessHandler TheAccessHandler)
        {

            SlimWaitAccessHandler TheCurrentAccessHandler;

            if(TryAccess(out TheCurrentAccessHandler))
            {

                TheAccessHandler = TheCurrentAccessHandler;

                return true;

            }
            else
            {

                myInternals.Wait();
                
                if(TryAccessAfterWait(out TheCurrentAccessHandler))
                {

                    TheAccessHandler = TheCurrentAccessHandler;

                    return true;

                }

            }

            TheAccessHandler = null;

            return false;

        }

        public bool TryAccessOrWait(out SlimWaitAccessHandler TheAccessHandler, CancellationToken TheCancellationToken)
        {

            SlimWaitAccessHandler TheCurrentAccessHandler;

            if(TryAccess(out TheCurrentAccessHandler))
            {

                TheAccessHandler = TheCurrentAccessHandler;

                return true;

            }
            else
            {

                myInternals.Wait(TheCancellationToken);

                if(TryAccessAfterWait(out TheCurrentAccessHandler))
                {

                    TheAccessHandler = TheCurrentAccessHandler;

                    return true;

                }

            }

            TheAccessHandler = null;

            return false;

        }

        public bool TryAccessOrWait(out SlimWaitAccessHandler TheAccessHandler, int TheMillisecondsTimeout)
        {

            SlimWaitAccessHandler TheCurrentAccessHandler;

            if(TryAccess(out TheCurrentAccessHandler))
            {

                TheAccessHandler = TheCurrentAccessHandler;

                return true;

            }
            else
            {

                if(myInternals.Wait(TheMillisecondsTimeout))
                {

                    if(TryAccessAfterWait(out TheCurrentAccessHandler))
                    {

                        TheAccessHandler = TheCurrentAccessHandler;

                        return true;

                    }

                }

            }

            TheAccessHandler = null;

            return false;

        }

        public bool TryAccessOrWait(out SlimWaitAccessHandler TheAccessHandler, TimeSpan TheTimeout)
        {

            SlimWaitAccessHandler TheCurrentAccessHandler;

            if(TryAccess(out TheCurrentAccessHandler))
            {

                TheAccessHandler = TheCurrentAccessHandler;

                return true;

            }
            else
            {

                if(myInternals.Wait(TheTimeout))
                {

                    if(TryAccessAfterWait(out TheCurrentAccessHandler))
                    {

                        TheAccessHandler = TheCurrentAccessHandler;

                        return true;

                    }

                }

            }

            TheAccessHandler = null;

            return false;

        }

        public bool TryAccessOrWait(out SlimWaitAccessHandler TheAccessHandler, int TheTimeout, CancellationToken TheCancellationToken)
        {

            SlimWaitAccessHandler TheCurrentAccessHandler;

            if(TryAccess(out TheCurrentAccessHandler))
            {

                TheAccessHandler = TheCurrentAccessHandler;

                return true;

            }
            else
            {

                myInternals.Wait(TheTimeout, TheCancellationToken);

                if(TryAccessAfterWait(out TheCurrentAccessHandler))
                {

                    TheAccessHandler = TheCurrentAccessHandler;

                    return true;

                }

            }

            TheAccessHandler = null;

            return false;

        }

        public bool TryAccessOrWait(out SlimWaitAccessHandler TheAccessHandler, TimeSpan TheTimeout, CancellationToken TheCancellationToken)
        {

            SlimWaitAccessHandler TheCurrentAccessHandler;

            if(TryAccess(out TheCurrentAccessHandler))
            {

                TheAccessHandler = TheCurrentAccessHandler;

                return true;

            }
            else
            {

                if(myInternals.Wait(TheTimeout, TheCancellationToken))
                {

                    if(TryAccessAfterWait(out TheCurrentAccessHandler))
                    {

                        TheAccessHandler = TheCurrentAccessHandler;

                        return true;

                    }

                }

            }

            TheAccessHandler = null;

            return false;

        }

        public void Reset()
        {

            myInternals.Reset();

        }

        public void Dispose()
        {

            myInternals.Reset();

        } 

    }

}
