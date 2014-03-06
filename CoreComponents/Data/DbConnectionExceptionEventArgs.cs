using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace CoreComponents.Data
{
    public class DbConnectionExceptionEventArgs<TSender> : MessageEventArgs<TSender>
    {

        Exception myException;

        public DbConnectionExceptionEventArgs(TSender Sender, string Message, DbConnection Connection, Exception e)
            : base(Sender, Message)
        {

            myException = e;

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
