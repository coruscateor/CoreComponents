using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;
using CoreComponents.Threading;
using CoreComponents.Threading.Jobs;

namespace CoreComponents.Threading.SubThreading.Jobs
{
    
    public class TextFileWriteJob : HandledJob<TextFileWriteJobHandler>, IDisposable
    {

        protected string myFilePath;

        protected ConcurrentQueue<char> myQueue = new ConcurrentQueue<char>();

        protected ConcurrentOutputQueueContainer<char> myOutputQueue;

        protected SemaphoreSlim mySemaphore;

        protected bool myFileFinished;

        protected SpinLock myFileFinishedSpinLock;

        public TextFileWriteJob(ISubThread TheSubThread)
        {

            myOutputQueue = new ConcurrentOutputQueueContainer<char>(myQueue);

            myHandler = new TextFileWriteJobHandler(this, myQueue, TheSubThread);

            mySemaphore = new SemaphoreSlim(1, 1);

        }

        public string FilePath
        {

            get
            {

                return myFilePath;

            }
            set
            {

                if(!IsActive)
                {

                    if(value != null)
                        myFilePath = value;
                    else
                        throw new Exception("The provided value must not be null");

                }
                else
                {

                    throw new Exception("The IsolatedWorkerThread must be inactive to change ther file path.");

                }

            }

        }

        public ConcurrentOutputQueueContainer<char> OutputQueue
        {

            get
            {

                return myOutputQueue;

            }

        }

        protected override void Reset()
        {

            base.Reset();

            if(myFilePath != null)
                myFilePath = null;

            bool LockTaken = false;

            try
            {

                myFileFinishedSpinLock.Enter(ref LockTaken);

                myFileFinished = false;

            }
            finally
            {

                if(LockTaken)
                    myFileFinishedSpinLock.Exit();

            }

            if(mySemaphore == null)
                mySemaphore = new SemaphoreSlim(1, 1);

        }

        public bool Wait()
        {

            WaitingForInput();

            mySemaphore.Wait();

            Active();

            return FileFinished;

        }

        public void WakeIfWaiting()
        {

            if(IsWaitingForInput)
            {

                mySemaphore.Release();

            }

        }

        public bool FileFinished
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    myFileFinishedSpinLock.Enter(ref LockTaken);

                    return myFileFinished;

                }
                finally
                {

                    if(LockTaken)
                        myFileFinishedSpinLock.Exit();

                }

            }

        }

        public void FileIsFinished()
        {

            bool LockTaken = false;

            try
            {

                myFileFinishedSpinLock.Enter(ref LockTaken);

                myFileFinished = true;

            }
            finally
            {

                if(LockTaken)
                    myFileFinishedSpinLock.Exit();

            }

            WakeIfWaiting();

        }


        public void Dispose()
        {

            mySemaphore.Dispose();

            mySemaphore = null;

        }

    }

}
