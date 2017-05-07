using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public sealed class SpinLockVariable<T> : IValueContainer<T>, IValueContainer
    {

        T myValue;

        readonly SpinLock mySpinLock;

        readonly bool myUseMemoryBarrier;

        readonly IEqualityComparer<T> myEqualityComparer;

        public SpinLockVariable(bool useMemoryBarrier = true)
        {

            myUseMemoryBarrier = useMemoryBarrier;

            myEqualityComparer = EqualityComparer<T>.Default;

        }

        public SpinLockVariable(IEqualityComparer<T> equalityComparer)
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


        public bool TryGet(out T item)
        {

            T value = Value;

            if(!myEqualityComparer.Equals(value, default(T)))
            {

                item = value;

                return true;

            }

            item = default(T);

            return false;

        }

    }

}
