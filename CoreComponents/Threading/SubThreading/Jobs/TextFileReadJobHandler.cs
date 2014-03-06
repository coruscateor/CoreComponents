using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using CoreComponents.Threading.Jobs;

namespace CoreComponents.Threading.SubThreading.Jobs
{

    public class TextFileReadJobHandler : JobHandler<TextFileReadJob>
    {

        protected ConcurrentOutputQueueContainer<char> myOutputQueue;

        public TextFileReadJobHandler(TextFileReadJob TheFileReadJob, ConcurrentQueue<char> TheQueue)
            : base(TheFileReadJob)
        {

            myOutputQueue = new ConcurrentOutputQueueContainer<char>(TheQueue);

        }

        public string FilePath
        {

            get
            {

                return myJob.FilePath;

            }

        }

        public ConcurrentOutputQueueContainer<char> OutputQueue
        {

            get
            {

                return myOutputQueue;

            }

        }

    }

}
