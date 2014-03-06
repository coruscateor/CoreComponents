using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading
{

    public abstract class IsolatedThreadWithState : BaseIsolatedTask, ISubThread
    {

        private ConcurrentInputQueueContainer<object> myInputQueueContainer;

        private ConcurrentOutputQueueContainer<object> myOutputQueueContainer;

        private ConcurrentReadOnlyState<string, object> myReadOnlyState;

        private ConcurrentAsynchronousInputOutputWithState<object, object> myThreadIO;

        public IsolatedThreadWithState()
        {

            ConcurrentQueue<object> InputQueue = new ConcurrentQueue<object>();

            ConcurrentQueue<object> OutputQueue = new ConcurrentQueue<object>();

            ConcurrentDictionary<string, object> Dictionary = new ConcurrentDictionary<string, object>();

            myThreadIO = new ConcurrentAsynchronousInputOutputWithState<object, object>(InputQueue, OutputQueue, Dictionary);

            myInputQueueContainer = new ConcurrentInputQueueContainer<object>(InputQueue);

            myOutputQueueContainer = new ConcurrentOutputQueueContainer<object>(OutputQueue);

            myReadOnlyState = new ConcurrentReadOnlyState<string, object>(Dictionary);

        }

        protected IAsynchronousInputOutputWithState<object, object> ThreadIO
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
