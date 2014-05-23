using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading
{

    public abstract class MonitorIsolatedTimer : BaseIsolatedTimer, ISubThread
    {

        private MonitorInputQueueContainer<object> myInputQueueContainer;

        private MonitorOutputQueueContainer<object> myOutputQueueContainer;

        private MonitorReadOnlyState<string, object> myReadOnlyState;

        private MonitorAsynchronousInputOutput<object, object> myThreadIO;

        public MonitorIsolatedTimer() : base()
        {
        }

        public MonitorIsolatedTimer(int TheDueTime, int ThePeriod, object TheProvidedState = null)
            : base(TheDueTime, ThePeriod, TheProvidedState)
        {

            Initalise();

        }

        public MonitorIsolatedTimer(long TheDueTime, long ThePeriod, object TheProvidedState = null)
            : base(TheDueTime, ThePeriod, TheProvidedState)
        {

            Initalise();

        }

        public MonitorIsolatedTimer(TimeSpan TheDueTime, TimeSpan ThePeriod, object TheProvidedState = null)
            : base(TheDueTime, ThePeriod, TheProvidedState)
        {

            Initalise();

        }

        public MonitorIsolatedTimer(uint TheDueTime, uint ThePeriod, object TheProvidedState = null)
            : base(TheDueTime, ThePeriod, TheProvidedState)
        {

            Initalise();

        }

        private void Initalise()
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
