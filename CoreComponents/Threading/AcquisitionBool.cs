using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public sealed class AcquisitionBool : IReset, IDisposable
    {

        bool myAcquired;

        readonly SpinLock mySpinLock;

        public AcquisitionBool()
        {
        }

        public AcquisitionBool(bool acquired)
        {

            myAcquired = acquired;

        }

        public bool Acquired
        {

            get
            {

                bool lockTaken = false;

                try
                {

                    mySpinLock.Enter(ref lockTaken);

                    return myAcquired;

                }
                finally
                {

                    if(lockTaken)
                        mySpinLock.Exit();

                }

            }

        }

        public bool CanAcquire
        {

            get
            {

                return !Acquired;

            }

        }

        public bool TryAquire()
        {

            bool lockTaken = false;

            try
            {

                mySpinLock.Enter(ref lockTaken);

                if(!myAcquired)
                {

                    myAcquired = true;

                    return true;

                }

                return false;

            }
            finally
            {

                if(lockTaken)
                    mySpinLock.Exit();

            }

        }

        public bool TryAquire(Action action)
        {

            if(TryAquire())
            {

                using(this)
                    action();

                return true;

            }

            return false;

        }

        public bool TryAquire<TResult>(Func<TResult> func, out TResult result)
        {

            if(TryAquire())
            {

                using(this)
                    result = func();

                return true;

            }

            result = default(TResult);

            return false;

        }

        public void Reset()
        {

            bool lockTaken = false;

            try
            {

                mySpinLock.Enter(ref lockTaken);

                myAcquired = false;

            }
            finally
            {

                if(lockTaken)
                    mySpinLock.Exit();

            }

        }

        public void Dispose()
        {

            Reset();

        }

    }

}
