using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Processes
{

    public class AsyncronousProcessOutputCacheDelegator : BaseAsyncronousProcessOutputCache, IOutputCacheDelegator
    {

        protected Action<string> myOutputDelegate;

        protected Action<string> myErrorDelegate;

        protected uint myOutputMax = 10;

        protected uint myErrorMax = 10;

        public AsyncronousProcessOutputCacheDelegator()
        { 
        }

        public Action<string> OutputDelegate
        {

            get
            {

                return myOutputDelegate;

            }
            set
            {

                myOutputDelegate = value;

            }

        }

        public Action<string> ErrorDelegate
        {

            get
            {

                return myErrorDelegate;

            }
            set
            {

                myErrorDelegate = value;

            }

        }

        public uint OutputMax
        {

            get
            {

                return myOutputMax;

            }
            set
            {

                myOutputMax = value;

            }

        }

        public uint ErrorMax
        {

            get
            {

                return myErrorMax;

            }
            set
            {

                myErrorMax = value;

            }

        }

        public void FetchOneOutput()
        {

            string Value;

            if(myOutputQueue.TryDequeue(out Value))
                myOutputDelegate(Value);

        }

        public void FetchOneError()
        {

            string Value;

            if(myErrorQueue.TryDequeue(out Value))
                myErrorDelegate(Value);

        }

        public void FetchOutput()
        {

            string Value;

            for (uint i = 0; i < myOutputMax; i++)
            {

                if (myOutputQueue.TryDequeue(out Value))
                    myOutputDelegate(Value);
                else
                    break;

            }

        }

        public void FetchError()
        {

            string Value;


            for (uint i = 0; i < myErrorMax; i++)
            {

                if (myErrorQueue.TryDequeue(out Value))
                    myErrorDelegate(Value);
                else
                    break;

            }

        }

    }

}
