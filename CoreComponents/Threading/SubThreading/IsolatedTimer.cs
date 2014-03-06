using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading
{

    public abstract class IsolatedTimer : BaseIsolatedTimer, ISubThread
    {

        private ConcurrentInputQueueContainer<object> myInputQueueContainer;

        private ConcurrentOutputQueueContainer<object> myOutputQueueContainer;

        private ConcurrentAsynchronousInputOutput<object, object> myThreadIO;

        public IsolatedTimer() : base()
        {
        }

        public IsolatedTimer(int TheDueTime, int ThePeriod, object TheProvidedState = null)
            : base(TheDueTime, ThePeriod, TheProvidedState)
        {

            Initalise();

        }

        public IsolatedTimer(long TheDueTime, long ThePeriod, object TheProvidedState = null)
            : base(TheDueTime, ThePeriod, TheProvidedState)
        {

            Initalise();

        }

        public IsolatedTimer(TimeSpan TheDueTime, TimeSpan ThePeriod, object TheProvidedState = null)
            : base(TheDueTime, ThePeriod, TheProvidedState)
        {

            Initalise();

        }

        public IsolatedTimer(uint TheDueTime, uint ThePeriod, object TheProvidedState = null)
            : base(TheDueTime, ThePeriod, TheProvidedState)
        {

            Initalise();

        }

        private void Initalise()
        {

            ConcurrentQueue<object> InputQueue = new ConcurrentQueue<object>();

            ConcurrentQueue<object> OutputQueue = new ConcurrentQueue<object>();

            ConcurrentDictionary<string, object> Dictionary = new ConcurrentDictionary<string, object>();

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
