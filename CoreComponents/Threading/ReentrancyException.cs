using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading
{
    
    public class ReentrancyException : Exception
    {

        protected readonly DateTime myAt;

        public ReentrancyException(bool utc = false)
            : base()
        {

            if(utc)
                myAt = DateTime.UtcNow;
            else
                myAt = DateTime.Now;

        }


        public ReentrancyException(string message, bool utc = false)
            : base(message)
        {

            if(utc)
                myAt = DateTime.UtcNow;
            else
                myAt = DateTime.Now;

        }

        public ReentrancyException(string message, Exception innerException, bool utc = false)
            : base(message, innerException)
        {

            if(utc)
                myAt = DateTime.UtcNow;
            else
                myAt = DateTime.Now;

        }

        public DateTime At
        {

            get
            {

                return myAt;

            }

        }

    }

}
