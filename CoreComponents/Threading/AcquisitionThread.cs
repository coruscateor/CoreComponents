using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public sealed class AcquisitionThread : IReset, IDisposable
    {

        public const int NoThread = -1;

        int myId = NoThread;

        readonly SpinLock mySpinLock;

        public AcquisitionThread()
        {
        }

        public AcquisitionThread(bool acquired)
        {

            if(acquired)
                myId = Thread.CurrentThread.ManagedThreadId;

        }

        public int Id
        {

            get
            {

                bool lockTaken = false;

                try
                {

                    mySpinLock.Enter(ref lockTaken);

                    return myId;

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

                return Id != NoThread;

            }

        }

        public bool TryAquire()
        {

            bool lockTaken = false;

            try
            {

                mySpinLock.Enter(ref lockTaken);

                if(myId != NoThread)
                {

                    myId = Thread.CurrentThread.ManagedThreadId;

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

                myId = NoThread;

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
