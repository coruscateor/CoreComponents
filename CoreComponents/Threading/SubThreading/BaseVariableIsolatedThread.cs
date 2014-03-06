using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreComponents.Threading.SubThreading
{

    [Serializable]
    public abstract class BaseVariableIsolatedThread : ISubThread
    {

        public const ExecutionMethod DefaultExecutionMethod = ExecutionMethod.Task;

        [NonSerialized]
        private Lazy<Thread> myLazyThread;

        [NonSerialized]
        private Lazy<Task> myLazyTask;

        private Lazy<AppDomain> myLazyAppDomian;

        private string myName;

        //private Thread myExecutingThread;

        private bool myIsActive;

        private AppDomain myCurrentAppDomain;

        private ExecutionMethod myExecutionMethod;

        private Action myStart;

        private bool myStopRequested;

        public BaseVariableIsolatedThread(ExecutionMethod TheExecutionMethod = DefaultExecutionMethod)
        {

            InitailseThis("", TheExecutionMethod);

        }

        public BaseVariableIsolatedThread(string TheName = "", ExecutionMethod TheExecutionMethod = DefaultExecutionMethod)
        {

            InitailseThis(TheName, TheExecutionMethod);

        }

        private void InitailseThis(string TheName = "", ExecutionMethod TheExecutionMethod = DefaultExecutionMethod)
        {

            myExecutionMethod = TheExecutionMethod;

            SetTheThreadExecutionEnvironment();

            //if (TheName == null || TheName.Length == 0)
            //{

            //    myName = new Guid().ToString();
                
            //}
            //else
            //{

            myName = TheName;

            //}

            myLazyThread = new Lazy<Thread>(() => { return new Thread(RunThreadMain); });

            InitaliseLazyTask();

            InitaliseLazyAppDomain();

        }

        private void InitaliseLazyTask()
        {

            myLazyTask = new Lazy<Task>(() => { return new Task(RunThreadMain); });

        }

        private void InitaliseLazyAppDomain()
        {

            myLazyAppDomian = new Lazy<AppDomain>(() => { return AppDomain.CreateDomain(myName, null); });
            
        }

        protected abstract void ThreadMain();

        //New Thread Starts here!
        private void RunThreadMain()
        {

            try
            {

                Thread.MemoryBarrier();

                if(!myStopRequested)
                {

                    myCurrentAppDomain = AppDomain.CurrentDomain;

                    ThreadMain();

                }
                
            }
            finally
            {

                Thread.MemoryBarrier();

                if(myStopRequested)
                {

                    myStopRequested = false;

                    Thread.MemoryBarrier();

                }

                myIsActive = false;

                Thread.MemoryBarrier();

            }

        }
        
        public virtual void Start()
        {

            Thread.MemoryBarrier();

            if(!myIsActive)
            {

                myIsActive = true;

                Thread.MemoryBarrier();

                try
                {

                    myStart();

                }
                catch
                {

                    Thread.MemoryBarrier();

                    if(myIsActive)
                    {

                        myIsActive = false;

                        Thread.MemoryBarrier();

                    }

                    throw;

                }

            }

        }

        public void Stop()
        {

            Thread.MemoryBarrier();

            if(!myStopRequested)
            {

                myStopRequested = true;

                Thread.MemoryBarrier();

            }

        }

        public bool StopRequested
        {

            get
            {

                Thread.MemoryBarrier();
                
                return myStopRequested;

            }

        }

        private void SetTheThreadExecutionEnvironment()
        {

            Thread.MemoryBarrier();

            switch(myExecutionMethod)
            {

                case ExecutionMethod.AppDomian:

                    myStart = () => { myLazyAppDomian.Value.DoCallBack(RunThreadMain); };

                    break;
                case ExecutionMethod.Task:

                    myStart = () => { myLazyTask.Value.Start(); };

                    break;
                case ExecutionMethod.Thread:

                    myStart = () => { myLazyThread.Value.Start(); };

                    break;
                case ExecutionMethod.ThisThread:

                    myStart = RunThreadMain;

                    break;
                case ExecutionMethod.WorkerThread:

                    myStart = () => { ThreadPool.QueueUserWorkItem((object TheState) => { RunThreadMain(); }); };

                    break;

            }

        }

        public string Name
        {

            get
            {

                Thread.MemoryBarrier();

                return myName;
                
            }
            set 
            {

                Thread.MemoryBarrier();

                if (!IsActive)
                {

                    myName = value;

                    Thread.MemoryBarrier();

                    if (myLazyAppDomian.IsValueCreated)
                    {

                        InitaliseLazyAppDomain();

                    }

                }

            }

        }

        public bool IsActive
        {

            get
            {

                Thread.MemoryBarrier();

                return myIsActive;

            }

        }

        //public bool IsActive
        //{

        //    get 
        //    {

        //        return myExecutingThread != null && myExecutingThread.IsAlive;

        //        //if (myExecutingThread != null)
        //        //{

        //        //    return myExecutingThread.IsAlive;

        //        //}

        //        //return false;
            
        //    }

        //}

        //public bool HasExecutedAtleastOnce
        //{

        //    get
        //    {

        //        return myExecutingThread != null;

        //    }

        //}

        //public bool IsThisThread
        //{

        //    get
        //    {


        //        if (myExecutingThread != null)
        //        {

        //            return myExecutingThread == Thread.CurrentThread;

        //        }

        //        return false;

        //    }

        //}

        //public bool IsNotThisThread
        //{

        //    get
        //    {

        //        if (myExecutingThread != null)
        //        {

        //            return myExecutingThread != Thread.CurrentThread;

        //        }

        //        return true;

        //    }

        //}

        public bool IsThisAppDomain
        {

            get
            {

                Thread.MemoryBarrier();

                if (myCurrentAppDomain != null)
                {

                    return myCurrentAppDomain == AppDomain.CurrentDomain;

                }

                return false;

            }

        }

        public bool IsNotThisAppDomain
        {

            get
            {

                Thread.MemoryBarrier();

                if (myCurrentAppDomain != null)
                {

                    return myCurrentAppDomain != AppDomain.CurrentDomain;

                }

                return true;

            }

        }

        public ExecutionMethod ExecutionMethod
        {

            get
            {

                Thread.MemoryBarrier();

                return myExecutionMethod;

            }
            set 
            {

                Thread.MemoryBarrier();

                if (!IsActive)
                {

                    myExecutionMethod = value;

                    Thread.MemoryBarrier();

                    SetTheThreadExecutionEnvironment();

                }

            }

        }

        public bool ReInstantiateTaskIfUsed()
        {

            Thread.MemoryBarrier();
            
            bool CurrenltyIsActive = IsActive;

            if(!CurrenltyIsActive && myLazyTask.IsValueCreated)
            {

                if(myLazyTask.Value.Status == TaskStatus.RanToCompletion || myLazyTask.Value.Status == TaskStatus.Faulted || myLazyTask.Value.Status == TaskStatus.Canceled)
                {

                    InitaliseLazyTask();

                    return true;

                }

            }
            
            return false;

        }

        //protected void AbortExecutingThread()
        //{

        //    if (myExecutingThread != null)
        //    {

        //        myExecutingThread.Abort();

        //    }

        //}

        public bool DisposeTaskIfUsed()
        {

            Thread.MemoryBarrier();

            if(!IsActive)
            {

                if(myLazyTask.IsValueCreated)
                {

                    if(myLazyTask.Value.Status == TaskStatus.RanToCompletion || myLazyTask.Value.Status == TaskStatus.Faulted || myLazyTask.Value.Status == TaskStatus.Canceled)
                    {

                        myLazyTask.Value.Dispose();

                        return true;

                    }

                }

            }

            return false;

        }

    }

    public enum ExecutionMethod
    {

        Thread,
        Task,
        AppDomian,
        ThisThread,
        WorkerThread

    }

}
