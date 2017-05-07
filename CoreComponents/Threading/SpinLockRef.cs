using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public sealed class SpinLockRef<T> : IValueContainer<T>, IValueContainer, IReset
    {

        T myValue;

        readonly SpinLock mySpinLock;

        readonly bool myUseMemoryBarrier;

        readonly IEqualityComparer<T> myEqualityComparer;

        bool myIsSet;

        public SpinLockRef(bool useMemoryBarrier = true)
        {

            myUseMemoryBarrier = useMemoryBarrier;

            myEqualityComparer = EqualityComparer<T>.Default;

        }

        public SpinLockRef(IEqualityComparer<T> equalityComparer)
        {

            myEqualityComparer = equalityComparer;

            myUseMemoryBarrier = true;

        }

        public T Value
        {

            get
            {

                bool lockTaken = false;

                try
                {

                    mySpinLock.Enter(ref lockTaken);

                    return myValue;

                }
                finally
                {

                    if(lockTaken)
                        mySpinLock.Exit(myUseMemoryBarrier);

                }

            }
            set
            {

                bool lockTaken = false;

                try
                {

                    mySpinLock.Enter(ref lockTaken);

                    myValue = value;

                    myIsSet = true;

                }
                finally
                {

                    if(lockTaken)
                        mySpinLock.Exit(myUseMemoryBarrier);

                }

            }

        }

        public bool IsDefault
        {

            get
            {

                return myEqualityComparer.Equals(Value, default(T));

            }

        }

        object IReadonlyValueContainer.Value
        {

            get
            {

                return Value;

            }

        }

        T IReadonlyValueContainer<T>.Value
        {

            get
            {

                return Value;

            }

        }

        object IValueContainer.Value
        {

            get
            {

                return Value;

            }
            set
            {

                Value = (T)value;

            }

        }

        public bool UseMemoryBarrier
        {

            get
            {

                return myUseMemoryBarrier;

            }

        }

        public bool IsSet
        {

            get
            {

                bool lockTaken = false;

                try
                {

                    mySpinLock.Enter(ref lockTaken);

                    return myIsSet;

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

            bool lockTaken = false;

            try
            {

                mySpinLock.Enter(ref lockTaken);

                if(myIsSet)
                {

                    item = myValue;

                    return true;

                }

                item = default(T);

                return false;

            }
            finally
            {

                if(lockTaken)
                    mySpinLock.Exit(myUseMemoryBarrier);

            }

        }

        public void Reset()
        {

            bool lockTaken = false;

            try
            {

                mySpinLock.Enter(ref lockTaken);

                myValue = default(T);

                myIsSet = false;

            }
            finally
            {

                if(lockTaken)
                    mySpinLock.Exit(myUseMemoryBarrier);

            }

        }

    }

}
