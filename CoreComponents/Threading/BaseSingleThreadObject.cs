using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public abstract class BaseSingleThreadObject
    {

        int myId;

        public BaseSingleThreadObject()
        {

            TryThreadAquire();

        }

        //Probably not thread-safe

        public bool TryThreadAquire()
        {

            int id = Volatile.Read(ref myId);

            if(id > 0)
                return false;

            Volatile.Write(ref myId, Thread.CurrentThread.ManagedThreadId);

            return true;

        }

        //Probably not thread-safe

        public bool TryThreadAquire(int managedThreadId)
        {

            int id = Volatile.Read(ref myId);

            if(id > 0)
                return false;

            Volatile.Write(ref myId, managedThreadId);

            return true;

        }

        public void CheckThread()
        {

            if(ThreadIsCurrent)
                throw new Exception("Object is owned by annother thread");

        }

        public bool ThreadIsCurrent
        {

            get
            {

                return Thread.CurrentThread.ManagedThreadId == Volatile.Read(ref myId);

            }

        }

        public void ReleaseThread()
        {

            int id = Volatile.Read(ref myId);

            if(id == Thread.CurrentThread.ManagedThreadId)
                Volatile.Write(ref myId, -1);

        }

        public bool IsOwnedByThread
        {

            get
            {

                return Volatile.Read(ref myId) == -1;

            }

        }

    }

}
