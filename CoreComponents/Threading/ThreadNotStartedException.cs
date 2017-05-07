using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading
{
    
    public class ThreadNotStartedException : Exception
    {

        public ThreadNotStartedException()
            : base("Thread not started")
        {
        }

        public ThreadNotStartedException(Exception innerException)
            : base("Thread not started", innerException)
        {
        }

    }

}
