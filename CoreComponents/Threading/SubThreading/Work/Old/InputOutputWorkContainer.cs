using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading.Work
{

    public abstract class InputOutputWorkContainer : IInputOutputWorkContainer
    {

        private IInputQueue<object> myInputQueue;

        private IOutputQueue<object> myOutputQueue;

        private IReadOnlyState<string, object> myState;

        public InputOutputWorkContainer(IInputQueue<object> TheInputQueue, IOutputQueue<object> TheOutputQueue, IReadOnlyState<string, object> TheState)
        {

            myInputQueue = TheInputQueue;

            myOutputQueue = TheOutputQueue;

            myState = TheState;

        }

        public IInputQueue<object> InputQueue
        {

            get
            {

                return myInputQueue;

            }

        }

        public bool HasInputQueue
        {

            get
            {

                return myInputQueue != null;

            }

        }

        public IOutputQueue<object> OutputQueue
        {

            get
            {

                return myOutputQueue;

            }

        }

        public bool HasOutputQueue
        {

            get
            {

                return myOutputQueue != null;

            }

        }

        public IReadOnlyState<string, object> State
        {

            get
            {

                return myState;
            
            }

        }

        public bool HasState
        {

            get 
            {

                return myState != null;
            
            }

        }

        //public void Execute(object TheInput)
        //{

        //    myInputQueue.Enqueue(TheInput);

        //    Execute();

        //}

        //public void Execute(IEnumerable<object> TheInput)
        //{

        //    myInputQueue.Enqueue(TheInput);

        //    Execute();

        //}

        public abstract void Execute();
        
    }

}
