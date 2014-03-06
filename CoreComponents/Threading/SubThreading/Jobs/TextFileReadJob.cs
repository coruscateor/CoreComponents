using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using CoreComponents.Threading;
using CoreComponents.Threading.Jobs;

namespace CoreComponents.Threading.SubThreading.Jobs
{
    
    public class TextFileReadJob : HandledJob<TextFileReadJobHandler>
    {

        protected string myFilePath;

        protected ConcurrentQueue<char> myQueue = new ConcurrentQueue<char>();

        protected ConcurrentInputQueueContainer<char> myInputQueue;

        public TextFileReadJob()
        {

            myInputQueue = new ConcurrentInputQueueContainer<char>(myQueue);

            myHandler = new TextFileReadJobHandler(this, myQueue);

        }

        public string FilePath
        {

            get
            {

                return myFilePath;

            }
            set
            {

                if(!IsActive)
                {

                    if(value != null)
                        myFilePath = value;
                    else
                        throw new Exception("The provided value must not be null");

                }
                else
                {

                    throw new Exception("The IsolatedWorkerThread must be inactive to change ther file path.");

                }

            }

        }

        public ConcurrentInputQueueContainer<char> InputQueue
        {

            get
            {

                return myInputQueue;

            }

        }

        protected override void Reset()
        {

            base.Reset();

            myFilePath = null;

        }

    }

}
