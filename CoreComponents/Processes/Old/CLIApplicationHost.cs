using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Reflection;
using System.IO;
using CoreComponents.Threading.SubThreading;

namespace CoreComponents.Processes
{

    [Serializable]
    public class CLIApplicationHost : BareVariableIsolatedThread, IDisposable  //IApplicationManager,
    {

        private AppDomain myApplicationAppDomain;

        private string myFilePathOrAssemblyName;

        private AssemblyName myAssemblyName;

        private string[] myArguments = new string[0];

        private string myApplicationAppDomainName;

        private int myReturnCode;

        private ApplicationHostExecutionMode myApplicationHostExecutionMode;

        public CLIApplicationHost(ExecutionMethod TheExecutionMethod = ExecutionMethod.AppDomian)
            : base(TheExecutionMethod)
        {

            myApplicationHostExecutionMode = ApplicationHostExecutionMode.File;

            GetDomain();
            
        }

        public CLIApplicationHost(ExecutionMethod TheExecutionMethod = ExecutionMethod.AppDomian, ApplicationHostExecutionMode TheApplicationHostExecutionMode = ApplicationHostExecutionMode.File)
            : base(ExecutionMethod.AppDomian)
        {

            myApplicationHostExecutionMode = TheApplicationHostExecutionMode;

            GetDomain();

            if (TheApplicationHostExecutionMode != myApplicationHostExecutionMode)
            {

                myApplicationHostExecutionMode = TheApplicationHostExecutionMode;

            }

        }

        protected void GetDomain()
        {

            myApplicationAppDomain = Thread.GetDomain();

        }

        public void Execute(string TheFilePathOrAssemblyName, string TheArgumentsString = "", string TheName = "")
        {

            if (!IsActive)
            {

                myFilePathOrAssemblyName = TheFilePathOrAssemblyName;

                if(TheArgumentsString.Length > 0)
                    myArguments = TheArgumentsString.Split(' ');

                if (TheName.Length > 0)
                {

                    ApplicationAppDomainName = TheName;

                }

                Execute();

            }

        }

        public void Execute(AssemblyName TheAssemblyName, string TheArgumentsString = "", string TheName = "")
        {

            if (!IsActive)
            {

                if (myApplicationHostExecutionMode != ApplicationHostExecutionMode.AssemblyName)
                {

                    myApplicationHostExecutionMode = ApplicationHostExecutionMode.AssemblyName;

                }

                myFilePathOrAssemblyName = TheAssemblyName.FullName;

                if (TheArgumentsString != null && TheArgumentsString.Length > 0)
                    myArguments = TheArgumentsString.Split(' ');

                if (TheName.Length > 0)
                {

                    ApplicationAppDomainName = TheName;

                }

                Execute();

            }

        }

        protected override void Main()
        {

            if (myApplicationAppDomainName == null || myApplicationAppDomainName == "")
            {

                if (myApplicationHostExecutionMode == ApplicationHostExecutionMode.File)
                {

                    myApplicationAppDomainName = Path.GetFileName(myFilePathOrAssemblyName);

                }
                else if(myApplicationHostExecutionMode == ApplicationHostExecutionMode.AssemblyName)
                {

                    myApplicationAppDomainName = myAssemblyName.Name;

                }
 
            }

            myApplicationAppDomain = AppDomain.CreateDomain(myApplicationAppDomainName);

            if (myReturnCode != 0)
                myReturnCode = 0;

            if (myArguments.Length > 0)
            {

                if (myApplicationHostExecutionMode == ApplicationHostExecutionMode.File)
                {

                    myReturnCode = myApplicationAppDomain.ExecuteAssembly(myFilePathOrAssemblyName, myArguments);

                }
                else if (myApplicationHostExecutionMode == ApplicationHostExecutionMode.AssemblyName)
                {

                    myReturnCode = myApplicationAppDomain.ExecuteAssemblyByName(myFilePathOrAssemblyName, myArguments);

                }

            }
            else
            {

                if (myApplicationHostExecutionMode == ApplicationHostExecutionMode.File)
                {

                    myReturnCode = myApplicationAppDomain.ExecuteAssembly(myFilePathOrAssemblyName);

                }
                else if (myApplicationHostExecutionMode == ApplicationHostExecutionMode.AssemblyName)
                {

                    myReturnCode = myApplicationAppDomain.ExecuteAssemblyByName(myFilePathOrAssemblyName);

                }

            }

        }

