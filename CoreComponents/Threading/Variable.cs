using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading
{

    public sealed class Variable : LockBase, IVariable
    {

        object myValue;

        public Variable()
        {
        }

        public Variable(object ThaValue)
        {

            myValue = ThaValue;

        }

        public object Value
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

    }

    public sealed class Variable<T> : LockBase, IVariable<T>
    {

        T myValue;

        public Variable()
        {
        }

        public Variable(T ThaValue)
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

        object IVariable.Value
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

    }

}
