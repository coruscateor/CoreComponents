using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    public class CancelException : Exception
    {

        public CancelException()
        {
        }

        public CancelException(string message)
            : base(message)
        {
        }

        public CancelException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

    }

}
