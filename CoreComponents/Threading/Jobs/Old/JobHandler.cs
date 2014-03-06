using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.Jobs
{

    public abstract class JobHandler<TJob> : IJobHandler where TJob : IJob
    {

        protected TJob myJob;

        protected bool myLogEvents;

        public JobHandler(TJob TheJob)
        {

            myJob = TheJob;

        }

        //public event EventHandler<MessageEventArgs> LogEvent;

        //public event EventHandler<MessageEventArgs> ErrorLogEvent;

        public bool LogEvents
        {

            get
            {

                return myLogEvents;

            }
            set
            {

                myLogEvents = value;

            }

        }

        //public virtual bool CheckProgress()
        //{

        //    return myJob.CheckProgress();

        //}

        public bool IsActive
        {

            get
            {

                return myJob.IsActive;

            }

        }

        public bool IsCanceling
        {

            get
            {

                return myJob.State == JobState.Canceling;

            }

        }

        //public bool HasCompleted
        //{

        //    get
        //    {

        //        return myJob.HasCompleted;

        //    }

        //}

        //public bool HasFailed
        //{

        //    get
        //    {

        //        return myJob.HasFailed; 

        //    }

        //}

        //public bool HasBeenCanceled
        //{

        //    get
        //    {

        //        return myJob.HasBeenCanceled;

        //    }

        //}

        public void RequestCancelation()
        {

            if (myJob.CancelationRequested != true)
                myJob.CancelationRequested = true;

        }

        public void RequestPause()
        {

            if (myJob.PauseRequseted != true)
                myJob.CancelationRequested = true;

        }

        public bool PauseRequested
        {

            get
            {

                return myJob.PauseRequseted;

            }

        }

        public bool CancelationRequested
        {

            get
            {

                return myJob.CancelationRequested;

            }

        }

        public JobState State
        {

            get
            {

                return myJob.State;

            }

        }

        public Exception Exception
        {

            get
            {

                return myJob.Exception;

            }

        }

        public bool HasException
        {

            get
            {

                return myJob.HasException;

            }

        }

        public bool IsCanceled
        {

            get
            {

                return myJob.IsCanceled;

            }

        }

        public bool IsCompleted
        {

            get
            {

                return myJob.IsCompleted;

            }

        }

        public bool IsFailed
        {

            get
            {

                return myJob.IsFailed;

            }

        }

        public bool IsPaused
        {

            get
            {

                return myJob.IsPaused;

            }

        }

        public bool IsWaiting
        {

            get
            {

                return myJob.IsWaiting;

            }

        }

        public bool IsWaitingForInput
        {

            get
            {

                return myJob.IsWaitingForInput;

            }

        }

        public bool IsWaitingToStart
        {

            get
            {

                return myJob.IsWaitingForInput;

            }

        }

        public bool IsDeactivated
        {

            get
            {

                return myJob.IsDeactivated;

            }

        }

        public string Message
        {

            get
            {

                return myJob.Message;

            }

        }

    }

}
