using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreComponents.Threading
{

    public sealed class GetPut<T>
    {

        T myItem;

        Guid myId;

        readonly SpinLock mySpinLock;

        readonly bool myUseMemoryBarrier;

        public GetPut(bool useMemoryBarrier = false)
        {

            myUseMemoryBarrier = useMemoryBarrier;

        }

        public GetPut(T item, bool useMemoryBarrier = false)
        {

            myItem = item;

            myUseMemoryBarrier = useMemoryBarrier;

        }

        public Guid CurrentId
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
                        mySpinLock.Exit(myUseMemoryBarrier);

                }

            }

        }

        public bool TryGet(out T item, Guid id)
        {

            bool lockTaken = false;

            try
            {

                mySpinLock.Enter(ref lockTaken);

                if(id != myId)
                {

                    item = myItem;

                    myId = id;

                    return true;

                }

            }
            finally
            {

                if(lockTaken)
                    mySpinLock.Exit(myUseMemoryBarrier);

            }

            item = default(T);

            return false;

        }

        public bool TrySet(T item, Guid id)
        {

            bool lockTaken = false;

            try
            {

                mySpinLock.Enter(ref lockTaken);

                if(id != myId)
                {

                    myItem = item;

                    myId = id;

                    return true;

                }

            }
            finally
            {

                if(lockTaken)
                    mySpinLock.Exit(myUseMemoryBarrier);

            }

            return false;

        }

        public bool WasLast(Guid id)
        {

            bool lockTaken = false;

            try
            {

                mySpinLock.Enter(ref lockTaken);

                return id == myId;

            }
            finally
            {

                if(lockTaken)
                    mySpinLock.Exit(myUseMemoryBarrier);

            }

        }

    }

}
