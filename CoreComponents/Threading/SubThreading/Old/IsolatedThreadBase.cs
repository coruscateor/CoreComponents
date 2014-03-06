using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;
using System.Dynamic;

namespace CoreComponents.Threading.SubThreading
{
    //Base class impamentaion for the "isolated thread" pattern.
    //Members in this class are substitute.
    public abstract class IsolatedThreadBase
    {

        private Lazy<ConcurrentQueue<IDictionary<string, object>>> myLazyThreadObjectsInput;

        private Lazy<ConcurrentQueue<IDictionary<string, object>>> myLazyThreadObjectsOuput;

        private Lazy<ConcurrentQueue<string>> myLazyThreadStringInput;

        private Lazy<ConcurrentQueue<string>> myLazyThreadStringOutput;

        private Lazy<ConcurrentDictionary<string, object>> myLazyThreadPublicState;

        private ThreadIO myThreadIO;

        //--

        private Lazy<StringObjectInputQueue> myLazyObjectsInput;

        private Lazy<StringObjectOutputQueue> myLazyObjectsOuput;

        private Lazy<InputQueue<string>> myLazyStringInput;

        private Lazy<OutputQueue<string>> myLazyStringOutput;

        private Lazy<ReadOnlyState<string, object>> myLazyPublicState;

        public IsolatedThreadBase() 
        {

            Initalise();

        }

        public IsolatedThreadBase(IEnumerable<string> TheInitalStringInput)
        {

            Initalise();

            foreach (string AnInputString in TheInitalStringInput) 
            {

                myLazyThreadStringInput.Value.Enqueue(AnInputString);

            }

        }

        public IsolatedThreadBase(IEnumerable<IDictionary<string, object>> TheInitalObjectsInput)
        {

            Initalise();

            foreach (IDictionary<string, object> AnInputObject in TheInitalObjectsInput)
            {

                myLazyThreadObjectsInput.Value.Enqueue(AnInputObject);

            }

        }

        public IsolatedThreadBase(IEnumerable<string> TheInitalStringInput, IEnumerable<IDictionary<string, object>> TheInitalObjectsInput)
        {

            Initalise();

            foreach (string AnInputString in TheInitalStringInput) 
            {

                myLazyThreadStringInput.Value.Enqueue(AnInputString);

            }

            foreach (IDictionary<string, object> AnInputObject in TheInitalObjectsInput) 
            {

                myLazyThreadObjectsInput.Value.Enqueue(AnInputObject);

            }

        }

        private void Initalise() 
        {

            myLazyThreadObjectsInput = new Lazy<ConcurrentQueue<IDictionary<string, object>>>(true);

            myLazyThreadObjectsOuput = new Lazy<ConcurrentQueue<IDictionary<string, object>>>(true);

            myLazyThreadStringInput = new Lazy<ConcurrentQueue<string>>(true);

            myLazyThreadStringOutput = new Lazy<ConcurrentQueue<string>>(true);

            myLazyThreadPublicState = new Lazy<ConcurrentDictionary<string, object>>(true);

            myThreadIO = new ThreadIO(myLazyThreadObjectsInput, myLazyThreadObjectsOuput, myLazyThreadStringInput, myLazyThreadStringOutput, myLazyThreadPublicState);

            //--

            myLazyObjectsInput = new Lazy<StringObjectInputQueue>(delegate() { return new StringObjectInputQueue(myLazyThreadObjectsInput); }, true);

            myLazyObjectsOuput = new Lazy<StringObjectOutputQueue>(delegate() { return new StringObjectOutputQueue(myLazyThreadObjectsOuput); }, true);

            myLazyStringInput = new Lazy<InputQueue<string>>(delegate() { return new InputQueue<string>(myLazyThreadStringInput); }, true);

            myLazyStringOutput = new Lazy<OutputQueue<string>>(delegate() { return new OutputQueue<string>(myLazyThreadStringOutput); }, true);

            myLazyPublicState = new Lazy<ReadOnlyState<string, object>>(delegate() { return new ReadOnlyState<string,object>(myLazyThreadPublicState); }, true);

        }

        protected ThreadIO ThreadIO
        {

            get
            {

                return myThreadIO;

            }

        }

        //--

        public InputQueue<IDictionary<string,object>> ObjectsInput
        {
            get
            {

                return myLazyObjectsInput.Value;

            }

        }

        public OutputQueue<IDictionary<string,object>> ObjectsOuput
        {
            get
            {

                return myLazyObjectsOuput.Value; 

            }

         }

        public InputQueue<string> StringInput
        {
            get
            {

                return myLazyStringInput.Value; 

            }

        }

        public OutputQueue<string> StringOutput
        {
            get
            {

                return myLazyStringOutput.Value;

            }

        }

        public ReadOnlyState<string, object> PublicState
        {

            get
            {

                return myLazyPublicState.Value;

            }

        }

        //Used from outside the main thread
        //public void InputString(ref string TheString)
        //{

        //    myLazyStringInputQueue.Value.Enqueue(TheString);

        //}

        ////Used from outside the main thread
        //public IEnumerator<string> GetInputStringsEnumerator() 
        //{

        //    return myLazyStringInputQueue.Value.GetEnumerator();

        //}

        //protected void GetLatestStringInput(out string TheResult)
        //{
        //    //Might need to wrap this in a spinner aswell
        //    myLazyStringInputQueue.Value.TryPeek(out TheResult);

        //}

        ////Used from inside the main thread
        //protected void OutputString(ref string TheString)
        //{

        //    myLazyStringInputQueue.Value.Enqueue(TheString);

        //}

        ////Used from outside the main thread
        //public IEnumerator<string> GetOutputStringsEnumerator()
        //{

        //    return myLazyStringOutputQueue.Value.GetEnumerator();

        //}

        //public void GetLatestStringOutput(out string TheResult)
        //{
        //    //Might need to wrap this in a spinner aswell
        //    myLazyStringOutputQueue.Value.TryPeek(out TheResult);

        //}

        //public void InputObjects(IDictionary<string, object> TheObjects)
        //{

        //    myLazyObjectsInputQueue.Value.Enqueue(new Dictionary<string, object>(TheObjects));

        //}

        //protected IEnumerator<IDictionary<string, object>> GetOutputObjectsEnumerator()
        //{

        //    return myLazyObjectsOuputQueue.Value.GetEnumerator();

        //}

        //public void GetLatestInputObject(out IDictionary<string, object> TheObject)
        //{

        //    myLazyObjectsInputQueue.Value.TryPeek(out TheObject);

        //}

        //protected void OutputObjects(IDictionary<string, object> TheObjects)
        //{

        //    myLazyObjectsInputQueue.Value.Enqueue(new Dictionary<string, object>(TheObjects));
        //    //myLazyObjectsInputQueue.Value.TryPeek(
        //}

        //public IEnumerator<IDictionary<string, object>> GetInputStringsEnumerator()
        //{

        //    return myLazyObjectsInputQueue.Value.GetEnumerator();

        //}

        //public void GetLatestOutputObject(out IDictionary<string, object> TheObjects)
        //{

        //    myLazyObjectsOuputQueue.Value.TryPeek(out TheObjects);

        //}

        //public void InputObjects(ExpandoObject TheObjects)
        //{

        //    myLazyObjectsInputQueue.Value.Enqueue(new Dictionary<string, object>(TheObjects));

        //}

    }
}
