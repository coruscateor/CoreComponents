using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public class SpinValueContainer<T> : IValueContainer<T>, IUsesMemoryBarrier
    {

        protected T myValue;

        protected SpinLock mySpinlock;

        protected bool myUsesMemoryBarrier;

        public SpinValueContainer()
        {
        }

        public SpinValueContainer(T TheValue)
        {

            myValue = TheValue;

        }

        public SpinValueContainer(bool TheUsesMemoryBarrier)
        {

            myUsesMemoryBarrier = TheUsesMemoryBarrier;

        }

        public SpinValueContainer(T TheValue, bool TheUsesMemoryBarrier)
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
