using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading.AccessIndication
{

    public class AccessIndicatorInternals : IAccessIndicatorInternals
    {

        public static readonly int NoThread = -1;

        protected int myCurrentThreadId = NoThread;

        protected SpinLock mySpinLock;

        public AccessIndicatorInternals()
        {
        }

        public int CurrentThreadId
        {

            get
            {

                bool LockTaken = true;

                try
                {

                    mySpinLock.Enter(ref LockTaken);

                    return myCurrentThreadId;

                }
                finally
                {

                    if(LockTaken)
                        mySpinLock.Exit();

                }

            }

        }

        public void SetCurrentThread()
        {

            bool LockTaken = true;

            try
            {

                mySpinLock.Enter(ref LockTaken);

                myCurrentThreadId = Thread.CurrentThread.ManagedThreadId;

            }
            finally
            {

                if(LockTaken)
                    mySpinLock.Exit();

            }

        }

        public bool IsNotBeingAccessed
        {

            get
            {

                bool LockTaken = true;

                try
                {

                    mySpinLock.Enter(ref LockTaken);

                    return myCurrentThreadId < 1;

                }
                finally
                {

                    if(LockTaken)
                        mySpinLock.Exit();

                }

            }

        }

        public bool IsBeingAccessedByThisThead
        {

            get
            {

                bool LockTaken = true;

                try
                {

                    mySpinLock.Enter(ref LockTaken);

                    return myCurrentThreadId == Thread.CurrentThread.ManagedThreadId;

                }
                finally
                {

                    if(LockTaken)
                        mySpinLock.Exit();

                }

            }

        }

        public bool IsNotBeingAccessedByThisThead
        {

            get
            {
                
                bool LockTaken = true;

                try
                {

                    mySpinLock.Enter(ref LockTaken);

                    return myCurrentThreadId != Thread.CurrentThread.ManagedThreadId;

                }
                finally
                {

                    if(LockTaken)
                        mySpinLock.Exit();

                }

            }

        }

        public bool IsBeingAccessed
        {

            get
            {

                bool LockTaken = true;

                try
                {

                    mySpinLock.Enter(ref LockTaken);

                    return myCurrentThreadId > 0;

                }
                finally
                {

                    if(LockTaken)
                        mySpinLock.Exit();

                }

            }

        }

        public virtual void Reset()
        {

            myCurrentThreadId = -1;

        }

    }

    public class AccessIndicatorInternals<T> : AccessIndicatorInternals, IAccessIndicatorInternals<T>
    {

        protected T myItem;

        public AccessIndicatorInternals(T TheItem)
        {

            myItem = TheItem;

        }
        
        public T Item
        {

            get
            {

                return myItem;

            }
        
        }
    
    }

}
