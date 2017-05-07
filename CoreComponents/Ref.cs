using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents
{

    public sealed class Ref<T> : IReset
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

                myIsSet = true;

            }

        }

        public bool IsSet
        {

            get
            {

                return myIsSet;

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

            if(myIsSet)
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

            myIsSet = false;

        }

    }

}
