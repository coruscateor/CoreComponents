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

        public ConcurrentValueContainer()
        {
        }

        public ConcurrentValueContainer(T TheValue)
        {

            myValue = TheValue;

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
                        mySpinlock.Exit();

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
                        mySpinlock.Exit();

                }

            }

        }

    }

}
