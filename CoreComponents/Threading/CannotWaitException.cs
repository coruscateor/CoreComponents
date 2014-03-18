using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading
{

    public class CannotWaitException : Exception
    {

        public CannotWaitException()
        {
        }

        public CannotWaitException(string TheMessage) : base(TheMessage)
        {
        }

        public CannotWaitException(string TheMessage, Exception TheInnerException)
        {
        }

    }

}
