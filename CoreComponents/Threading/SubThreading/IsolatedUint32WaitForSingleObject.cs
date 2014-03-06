using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading.SubThreading
{
    
    public abstract class IsolatedUint32WaitForSingleObject  : BaseIsolatedUint32WaitForSingleObject
    {

        private ConcurrentInputQueueContainer<object> myInputQueueContainer;

        private ConcurrentOutputQueueContainer<object> myOutputQueueContainer;

        private ConcurrentReadOnlyState<string, object> myReadOnlyState;

        private ConcurrentAsynchronousInputOutput<object, object> myThreadIO;

        public IsolatedUint32WaitForSingleObject()
        {

            InitaliseUint32IsolatedWaitForSingleObject();

        }

        public IsolatedUint32WaitForSingleObject(uint TheTimeoutInterval) : base(TheTimeoutInterval)
        {

            InitaliseUint32IsolatedWaitForSingleObject();

        }

        public IsolatedUint32WaitForSingleObject(uint TheTimeoutInterval, bool ExecuteOnce)
            : base(TheTimeoutInterval, ExecuteOnce)
        {

            InitaliseUint32IsolatedWaitForSingleObject();

        }

        private void InitaliseUint32IsolatedWaitForSingleObject()
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

        public IReadOnlyState<string, object> State
        {

            get
            {

                return myReadOnlyState;

            }

        }

    }

}
