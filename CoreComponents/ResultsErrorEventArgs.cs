using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    public class ResultsErrorEventArgs<TResult, TError> : ResultsEventArgs<TResult>
    {

        protected TError myError;

        public ResultsErrorEventArgs(object TheSender, ReadOnlyCollection<TResult> TheResults, TError TheError)
            : base(TheSender, TheResults)
        {

            myError = TheError;

        }

        public TError Error
        {

            get
            {

                return myError;

            }

        }

    }

}
