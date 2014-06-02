using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading.Jobs
{

    [Serializable]
    public class MonitorJob
    {

        protected JobState myJobState = JobState.WaitingToStart;

        protected bool myCancelationRequested;

        protected bool myPausalRequested;

        protected Exception myException;

        protected string myMessage;

        protected object myJobStateLockObject = new object();

        protected object myCancelationRequestedLockObject = new object();

        protected object myPausalRequestedLockObject = new object();

        protected object myExceptionLockObject = new object();

        protected object myMessageLockObject = new object();

        public MonitorJob()
        {
        }

        public JobState State
        {

            get
            {

                lock(myJobStateLockObject)
                {

                    return myJobState;

                }

            }
            protected set
            {

                lock(myJobStateLockObject)
                {

                    myJobState = value;

                }

            }

        }

        public string Message
        {

            get
            {

                lock(myMessageLockObject)
                {

                    return myMessage;

                }

            }
            set
            {

                lock(myMessageLockObject)
                {

                    myMessage = value;

                }

            }

        }

        public bool CancelationRequested
        {

            get
            {

                lock(myCancelationRequestedLockObject)
                {

                    return myCancelationRequested;

                }

            }
            set
            {

                lock(myCancelationRequestedLockObject)
                {

                    myCancelationRequested = value;

                }

            }

        }

        public bool IsActive
        {

            get
            {

                lock(myJobStateLockObject)
                {

                    return myJobState == JobState.Active;

                }

            }

        }

        public bool IsCanceled
        {

            get
            {

                lock(myJobStateLockObject)
                {

                    return myJobState == JobState.Canceled;

                }

            }

        }

        public bool IsCanceling
        {

            get
            {

                lock(myJobStateLockObject)
                {

                    return myJobState == JobState.Canceling;

                }

            }

        }

        public bool IsCompleted
        {

            get
            {
                
                lock(myJobStateLockObject)
                {

                    return myJobState == JobState.Completed;

                }

            }

        }

        public bool HasFailed
        {

            get
            {

                lock(myJobStateLockObject)
                {

                    return myJobState == JobState.Failed;

                }

            }

        }

        public bool IsPaused
        {

            get
            {

                lock(myJobStateLockObject)
                {

                    return myJobState == JobState.Paused;

                }

            }

        }

        public bool IsWaiting
        {

            get
            {

                lock(myJobStateLockObject)
                {

                    return myJobState == JobState.Waiting;

                }

            }

        }

        public bool IsWaitingForInput
        {

            get
            {

                lock(myJobStateLockObject)
                {

                    return myJobState == JobState.WaitingForInput;

                }

            }

        }

        public bool IsWaitingToStart
        {

            get
            {

                lock(myJobStateLockObject)
                {

                    return myJobState == JobState.WaitingToStart;

                }

            }

        }

        public bool IsDeactivated
        {

            get
            {

                lock(myJobStateLockObject)
                {

                    return myJobState == JobState.Deactivated;

                }

            }

        }

        public void Active()
        {

            lock(myJobStateLockObject)
            {

                if(myJobState == JobState.WaitingToStart || myJobState == JobState.Waiting || myJobState == JobState.WaitingForInput || myJobState == JobState.Paused)
                    State = JobState.Active;

            }

        }

        public void Completed()
        {

            bool CurrentHasEnded = HasEnded;

            bool CurrentIsDeactivated = IsDeactivated;

            if(!CurrentHasEnded && !CurrentIsDeactivated)
                State = JobState.Completed;

        }

        public void Failed()
        {

            bool CurrentHasEnded = HasEnded;

            bool CurrentIsDeactivated = IsDeactivated;

            if(!CurrentHasEnded && !CurrentIsDeactivated)
                State = JobState.Failed;

        }

        public void Failed(string TheMessage)
        {

            bool CurrentHasEnded = HasEnded;

            bool CurrentIsDeactivated = IsDeactivated;

            if(!CurrentHasEnded && !CurrentIsDeactivated)
            {

                Message = TheMessage;

                State = JobState.Failed;

            }

        }

        public void Failed(Exception TheException)
        {

            bool CurrentHasEnded = HasEnded;

            bool CurrentIsDeactivated = IsDeactivated;

            if(!CurrentHasEnded && !CurrentIsDeactivated)
            {

                Exception = TheException;

                State = JobState.Failed;

            }

        }

        public void Canceling()
        {

            bool CurrentHasEnded = HasEnded;

            bool CurrentIsDeactivated = IsDeactivated;

            if(!CurrentHasEnded && !CurrentIsDeactivated)
                State = JobState.Canceling;

        }

        public void Canceled()
        {

            bool CurrentHasEnded = HasEnded;

            bool CurrentIsDeactivated = IsDeactivated;

            if(!CurrentHasEnded && !CurrentIsDeactivated)
                State = JobState.Canceled;

        }

        public void Paused()
        {

            bool CurrentHasEnded = HasEnded;

            bool CurrentIsDeactivated = IsDeactivated;

            if(!CurrentHasEnded && !CurrentIsDeactivated)
                State = JobState.Paused;

        }

        public void Waiting()
        {

            bool CurrentHasEnded = HasEnded;

            bool CurrentIsDeactivated = IsDeactivated;

            if(!CurrentHasEnded && !CurrentIsDeactivated)
                State = JobState.Waiting;

        }

        public virtual void WaitingForInput()
        {

            bool CurrentHasEnded = HasEnded;

            bool CurrentIsDeactivated = IsDeactivated;

            bool CurrentIsWaitingForInput = IsWaitingForInput;

            if(!CurrentIsWaitingForInput && !CurrentHasEnded && !CurrentIsDeactivated)
                State = JobState.WaitingForInput;

        }

        public virtual void WaitingToStart()
        {

            bool CurrentIsDeactivated = IsDeactivated;

            bool CurrentIsWaitingToStart = IsWaitingToStart;

            if(!CurrentIsWaitingToStart && CurrentIsDeactivated)
                Reset();

        }

        protected virtual void Reset()
        {

            //if(myJobState != JobState.Deactivated)
            //    throw new Exception("The job needs to be in the Deactivated state to reset fields.");

            CancelationRequested = false;

            PausalRequested = false;

            Exception = null;

            Message = null;

            State = JobState.WaitingToStart;

        }

        public void Deactivate()
        {

            if (!IsDeactivated || HasEnded)
            {

                State = JobState.Deactivated;

            }

        }

        public Exception Exception
        {

            get
            {

                lock(myExceptionLockObject)
                {

                    return myException;

                }

            }
            set
            {

                lock(myExceptionLockObject)
                {

                    myException = value;

                }

            }

        }

        public bool HasException
        {

            get
            {

                lock(myExceptionLockObject)
                {

                    return myException != null;

                }

            }

        }

        public bool HasFailedWithException
        {

            get
            {

                return State == JobState.Failed && Exception != null;

            }

        }

        public bool HasEnded
        {

            get
            {

                JobState CurrentState = State;

                return CurrentState == JobState.Completed || CurrentState == JobState.Failed || CurrentState == JobState.Canceled;

            }

        }

        public bool HasStarted
        {

            get
            {

                JobState CurrentState = State;

                return CurrentState != JobState.WaitingToStart && CurrentState != JobState.Completed && CurrentState != JobState.Failed && CurrentState != JobState.Deactivated && CurrentState != JobState.Canceled && CurrentState != JobState.Canceling;

            }

        }

        //public void ThrowIfInActive()
        //{

        //    if (!IsActive)
        //        throw new Exception("The Job must be active");

        //}

        //public void ThrowIfActive()
        //{

        //    if(IsActive)
        //        throw new Exception("The Job must be inactive");

        //}

        public void RequestCancelation()
        {

            lock(myCancelationRequestedLockObject)
            {

                if(!myCancelationRequested)
                    myCancelationRequested = true;

            }

        }

        public void RequestPausal()
        {

            lock(myExceptionLockObject)
            {

                if(!myPausalRequested)
                    myPausalRequested = true;

            }

        }

        public bool PausalRequested
        {

            get
            {

                lock(myPausalRequestedLockObject)
                {

                    return myPausalRequested;

                }

            }
            set
            {

                lock(myPausalRequestedLockObject)
                {

                    myPausalRequested = value;

                }

            }

        }

        public bool HasMessage
        {

            get
            {

                return string.IsNullOrEmpty(Message);

            }

        }

    }

}
