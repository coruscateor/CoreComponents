using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.IO;
using CoreComponents.Threading.Jobs;

namespace CoreComponents.Threading.SubThreading.Jobs
{

    public class FileIsolatedWorkerThread : BaseIsolatedWorkerThread
    {

        //protected string myFilePath;

        protected ConcurrentQueue<IJob> myWaitingJobQueue = new ConcurrentQueue<IJob>();

        //protected FileIsolatedWorkerThreadJobPool myJobPool = new FileIsolatedWorkerThreadJobPool();

        //protected ConcurrentQueue<TextFileReadJob> myTextFileReadJobPool = new ConcurrentQueue<TextFileReadJob>();

        //protected ConcurrentQueue<TextFileWriteJob> myTextFileWriteJobPool = new ConcurrentQueue<TextFileWriteJob>();

        public FileIsolatedWorkerThread()
        {
        }

        /*
        public FileIsolatedWorkerThread(string TheFilePath)
        {

            myFilePath = TheFilePath;

        }
        */
         
        /*
        public string FilePath
        {

            get
            {

                return myFilePath;

            }
            set
            {

                if(!IsActive)
                    myFilePath = value;
                else
                    throw new Exception("The IsolatedWorkerThread must be inactive to change ther file path.");

            }

        }
        */

        protected override void ThreadMain()
        {
            
            IJob JobValue;

            /*
            if(myWaitingJobQueue.TryDequeue(out JobValue))
                Executejob(JobValue);
            */

            if(myWaitingJobQueue.TryDequeue(out JobValue))
            {

                if(JobValue is TextFileReadJob)
                    Executejob((TextFileReadJob)JobValue);
                else if(JobValue is TextFileWriteJob)
                    Executejob((TextFileWriteJob)JobValue);
                else
                    Executejob(JobValue);

            }

            if(myWaitingJobQueue.Count > 0)
                Continue();

        }

        protected void Executejob(TextFileReadJob TheJob)
        {

            TheJob.Active();

            try
            {

                byte[] StreamBytes = new byte[512];

                Decoder StreamDecoder = Encoding.Default.GetDecoder();

                char[] StreamChars = new char[256];

                using(FileStream OpenFileStream = File.OpenRead(TheJob.FilePath))
                {

                    do
                    {

                        int ReadByteCount = OpenFileStream.Read(StreamBytes, 0, StreamBytes.Length);

                        if(ReadByteCount < 1)
                            break;

                        int DecodedCharCount = StreamDecoder.GetChars(StreamBytes, 0, ReadByteCount, StreamChars, 0);

                        for(int i = 0; i < DecodedCharCount; ++i)
                        {

                            TheJob.InputQueue.Enqueue(StreamChars[i]);

                        }

                    }
                    while(true);

                }

                TheJob.Completed();

            }
            catch(Exception e)
            {

                TheJob.Failed(e);

            }

        }

        protected void Executejob(TextFileWriteJob TheJob)
        {

            TheJob.Active();

            try
            {

                byte[] StreamBytes = new byte[512];

                Encoder StreamEncoder = Encoding.Default.GetEncoder();

                char[] StreamChars = new char[256];

                long TotalBytes = 0;

                using(FileStream OpenFileStream = File.OpenWrite(TheJob.FilePath))
                {

                    while(true)
                    {

                        if(TheJob.OutputQueue.Count < 1)
                        {

                            if(TheJob.FileFinished)
                            {

                                TheJob.Completed();

                                break;

                            }

                            //If waiting is finised quit.

                            if(TheJob.Wait())
                            {

                                if(TheJob.OutputQueue.Count < 1)
                                {

                                    TheJob.Completed();

                                    break;

                                }

                            }

                        }

                        char RetrivedChar;

                        int MaxCharCount = StreamChars.Length - 1;

                        int CurrentCharCount = 0;

                        if(TheJob.OutputQueue.TryDequeue(out RetrivedChar))
                        {

                            StreamChars[CurrentCharCount] = RetrivedChar;

                            ++CurrentCharCount;

                            //if(CurrentCharCount == MaxCharCount)
                            //    break;

                            int CharsUsed;

                            int BytesUsed;

                            bool Completed;

                            StreamEncoder.Convert(StreamChars, 0, CurrentCharCount, StreamBytes, 0, StreamBytes.Length - 1, false, out CharsUsed, out BytesUsed, out Completed);

                            OpenFileStream.Write(StreamBytes, 0, BytesUsed);

                            TotalBytes += BytesUsed;

                            if(!Completed)
                            {

                                //int CharIndex = CharsUsed

                                int CharsUsed2;

                                int BytesUsed2;

                                bool Completed2;

                                StreamEncoder.Convert(StreamChars, CharsUsed - 1, CurrentCharCount, StreamBytes, 0, StreamBytes.Length - 1, false, out CharsUsed2, out BytesUsed2, out Completed2);

                                OpenFileStream.Write(StreamBytes, 0, BytesUsed2);

                                TotalBytes += BytesUsed2;

                            }

                        }

                    }
                    
                    if(OpenFileStream.Length > TotalBytes)
                        OpenFileStream.SetLength(TotalBytes);

                }

            }
            catch(Exception e)
            {

                TheJob.Failed(e);

            }

        }
        
        protected void Executejob(IJob TheJob)
        {

            TheJob.Failed("Unkown job detected");

        }

        public TextFileReadJobHandler ReadText(string TheFilePath)
        {

            //TextFileReadJob Job =  myJobPool.FetchTextFileReadJob();

            TextFileReadJob JobToStart = new TextFileReadJob();

            //if(!myTextFileReadJobPool.TryDequeue(out JobToStart))
            //    JobToStart = new TextFileReadJob();

            JobToStart.FilePath = TheFilePath;

            myWaitingJobQueue.Enqueue(JobToStart);

            Start();

            return JobToStart.Handler;

        }

        public TextFileWriteJobHandler WriteText(string TheFilePath)
        {

            //TextFileWriteJob Job = myJobPool.FetchTextFileWriteJob();

            TextFileWriteJob JobToStart = new TextFileWriteJob(this);

            //if(!myTextFileWriteJobPool.TryDequeue(out JobToStart))
            //    JobToStart = new TextFileWriteJob(this);

            JobToStart.FilePath = TheFilePath;

            myWaitingJobQueue.Enqueue(JobToStart);

            Start();

            return JobToStart.Handler;

        }

        /*
        public class FileIsolatedWorkerThreadJobPool : JobPool
        {

            public FileIsolatedWorkerThreadJobPool()
            {
            }

            public TextFileReadJob FetchTextFileReadJob()
            {

                TextFileReadJob Value;

                if(FetchOut<TextFileReadJob>(out Value))
                    return Value;

                return new TextFileReadJob();

            }

            public TextFileWriteJob FetchTextFileWriteJob()
            {

                TextFileWriteJob Value;

                if(FetchOut<TextFileWriteJob>(out Value))
                    return Value;

                return new TextFileWriteJob((ISubThread)Value);

            }

        }
        */

    }

}
