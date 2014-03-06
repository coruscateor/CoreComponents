using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    [Serializable]
    public class ConcurrentAsynchronousInputOutput<TInput, TOutput> : IAsynchronousInputOutput<TInput, TOutput>
    {

        //private ConcurrentQueue<object> myInput;

        //private ConcurrentQueue<object> myOutput;

        //private ConcurrentDictionary<string, object> myState;

        //private ConcurrentInputQueue<object> myPublicInput;

        //private ConcurrentOutputQueue<object> myPublicOutput;

        //private ReadOnlyState<string, object> myPublicState;

        private ConcurrentQueueContainer<TInput> myConcurrentInputQueue;

        private ConcurrentQueueContainer<TOutput> myConcurrentOutputQueue;

        //private ConcurrentState<string, object> myState;

        //public ConcurrentInputOutput()
        //{

        //    myInput = new ConcurrentQueue<object>();

        //    myOutput = new ConcurrentQueue<object>();

        //    myState = new ConcurrentDictionary<string, object>();

        //    myPublicInput = new ConcurrentInputQueue<object>(myInput);

        //    myPublicOutput = new ConcurrentOutputQueue<object>(myOutput);

        //    myPublicState = new ReadOnlyState<string, object>(myState);

        //}

        public ConcurrentAsynchronousInputOutput()
        {

            myConcurrentInputQueue = new ConcurrentQueueContainer<TInput>(new ConcurrentQueue<TInput>());

            myConcurrentOutputQueue = new ConcurrentQueueContainer<TOutput>(new ConcurrentQueue<TOutput>());

        }

        public ConcurrentAsynchronousInputOutput(ConcurrentQueue<TInput> TheInputQueue, ConcurrentQueue<TOutput> TheOutputQueue) //, ConcurrentDictionary<string, object> TheState)
        {

            myConcurrentInputQueue = new ConcurrentQueueContainer<TInput>(TheInputQueue);

            myConcurrentOutputQueue = new ConcurrentQueueContainer<TOutput>(TheOutputQueue);

            //myState = new ConcurrentState<string, object>(TheState);

        }

        public IInputOutputQueue<TInput> Input
        {

            get
            {

                return myConcurrentInputQueue;

            }

        }

        public IInputOutputQueue<TOutput> Output
        {

            get
            {

                return myConcurrentOutputQueue;

            }

        }

        /*

        public IState<string, object> State
        {

            get
            {

                return myState;

            }

        }

        */ 
         
        //public IInputQueue<object> PublicInput
        //{

        //    get
        //    {

        //        return myPublicInput;

        //    }

        //}

        //public IOutputQueue<object> PublicOutput
        //{

        //    get
        //    {

        //        return myPublicOutput;

        //    }

        //}

        //public IReadOnlyState<string, object> PublicState
        //{

        //    get
        //    {

        //        return myPublicState;

        //    }

        //}

        //protected static int FlushQueue<T>(ConcurrentQueue<T> TheQueue)
        //{

        //    int count = TheQueue.Count;

        //    for (int i = 0; i <= count; i++)
        //    {

        //        T dump;

        //        if (!TheQueue.TryDequeue(out dump))
        //        {

        //            count--;

        //        }

        //    }

        //    return count;

        //}

        //public int FlushInput()
        //{

        //    return FlushQueue<object>(myInput);

        //}

        //public int FlushOutput()
        //{

        //    return FlushQueue<object>(myOutput);

        //}

        //public int FlushQueues()
        //{

        //    return FlushInput() + FlushOutput();

        //}

        //public int FlushQueuesAndClearState()
        //{

        //    int Amount = myState.Count + FlushQueues();

        //    myState.Clear();

        //    return Amount;

        //}
        
        /*

        IInputQueue<object> IAsynchronousInputOutput.Input
        {

            get
            {
                
                return (IInputQueue<object>)myConcurrentInputQueue;
            
            }

        }

        IOutputQueue<object> IAsynchronousInputOutput.Output
        {

            get
            {
                
                return (IOutputQueue<object>)myConcurrentOutputQueue;
            
            }

        }
         
        */ 

    }

}
