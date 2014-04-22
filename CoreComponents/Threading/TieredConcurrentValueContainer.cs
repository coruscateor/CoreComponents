using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public class TieredConcurrentValueContainer<T> : ConcurrentValueContainer<T>
    {

        protected object myLockObject;

        public TieredConcurrentValueContainer()
        {

            InitaliseLockObject();

        }
        
        public TieredConcurrentValueContainer(T TheValue)
        {

            myValue = TheValue;

            InitaliseLockObject();

        }

        public TieredConcurrentValueContainer(bool TheUsesMemoryBarrier)
        {

            myUsesMemoryBarrier = TheUsesMemoryBarrier;

            InitaliseLockObject();

        }

        public TieredConcurrentValueContainer(T TheValue, bool TheUsesMemoryBarrier)
        {

            myValue = TheValue;

            myUsesMemoryBarrier = TheUsesMemoryBarrier;

            InitaliseLockObject();

        }

        public TieredConcurrentValueContainer(object TheLockObject)
        {

            myLockObject = TheLockObject;

        }

        public TieredConcurrentValueContainer(T TheValue, object TheLockObject)
        {

            myValue = TheValue;

            myLockObject = TheLockObject;

        }

        public TieredConcurrentValueContainer(bool TheUsesMemoryBarrier, object TheLockObject)
        {

            myUsesMemoryBarrier = TheUsesMemoryBarrier;

            myLockObject = TheLockObject;

        }

        public TieredConcurrentValueContainer(T TheValue, bool TheUsesMemoryBarrier, object TheLockObject)
        {

            myValue = TheValue;

            myUsesMemoryBarrier = TheUsesMemoryBarrier;

            myLockObject = TheLockObject;

        }

        protected void InitaliseLockObject()
        {

            myLockObject = new object();

        }

        public T LockedValue
        {

            get
            {

                lock(myLockObject)
                {

                    return Value;

                }

            }
            set
            {

                lock(myLockObject)
                {

                    Value = value;

                }

            }

        }

        public bool IsEntered
        {

            get
            {

                return Monitor.IsEntered(myLockObject);

            }

        }

        public object LockObject
        {

            get
            {

                return myLockObject;

            }

        }

        public bool TryGetValue(int MillisecondsTimeout, out T TheValue)
        {

            if(Monitor.TryEnter(myLockObject, MillisecondsTimeout))
            {

                TheValue = Value;

                Monitor.Exit(myLockObject);

                return true;

            }

            TheValue = default(T);

            return false;

        }

        public bool TryGetValue(TimeSpan Timeout, out T TheValue)
        {

            if(Monitor.TryEnter(myLockObject, Timeout))
            {

                TheValue = Value;

                Monitor.Exit(myLockObject);

                return true;

            }

            TheValue = default(T);

            return false;

        }

    }

}
