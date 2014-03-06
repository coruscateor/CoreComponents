using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading
{

    public abstract class IsolatedTask : BaseIsolatedTask, ISubThread
    {

        private ConcurrentInputQueueContainer<object> myInputQueueContainer;

        private ConcurrentOutputQueueContainer<object> myOutputQueueContainer;

        private ConcurrentReadOnlyState<string, object> myReadOnlyState;

        private ConcurrentAsynchronousInputOutput<object, object> myThreadIO;

        public IsolatedTask()
        {

            Initalise();

            ConcurrentQueue<object> InputQueue = new ConcurrentQueue<object>();

            ConcurrentQueue<object> OutputQueue = new ConcurrentQueue<object>();

            ConcurrentDictionary<string, object> Dictionary = new ConcurrentDictionary<string,object>();

            myThreadIO = new ConcurrentAsynchronousInputOutput<object, object>(InputQueue, OutputQueue);

            myInputQueueContainer = new ConcurrentInputQueueContainer<object>(InputQueue);

            myOutputQueueContainer = new ConcurrentOutputQueueContainer<object>(OutputQueue);

            myReadOnlyState = new ConcurrentReadOnlyState<string, object>(Dictionary);

        }

        //public IsolatedTask(bool StartNow)
        //    : base(StartNow) 
        //{
        //}

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

        /*

        public IReadOnlyState<string, object> State
        {

            get
            {

                return myReadOnlyState;

            }

        }

        */ 
         
    }

    //public abstract class IsolatedTask<TResult> : BareIsolatedTask<TResult>, ISubThread
    //{

    //    private AsynchronousInputOutput myThreadIO = new AsynchronousInputOutput();

    //    public IsolatedTask()
    //    {

    //        Initalise();

    //    }

    //    //public IsolatedTask(bool StartNow)
    //    //    : base(StartNow)
    //    //{
    //    //}

    //    public IInputQueue<object> Input
    //    {

    //        get
    //        {

    //            return myThreadIO.PublicInput;

    //        }

    //    }

    //    public IOutputQueue<object> Output
    //    {

    //        get
    //        {

    //            return myThreadIO.PublicOutput;

    //        }

    //    }

    //    public IReadOnlyState<string, object> State
    //    {

    //        get
    //        {

    //            return myThreadIO.PublicState;

    //        }

    //    }

    //}

}
