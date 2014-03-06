using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.Jobs
{

    public interface IJobHandler
    {

        //event EventHandler<MessageEventArgs> LogEvent;

        //event EventHandler<MessageEventArgs> ErrorLogEvent;

        bool LogEvents
        {

            get;
            set;

        }

        //bool CheckProgress();

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

        void RequestCancelation();

        void RequestPause();

        JobState State
        {

            get;

        }

        bool PauseRequested
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

    }

    //public interface IJobHandler<out TResult> : IJobHandler
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
