using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.Jobs
{

    public interface IJobHandler //: IDisposable
    {
        
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

        void Deactivate();

        void RequestCancelation();

        void RequestPausal();

        JobState State
        {

            get;

        }

        bool PausalRequested
        {

            get;

        }

        bool CancelationRequested
        {

            get;

        }

        string Message
        {

            get;

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
