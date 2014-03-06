using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    public class CaughtExecption : ICaughtExecption
    {

        protected readonly Exception myException;

        public CaughtExecption(Exception TheException)
        {

            myException = TheException;

        }

        public Exception Exception
        {

            get
            {

                return myException;

            }

        }

    }

}
