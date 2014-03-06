using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading.Work
{

    public class BaseInputOutputTaskExecutor : BaseIsolatedTask
    {

        protected IInputOutputWorkContainer myInputOutputWorkContainer;

        private Action myExecute;

        private Type myIInputOutputWorkContainerType;

        private IInputQueue<object> myPublicInputQueue;
        
        private IOutputQueue<object> myPublicOutputQueue;
        
        private IInputQueue<object> myInputQueue;
        
        private IOutputQueue<object> myOutputQueue;

        private IReadOnlyState<string, object> myState;

        public BaseInputOutputTaskExecutor(Type TheIInputOutputWorkContainerType, IInputQueue<object> ThePublicInputQueue, IOutputQueue<object> ThePublicOutputQueue, IInputQueue<object> TheInputQueue, IOutputQueue<object> TheOutputQueue, IReadOnlyState<string, object> TheState)
        {

            myExecute = Initalise;

            myIInputOutputWorkContainerType = TheIInputOutputWorkContainerType;

            myPublicInputQueue = ThePublicInputQueue;

            myInputQueue = TheInputQueue;

            myOutputQueue = TheOutputQueue;

            myState = TheState;

        }

        protected void Initalise()
        {

            myInputOutputWorkContainer = Activator.CreateInstance(myIInputOutputWorkContainerType, myPublicInputQueue, myPublicOutputQueue, myInputQueue, myOutputQueue, myState) as IInputOutputWorkContainer;

            myExecute = myInputOutputWorkContainer.Execute;

        }

        protected override void Main()
        {

            myExecute();

        }

        protected void InitaliseWorker()
        {
        }

        public IInputQueue<object> InputQueue
        {

            get
            {

                return myInputOutputWorkContainer.PublicInputQueue;

            }

        }

        public bool HasInputQueue
        {

            get
            {

                return myInputOutputWorkContainer.HasInputQueue;

            }

        }

        public IOutputQueue<object> OutputQueue
        {

            get
            {

                return myInputOutputWorkContainer.PublicOutputQueue;

            }

        }

        public bool HasOutputQueue
        {

            get
            {

                return myInputOutputWorkContainer.HasOutputQueue;

            }

        }

        public IReadOnlyState<string, object> State
        {

            get
            {

                return myInputOutputWorkContainer.PublicState;

            }

        }

        public bool HasState
        {

            get
            {

                return myInputOutputWorkContainer.HasState;

            }

        }

    }

}
