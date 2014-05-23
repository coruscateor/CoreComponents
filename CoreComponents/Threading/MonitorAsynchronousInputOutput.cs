using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    public class MonitorAsynchronousInputOutput<TInput, TOutput> : IAsynchronousInputOutput<TInput, TOutput>
    {

        //private Queue<object> myInputQueue;

        //private object myInputLockObject;

        //private Queue<object> myOutputQueue;

        //private object myOutputLockObject;

        //private Dictionary<string, object> myDictionary;

        //private object myStateLockObject;

        private MonitorQueueContainer<TInput> myLockingInputQueue;

        private MonitorQueueContainer<TOutput> myLockingOutputQueue;
        
        private MonitorState<string, object> myState;

        //private LockingReadOnlyState<string, object> myReadOnlyState;

        //private LockingInputQueue<object> myPublicInput;

        //private LockingOutputQueue<object> myPublicOutput;

        //private LockingReadOnlyState<string, object> myPublicState;

        //public LockingAsynchronousInputOutput()
        //{

        //    myInputLockObject = new object();

        //    myInputQueue = new Queue<object>();

        //    myOutputLockObject = new object();

        //    myOutputQueue = new Queue<object>();

        //    myStateLockObject = new object();

        //    myDictionary = new Dictionary<string, object>();

        //    myStateLockObject = new LockingState<string, object>(myDictionary, myStateLockObject);

        //    myReadOnlyState = new LockingReadOnlyState<string, object>(myDictionary, myStateLockObject);

        //    myPublicInput = new LockingInputQueue<object>(myInputQueue, myInputLockObject);

        //    myPublicOutput = new LockingOutputQueue<object>(myOutputQueue, myOutputLockObject);

        //}

        public MonitorAsynchronousInputOutput(Queue<TInput> TheInputQueue, object TheInputLockObject, Queue<TOutput> TheOutputQueue, object TheOutputLockObject, Dictionary<string, object> TheDictionary, object TheDictionaryLockObject)
        {

            //myInputLockObject = new object();

            //myInputQueue = new Queue<object>();

            //myOutputLockObject = new object();

            //myOutputQueue = new Queue<object>();

            //myStateLockObject = new object();

            //myDictionary = new Dictionary<string, object>();

            myLockingInputQueue = new MonitorQueueContainer<TInput>(TheInputQueue, TheInputLockObject);

            myLockingOutputQueue = new MonitorQueueContainer<TOutput>(TheOutputQueue, TheOutputLockObject);

            myState = new MonitorState<string, object>(TheDictionary, TheDictionaryLockObject);

            //myStateLockObject = new LockingState<string, object>(myDictionary, myStateLockObject);

            //myReadOnlyState = new LockingReadOnlyState<string, object>(myDictionary, myStateLockObject);

            //myPublicInput = new LockingInputQueue<object>(myInputQueue, myInputLockObject);

            //myPublicOutput = new LockingOutputQueue<object>(myOutputQueue, myOutputLockObject);

        }

        public IInputOutputQueue<TInput> Input
        {

            get
            {

                return myLockingInputQueue;
            
            }

        }

        public IInputOutputQueue<TOutput> Output
        {

            get 
            {

                return myLockingOutputQueue;
            
            }

        }

        public IState<string, object> State
        {

            get
            {

                return myState;
            
            }

        }

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

        //public int FlushInput()
        //{

        //    lock (myInputLockObject)
        //    {

        //        int Count = myInputQueue.Count;

        //        myInputQueue.Clear();

        //        return Count;

        //    }

        //}

        //public int FlushOutput()
        //{

        //    lock (myOutputLockObject)
        //    {

        //        int Count = myOutputQueue.Count;

        //        myOutputQueue.Clear();

        //        return Count;

        //    }
            
        //}

        //public int FlushQueues()
        //{

        //    return FlushInput() + FlushOutput();

        //}

        //public int FlushQueuesAndClearState()
        //{

        //    lock (myStateLockObject)
        //    {

        //        int Count = FlushQueues();

        //        Count += myDictionary.Count;

        //        myDictionary.Clear();

        //        return Count;
                
        //    }

        //}

        /*
        IInputQueue<object> IAsynchronousInputOutput.Input
        {

            get
            {
                
                return (IInputQueue<object>)myLockingInputQueue;
            
            }

        }

        IOutputQueue<object> IAsynchronousInputOutput.Output
        {

            get
            {
                
                return (IOutputQueue<object>)myLockingOutputQueue;
            
            }

        }
        */

    }

}
