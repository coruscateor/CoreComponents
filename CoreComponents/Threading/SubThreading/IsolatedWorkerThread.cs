using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading
{
    
    public abstract class IsolatedWorkerThread : BaseIsolatedWorkerThread
    {

        private ConcurrentInputQueueContainer<object> myInputQueueContainer;

        private ConcurrentOutputQueueContainer<object> myOutputQueueContainer;

        private ConcurrentAsynchronousInputOutput<object, object> myThreadIO;

        public IsolatedWorkerThread()
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
