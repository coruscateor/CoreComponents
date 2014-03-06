using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Security;

namespace CoreComponents.Processes
{

    public class ProcessManager : IApplicationManager
    {

        protected const char Space = ' ';

        private Process myProcess = new Process();

        private bool myIsEngaged = false;

        //private bool myOutputDataReceivedIsEngaged = false;

        //private bool myErrorDataReceivedIsEngaged = false;

        private bool myIsActive = false;

        private string[] myArgumentsArray = new string[0];

        //private volatile ConcurrentQueue<string> OutputDataQueue;

        //private volatile ConcurrentQueue<string> ErrorDataQueue;

        private Lazy<ProcessOutputReader> LazyOutputReader;

        private Lazy<ProcessOutputReader> LazyErrorReader;

        private Lazy<AsyncronousProcessOutputReader> LazyAsyncronousProcessOutputReader;

        private Lazy<AsyncronousProcessOutputReader> LazyAsyncronousProcessErrorReader;

        private Lazy<ProcessOutputChache> LazyOutputChache;

        private Lazy<ProcessOutputChache> LazyErrorChache;

        private IProcessOuputReader myOutputReader;

        private IProcessOuputReader myErrorReader;

        private IProcessInputWriter myProcessInputWriter;

        public ProcessManager()
        {

            LazyOutputReader = new Lazy<ProcessOutputReader>(() => { return new ProcessOutputReader(this, myProcess.StandardOutput); });

            LazyErrorReader = new Lazy<ProcessOutputReader>(() => { return new ProcessOutputReader(this, myProcess.StandardError); });

            LazyAsyncronousProcessOutputReader = new Lazy<AsyncronousProcessOutputReader>(() => { return new AsyncronousProcessOutputReader(this, myProcess); });

            LazyAsyncronousProcessErrorReader = new Lazy<AsyncronousProcessOutputReader>(() => { return new AsyncronousProcessOutputReader(this, myProcess, AsyncronousProcessOutputType.Error); });

            myOutputReader = LazyOutputReader.Value;

            myErrorReader = LazyErrorReader.Value;

            myProcessInputWriter = new ProcessInputWriter(this, myProcess.StandardInput);

        }

        protected void Engage()
        {

            if (!myIsEngaged)
            {

                myProcess.Exited += myProcess_Exited;

                myIsEngaged = true;

            }

        }

        //protected void EngageOutputDataReceived()
        //{

        //    if (!myOutputDataReceivedIsEngaged)
        //    {

        //        OutputDataQueue = new ConcurrentQueue<string>();

        //        myProcess.OutputDataReceived += myProcess_OutputDataReceived;

        //        myOutputDataReceivedIsEngaged = true;

        //    }

        //}

        //protected void DisEngageOutputDataReceived()
        //{

        //    if (!myOutputDataReceivedIsEngaged)
        //    {

        //        myProcess.OutputDataReceived -= myProcess_OutputDataReceived;

        //        myOutputDataReceivedIsEngaged = false;

        //    }

        //}

        //protected void EngageErrorDataReceived()
        //{

        //    if (!myErrorDataReceivedIsEngaged)
        //    {

        //        ErrorDataQueue = new ConcurrentQueue<string>();

        //        myProcess.ErrorDataReceived += myProcess_ErrorDataReceived;

        //        myErrorDataReceivedIsEngaged = true;

        //    }

        //}

        //protected void DisEngageErrorDataReceived()
        //{

        //    if (myErrorDataReceivedIsEngaged)
        //    {

        //        myProcess.ErrorDataReceived -= myProcess_ErrorDataReceived;

        //        myErrorDataReceivedIsEngaged = false;

        //    }

        //}

        //void myProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        //{

        //    OutputDataQueue.Enqueue(e.Data);

        //}

        //void myProcess_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        //{

        //    ErrorDataQueue.Enqueue(e.Data);

        //}

        void myProcess_Exited(object sender, EventArgs e)
        {

            myIsActive = false;

        }

        protected void DisEngage()
        {
            
            if (!myIsActive && myIsEngaged)
            {

                myProcess.Exited -= myProcess_Exited;

                myIsEngaged = false;

            }

        }

