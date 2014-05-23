using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading
{

    public abstract class MonitorIsolatedThread : BaseIsolatedThread, ISubThread
    {

        private MonitorInputQueueContainer<object> myInputQueueContainer;

        private MonitorOutputQueueContainer<object> myOutputQueueContainer;

        private MonitorReadOnlyState<string, object> myReadOnlyState;

        private MonitorAsynchronousInputOutput<object, object> myThreadIO;

        public MonitorIsolatedThread(int TheMaxStackSize = 0) : base(TheMaxStackSize)
        {

            Queue<object> InputQueue = new Queue<object>();

            Queue<object> OutputQueue = new Queue<object>();

            Dictionary<string, object> Dictionary = new Dictionary<string, object>();

            object TheInputLockObject = new object();

            object TheOutputLockObject = new object();

            object TheDictionaryLockObject = new object();

            myThreadIO = new MonitorAsynchronousInputOutput<object, object>(InputQueue, TheInputLockObject, OutputQueue, TheOutputLockObject, Dictionary, TheDictionaryLockObject);

            myInputQueueContainer = new MonitorInputQueueContainer<object>(InputQueue, TheInputLockObject);

            myOutputQueueContainer = new MonitorOutputQueueContainer<object>(OutputQueue, TheOutputLockObject);

            myReadOnlyState = new MonitorReadOnlyState<string, object>(Dictionary, TheDictionaryLockObject);

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
