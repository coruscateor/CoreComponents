using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public sealed class AcquisitionId<TID> : IReset, IDisposable
    {

        TID myId;

        readonly SpinLock mySpinLock;

        public AcquisitionId()
        {
        }

        public AcquisitionId(TID id)
        {

            myId = id;

        }

        public TID Id
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

        public bool IsAcquired
        {

            get
            {

                return object.Equals(Id, default(TID));

            }

        }

        public bool CanAquire
        {

            get
            {

                return !object.Equals(Id, default(TID));

            }

        }

        public bool TryAquire(TID id)
        {

            bool lockTaken = false;

            try
            {

                mySpinLock.Enter(ref lockTaken);

                if(!object.Equals(myId, default(TID)))
                {

                    myId = id;

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

        public bool TryAquire(TID id, Action action)
        {

            if(TryAquire(id))
            {

                using(this)
                    action();

                return true;

            }

            return false;

        }

        public bool TryAquire<TResult>(TID id, Func<TResult> func, out TResult result)
        {

            if(TryAquire(id))
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

                myId = default(TID);

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
