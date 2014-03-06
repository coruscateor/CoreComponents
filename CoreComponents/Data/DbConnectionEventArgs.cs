using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace CoreComponents.Data
{

    public class DbConnectionEventArgs<TSender> : SenderEventArgs<TSender>
    {

        DbConnection myConnection;

        public DbConnectionEventArgs(TSender Sender, DbConnection Connection)
            : base(Sender)
        {

            myConnection = Connection;

        }

        public DbConnection Connection
        {

            get
            {

                return myConnection;

            }

        }

    }

    /*
    public class DbMessageEventArgs<TSender> : MessageEventArgs<TSender>
    {

        DbConnection myConnection;

        public DbMessageEventArgs(TSender Sender, string Message, DbConnection Connection) : base(Sender, Message)
        {

            myConnection = Connection;

        }

        public DbConnection Connection
        {

            get
            {

                return myConnection;

            }

        }

    }
    */
}
