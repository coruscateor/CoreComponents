using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading.SubThreading
{
    
    public class IsolatedThreadException : Exception
    {

        protected readonly Type myType;

        public IsolatedThreadException(IIsolatedThread isolatedThread)
            : base()
        {

            myType = isolatedThread.GetType();

        }

        public IsolatedThreadException(IIsolatedThread isolatedThread, string message)
            : base(message)
        {

            myType = isolatedThread.GetType();

        }

        public IsolatedThreadException(IIsolatedThread isolatedThread, Exception innerException)
            : base("", innerException)
        {

            myType = isolatedThread.GetType();

        }

        public IsolatedThreadException(IIsolatedThread isolatedThread, string message, Exception innerException)
            : base(message, innerException)
        {

            myType = isolatedThread.GetType();

        }

        public Type Type
        {

            get
            {

                return myType;

            }

        }

    }

}
