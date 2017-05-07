using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public sealed class CountDownRef<T> where T : class
    {

        T myRef;

        int myCount;

        SpinLock mySpinLock;

        public CountDownRef()
        {
        }

        public CountDownRef(T @ref, int count)
        {

            if(count > 0)
            {

                myRef = @ref;

                myCount = count;

            }

        }

        public bool Set(T @ref, int count)
        {

            bool lockTaken = false;

            try
            {

                mySpinLock.Enter(ref lockTaken);

                if(count > 0)
                {

                    myRef = @ref;

                    Volatile.Write(ref myCount, count);

                    return true;

                }

            }
            finally
            {

                if(lockTaken)
                    mySpinLock.Exit();

            }

            return false;

        }

        public int Count
        {

            get
            {

                return Volatile.Read(ref myCount);

            }

        }

        public bool TryGet(out T @ref)
        {

            bool lockTaken = false;

            try
            {

                mySpinLock.Enter(ref lockTaken);

                if(Volatile.Read(ref myCount) > 0)
                {

                    @ref = myRef;

                    //Decrement the Count and if it is less than one remove the reference.

                    int result = Interlocked.Decrement(ref myCount);

                    if(result < 1)
                        @ref = null;

                    return true;

                }

            }
            finally
            {

                if(lockTaken)
                    mySpinLock.Exit();

            }

            @ref = null;

            return false;

        }

    }

}
