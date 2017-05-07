using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading
{

    public sealed class LockVariable<T> : LockBase, IValueContainer<T>, IValueContainer
    {

        T myValue;

        public LockVariable()
            : base()
        {
        }

        public LockVariable(T ThaValue)
            : base()
        {

            myValue = ThaValue;

        }

        public T Value
        {

            get
            {

                lock(myLockObject)
                {

                    return myValue;

                }

            }
            set
            {

                lock(myLockObject)
                {

                    myValue = value;

                }

            }

        }

        object IValueContainer.Value
        {

            get
            {

                lock(myLockObject)
                {

                    return myValue;

                }

            }
            set
            {

                lock(myLockObject)
                {

                    myValue = (T)value;

                }

            }

        }


        object IReadonlyValueContainer.Value
        {

            get
            {

                lock(myLockObject)
                {

                    return myValue;

                }

            }

        }

        public bool HasValue
        {

            get
            {

                lock(myLockObject)
                {

                    return myValue != null;

                }
            
            }

        }

    }

}
