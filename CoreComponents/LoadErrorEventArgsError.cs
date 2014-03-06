using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace CoreComponents
{
    public class LoadErrorEventArgs<TSender, TSource, TException> : LoadEventArgs<TSender, TSource> where TException : _Exception
    {

        TException myException;

        public LoadErrorEventArgs(TSender sender, TSource theSource, TException theException)
           : base(sender, theSource)
        {

            myException = theException;

        }

        public TException Exception
        {

            get
            {

                return myException;

            }

        }

    }
}