        public void Execute(string TheApplicationPath, string TheArgumentsString = "", string TheName = "")
        {

            if (!myIsActive)
            {

                myProcess.StartInfo.FileName = TheApplicationPath;

                if (TheArgumentsString != null && TheArgumentsString.Length > 0)
                {

                    myProcess.StartInfo.FileName = TheArgumentsString;

                    myArgumentsArray = TheArgumentsString.Split(Space);

                }
                else if (myArgumentsArray.Length > 0)
                {

                    myArgumentsArray = new string[0];

                }

                Engage();

                myIsActive = myProcess.Start();

            }

        }

        public void Execute()
        {

            if (!myIsActive)
            {

                Engage();

                myIsActive = myProcess.Start();

            }

        }

        public string Name
        {

            get
            {

                return myProcess.ProcessName;

            }

        }

        public IEnumerable<string> ArgumentsEnumerator
        {
            get
            {

                return (IEnumerable<string>)myArgumentsArray.Clone();

            }
            set
            {
                
                if (!myIsActive)
                {

                    myArgumentsArray = value.ToArray();

                    ArgumentsToString();

                }

            }

        }

        protected void ArgumentsToString()
        {

            if (myArgumentsArray.Length > 1)
            {

                StringBuilder SB = new StringBuilder(myArgumentsArray[0]);

                for (int i = 1; i < myArgumentsArray.Length; i++)
                {

                    SB.Append(Space);

                    SB.Append(myArgumentsArray[i]);

                }

                myProcess.StartInfo.Arguments = SB.ToString();

            }
            else if (myArgumentsArray.Length == 1)
            {

                myProcess.StartInfo.Arguments = myArgumentsArray[0];

            }
            else if (myProcess.StartInfo.Arguments != null && myProcess.StartInfo.Arguments.Length > 0)
            {

                myProcess.StartInfo.Arguments = string.Empty;

            }

        }

        public int ArgumentsCount
        {

            get
            {

                return myArgumentsArray.Length;
            
            }

        }

        public int ReturnCode
        {

            get 
            { 
                
                return myProcess.ExitCode;

            }

        }

        public DateTime StartTime
        {

            get 
            {

                return myProcess.StartTime;
                
            }

        }

        public bool Responding
        {

            get
            {

                return myProcess.Responding;
                
            }

        }

        public IntPtr ProcessorAffinity
        {

            get
            {

                return myProcess.ProcessorAffinity;
                
            }
 
        }

        public int SessionId 
        {

            get 
            {

                return myProcess.SessionId;

            }

        }

        public void Kill()
        {

            if (myIsActive)
            {

                myProcess.Kill();

            }

        }

        public string FilePath
        {

            get
            {

                return myProcess.StartInfo.FileName;

            }
            set 
            {

                if (!myIsActive) 
                {

                    myProcess.StartInfo.FileName = value;

                }

            }

        }

        public string Arguments
        {
            get 
            {

                return myProcess.StartInfo.Arguments;

            }
            set 
            {

                if (!myIsActive)
                {

                    myProcess.StartInfo.Arguments = value;

                    myArgumentsArray = value.Split(Space);

                }

            }

        }

        public bool CreateNoWindow
        {

            get 
            {

                return myProcess.StartInfo.CreateNoWindow;

            }
            set 
            {

                if (!myIsActive)
                {

                    myProcess.StartInfo.CreateNoWindow = value;

                }

            }

        }

        public string Domain
        {
            get 
            {

                return myProcess.StartInfo.Domain;

            }
            set 
            {

                if (!myIsActive)
                {

                    myProcess.StartInfo.Domain = value;

                }

            }

        }

        public bool ErrorDialog
        {
            get 
            {

                return myProcess.StartInfo.ErrorDialog;

            }
            set 
            {

                if (!myIsActive)
                {

                    myProcess.StartInfo.ErrorDialog = value;

                }

            }

        }

        public IntPtr ErrorDialogParentHandle 
        {

            get 
            {

                return myProcess.StartInfo.ErrorDialogParentHandle;

            }
            set 
            {

                if (!myIsActive)
                {

                    myProcess.StartInfo.ErrorDialogParentHandle = value;

                }

            }

        }

        //public string FileName 
        //{

        //    get 
        //    {

        //        return myProcess.StartInfo.FileName;

        //    }
        //    set 
        //    {

