using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public sealed class NoLockRef<T> : IReset
    {

        T myValue;

        bool myIsSet;

        public T Value
        {

            get
            {

                return myValue;

            }
            set
            {

                myValue = value;

                Volatile.Write(ref myIsSet, true);

            }

        }

        public bool IsSet
        {

            get
            {

                return Volatile.Read(ref myIsSet);

            }

        }

        public bool IsDefualt()
        {

            return EqualityComparer<T>.Default.Equals(myValue, default(T));

        }

        public bool IsDefualt(IEqualityComparer<T> comparer)
        {

            return comparer.Equals(myValue, default(T));

        }

        public bool IsDefualt(Func<T, T, bool> func)
        {

            return func(myValue, default(T));

        }

        public bool TryGet(out T item)
        {

            if(Volatile.Read(ref myIsSet))
            {

                item = myValue;

                return true;

            }

            item = default(T);

            return false;

        }

        public void Reset()
        {

            myValue = default(T);

            Volatile.Write(ref myIsSet, false);

        }

    }

}
