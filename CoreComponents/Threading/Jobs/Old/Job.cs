using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading.Jobs
{

    public abstract class Job<TJobHandler> : IJob<TJobHandler> where TJobHandler : IJobHandler
    {

        //public event EventHandler<EventArgs> CompletedFailedOrCanceled;

        protected TJobHandler myHandler;

        //protected IJobScheduler myJobScheduler;

        volatile JobState myJobState = JobState.WaitingToStart;

        volatile bool myCancelationRequested;

        volatile bool myPauseRequested;

        Thread myOwner;

        Exception myException;

        string myMessage;

        public Job()
        {
        }

        protected virtual void Initalise()
        {

            myOwner = Thread.CurrentThread;

        }

        //public Job(IJobScheduler TheJobScheduler)
        //{

        //    myJobScheduler = TheJobScheduler;

        //}

        //protected void OnCompletedFailedOrCanceled()
        //{

        //    if (CompletedFailedOrCanceled != null)
        //        CompletedFailedOrCanceled(this, EventArgs.Empty);

        //}

        public TJobHandler Handler
        {

            get
            {

                return myHandler;

            }

        }

        //IJobHandler Handler
        //{

        //    get
        //    {

        //        return myHandler;

        //    }

        //}

        public JobState State
        {

            get
            {

                return myJobState;

            }

        }

        public string Message
        {

            get
            {

                return myMessage;

            }
            set
            {

                myMessage = value;

            }

        }

        public bool PauseRequseted
        {

            get
            {

                return myPauseRequested;

            }
            set
            {

                myPauseRequested = value;

            }

        }

        public bool CancelationRequested
        {

            get
            {

                return myCancelationRequested;

            }
            set
            {

                myCancelationRequested = value;

            }

        }

        public bool IsActive
        {

            get
            {

                return myJobState == JobState.Active;

            }

        }

        public bool IsCanceled
        {

            get
            {

                return myJobState == JobState.Canceled;

            }

        }

        public bool IsCanceling
        {

            get
            {

                return myJobState == JobState.Canceling;

            }

        }

        public bool IsCompleted
        {

            get
            {

                return myJobState == JobState.Completed;

            }

        }

        public bool IsFailed
        {

            get
            {

                return myJobState == JobState.Failed;

            }

        }

        public bool IsPaused
        {

            get
            {

                return myJobState == JobState.Paused;

            }

        }

        public bool IsWaiting
        {

            get
            {

                return myJobState == JobState.Waiting;

            }

        }

        public bool IsWaitingForInput
        {

            get
            {

                return myJobState == JobState.WaitingForInput;

            }

        }

        public bool IsWaitingToStart
        {

            get
            {

                return myJobState == JobState.WaitingToStart;

            }

        }

        public bool IsDeactivated
        {

            get
            {

                return myJobState == JobState.Deactivated;

            }

        }

        //public IJobScheduler JobScheduler
        //{

        //    get
        //    {

        //        return myJobScheduler;

        //    }
        //    set
        //    {

        //        if (value == null)
        //            throw new Exception("The Job must have a task scheduler");

        //        myJobScheduler = value;

        //    }

        //}

        public void Active()
        {

            if (myJobState == JobState.WaitingToStart || myJobState == JobState.Waiting || myJobState == JobState.WaitingForInput || myJobState == JobState.Paused)
            {

                myJobState = JobState.Active;

            }

        }

        public void Completed()
        {

            if (!HasEnded && !IsDeactivated)
                myJobState = JobState.Completed;

        }

        public void Failed()
        {

            if (!HasEnded && !IsDeactivated)
                myJobState = JobState.Failed;

        }

        public void Failed(Exception TheException)
        {

            if (!HasEnded && !IsDeactivated)
            {

                myException = TheException;

                myJobState = JobState.Failed;

            }

        }

        public void Canceling()
        {

            if (!HasEnded && !IsDeactivated)
                myJobState = JobState.Canceling;

        }

        public void Canceled()
        {

            if (!HasEnded && !IsDeactivated)
                myJobState = JobState.Canceled;

        }

        public void Paused()
        {

            if (!HasEnded && !IsDeactivated)
                myJobState = JobState.Paused;

        }

        public void Waiting()
        {

            if (!HasEnded && !IsDeactivated)
                myJobState = JobState.Waiting;

        }

        public virtual void WaitingForInput()
        {

            if (!IsWaitingForInput && !HasEnded && !IsDeactivated)
            {

                myJobState = JobState.WaitingForInput;

            }

        }

        [Guarded]
        public virtual void WaitingToStart()
        {

            ThrowIfNotOwningThread();

            if (!IsWaitingToStart)
            {

                myJobState = JobState.WaitingToStart;

                Reset();

            }

        }

        protected virtual void Reset()
        {

            if (myJobState != JobState.WaitingToStart)
                throw new Exception("The job needs to be in the WaitingToStart state to reset fields.");

            if (myCancelationRequested == true)
                myCancelationRequested = false;

            if (myPauseRequested == true)
                myPauseRequested = false;

            if (HasException)
                myException = null;

        }

        [Guarded]
        public void Deactivate()
        {

            ThrowIfNotOwningThread();

            if (!IsDeactivated || HasEnded)
            {

                myJobState = JobState.Deactivated;

            }

        }

        public bool IsOwnedByThisThread()
        {

            return myOwner == Thread.CurrentThread;

        }

        public void ThrowIfNotOwningThread()
        {

            if (!IsOwnedByThisThread())
                throw new Exception("Invalid Access");

        }

        public bool Take()
        {

            if (IsDeactivated)
            {

                if (myOwner != Thread.CurrentThread)
                    myOwner = Thread.CurrentThread;

                return true;

            }

            return false;

        }

        public Exception Exception
        {

            get
            {

                return myException;

            }

        }

        public bool HasException
        {

            get
            {

                return myException != null;

            }

        }

        public bool HasEnded
        {

            get
            {

                return myJobState == JobState.Completed || myJobState == JobState.Failed || myJobState == JobState.Canceled;

            }

        }

        public bool HasStarted
        {

            get
            {

                //return myJobState == JobState.Active || myJobState == JobState.WaitingForInput || myJobState == JobState.Waiting || myJobState == JobState.Paused || myJobState == JobState.Completed || myJobState == JobState.Canceled || myJobState == JobState.Canceling || myJobState == JobState.Failed;

                return myJobState != JobState.WaitingToStart;

            }

        }

        public void ThrowIfInActive()
        {

            if (!IsActive)
                throw new Exception("The Job must be active");

        }

        //protected abstract void StartJob();

        //public void Cancel()
        //{

        //    if (myJobState != JobState.Canceling)
        //    {

        //        CancelJob();

        //        myJobState = JobState.Canceling;

        //    }

        //}

        //protected abstract void CancelJob();

        //public abstract bool CheckProgress();
        //{

        //    return false;

        //}

        IJobHandler IJob.Handler
        {

            get
            {

                return myHandler;

            }

        }

    }

    //public abstract class Job<TJobHandler, TResult> : IJob<TJobHandler> where TJobHandler : IJobHandler<TResult>
    //{

    //    TResult Result
    //    {

    //        get;

    //    }

    //    bool HasResult
    //    {

    //        get;

    //    }

    //}

}
