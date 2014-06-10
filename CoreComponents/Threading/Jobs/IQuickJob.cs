using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading.Jobs
{
    
    public interface IQuickJob
    {

        QuickJobState State
        {

            get;

        }

        string FailureMessage
        {

            get;

        }

        bool TryGetFailureMessage(out string TheFailureMessage);

        object FailureData
        {

            get;

        }

        bool TryGetFailureData(out object TheFailureData);

        void Reset();

        bool IsPending
        {

            get;

        }

        bool WasSuccessful
        {

            get;

        }

        bool HasFailed
        {

            get;

        }

        bool ErrorOccured
        {

            get;

        }

        void Failed();

        Exception Exception
        {

            get;
            set;

        }

        bool HasException
        {

            get;

        }

        bool TryGetException(out Exception TheException);

        bool TryGetException(Action<Exception> TheAction);

    }

}
