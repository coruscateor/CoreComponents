using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace CoreComponents.Processes
{

    public class AsyncronousProcessOutputReader : IProcessOuputReader
    {

        protected ConcurrentQueue<string> myOutputQueue = new ConcurrentQueue<string>();

        protected Process myProcess;

        protected ProcessManager myProcessManager;

        protected AsyncronousProcessOutputType myAsyncronousProcessOutputType;

        protected Lazy<Queue<string>> myLazyQueue = new Lazy<Queue<string>>();

        protected Lazy<StringBuilder> myLazySB = new Lazy<StringBuilder>();

        protected bool myIsEngaged;

        public AsyncronousProcessOutputReader(ProcessManager TheProcessManager, Process TheProcess, AsyncronousProcessOutputType TheAsyncronousProcessOutputType = AsyncronousProcessOutputType.Output)
        {

            myProcessManager = TheProcessManager;

            myProcess = TheProcess;

            myAsyncronousProcessOutputType = TheAsyncronousProcessOutputType;

            EngageProcess();

        }

        public bool IsEngaged
        {

            get
            {

                return myIsEngaged;

            }
            set 
            {

                if (myIsEngaged != value)
                {

                    myIsEngaged = value;

                    if (myIsEngaged)
                    {

                        DisEngageProcess();

                    }
                    else
                    {

                        EngageProcess();

                    }

                }

            }
 
        }

        public void Engage()
        {

            if (!myIsEngaged)
            {

                EngageProcess();

                myIsEngaged = true;

            }

        }

        public void DisEngage()
        {

            if (myIsEngaged)
            {

                DisEngageProcess();

                myIsEngaged = false;

            }

        }

        protected void EngageProcess()
        {

            if (myAsyncronousProcessOutputType == AsyncronousProcessOutputType.Output)
            {

                myProcess.OutputDataReceived += OutputDataReceived;

            }
            else if (myAsyncronousProcessOutputType == AsyncronousProcessOutputType.Error)
            {

                myProcess.ErrorDataReceived += OutputDataReceived;

            }

        }

        protected void DisEngageProcess()
        {

            if (myAsyncronousProcessOutputType == AsyncronousProcessOutputType.Output)
            {

                myProcess.OutputDataReceived -= OutputDataReceived;

            }
            else if (myAsyncronousProcessOutputType == AsyncronousProcessOutputType.Error)
            {

                myProcess.ErrorDataReceived -= OutputDataReceived;

            }

        }

        void OutputDataReceived(object sender, DataReceivedEventArgs e)
        {

            myOutputQueue.Enqueue(e.Data);

        }

        public ProcessManager ProcessManager
        {

            get
            {

                return myProcessManager;

            }

        }

        public string ReadLine()
        {

            string result;

            if(myOutputQueue.TryDequeue(out result))
            {

                return result;

            }

            return string.Empty;

        }

        public IEnumerable<string> ReadLines(int MaxOf = 0)
        {

            MaxOf = myOutputQueue.Count;

            if (MaxOf > 0)
            {

                try
                {

                    string result;

                    for (; MaxOf > 0; MaxOf--)
                    {

                        if (myOutputQueue.TryDequeue(out result))
                        {

                            myLazyQueue.Value.Enqueue(result);

                        }

                    }

                    return myLazyQueue.Value.ToArray();

                }
                finally 
                {

                    myLazyQueue.Value.Clear();

                }

            }

            return new string[0];

        }

        public void ReadInto(ICollection<string> TheExistingCollection, int MaxOf = 0)
        {

            if (myOutputQueue.Count > 0)
            {

                try
                {

                    string result;

                    if (MaxOf < 1)
                    {

                        MaxOf = myOutputQueue.Count;

                    }
                    else if(MaxOf > myOutputQueue.Count)
                    {

                        MaxOf = myOutputQueue.Count;

                    }

                    for (; MaxOf > 0; MaxOf--)
                    {

                        if (myOutputQueue.TryDequeue(out result))
                        {

                            TheExistingCollection.Add(result);

                        }

                    }

                }
                finally
                {

                    myLazyQueue.Value.Clear();

                }

            }

        }

        public string ReadToEnd()
        {

            if (myOutputQueue.Count > 0)
            {

                try
                {

                    string result;

                    int Max = myOutputQueue.Count;

                    for (; Max > 0; Max--)
                    {

                        if (myOutputQueue.TryDequeue(out result))
                        {

                            myLazySB.Value.AppendLine(result);

                        }

                    }

                    return myLazySB.Value.ToString();

                }
                finally
                {

                    myLazySB.Value.Clear();

                }

            }
            
            return string.Empty;

        }
        
        public void Dispose()
        {

            DisEngage();

        }

        public bool HasEntries
        {

            get
            {

                return myOutputQueue.Count > 0;

            }

        }

    }

    public enum AsyncronousProcessOutputType
    {

        Output,
        Error

    }

}
