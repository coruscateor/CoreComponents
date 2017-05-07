using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreComponents.Threading
{

    public sealed class ThreadGetPut<T>
    {

        T myItem;

        int myId;

        readonly SpinLock mySpinLock;

        readonly bool myUseMemoryBarrier;

        public ThreadGetPut(bool useMemoryBarrier = false)
        {

            myUseMemoryBarrier = useMemoryBarrier;

        }

        public ThreadGetPut(T item, bool useMemoryBarrier = false)
        {

            myItem = item;

            myUseMemoryBarrier = useMemoryBarrier;

        }

        public int CurrentId
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

        public bool TryGet(out T item)
        {

            int id = Thread.CurrentThread.ManagedThreadId;

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

        public bool TrySet(T item)
        {

            int id = Thread.CurrentThread.ManagedThreadId;

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

        public bool WasLast()
        {

            int id = Thread.CurrentThread.ManagedThreadId;

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
