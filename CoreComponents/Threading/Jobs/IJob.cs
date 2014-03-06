using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.Jobs
{

    public interface IJob //: IDisposable
    {

        bool CancelationRequested
        {

            get;
            set;

        }

        JobState State
        {

            get;

        }

        void Active();

        void Completed();

        void Failed();

        void Failed(string TheMessage);

        void Failed(Exception TheException);

        void RequestCancelation();

        void Canceling();

        void Canceled();

        void Paused();

        void RequestPausal();

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

        bool HasFailed
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

        bool PausalRequested
        {

            get;
            set;

        }
        
        string Message
        {

            get;
            set;

        }

        bool HasMessage
        {

            get;

        }

        bool HasFailedWithException
        {

            get;

        }

        //bool CanPause
        //{

        //    get;

        //}

    }

}
