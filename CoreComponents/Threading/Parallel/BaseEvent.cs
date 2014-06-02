using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading.Parallel
{

    public abstract class BaseEvent<T> where T : class
    {

        private Exception myException;

        private SpinLock myExceptionSpinLock;

        private Action<T> myAddAction;

        private SpinLock myAddActionSpinLock;

        private Action<T> myRemoveAction;

        private SpinLock myRemoveActionSpinLock;

        protected MonitorList<T> myItems = new MonitorList<T>();

        public BaseEvent()
        {
        }

        public int Count
        {

            get
            {

                return myItems.Count;

            }

        }

        public Action<T> AddAction
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    myAddActionSpinLock.Enter(ref LockTaken);

                    return myAddAction;

                }
                finally
                {

                    myAddActionSpinLock.Exit();

                }

            }
            set
            {

                bool LockTaken = false;

                try
                {

                    myAddActionSpinLock.Enter(ref LockTaken);

                    myAddAction = value;

                }
                finally
                {

                    myAddActionSpinLock.Exit();

                }

            }

        }

        public bool HasAddAction
        {

            get
            {

                return AddAction != null;

            }

        }

        public bool TryGetAddAction(out Action<T> TheAction)
        {

            Action<T> Item = AddAction;

            if(Item != null)
            {

                TheAction = Item;

                return true;

            }

            TheAction = null;

            return false;

        }

        private void TryExecuteAddAction(T TheAddedAction)
        {

            Action<T> Item = AddAction;

            if(Item != null)
            {

                ThreadPool.QueueUserWorkItem((TheState) =>
                {

                    try
                    {

                        Item(TheAddedAction);

                    }
                    catch(Exception e)
                    {

                        Exception = e;

                    }

                });

            }

        }

        public void TryRemoveAddAction()
        {

            AddAction = null;

        }

        public Action<T> RemoveAction
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    myRemoveActionSpinLock.Enter(ref LockTaken);

                    return myRemoveAction;

                }
                finally
                {

                    myRemoveActionSpinLock.Exit();

                }

            }
            set
            {

                bool LockTaken = false;

                try
                {

                    myRemoveActionSpinLock.Enter(ref LockTaken);

                    myRemoveAction = value;

                }
                finally
                {

                    myRemoveActionSpinLock.Exit();

                }

            }

        }

        public bool HasRemoveAction
        {

            get
            {

                return RemoveAction != null;

            }

        }

        public bool TryGetRemoveAction(out Action<T> TheAction)
        {

            Action<T> Item = RemoveAction;

            if(Item != null)
            {

                TheAction = Item;

                return true;

            }

            TheAction = null;

            return false;

        }

        private void TryExecuteRemoveAction(T TheRemoveAction)
        {

            Action<T> Item = AddAction;

            if(Item != null)
            {

                ThreadPool.QueueUserWorkItem((TheState) =>
                {

                    try
                    {

                        Item(TheRemoveAction);

                    }
                    catch(Exception e)
                    {

                        Exception = e;

                    }

                });

            }

        }

        public void TryRemoveRemoveAction()
        {

            RemoveAction = null;

        }

        public Exception Exception
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    myExceptionSpinLock.Enter(ref LockTaken);

                    return myException;

                }
                finally
                {

                    if(LockTaken)
                        myExceptionSpinLock.Exit();

                }

            }
            protected set
            {

                bool LockTaken = false;

                myExceptionSpinLock.Enter(ref LockTaken);

                myException = value;

                if(LockTaken)
                    myExceptionSpinLock.Exit();

            }

        }

        public bool TryGetException(out Exception TheException)
        {

            bool LockTaken = false;

            myExceptionSpinLock.Enter(ref LockTaken);

            TheException = myException;

            if(LockTaken)
                myExceptionSpinLock.Exit();

            if(TheException == null)
                return false;

            return true;

        }

        public void TryClearException()
        {

            bool LockTaken = false;

            myExceptionSpinLock.Enter(ref LockTaken);

            if(myException != null)
                myException = null;

            if(LockTaken)
                myExceptionSpinLock.Exit();

        }

        public virtual void Add(T TheAction)
        {

            myItems.Add(TheAction);

            TryExecuteAddAction(TheAction);

        }
        
        public virtual bool Remove(T TheItem)
        {

            if(myItems.Remove(TheItem))
            {

                TryExecuteRemoveAction(TheItem);

                return true;

            }

            return false;

        }

    }

}
