using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    public class ResultsEventArgs<TResult> : SenderEventArgs
    {

        protected ReadOnlyCollection<TResult> myResults;

        public ResultsEventArgs(object TheSender, ReadOnlyCollection<TResult> TheResults)
            : base(TheSender)
        {

            myResults = new ReadOnlyCollection<TResult>(TheResults);

        }

        public ResultsEventArgs(object TheSender, IEnumerable<TResult> TheResults)
            : base(TheSender)
        {

            myResults = new ReadOnlyCollection<TResult>(new List<TResult>(TheResults));

        }

        public ReadOnlyCollection<TResult> TheResults
        {

            get
            {

                return myResults;

            }

        }

    }

}
