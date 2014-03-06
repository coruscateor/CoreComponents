using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading.AccessIndication
{

    public class AccessIndicator : IAccessIndicator, IReset, IDisposable
    {

        protected AccessIndicatorInternals myInternals;

        protected AccessHandler myToken;

        protected SpinLock myChangeAccessLock;

        public AccessIndicator()
        {

            Initalise();

        }

        public AccessIndicator(bool Access)
        {

            Initalise();

            if(Access)
                myInternals.SetCurrentThread();

        }

        protected void Initalise()
        {

            myInternals = new AccessIndicatorInternals();

            myToken = new AccessHandler(myInternals);

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

        public bool TryAccess(out AccessHandler TheAccessHandler)
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

        public void Reset()
        {

            myInternals.Reset();

        }

        public void Dispose()
        {

            myInternals.Reset();

        }

    }

    public class AccessIndicator<T> : IAccessIndicator<T>, IReset, IDisposable
    {

        protected AccessIndicatorInternals<T> myInternals;

        protected AccessHandler<T> myToken;

        protected SpinLock myChangeAccessLock;

        public AccessIndicator(T TheItem)
        {
            
            Initalise(TheItem);

        }

        public AccessIndicator(T TheItem, bool Access)
        {

            Initalise(TheItem);

            if(Access)
                myInternals.SetCurrentThread();

        }

        protected void Initalise(T TheItem)
        {

            myInternals = new AccessIndicatorInternals<T>(TheItem);

            myToken = new AccessHandler<T>(myInternals);

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

        public bool TryAccess(out AccessHandler<T> TheAccessHandler)
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