        public override void Execute()
        {

            if (myFilePathOrAssemblyName.Length > 0)
            {

                base.Execute();

            }

        }

        public string FilePath
        {

            get
            {

                return myFilePathOrAssemblyName;

            }
            set
            {

                if (!IsActive)
                {

                    myFilePathOrAssemblyName = value;

                }

            }

        }

        public string ApplicationName
        {

            get
            {

                if (myApplicationHostExecutionMode == ApplicationHostExecutionMode.File)
                {

                    return Path.GetFileName(myFilePathOrAssemblyName);

                } 
                else if (myApplicationHostExecutionMode == ApplicationHostExecutionMode.AssemblyName)
                {

                    return myAssemblyName.Name;

                }

                return string.Empty;

            }

        }

        public IEnumerable<string> ArgumentsEnumerator
        {

            get
            {

                return (IEnumerable<string>)myArguments.Clone();

            }
            set 
            {

                if (!IsActive)
                {

                    if (value != null)
                    {

                        myArguments = value.ToArray();

                    }
                    else 
                    {

                        myArguments = new string[0];

                    }

                }

            }

        }

        public int ArgumentsCount
        {

            get 
            {

                return myArguments.Length;
                
            }

        }

        public void SetArguments(string TheArgumentsString)
        {

            if (!IsActive)
            {

                myArguments = TheArgumentsString.Split(' ');

            }

        }

        public string AssembleArguments()
        {

            if (myArguments.Length == 0)
            {

                return "";

            }

            if (myArguments.Length == 1) 
            {

                return myArguments[0];

            }

            StringBuilder SB = new StringBuilder();

            for (int i = 0; i < myArguments.Length; i++)
            {

                SB.Append(myArguments[i]);

                if (i < myArguments.Length) //Something like this...
                {

                    SB.Append(' ');

                }

            }

            return SB.ToString();

        }

        public string ApplicationAppDomainName
        {

            get
            {

                return myApplicationAppDomainName;

            }
            set 
            {

                if (!IsActive)
                {

                    myApplicationAppDomainName = value;

                    myApplicationAppDomain = AppDomain.CreateDomain(myApplicationAppDomainName);

                }

            }

        }

        public AppDomainSetup SetupInformation
        {

            get
            {

                return myApplicationAppDomain.SetupInformation;

            }

        }

        public int ReturnCode
        {

            get
            {

                return myReturnCode;

            }

        }

        public ApplicationHostExecutionMode ExecutionMode
        {

            get
            {

                return myApplicationHostExecutionMode;

            }
            set 
            {

                myApplicationHostExecutionMode = value;

                if (myApplicationHostExecutionMode == ApplicationHostExecutionMode.File)
                {

                    ResetAssemblyName();

                }

            }

        }

        protected void SetAssemblyName()
        {

            myAssemblyName = new AssemblyName(myFilePathOrAssemblyName);

        }

        protected void SetFilePathOrAssemblyName()
        {

            myFilePathOrAssemblyName = myAssemblyName.FullName;

        }

        protected void ResetAssemblyName()
        {

            if(myAssemblyName != null)
                myAssemblyName = null;

        }

        public AssemblyName AssemblyName
        {

            get
            {

                return myAssemblyName;

            }

        }

        public bool HasAssemblyName
        {

            get
            {

                return myAssemblyName != null;

            }

        }

        public void Kill()
        {

            try
            {

                if (IsNotThisAppDomain && IsActive)
                {
                    
                    AppDomain.Unload(myApplicationAppDomain);

                }

            }
            finally
            {
            }

        }

        public void Dispose()
        {

            DisposeTaskIfUsed();

        }

    }

    public enum ApplicationHostExecutionMode
    {

        File,
        AssemblyName

    }

}
