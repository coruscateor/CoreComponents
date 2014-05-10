using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading.SubThreading
{
    
    public abstract class IsolatedInt64WaitForSingleObject : BaseIsolatedInt64WaitForSingleObject
    {

        private ConcurrentInputQueueContainer<object> myInputQueueContainer;

        private ConcurrentOutputQueueContainer<object> myOutputQueueContainer;

        private ConcurrentReadOnlyState<string, object> myReadOnlyState;

        private ConcurrentAsynchronousInputOutput<object, object> myThreadIO;

        public IsolatedInt64WaitForSingleObject()
        {

            InitaliseInt64IsolatedWaitForSingleObject();

        }

        public IsolatedInt64WaitForSingleObject(int TheTimeoutInterval) : base(TheTimeoutInterval)
        {

            InitaliseInt64IsolatedWaitForSingleObject();

        }

        public IsolatedInt64WaitForSingleObject(int TheTimeoutInterval, bool ExecuteOnce)
            : base(TheTimeoutInterval, ExecuteOnce)
        {

            InitaliseInt64IsolatedWaitForSingleObject();

        }

        private void InitaliseInt64IsolatedWaitForSingleObject()
        {

            ConcurrentQueue<object> InputQueue = new ConcurrentQueue<object>();

            ConcurrentQueue<object> OutputQueue = new ConcurrentQueue<object>();

            myThreadIO = new ConcurrentAsynchronousInputOutput<object, object>(InputQueue, OutputQueue);

            myInputQueueContainer = new ConcurrentInputQueueContainer<object>(InputQueue);

            myOutputQueueContainer = new ConcurrentOutputQueueContainer<object>(OutputQueue);

            myReadOnlyState = new ConcurrentReadOnlyState<string, object>(new ConcurrentDictionary<string, object>());

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
