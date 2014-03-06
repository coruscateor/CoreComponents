using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.Jobs
{

    [Serializable]
    public abstract class JobHandler<TJob> : IJobHandler where TJob : IHandledJob
    {

        protected TJob myJob;

        //protected bool myLogEvents;

        public JobHandler(TJob TheJob)
        {

            myJob = TheJob;

        }

        //public bool LogEvents
        //{

        //    get
        //    {
                
        //        return myLogEvents;
            
        //    }
        //    set
        //    {

        //        myLogEvents = value;

        //    }

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

        public void RequestCancelation()
        {

            myJob.RequestCancelation();

        }

        public void RequestPausal()
        {

            myJob.RequestPausal();

        }

        public bool PausalRequested
        {

            get
            {

                return myJob.PausalRequested;

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

        public bool HasFailed
        {

            get
            {
                
                return myJob.HasFailed;
            
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

        public void Deactivate()
        {

            myJob.Deactivate();

        }
        
        public string Message
        {

            get
            {

                return myJob.Message;

            }

        }

        public bool HasMessage
        {

            get
            {

                return myJob.HasMessage;

            }

        }

        public bool HasFailedWithException
        {

            get
            {

                return myJob.HasFailedWithException;

            }

        }

        //public bool CanPause
        //{

        //    get
        //    {

        //        return myJob.CanPause;

        //    }

        //}

        public bool ReportProgress
        {

            get
            {

                return myJob.ReportProgress;

            }
            set
            {

                myJob.ReportProgress = value;

            }

        }

        public void DoReportProgress()
        {

            myJob.ReportProgress = true;

        }
        
    }

}
