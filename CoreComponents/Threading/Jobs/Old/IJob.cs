using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.Jobs
{

    public interface IJob
    {

        IJobHandler Handler
        {

            get;

        }

        //bool HasCompleted
        //{

        //    get;

        //}

        //bool HasFailed
        //{

        //    get;

        //}

        bool CancelationRequested
        {

            get;
            set;

        }

        bool PauseRequseted
        {

            get;
            set;

        }

        //bool HasBeenCanceled
        //{

        //    get;

        //}

        //void Cancel();

        JobState State
        {

            get;

        }

        void Active();

        void Completed();

        void Failed();

        void Failed(Exception TheException);

        void Canceling();

        void Canceled();

        void Paused();

        void WaitingToStart();

        void Waiting();

        void WaitingForInput();

        void Deactivate();

        bool HasEnded
        {

            get;

        }

        bool HasStarted
        {

            get;

        }

        bool IsOwnedByThisThread();

        bool Take();

        Exception Exception
        {

            get;

        }

        bool HasException
        {

            get;

        }

        bool IsActive
        {

            get;

        }

        bool IsCanceled
        {

            get;

        }

        bool IsCanceling
        {

            get;

        }

        bool IsCompleted
        {

            get;

        }

        bool IsFailed
        {

            get;

        }

        bool IsPaused
        {

            get;

        }

        bool IsWaiting
        {

            get;

        }

        bool IsWaitingForInput
        {

            get;

        }

        bool IsWaitingToStart
        {

            get;

        }

        bool IsDeactivated
        {

            get;

        }

        string Message
        {

            get;
            set;

        }

    }

    public interface IJob<TJobHandler> : IJob where TJobHandler : IJobHandler
    {

        TJobHandler Handler
        {

            get;

        }

    }

}
