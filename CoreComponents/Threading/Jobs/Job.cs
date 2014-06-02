﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading.Jobs
{

    [Serializable]
    public abstract class Job : IJob
    {

        protected JobState myJobState = JobState.WaitingToStart;

        protected bool myCancelationRequested;

        protected bool myPausalRequested;

        protected Exception myException;

        protected string myMessage;

        protected SpinLock myJobStateSpinLock;

        protected SpinLock myCancelationRequestedSpinLock;

        protected SpinLock myPausalRequestedSpinLock;

        protected SpinLock myExceptionSpinLock;

        protected SpinLock myMessageSpinLock;

        protected bool myUseMemoryBarrier;

        public Job()
        {
        }

        public Job(bool TheUseMemoryBarrier)
        {

            myUseMemoryBarrier = TheUseMemoryBarrier;

        }

        public bool UseMemoryBarrier
        {

            get
            {

                return myUseMemoryBarrier;

            }

        }

        public JobState State
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    myJobStateSpinLock.Enter(ref LockTaken);

                    return myJobState;

                }
                finally
                {

                    if(LockTaken)
                        myJobStateSpinLock.Exit(myUseMemoryBarrier);

                }

            }
            protected set
            {

                bool LockTaken = false;

                try
                {

                    myJobStateSpinLock.Enter(ref LockTaken);

                    myJobState = value;

                }
                finally
                {

                    if(LockTaken)
                        myJobStateSpinLock.Exit(myUseMemoryBarrier);

                }

            }

        }

        public string Message
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    myMessageSpinLock.Enter(ref LockTaken);

                    return myMessage;

                }
                finally
                {

                    if(LockTaken)
                        myMessageSpinLock.Exit(myUseMemoryBarrier);

                }

            }
            set
            {

                bool LockTaken = false;

                try
                {

                    myMessageSpinLock.Enter(ref LockTaken);

                    myMessage = value;

                }
                finally
                {

                    if(LockTaken)
                        myMessageSpinLock.Exit(myUseMemoryBarrier);

                }

            }

        }

        public bool CancelationRequested
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    myCancelationRequestedSpinLock.Enter(ref LockTaken);

                    return myCancelationRequested;

                }
                finally
                {

                    if(LockTaken)
                        myCancelationRequestedSpinLock.Exit(myUseMemoryBarrier);

                }

            }
            set
            {

                bool LockTaken = false;

                try
                {

                    myCancelationRequestedSpinLock.Enter(ref LockTaken);

                    myCancelationRequested = value;

                }
                finally
                {

                    if(LockTaken)
                        myCancelationRequestedSpinLock.Exit(myUseMemoryBarrier);

                }

            }

        }

        public bool IsActive
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    myJobStateSpinLock.Enter(ref LockTaken);

                    return myJobState == JobState.Active;

                }
                finally
                {

                    if(LockTaken)
                        myJobStateSpinLock.Exit(myUseMemoryBarrier);

                }

            }

        }

        public bool IsCanceled
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    myJobStateSpinLock.Enter(ref LockTaken);

                    return myJobState == JobState.Canceled;

                }
                finally
                {

                    if(LockTaken)
                        myJobStateSpinLock.Exit(myUseMemoryBarrier);

                }

            }

        }

        public bool IsCanceling
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    myJobStateSpinLock.Enter(ref LockTaken);

                    return myJobState == JobState.Canceling;

                }
                finally
                {

                    if(LockTaken)
                        myJobStateSpinLock.Exit(myUseMemoryBarrier);

                }

            }

        }

        public bool IsCompleted
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    myJobStateSpinLock.Enter(ref LockTaken);

                    return myJobState == JobState.Completed;

                }
                finally
                {

                    if(LockTaken)
                        myJobStateSpinLock.Exit(myUseMemoryBarrier);

                }

            }

        }

        public bool HasFailed
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    myJobStateSpinLock.Enter(ref LockTaken);

                    return myJobState == JobState.Failed;

                }
                finally
                {

                    if(LockTaken)
                        myJobStateSpinLock.Exit(myUseMemoryBarrier);

                }

            }

        }

        public bool IsPaused
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    myJobStateSpinLock.Enter(ref LockTaken);

                    return myJobState == JobState.Paused;

                }
                finally
                {

                    if(LockTaken)
                        myJobStateSpinLock.Exit(myUseMemoryBarrier);

                }

            }

        }

        public bool IsWaiting
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    myJobStateSpinLock.Enter(ref LockTaken);

                    return myJobState == JobState.Waiting;

                }
                finally
                {

                    if(LockTaken)
                        myJobStateSpinLock.Exit(myUseMemoryBarrier);

                }

            }

        }

        public bool IsWaitingForInput
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    myJobStateSpinLock.Enter(ref LockTaken);

                    return myJobState == JobState.WaitingForInput;

                }
                finally
                {

                    if(LockTaken)
                        myJobStateSpinLock.Exit(myUseMemoryBarrier);

                }

            }

        }

        public bool IsWaitingToStart
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    myJobStateSpinLock.Enter(ref LockTaken);

                    return myJobState == JobState.WaitingToStart;

                }
                finally
                {

                    if(LockTaken)
                        myJobStateSpinLock.Exit(myUseMemoryBarrier);

                }

            }

        }

        public bool IsDeactivated
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    myJobStateSpinLock.Enter(ref LockTaken);

                    return myJobState == JobState.Deactivated;

                }
                finally
                {

                    if(LockTaken)
                        myJobStateSpinLock.Exit(myUseMemoryBarrier);

                }

            }

        }

        public void Active()
        {

            bool Result;

            bool LockTaken = false;

            myJobStateSpinLock.Enter(ref LockTaken);

            Result = myJobState == JobState.WaitingToStart || myJobState == JobState.Waiting || myJobState == JobState.WaitingForInput || myJobState == JobState.Paused;

            if(LockTaken)
                myJobStateSpinLock.Exit(myUseMemoryBarrier);

            if(Result)
                State = JobState.Active;

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

                bool LockTaken = false;

                try
                {

                    myExceptionSpinLock.Enter(ref LockTaken);

                    return myException;

                }
                finally
                {

                    if(LockTaken)
                        myExceptionSpinLock.Exit(myUseMemoryBarrier);

                }

            }
            set
            {

                bool LockTaken = false;

                try
                {

                    myExceptionSpinLock.Enter(ref LockTaken);

                    myException = value;

                }
                finally
                {

                    if(LockTaken)
                        myExceptionSpinLock.Exit(myUseMemoryBarrier);

                }

            }

        }

        public bool HasException
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    myExceptionSpinLock.Enter(ref LockTaken);

                    return myException != null;

                }
                finally
                {

                    if(LockTaken)
                        myExceptionSpinLock.Exit(myUseMemoryBarrier);

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

            bool LockTaken = false;

            try
            {

                myCancelationRequestedSpinLock.Enter(ref LockTaken);

                if(!myCancelationRequested)
                    myCancelationRequested = true;

            }
            finally
            {

                myCancelationRequestedSpinLock.Exit(myUseMemoryBarrier);

            }

        }

        public void RequestPausal()
        {

            bool LockTaken = false;

            try
            {

                myPausalRequestedSpinLock.Enter(ref LockTaken);

                if(!myPausalRequested)
                    myPausalRequested = true;

            }
            finally
            {

                myPausalRequestedSpinLock.Exit(myUseMemoryBarrier);

            }

        }

        public bool PausalRequested
        {

            get
            {

                bool LockTaken = false;

                try
                {

                    myPausalRequestedSpinLock.Enter(ref LockTaken);

                    return myPausalRequested;

                }
                finally
                {

                    myPausalRequestedSpinLock.Exit(myUseMemoryBarrier);

                }

            }
            set
            {

                bool LockTaken = false;

                try
                {

                    myPausalRequestedSpinLock.Enter(ref LockTaken);

                    myPausalRequested = value;

                }
                finally
                {

                    myPausalRequestedSpinLock.Exit(myUseMemoryBarrier);

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
