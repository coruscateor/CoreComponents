using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents
{

    public class ResultErrorEventArgs<TResult, TError> : ResultEventArgs<TResult>
    {

        protected TError myError;

        public ResultErrorEventArgs(object TheSender, TResult TheResult, TError TheError) : base(TheSender, TheResult)
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
