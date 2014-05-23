using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading.AccessIndication
{

    //Say you want access to a resource but you don't want to wait for it.

    //You would rather have your thread doing things rather than sleeping.

    //So you have the AcquisitionQueue where a thread can join a queue to gain access to an object but can do other things in the interim. 


    //When the thread that currently "owns" the object is done using it must call Release() method on the AcquisitionQueue to indicate that it has finished with the object and dequeue the next thread if one is preseant.

    //When this happens the thread that had been accessing the object must "forget" about the reference it had been using to access the object that is the focus of the AcquisitionQueue.

    //This is what I call non-exclusive ownership.

    public class AcquisitionQueue<T> where T : class
    {

        protected ConcurrentQueue<Thread> myQueue;

        protected readonly T myItem;

        //The thread that currely "owns" the item.

        protected Thread myCurrentThread;

        protected SpinLock myCurrentThreadSpinLock;

        public AcquisitionQueue(T TheItem)
        {

            myItem = TheItem;

        }

        public AcquisitionQueue(T TheItem, bool TakeOwnership)
        {

            myItem = TheItem;

            if(TakeOwnership)
                myCurrentThread = Thread.CurrentThread;

        }

        protected Thread CurrentThread
        {

            get
            {

                bool LockTaken = false;

                myCurrentThreadSpinLock.Enter(ref LockTaken);

                try
                {

                    return myCurrentThread;

                }
                finally
                {

                    if(LockTaken)
                        myCurrentThreadSpinLock.Exit();

                }

            }

        }

        public void Join()
        {

            if(myQueue.Count > 0 || !SetCurrentThreadIfNull())
            {

                myQueue.Enqueue(Thread.CurrentThread);

            }

        }

        public bool JoinAndCheck(out T TheItem)
        {

            if(myQueue.Count < 1 && SetCurrentThreadIfNull())
            {

                TheItem = myItem;

                return true;

            }
            else
            {

                myQueue.Enqueue(Thread.CurrentThread);

            }

            TheItem = null;

            return false;

        }

        public bool JoinAndCheck(Action<T> TheAction, bool AutoRelease = true)
        {

            if(myQueue.Count < 1 && SetCurrentThreadIfNull())
            {

                try
                {

                    TheAction(myItem);

                }
                catch
                {

                    if(!AutoRelease)
                        AutoRelease = true;

                }
                finally
                {

                    if(AutoRelease)
                        Release();

                }

                return true;

            }
            else
            {

                myQueue.Enqueue(Thread.CurrentThread);

            }

            return false;

        }

        public bool HasItem()
        {

            return CurrentThread == Thread.CurrentThread;

        }

        public bool Check(out T TheItem)
        {

            if(CurrentThread == Thread.CurrentThread)
            {

                TheItem = myItem;

                return true;

            }

            TheItem = null;

            return false;

        }

        public bool Check(Action<T> TheAction, bool AutoRelease = true)
        {

            if(CurrentThread == Thread.CurrentThread)
            {

                try
                {

                    TheAction(myItem);

                }
                catch
                {

                    if(!AutoRelease)
                        AutoRelease = true;

                }
                finally
                {

                    if(AutoRelease)
                        Release();

                }

                return true;

            }
            else
            {

                myQueue.Enqueue(Thread.CurrentThread);

            }

            return false;

        }

        public bool HasJoined()
        {

            Thread ThisThread = Thread.CurrentThread;

            foreach(var Item in myQueue)
            {

                if(Item == ThisThread)
                    return true;

            }

            return false;

        }
        
        public bool IsCurrentlyOwned
        {

            get
            {

                return CurrentThread != null;

            }

        }

        public int GetCount
        {

            get
            {

                if(CurrentThread != null)
                {

                    unchecked
                    {

                        return myQueue.Count + 1;

                    }

                }

                return myQueue.Count;

            }

        }

        //Call this method when you are done and don't refer the focused object again unless you go though the process to aquire it. 

        public void Release()
        {

            if(CurrentThread == Thread.CurrentThread)
            {

                //We've established that the current thread is the "owner".

                //So there shouldn't be any funny business with the following instructions. 

                Thread NextThread;

                if(myQueue.TryDequeue(out NextThread))
                {

                    bool LockTaken = false;

                    myCurrentThreadSpinLock.Enter(ref LockTaken);

                    myCurrentThread = NextThread;

                    if(LockTaken)
                        myCurrentThreadSpinLock.Exit();

                }
                else
                {

                    bool LockTaken = false;

                    myCurrentThreadSpinLock.Enter(ref LockTaken);

                    myCurrentThread = null;

                    if(LockTaken)
                        myCurrentThreadSpinLock.Exit();

                }

            }

        }

        public bool SetCurrentThreadIfNull()
        {

            bool LockTaken = false;

            Thread ThisThread = Thread.CurrentThread;

            try
            {

                myCurrentThreadSpinLock.Enter(ref LockTaken);

                if(myCurrentThread == null)
                {

                    myCurrentThread = ThisThread;

                    return true;

                }
                else
                {

                    return false;

                }

            }
            finally
            {

                if(LockTaken)
                    myCurrentThreadSpinLock.Exit();

            }

        }

        /*
        protected void SetCurrentThreadIfNotNull(Thread TheNextThread)
        {

            bool LockTaken = false;

            myCurrentThreadSpinLock.Enter(ref LockTaken);

            if(myCurrentThread == null)
                myCurrentThread = Thread.CurrentThread;

            if(LockTaken)
                myCurrentThreadSpinLock.Exit();

        }

        protected void SetCurrentThreadNullIfNotNull()
        {

            bool LockTaken = false;

            myCurrentThreadSpinLock.Enter(ref LockTaken);

            if(myCurrentThread != null)
                myCurrentThread = null;

            if(LockTaken)
                myCurrentThreadSpinLock.Exit();

        }
        */

    }

}
