using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading.SubThreading
{
    
    public abstract class WaitForSingleObjectSubThread : BaseWaitForSingleObjectSubThread
    {

        private ConcurrentInputQueueContainer<object> myInputQueueContainer;

        private ConcurrentOutputQueueContainer<object> myOutputQueueContainer;

        private ConcurrentAsynchronousInputOutput<object, object> myThreadIO;

        public WaitForSingleObjectSubThread()
        {

            InitialiseQueues();

        }

        public WaitForSingleObjectSubThread(TimeSpan TheTimespan) : base(TheTimespan)
        {

            InitialiseQueues();

        }

        public WaitForSingleObjectSubThread(bool TheExecuteOnlyOnce) : base(TheExecuteOnlyOnce)
        {

            InitialiseQueues();

        }

        public WaitForSingleObjectSubThread(TimeSpan TheTimespan, bool TheExecuteOnlyOnce) : base(TheTimespan, TheExecuteOnlyOnce)
        {

            InitialiseQueues();

        }

        private void InitialiseQueues()
        {

            ConcurrentQueue<object> InputQueue = new ConcurrentQueue<object>();

            ConcurrentQueue<object> OutputQueue = new ConcurrentQueue<object>();

            myThreadIO = new ConcurrentAsynchronousInputOutput<object, object>(InputQueue, OutputQueue);

            myInputQueueContainer = new ConcurrentInputQueueContainer<object>(InputQueue);

            myOutputQueueContainer = new ConcurrentOutputQueueContainer<object>(OutputQueue);

        }

        protected IAsynchronousInputOutput<object, object> ThreadIO
        {

            get
            {

                return myThreadIO;

            }

        }

        public IInputQueue<object> Input
        {

            get
            {

                return myInputQueueContainer;

            }

        }

        public IOutputQueue<object> Output
        {

            get
            {

                return myOutputQueueContainer;

            }

        }

    }

}
