using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace CoreComponents.Processes
{

    public abstract class BaseAsyncronousProcessOutputCache : BaseAsyncronousProcessOutputManager
    {

        protected ConcurrentQueue<string> myOutputQueue = new ConcurrentQueue<string>();

        protected ConcurrentQueue<string> myErrorQueue = new ConcurrentQueue<string>();

        public BaseAsyncronousProcessOutputCache()
        {
        }
        
        protected override void OutputDataReceived(object sender, DataReceivedEventArgs e)
        {

            myOutputQueue.Enqueue(e.Data);

        }

        protected override void ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {

            myErrorQueue.Enqueue(e.Data);

        }

        public int OutputCount
        {

            get
            {

                return myOutputQueue.Count;

            }

        }

        public int ErrorCount
        {

            get
            {

                return myErrorQueue.Count;

            }

        }

        public bool OutputOutputHasEntries
        {

            get
            {

                return myOutputQueue.Count > 0;

            }

        }

        public bool ErrorOutputHasEntries
        {

            get
            {

                return myErrorQueue.Count > 0;

            }

        }

    }

}
