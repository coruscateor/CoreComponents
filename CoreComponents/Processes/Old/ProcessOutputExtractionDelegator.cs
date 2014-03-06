using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Processes
{

    public class ProcessOutputExtractionDelegator : BaseProcessOutputExtractior, IOutputCacheDelegator
    {

        protected Action<string> myOutputDelegate;

        protected Action<string> myErrorDelegate;

        protected uint myOutputMax = 10;

        protected uint myErrorMax = 10;

        public ProcessOutputExtractionDelegator()
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

            myOutputStreamExtractor.ReadLine(myOutputDelegate);

        }

        public void FetchOneError()
        {

            myErrorStreamExtractor.ReadLine(myErrorDelegate);

        }

        public void FetchOutput()
        {

            myOutputStreamExtractor.ReadAllLines(myOutputDelegate);

        }

        public void FetchError()
        {

            myErrorStreamExtractor.ReadAllLines(myErrorDelegate);

        }
    }

}
