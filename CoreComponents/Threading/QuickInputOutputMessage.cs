using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public class QuickInputOutputMessage<TInput, TOutput>
    {

        protected TInput myInput;

        protected bool myInputSet;

        protected TOutput myOutput;

        protected bool myOutputSet;

        protected SpinLock myOutputSpinLock;

        protected bool myUseMemoryBarrier;

        public QuickInputOutputMessage()
        {
        }

        public QuickInputOutputMessage(TInput TheInput)
        {

            myInput = TheInput;

        }

        public void SetInput(TInput TheInput)
        {

            if(!myInputSet)
            {

                myInput = TheInput;

                myInputSet = true;

            }
            else
            {

                throw new Exception("The input has been set");

            }

        }

        public bool TrySetInput(TInput TheInput)
        {

            if(!myInputSet)
            {

                myInput = TheInput;

                myInputSet = true;

                return true;

            }

            return false;

        }

        public TInput Input
        {

            get
            {

                return myInput;

            }

        }

        public bool InputSet
        {

            get
            {

                return myInputSet;

            }

        }

        public TOutput Output
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    myOutputSpinLock.Enter(ref LockTaken);

                    return myOutput;

                }
                finally
                {

                    myOutputSpinLock.Exit(myUseMemoryBarrier);

                }

            }
            set
            {

                bool LockTaken = false;

                myOutputSpinLock.Enter(ref LockTaken);

                myOutput = value;

                myOutputSet = true;

                myOutputSpinLock.Exit(myUseMemoryBarrier);

            }

        }

        public bool OutputSet
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    myOutputSpinLock.Enter(ref LockTaken);

                    return myOutputSet;

                }
                finally
                {

                    myOutputSpinLock.Exit(myUseMemoryBarrier);

                }

            }

        }

        public bool TryGetOutput(out TOutput TheOutput)
        {

            bool LockTaken = false;

            try
            {

                myOutputSpinLock.Enter(ref LockTaken);

                TheOutput = myOutput;

                return myOutputSet;

            }
            finally
            {

                myOutputSpinLock.Exit(myUseMemoryBarrier);

            }

        }

        public void Reset()
        {

            if(myInputSet)
            {

                myInput = default(TInput);

                Output = default(TOutput);

                myInputSet = false;

                myOutputSet = false;

            }

        }

        public void Reset(TInput TheInput)
        {

            if(myInputSet)
            {

                myInput = TheInput;

                Output = default(TOutput);

                myInputSet = false;

                myOutputSet = false;

            }

        }

    }

}
