using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using CoreComponents.Threading;
using CoreComponents.Threading.Jobs;

namespace CoreComponents.Threading.SubThreading.Jobs
{

    public class TextFileWriteJobHandler : JobHandler<TextFileWriteJob>, ITextWriteJobHandler, IDisposable
    {

        protected ConcurrentInputQueueSubThreadContainer<char> myInputQueue;

        public TextFileWriteJobHandler(TextFileWriteJob TheFileWriteJob, ConcurrentQueue<char> TheQueue, ISubThread TheSubThread)
            : base(TheFileWriteJob)
        {

            myInputQueue = new ConcurrentInputQueueSubThreadContainer<char>(TheQueue, TheSubThread);

        }

        public string FilePath
        {

            get
            {

                return myJob.FilePath;

            }

        }

        public ConcurrentInputQueueSubThreadContainer<char> InputQueue
        {

            get
            {

                return myInputQueue;

            }

        }

        public void Input(string TheValue)
        {

            if(TheValue.Length > 0)
            {

                foreach(var Item in TheValue)
                {

                    myInputQueue.Enqueue(Item);

                }

            }

        }

        public void InputAndCheck(string TheValue)
        {

            foreach(var Item in TheValue)
            {

                myInputQueue.EnqueueAndCheck(Item);

            }

        }

        public bool FileFinished
        {

            get
            {

                return myJob.FileFinished;

            }

        }

        public void FileIsFinished()
        {

            myJob.FileIsFinished();

        }

        public void Dispose()
        {

            myJob.Dispose();

        }
    }

}
