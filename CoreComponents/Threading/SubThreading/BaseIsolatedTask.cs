using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreComponents.Threading.SubThreading
{

    public abstract class BaseIsolatedTask : IBaseIsolatedTask, IDisposable
    {

        private Task myCurrentTask;

        private Task myNextTask;

        private bool myIsActive;

        private bool myStopRequested;

        //private Queue<Task> myContinuationQueue;

        //private Dictionary<Task, object> myContinuationQueueStateIndex;

        private object myState;

        private object myNextState;

        //private bool myClearingState;

        //private Action<Task> myEnqueueNextTaskAction;

        //private Action<Task, object> myAddStateAction;

        //private Func<int> myContinuationQueueCountFunc;

        //private Func<bool> myIsContinuingFunc;

        //private Func<int> myContinuationQueueStateIndexCountFunc;

        //private Func<bool> myContinuationQueueStateIndexHasItemsFunc;

        //private Func<Task> myLastTaskFunc;

        public BaseIsolatedTask() //bool StartNow = false 
        {

            Initalise();

        }

        protected void Initalise()
        {

            //if (myCurrentTask == null)

            myCurrentTask = new Task(RunThreadMain);

            //myEnqueueNextTaskAction = InitaliseContinuationQueue;

            //myAddStateAction = InitaliseContinuationQueueStateIndex;

            //myContinuationQueueCountFunc = () => { return 0; };

            //myIsContinuingFunc = () => { return false; };

            //myContinuationQueueStateIndexCountFunc = myContinuationQueueCountFunc;

            //myLastTaskFunc = () => { return myCurrentTask; };

            //myContinuationQueueStateIndexHasItemsFunc = myIsContinuingFunc;

        }

        public void Start()
        {

            CheckTask();

            myCurrentTask.Start();

        }

        public void Start(TaskScheduler TheTaskScheduler)
        {

            CheckTask();

            myCurrentTask.Start(TheTaskScheduler);

        }

        private void CheckTask()
        {

            if (myCurrentTask.IsCompleted || myCurrentTask.IsFaulted || myCurrentTask.IsCanceled)
            {

                myCurrentTask.Dispose();

                myCurrentTask = new Task(RunThreadMain);

            }

        }

        public void Stop()
        {

            Thread.MemoryBarrier();

            bool IsActive = myIsActive;

            Thread.MemoryBarrier();

            bool StopRequested = myStopRequested;

            if(!IsActive && !StopRequested)
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

        //New Thread Starts here!
        private void RunThreadMain()
        {

            Thread.MemoryBarrier();

            if (!myIsActive)
            {

                Thread.MemoryBarrier();

                if (!myStopRequested)
                {

                    myIsActive = true;

                    Thread.MemoryBarrier();

                    if (myCurrentTask.AsyncState != null)
                        myState = myCurrentTask.AsyncState;
                    //else if (myState != null)
                    //    myState = null;

                    try
                    {

                        Thread.MemoryBarrier();
                        
                        if(!myStopRequested)
                            ThreadMain();

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
                else
                {

                    myStopRequested = false;

                    Thread.MemoryBarrier();

                }

            }

        }

        protected abstract void ThreadMain();

        private void ContinueMain(Task TheTask)
        {

            //try
            //{

            Thread.MemoryBarrier();

            if(myIsActive)
            {

                myCurrentTask.Dispose();

                //myCurrentTask = myContinuationQueue.Dequeue();

                //if (HasState() && myContinuationQueueStateIndex.ContainsKey(myCurrentTask))
                //{

                //    myState = myContinuationQueueStateIndex[myCurrentTask];

                //    myContinuationQueueStateIndex.Remove(myCurrentTask);

                //}

                myCurrentTask = myNextTask;

                myNextTask = null;

                Thread.MemoryBarrier();

                if(!myStopRequested)
                {

                    if(myNextTask != null)
                    {

                        myState = myNextState;

                        myNextState = null;

                    }
                    else if(myState != null)
                    {

                        myState = null;

                    }

                    ThreadMain();

                }
                else
                {

                    if(myState == null)
                        myState = null;

                    if(myNextState == null)
                        myNextState = null;

                }

            }

            //}
            //finally
            //{
                
            //    Thread.MemoryBarrier();

            //    if (!IsContinuing)
            //    {

            //        Thread.MemoryBarrier();

            //        if(myStopRequested)
            //        {

            //            myStopRequested = false;

            //            Thread.MemoryBarrier();

            //        }

            //        //if (myContinuationQueue.Count > 0)
            //        //    myContinuationQueue.Clear();

            //        //if (myContinuationQueueStateIndex.Count > 0)
            //        //    myContinuationQueueStateIndex.Clear();

            //        myIsActive = false;

            //        Thread.MemoryBarrier();

            //    }

            //}

        }

        //private int GetContinuationQueueCount()
        //{

        //    return myContinuationQueue.Count;

        //}

        //protected int ContinuationQueueCount
        //{

        //    get
        //    {

        //        return myContinuationQueueCountFunc();

        //    }

        //}

        //private bool GetIsContinuing()
        //{

        //    return myContinuationQueue.Count > 0;

        //}

        public bool IsContinuing
        {

            get
            {

                //return myIsContinuingFunc();

                Thread.MemoryBarrier();

                return myNextTask != null;

            }

        }

        protected bool CheckIsContinuing
        {

            get
            {

                return myNextTask != null;

            }

        }

        //private int GetContinuationQueueStateIndexCount()
        //{

        //    return myContinuationQueue.Count;

        //}

        //protected int ContinuationQueueStateIndexCount
        //{

        //    get
        //    {

        //        return myContinuationQueueStateIndexCountFunc();

        //    }

        //}

        //private bool GetContinuationQueueStateIndexHasItems()
        //{

        //    return myContinuationQueue.Count > 0;

        //}

        //private Task GetLastTask()
        //{

        //    if (myContinuationQueue.Count > 0)
        //        return myContinuationQueue.Peek();

        //    return myCurrentTask;

        //}

        //protected bool ContinuationQueueStateIndexHasItems
        //{

        //    get
        //    {

        //        return myContinuationQueueStateIndexHasItemsFunc();

        //    }

        //}

        protected object State
        {

            get
            {

                return myState;

            }

        }

        protected bool HasState
        {

            get
            {

                return myState != null;

            }

        }

        protected void FetchState(Action<object> StateFoundAction)
        {

            if (myState != null)
                StateFoundAction(myState);

        }

        //protected bool ClearingStateOnNextStart
        //{

        //    get
        //    {

        //        return myClearingState;

        //    }
        //    set
        //    {

        //        myClearingState = value;

        //    }
 
        //}

        //protected void ClearStateOnNextStart()
        //{

        //    if(!myClearingState)
        //    {

        //        myClearingState = true;

        //    }

        //}

        //protected void DontClearStateOnNextStart()
        //{

        //    if(myClearingState)
        //    {

        //        myClearingState = false;

        //    }

        //}

        public bool IsActive
        {

            get
            {

                Thread.MemoryBarrier();

                return myIsActive;

            }

        }

        public void ReInstantiateTask()
        {

            Thread.MemoryBarrier();

            if (!myIsActive)
            {

                myCurrentTask = new Task(RunThreadMain);

            }

        }

        public bool CaughtException
        {

            get
            {

                return myCurrentTask.Exception != null;

            }

        }

        public Exception Exception
        {

            get
            {

                return myCurrentTask.Exception;
 
            }

        }

        //private bool HasState()
        //{

        //    return myContinuationQueueStateIndex != null && myContinuationQueueStateIndex.Count > 0;
 
        //}

        public void Dispose() 
        {

            myCurrentTask.Dispose();

        }

        protected bool Continue()
        {

            if(!CheckIsContinuing)
            {

                myNextTask = myCurrentTask.ContinueWith(ContinueMain);

                return true;

            }

            return false;

            //Task NextTask =  myLastTaskFunc().ContinueWith(ContinueMain);

            //myEnqueueNextTaskAction(NextTask);

        }

        protected bool Continue(CancellationToken TheCancellationToken)
        {

            if(!CheckIsContinuing)
            {

                myNextTask = myCurrentTask.ContinueWith(ContinueMain, TheCancellationToken);

                return true;

            }

            return false;

        //    Task NextTask = myLastTaskFunc().ContinueWith(ContinueMain, TheCancellationToken);

        //    myEnqueueNextTaskAction(NextTask);

        }

        protected bool Continue(TaskContinuationOptions TheContinuationOptions)
        {

            if(!CheckIsContinuing)
            {

                myNextTask = myCurrentTask.ContinueWith(ContinueMain, TheContinuationOptions);

                return true;

            }

            return false;

        //    Task NextTask = myLastTaskFunc().ContinueWith(ContinueMain, TheContinuationOptions);

        //    myEnqueueNextTaskAction(NextTask);

        }

        protected bool Continue(TaskScheduler TheTaskScheduler)
        {

            if(!CheckIsContinuing)
            {

                myNextTask = myCurrentTask.ContinueWith(ContinueMain, TheTaskScheduler);

                return true;

            }

            return false;

        //    Task NextTask = myLastTaskFunc().ContinueWith(ContinueMain, TheTaskScheduler);

        //    myEnqueueNextTaskAction(NextTask);

        }

        protected bool Continue(CancellationToken TheCancellationToken, TaskContinuationOptions TheContinuationOptions,TaskScheduler TheTaskScheduler)
        {

            if(!CheckIsContinuing)
            {

                myNextTask = myCurrentTask.ContinueWith(ContinueMain, TheCancellationToken, TheContinuationOptions, TheTaskScheduler);

                return true;

            }

            return false;

        //    Task NextTask = myLastTaskFunc().ContinueWith(ContinueMain, TheCancellationToken, TheContinuationOptions, TheTaskScheduler);

        //    myEnqueueNextTaskAction(NextTask);

        }

        protected bool Continue(object TheState)
        {

            if(!CheckIsContinuing)
            {

                myNextTask = myCurrentTask.ContinueWith(ContinueMain);

                myNextState = TheState;

                return true;

            }

            return false;

        //    Task NextTask = myLastTaskFunc().ContinueWith(ContinueMain);

        //    myEnqueueNextTaskAction(NextTask);

        //    myAddStateAction(NextTask, TheState);

        }

        protected bool Continue(object TheState, CancellationToken TheCancellationToken)
        {

            if(!CheckIsContinuing)
            {

                myNextTask = myCurrentTask.ContinueWith(ContinueMain, TheCancellationToken);

                myNextState = TheState;

                return true;

            }

            return false;

        //    Task NextTask = myLastTaskFunc().ContinueWith(ContinueMain, TheCancellationToken);

        //    myEnqueueNextTaskAction(NextTask);

        //    myAddStateAction(NextTask, TheState);

        }

        protected bool Continue(object TheState, TaskContinuationOptions TheContinuationOptions)
        {

            if(!CheckIsContinuing)
            {

                myNextTask = myCurrentTask.ContinueWith(ContinueMain, TheContinuationOptions);

                myNextState = TheState;

                return true;

            }

            return false;

        //    Task NextTask = myLastTaskFunc().ContinueWith(ContinueMain, TheContinuationOptions);

        //    myEnqueueNextTaskAction(NextTask);

        //    myAddStateAction(NextTask, TheState);

        }

        protected bool Continue(object TheState, TaskScheduler TheTaskScheduler)
        {

            if(!CheckIsContinuing)
            {

                myNextTask = myCurrentTask.ContinueWith(ContinueMain, TheTaskScheduler);

                myNextState = TheState;

                return true;

            }

            return false;

        //    Task NextTask = myLastTaskFunc().ContinueWith(ContinueMain, TheTaskScheduler);

        //    myEnqueueNextTaskAction(NextTask);

        //    myAddStateAction(NextTask, TheState);

        }

        protected bool Continue(object TheState, CancellationToken TheCancellationToken, TaskContinuationOptions TheContinuationOptions, TaskScheduler TheTaskScheduler)
        {

            if(!CheckIsContinuing)
            {

                myNextTask = myCurrentTask.ContinueWith(ContinueMain, TheCancellationToken, TheContinuationOptions, TheTaskScheduler);

                myNextState = TheState;

                return true;

            }

            return false;

        //    Task NextTask = myLastTaskFunc().ContinueWith(ContinueMain, TheCancellationToken, TheContinuationOptions, TheTaskScheduler);

        //    myEnqueueNextTaskAction(NextTask);

        //    myAddStateAction(NextTask, TheState);

        }

        //private void EnqueueNextTask(Task NextTask)
        //{

        //    myContinuationQueue.Enqueue(NextTask);

        //}

        //private void InitaliseContinuationQueue(Task NextTask)
        //{

        //    myContinuationQueue = new Queue<Task>();

        //    myContinuationQueueCountFunc = GetContinuationQueueCount;

        //    myIsContinuingFunc = GetIsContinuing;

        //    myLastTaskFunc = GetLastTask;

        //    myContinuationQueue.Enqueue(NextTask);

        //    myEnqueueNextTaskAction = EnqueueNextTask;

        //}

        //private void AddState(Task NextTask, object TheState)
        //{

        //    myContinuationQueueStateIndex.Add(NextTask, TheState);

        //}

        //private void InitaliseContinuationQueueStateIndex(Task NextTask, object TheState)
        //{

        //    myContinuationQueueStateIndex = new Dictionary<Task, object>();

        //    myContinuationQueueStateIndexCountFunc = GetContinuationQueueStateIndexCount;

        //    myContinuationQueueStateIndexHasItemsFunc = GetContinuationQueueStateIndexHasItems;

        //    myContinuationQueueStateIndex.Add(NextTask, TheState);

        //    myAddStateAction = AddState;

        //}
        
    }

    //public abstract class BareIsolatedTask<TResult> : IBaseIsolatedTask, IDisposable
    //{

    //    private Task<TResult> myTask;

    //    private bool myIsActive;

    //    public BareIsolatedTask() //bool StartNow = false
    //    {

    //        //if (StartNow)
    //        //{

    //        myTask = new Task<TResult>(RunMain);
                
    //        //}
    //        //else
    //        //{

    //        //    myTask = Task<TResult>.Factory.StartNew(RunMain);

    //        //}

    //    }

    //    protected void Initalise()
    //    {

    //        if(myTask == null)
    //            myTask = new Task<TResult>(RunMain);

    //    }

    //    public void Execute()
    //    {

    //        myTask.Start();

    //    }

    //    public void Execute(TaskScheduler TheTaskScheduler)
    //    {

    //        myTask.Start(TheTaskScheduler);
            
    //    }

    //    //New Thread Starts here!
    //    private TResult RunMain()
    //    {

    //        if (!myIsActive)
    //        {

    //            try
    //            {

    //                myIsActive = true;

    //                return Main();

    //            }
    //            finally
    //            {

    //                myIsActive = false;

    //            }

    //        }

    //        //Error!

    //        return default(TResult);

    //    }

    //    protected abstract TResult Main();

    //    public Task<TResult> TheTask
    //    {

    //        get
    //        {

    //            return myTask;

    //        }

    //    }

    //    public bool IsActive
    //    {

    //        get
    //        {

    //            return myIsActive;

    //        }

    //    }

    //    public void ReInstantiateTask()
    //    {

    //        if (!myIsActive)
    //        {

    //            myTask = new Task<TResult>(RunMain);

    //        }

    //    }

    //    public void Dispose()
    //    {

    //        myTask.Dispose();

    //    }

    //}

}
