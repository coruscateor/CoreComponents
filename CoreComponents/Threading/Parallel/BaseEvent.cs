using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading.Parallel
{

    public abstract class BaseEvent<T> : IDisposable where T : class
    {

        private Exception myException;

        private SpinLock myExceptionSpinLock;

        protected BlockingCollection<T> myItems = new BlockingCollection<T>();

        private Action<T> myAddAction;

        private SpinLock myAddActionSpinLock;

        private Action<T> myRemoveAction;

        private SpinLock myRemoveActionSpinLock;

        public BaseEvent()
        {
        }

        public int BoundedCapacity
        {

            get
            {

                return myItems.BoundedCapacity;

            }

        }

        public int Count
        {

            get
            {

                return myItems.Count;

            }

        }

        public bool IsAddingCompleted
        {

            get
            {

                return myItems.IsAddingCompleted;

            }

        }

        public bool IsCompleted
        {

            get
            {

                return myItems.IsCompleted;

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

        public virtual bool TryAdd(T TheAction)
        {

            try
            {

                return myItems.TryAdd(TheAction);

            }
            finally
            {

                TryExecuteAddAction(TheAction);

            }

        }

        public bool TryTake(out T TheItem)
        {

            T TheItemToTake;

            if(myItems.TryTake(out TheItemToTake))
            {

                TheItem = TheItemToTake;

                TryExecuteRemoveAction(TheItem);

                return true;

            }

            TheItem = null;

            return false;

        }

        public T Take()
        {

            T Item = myItems.Take();

            TryExecuteRemoveAction(Item);

            return Item;

        }

        public bool TryRemove(T TheItem)
        {

            if(myItems.TryTake(out TheItem))
            {

                TryExecuteRemoveAction(TheItem);

                return true;

            }

            return false;

        }

        public void Dispose()
        {

            myItems.Dispose();

        }

    }

}
