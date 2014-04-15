using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public class ConcurrentValueContainer<T> : IValueContainer<T>
    {

        protected T myValue;

        protected SpinLock mySpinlock;

        protected bool myUsesMemoryBarrier;

        public ConcurrentValueContainer()
        {
        }

        public ConcurrentValueContainer(T TheValue)
        {

            myValue = TheValue;

        }

        public ConcurrentValueContainer(bool TheUsesMemoryBarrier)
        {

            myUsesMemoryBarrier = TheUsesMemoryBarrier;

        }

        public ConcurrentValueContainer(T TheValue, bool TheUsesMemoryBarrier)
        {

            myValue = TheValue;

            myUsesMemoryBarrier = TheUsesMemoryBarrier;

        }

        public bool UsesMemoryBarrier
        {

            get
            {

                return myUsesMemoryBarrier;

            }

        }

        public virtual T Value
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    mySpinlock.Enter(ref LockTaken);

                    return myValue;

                }
                finally
                {

                    if(LockTaken)
                        mySpinlock.Exit(myUsesMemoryBarrier);

                }

            }
            set
            {

                bool LockTaken = false;

                try
                {

                    mySpinlock.Enter(ref LockTaken);

                    myValue = value;

                }
                finally
                {

                    if (LockTaken)
                        mySpinlock.Exit(myUsesMemoryBarrier);

                }

            }

        }

    }

}
