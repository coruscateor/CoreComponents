using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreComponents.Threading
{

    /// <summary>
    /// Incase you don't want to use a queue to pass data between threads.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class GetSet<T>
    {

        T myItem;

        readonly SpinLock mySpinLock = new SpinLock(false);

        readonly bool myUseMemoryBarrier;

        public GetSet(bool useMemoryBarrier = false)
        {

            myUseMemoryBarrier = useMemoryBarrier;

        }

        public GetSet(T item, bool useMemoryBarrier = false)
        {

            myItem = item;

            myUseMemoryBarrier = useMemoryBarrier;

        }

        public T Get()
        {

            bool lockTaken = false;

            try
            {

                mySpinLock.Enter(ref lockTaken);

                return myItem;

            }
            finally
            {

                if(lockTaken)
                    mySpinLock.Exit(myUseMemoryBarrier);

            }

        }

        public bool Get(T previous, Func<T, T, bool> func)
        {

            T item = Get();

            return func(item, previous);

        }

        /// <summary>
        /// Use if reference type
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool TryGet(out T item)
        {

            bool lockTaken = false;

            try
            {

                mySpinLock.Enter(ref lockTaken);

                item = myItem;

            }
            finally
            {

                if(lockTaken)
                    mySpinLock.Exit(myUseMemoryBarrier);

            }

            return item != null;

        }

        public void Set(T item)
        {

            bool lockTaken = false;

            try
            {

                mySpinLock.Enter(ref lockTaken);

                myItem = item;

            }
            finally
            {

                if(lockTaken)
                    mySpinLock.Exit(myUseMemoryBarrier);

            }

        }

        public void SetDefault()
        {

            bool lockTaken = false;

            try
            {

                mySpinLock.Enter(ref lockTaken);

                myItem = default(T);

            }
            finally
            {

                if(lockTaken)
                    mySpinLock.Exit(myUseMemoryBarrier);

            }

        }

        public bool IsNull
        {

            get
            {

                bool lockTaken = false;

                try
                {

                    mySpinLock.Enter(ref lockTaken);

                    return myItem == null;

                }
                finally
                {

                    if(lockTaken)
                        mySpinLock.Exit(myUseMemoryBarrier);

                }

            }

        }

        public bool UseMemoryBarrier
        {

            get
            {

                return myUseMemoryBarrier;

            }

        }

    }

}
