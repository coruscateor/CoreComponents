using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading
{

    public abstract class LockingIsolatedTask : BaseIsolatedTask, ISubThread
    {

        private LockingInputQueueContainer<object> myInputQueueContainer;

        private LockingOutputQueueContainer<object> myOutputQueueContainer;

        private LockingReadOnlyState<string, object> myReadOnlyState;

        private LockingAsynchronousInputOutput<object, object> myThreadIO;

        public LockingIsolatedTask()
        {

            Queue<object> InputQueue = new Queue<object>();

            Queue<object> OutputQueue = new Queue<object>();

            Dictionary<string, object> Dictionary = new Dictionary<string, object>();

            object TheInputLockObject = new object();

            object TheOutputLockObject = new object();

            object TheDictionaryLockObject = new object();

            myThreadIO = new LockingAsynchronousInputOutput<object, object>(InputQueue, TheInputLockObject, OutputQueue, TheOutputLockObject, Dictionary, TheDictionaryLockObject);

            myInputQueueContainer = new LockingInputQueueContainer<object>(InputQueue, TheInputLockObject);

            myOutputQueueContainer = new LockingOutputQueueContainer<object>(OutputQueue, TheOutputLockObject);

            myReadOnlyState = new LockingReadOnlyState<string, object>(Dictionary, TheDictionaryLockObject);

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