        //        if (!myIsActive)
        //        {

        //            myProcess.StartInfo.FileName = value;

        //        }

        //    }

        //}

        public bool LoadUserProfile 
        {

            get 
            {

                return myProcess.StartInfo.LoadUserProfile;

            }
            set 
            {

                if (!myIsActive)
                {

                    myProcess.StartInfo.LoadUserProfile = value;

                }

            }

        }

        public SecureString Password 
        {

            get 
            {

                return myProcess.StartInfo.Password;

            }
            set 
            {

                if (!myIsActive)
                {

                    myProcess.StartInfo.Password = value;

                }

            }

        }

        public bool RedirectStandardInput 
        {

            get 
            {

                return myProcess.StartInfo.RedirectStandardInput;

            }
            set 
            {

                myProcess.StartInfo.RedirectStandardInput = value;

            }

        }

        public bool RedirectStandardOutput 
        {

            get 
            {

                return myProcess.StartInfo.RedirectStandardOutput;

            }
            set 
            {

                if (value)
                {

                    //EngageOutputDataReceived();

                }

                myProcess.StartInfo.RedirectStandardOutput = value;

            }

        }

        public bool RedirectStandardError
        {

            get
            {

                return myProcess.StartInfo.RedirectStandardError;

            }
            set
            {

                if (value)
                {

                    //EngageErrorDataReceived();

                }

                myProcess.StartInfo.RedirectStandardError = value;

            }

        }

        public Encoding StandardErrorEncoding 
        {

            get 
            {

                return myProcess.StartInfo.StandardErrorEncoding;

            }
            set 
            {

                if (!myIsActive)
                {

                    myProcess.StartInfo.StandardErrorEncoding = value;

                }

            }

        }

        public Encoding StandardOutputEncoding 
        {

            get 
            {

                return myProcess.StartInfo.StandardOutputEncoding;

            }
            set 
            {

                if (!myIsActive)
                {

                    myProcess.StartInfo.StandardOutputEncoding = value;

                }

            }

        }

        public string UserName 
        {

            get 
            {

                return myProcess.StartInfo.UserName;

            }
            set 
            {

                if (!myIsActive)
                {

                    myProcess.StartInfo.UserName = value;

                }

            }

        }

        public bool UseShellExecute 
        {

            get 
            {

                return myProcess.StartInfo.UseShellExecute;

            }
            set 
            {

                if (!myIsActive)
                {

                    myProcess.StartInfo.UseShellExecute = value;

                }

            }
        
        }

        public string Verb 
        {

            get 
            {

                return myProcess.StartInfo.Verb;

            }
            set 
            {
                
                if (!myIsActive)
                {

                    myProcess.StartInfo.Verb = value;

                }

            }

        }

        public ProcessWindowStyle WindowStyle 
        {
            get 
            {

                return myProcess.StartInfo.WindowStyle;

            }

            set 
            {

                if (!myIsActive)
                {

                    myProcess.StartInfo.WindowStyle = value;

                }

            }

        }

        public string WorkingDirectory
        {

            get
            {

                return myProcess.StartInfo.WorkingDirectory;

            }
            set
            {

                if (!myIsActive)
                {

                    myProcess.StartInfo.WorkingDirectory = value;

                }

            }

        }

        public IProcessOuputReader OutputReader
        {

            get 
            {

                return myOutputReader;

            }

        }

        public IProcessOuputReader ErrorReader
        {

            get
            {

                return myErrorReader;

            }

        }

        public IProcessInputWriter InputWriter
        {


            get
            {

                return myProcessInputWriter;

            }

        }

        public void Dispose()
        {

            DisEngage();

            //DisEngageErrorDataReceived();

            //DisEngageOutputDataReceived();

            if (!myIsActive)
            {

                myProcess.Dispose();

            }

        }
        
        //public string ApplicationPath
        //{

        //    get
        //    {

        //        return myProcess.StartInfo.FileName;

        //    }
        //    set
        //    {

        //        if (!myIsActive) 
        //        {

        //            myProcess.StartInfo.FileName = value;

        //        }

        //    }

        //}

        public void SetArguments(string TheArgumentsString)
        {

            if (!myIsActive)
            {

                myProcess.StartInfo.Arguments = TheArgumentsString;


            }

        }

    }

}
