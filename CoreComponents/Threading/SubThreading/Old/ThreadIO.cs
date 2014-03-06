using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading
{

    //Consolidates the four queues and state dictionary.
    //For the private use of the IsolatedThread types. 
    public class ThreadIO
    {

        private Lazy<ConcurrentQueue<IDictionary<string, object>>> myLazyObjectsInput;

        private Lazy<ConcurrentQueue<IDictionary<string, object>>> myLazyObjectsOutput;

        private Lazy<ConcurrentQueue<string>> myLazyStringInput;

        private Lazy<ConcurrentQueue<string>> myLazyStringOutput;

        private Lazy<ConcurrentDictionary<string, object>> myLazyPublicState;

        public ThreadIO(Lazy<ConcurrentQueue<IDictionary<string, object>>> TheLazyObjectsInput, Lazy<ConcurrentQueue<IDictionary<string, object>>> TheLazyObjectsOuput, Lazy<ConcurrentQueue<string>> TheLazyStringInput, Lazy<ConcurrentQueue<string>> TheLazyStringOutput, Lazy<ConcurrentDictionary<string, object>> TheLazyPublicState)
        {

            myLazyObjectsInput = TheLazyObjectsInput;

            myLazyObjectsOutput = TheLazyObjectsOuput;

            myLazyStringInput = TheLazyStringInput;

            myLazyStringOutput = TheLazyStringOutput;

            myLazyPublicState = TheLazyPublicState;

        }

        public ConcurrentQueue<IDictionary<string, object>> ObjectsInput
        {

            get
            {

                return myLazyObjectsInput.Value;

            }

        }

        public bool ObjectsInputHasBeenUsed
        {

            get
            {

                return myLazyObjectsInput.IsValueCreated;

            }

        }

        public ConcurrentQueue<IDictionary<string, object>> ObjectsOutput
        {

            get
            {

                return myLazyObjectsOutput.Value;

            }

        }

        public bool ObjectsOuputHasBeenUsed
        {

            get
            {

                return myLazyObjectsOutput.IsValueCreated;

            }

        }

        public ConcurrentQueue<string> StringInput
        {

            get
            {

                return myLazyStringInput.Value;

            }

        }

        public bool StringInputHasBeenUsed
        {

            get
            {

                return myLazyStringInput.IsValueCreated;

            }

        }

        public ConcurrentQueue<string> StringOutput
        {

            get
            {

                return myLazyStringOutput.Value;

            }

        }

        public bool StringOutputHasBeenUsed
        {

            get
            {

                return myLazyStringOutput.IsValueCreated;

            }

        }

        public ConcurrentDictionary<string, object> PublicState
        {

            get
            {

                return myLazyPublicState.Value;

            }

        }

        public bool PublicStateHasBeenUsed
        {

            get
            {

                return myLazyPublicState.IsValueCreated;

            }

        }

        //public void ClearsAndState() 
        //{

        //    if (myLazyObjectsInput.IsValueCreated)
        //    {

        //        //myLazyObjectsInput.Value.Clear();

        //    }


        //}

        protected int FlushLazyQueue<T>(Lazy<ConcurrentQueue<T>> TheLazyStringQueue) 
        {

            if (TheLazyStringQueue.IsValueCreated)
            {

                int count = TheLazyStringQueue.Value.Count;

                for (int i = 0; i < count; i++)
                {

                    T dump;

                    TheLazyStringQueue.Value.TryDequeue(out dump);

                }

                return count - 1;

            }

            return 0;

        }

        public int FlushStringInput() 
        {

            return FlushLazyQueue<string>(myLazyStringInput);

        }

        public int FlushStringOutput()
        {

            return FlushLazyQueue<string>(myLazyStringOutput);

        }

        public int FlushObjectsInput()
        {

            return FlushLazyQueue<IDictionary<string, object>>(myLazyObjectsInput);

        }

        public int FlushObjectsOutput()
        {

            return FlushLazyQueue<IDictionary<string, object>>(myLazyObjectsOutput);

        }

        public void FlushQueues() 
        {

            FlushStringInput();

            FlushStringOutput();

            FlushObjectsInput();

            FlushObjectsOutput();

        }

        public void FlushQueuesAndClearPublicState() 
        {

            FlushQueues();

            if (myLazyPublicState.IsValueCreated) 
            {

                myLazyPublicState.Value.Clear();

            }

        }

        public void FlushInput()
        {

            FlushStringInput();

            FlushObjectsInput();

        }

        public void FlushOutput()
        {

            FlushStringOutput();

            FlushObjectsOutput();

        }

    }

}
