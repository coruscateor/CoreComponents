using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading.AccessIndication
{

    public class WaitAccessIndicator : IAccessIndicator //IReset, IDisposable
    {

        protected WaitAccessIndicatorInternals myInternals;

        protected WaitAccessHandler myToken;

        protected SpinLock myChangeAccessLock;

        public WaitAccessIndicator()
        {

            Initalise();

        }

        public WaitAccessIndicator(bool Access)
        {

            Initalise();

            if(Access)
                myInternals.SetCurrentThread();

        }

        protected void Initalise()
        {

            myInternals = new WaitAccessIndicatorInternals();

            myToken = new WaitAccessHandler(myInternals);

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

        //public bool TryAccess(out AccessHandler TheAccessHandler)
        //{
        //    throw new NotImplementedException();
        //}

        public bool TryAccess(out WaitAccessHandler TheAccessHandler)
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
        
        protected bool TryAccessAfterWait(out WaitAccessHandler TheAccessHandler)
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

        public bool TryAccessOrWait(out WaitAccessHandler TheAccessHandler)
        {

            WaitAccessHandler TheCurrentAccessHandler;

            if(TryAccess(out TheCurrentAccessHandler))
            {

                TheAccessHandler = TheCurrentAccessHandler;

                return true;

            }
            else
            {

                if(myInternals.Wait())
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

        public bool TryAccessOrWait(out WaitAccessHandler TheAccessHandler, int TheMillisecondsTimeout)
        {

            WaitAccessHandler TheCurrentAccessHandler;

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

        public bool TryAccessOrWait(out WaitAccessHandler TheAccessHandler, TimeSpan TheTimeout)
        {

            WaitAccessHandler TheCurrentAccessHandler;

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

        public bool TryAccessOrWait(out WaitAccessHandler TheAccessHandler, int TheMillisecondsTimeout, bool TheExitContext)
        {

            WaitAccessHandler TheCurrentAccessHandler;

            if(TryAccess(out TheCurrentAccessHandler))
            {

                TheAccessHandler = TheCurrentAccessHandler;

                return true;

            }
            else
            {

                if(myInternals.Wait(TheMillisecondsTimeout, TheExitContext))
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

        public bool TryAccessOrWait(out WaitAccessHandler TheAccessHandler, TimeSpan TheTimeout, bool TheExitContext)
        {

            WaitAccessHandler TheCurrentAccessHandler;

            if(TryAccess(out TheCurrentAccessHandler))
            {

                TheAccessHandler = TheCurrentAccessHandler;

                return true;

            }
            else
            {

                if(myInternals.Wait(TheTimeout, TheExitContext))
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

    public class WaitAccessIndicator<T> : IAccessIndicator<T> //IReset, IDisposable
    {

        protected WaitAccessIndicatorInternals<T> myInternals;

        protected WaitAccessHandler<T> myToken;

        protected SpinLock myChangeAccessLock;

        public WaitAccessIndicator(T TheItem)
        {

            Initalise(TheItem);

        }

        public WaitAccessIndicator(T TheItem, bool Access)
        {

            Initalise(TheItem);

            if(Access)
                myInternals.SetCurrentThread();

        }

        protected void Initalise(T TheItem)
        {

            myInternals = new WaitAccessIndicatorInternals<T>(TheItem);

            myToken = new WaitAccessHandler<T>(myInternals);

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

        public bool TryAccess(out WaitAccessHandler<T> TheAccessHandler)
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

        protected bool TryAccessAfterWait(out WaitAccessHandler<T> TheAccessHandler)
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

        public bool TryAccessOrWait(out WaitAccessHandler<T> TheAccessHandler)
        {

            WaitAccessHandler<T> TheCurrentAccessHandler;

            if(TryAccess(out TheCurrentAccessHandler))
            {

                TheAccessHandler = TheCurrentAccessHandler;

                return true;

            }
            else
            {

                if(myInternals.Wait())
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

        public bool TryAccessOrWait(out WaitAccessHandler<T> TheAccessHandler, int TheMillisecondsTimeout)
        {

            WaitAccessHandler<T> TheCurrentAccessHandler;

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

        public bool TryAccessOrWait(out WaitAccessHandler<T> TheAccessHandler, TimeSpan TheTimeout)
        {

            WaitAccessHandler<T> TheCurrentAccessHandler;

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

        public bool TryAccessOrWait(out WaitAccessHandler<T> TheAccessHandler, int TheMillisecondsTimeout, bool TheExitContext)
        {

            WaitAccessHandler<T> TheCurrentAccessHandler;

            if(TryAccess(out TheCurrentAccessHandler))
            {

                TheAccessHandler = TheCurrentAccessHandler;

                return true;

            }
            else
            {

                if(myInternals.Wait(TheMillisecondsTimeout, TheExitContext))
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

        public bool TryAccessOrWait(out WaitAccessHandler<T> TheAccessHandler, TimeSpan TheTimeout, bool TheExitContext)
        {

            WaitAccessHandler<T> TheCurrentAccessHandler;

            if(TryAccess(out TheCurrentAccessHandler))
            {

                TheAccessHandler = TheCurrentAccessHandler;

                return true;

            }
            else
            {

                if(myInternals.Wait(TheTimeout, TheExitContext))
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
