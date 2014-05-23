using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading
{
    
    public class MonitorValueContainer<T> : IValueContainer<T>
    {

        protected T myValue;

        protected object myLockObject;

        public MonitorValueContainer()
        {
        }

        public MonitorValueContainer(object TheLockObject)
        {

            myLockObject = TheLockObject;

        }

        public MonitorValueContainer(T TheValue)
        {

            myValue = TheValue;

        }

        public MonitorValueContainer(T TheValue, object TheLockObject)
        {

            myValue = TheValue;

            myLockObject = TheLockObject;

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

    }

}
