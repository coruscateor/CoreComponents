using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading.Jobs
{

    [Serializable]
    public abstract class Job : IJob
    {

        JobState myJobState = JobState.WaitingToStart;

        bool myCancelationRequested;

        bool myPausalRequested;

        Exception myException;

        string myMessage;

        public Job()
        {
        }

        public JobState State
        {

            get
            {

                Thread.MemoryBarrier();

                return myJobState;

            }

        }

        public string Message
        {

            get
            {

                Thread.MemoryBarrier();

                return myMessage;

            }
            set
            {

                myMessage = value;

                Thread.MemoryBarrier();

            }

        }

        public bool CancelationRequested
        {

            get
            {

                Thread.MemoryBarrier();

                return myCancelationRequested;

            }
            set
            {

                myCancelationRequested = value;

                Thread.MemoryBarrier();

            }

        }

        public bool IsActive
        {

            get
            {

                Thread.MemoryBarrier();

                return myJobState == JobState.Active;

            }

        }

        public bool IsCanceled
        {

            get
            {

                Thread.MemoryBarrier();

                return myJobState == JobState.Canceled;

            }

        }

        public bool IsCanceling
        {

            get
            {

                Thread.MemoryBarrier();

                return myJobState == JobState.Canceling;

            }

        }

        public bool IsCompleted
        {

            get
            {

                Thread.MemoryBarrier();

                return myJobState == JobState.Completed;

            }

        }

        public bool HasFailed
        {

            get
            {

                Thread.MemoryBarrier();

                return myJobState == JobState.Failed;

            }

        }

        public bool IsPaused
        {

            get
            {

                Thread.MemoryBarrier();

                return myJobState == JobState.Paused;

            }

        }

        public bool IsWaiting
        {

            get
            {

                Thread.MemoryBarrier();

                return myJobState == JobState.Waiting;

            }

        }

        public bool IsWaitingForInput
        {

            get
            {

                Thread.MemoryBarrier();

                return myJobState == JobState.WaitingForInput;

            }

        }

        public bool IsWaitingToStart
        {

            get
            {

                Thread.MemoryBarrier();

                return myJobState == JobState.WaitingToStart;

            }

        }

        public bool IsDeactivated
        {

            get
            {

                Thread.MemoryBarrier();

                return myJobState == JobState.Deactivated;

            }

        }

        public void Active()
        {

            Thread.MemoryBarrier();

            if(myJobState == JobState.WaitingToStart || myJobState == JobState.Waiting || myJobState == JobState.WaitingForInput || myJobState == JobState.Paused)
            {

                myJobState = JobState.Active;

                Thread.MemoryBarrier();

            }

        }

        public void Completed()
        {

            Thread.MemoryBarrier();

            if(!HasEnded && !IsDeactivated)
            {

                myJobState = JobState.Completed;

                Thread.MemoryBarrier();

            }

        }

        public void Failed()
        {

            Thread.MemoryBarrier();

            if(!HasEnded && !IsDeactivated)
            {

                myJobState = JobState.Failed;

                Thread.MemoryBarrier();

            }

        }

        public void Failed(string TheMessage)
        {

            Thread.MemoryBarrier();

            if(!HasEnded && !IsDeactivated)
            {

                Message = TheMessage;

                myJobState = JobState.Failed;

                Thread.MemoryBarrier();

            }

        }

        public void Failed(Exception TheException)
        {

            Thread.MemoryBarrier();

            if(!HasEnded && !IsDeactivated)
            {

                myException = TheException;

                Thread.MemoryBarrier();

                myJobState = JobState.Failed;

                Thread.MemoryBarrier();

            }

        }

        public void Canceling()
        {

            Thread.MemoryBarrier();

            if(!HasEnded && !IsDeactivated)
            {

                myJobState = JobState.Canceling;

                Thread.MemoryBarrier();

            }

        }

        public void Canceled()
        {

            Thread.MemoryBarrier();

            if(!HasEnded && !IsDeactivated)
            {

                myJobState = JobState.Canceled;

                Thread.MemoryBarrier();

            }

        }

        public void Paused()
        {

            Thread.MemoryBarrier();

            if(!HasEnded && !IsDeactivated)
            {

                myJobState = JobState.Paused;

                Thread.MemoryBarrier();

            }

        }

        public void Waiting()
        {

            Thread.MemoryBarrier();

            if(!HasEnded && !IsDeactivated)
            {

                myJobState = JobState.Waiting;

                Thread.MemoryBarrier();

            }

        }

        public virtual void WaitingForInput()
        {

            Thread.MemoryBarrier();

            if(!IsWaitingForInput && !HasEnded && !IsDeactivated)
            {

                myJobState = JobState.WaitingForInput;

                Thread.MemoryBarrier();

            }

        }

        public virtual void WaitingToStart()
        {

            Thread.MemoryBarrier();

            if(!IsWaitingToStart && IsDeactivated)
            {

                Reset();

            }

        }

        protected virtual void Reset()
        {

            //if(myJobState != JobState.Deactivated)
            //    throw new Exception("The job needs to be in the Deactivated state to reset fields.");

            Thread.MemoryBarrier();

            if(myCancelationRequested == true)
            {

                myCancelationRequested = false;

                Thread.MemoryBarrier();

            }

            Thread.MemoryBarrier();

            if(myPausalRequested == true)
            {

                myPausalRequested = false;

                Thread.MemoryBarrier();

            }

            if(HasException)
            {

                myException = null;

                Thread.MemoryBarrier();

            }

            if(HasMessage)
            {

                myMessage = null;

                Thread.MemoryBarrier();

            }

            myJobState = JobState.WaitingToStart;

            Thread.MemoryBarrier();

        }

        public void Deactivate()
        {

            Thread.MemoryBarrier();

            if (!IsDeactivated || HasEnded)
            {

                myJobState = JobState.Deactivated;

                Thread.MemoryBarrier();

            }

        }

        public Exception Exception
        {

            get
            {

                Thread.MemoryBarrier();

                return myException;

            }

        }

        public bool HasException
        {

            get
            {

                Thread.MemoryBarrier();

                return myException != null;

            }

        }

        public bool HasFailedWithException
        {

            get
            {

                Thread.MemoryBarrier();

                return myJobState == JobState.Failed && myException != null;

            }

        }

        public bool HasEnded
        {

            get
            {

                Thread.MemoryBarrier();

                return myJobState == JobState.Completed || myJobState == JobState.Failed || myJobState == JobState.Canceled;

            }

        }

        public bool HasStarted
        {

            get
            {

                Thread.MemoryBarrier();
            	
                return myJobState != JobState.WaitingToStart && myJobState != JobState.Completed && myJobState != JobState.Failed && myJobState != JobState.Deactivated && myJobState != JobState.Canceled && myJobState != JobState.Canceling;

            }

        }

        public void ThrowIfInActive()
        {

            if (!IsActive)
                throw new Exception("The Job must be active");

        }

        public void ThrowIfActive()
        {

            if(IsActive)
                throw new Exception("The Job must be inactive");

        }

        public void RequestCancelation()
        {

            Thread.MemoryBarrier();

            if(!myCancelationRequested)
            {

                myCancelationRequested = true;

                Thread.MemoryBarrier();

            }

        }

        public void RequestPausal()
        {

            Thread.MemoryBarrier();

            if(!myPausalRequested)
            {

                myPausalRequested = true;

                Thread.MemoryBarrier();

            }

        }

        public bool PausalRequested
        {

            get
            {

                Thread.MemoryBarrier();

                return myPausalRequested;

            }
            set
            {

                myPausalRequested = true;

                Thread.MemoryBarrier();

            }

        }

        public bool HasMessage
        {

            get
            {

                Thread.MemoryBarrier();

                return string.IsNullOrEmpty(myMessage);

            }

        }

    }

}
