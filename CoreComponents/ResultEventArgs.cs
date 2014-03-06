using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    public class ResultEventArgs<TResult> : SenderEventArgs
    {

        protected TResult myResult;

        public ResultEventArgs(object TheSender, TResult TheResult) : base(TheSender)
        {

            myResult = TheResult;

        }

        public TResult Result
        {

            get
            {

                return myResult;

            }

        }

    }

}
