using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace CoreComponents.Data
{
    public class DbConnectionTester //: IEnabled
    {

        public delegate void SuccessDelegate(MessageEventArgs<DbConnectionTester> Parameter);

        //public delegate void FailureDelegate(ErrorEventArgs<DbConnectionTester> Parameter);

        public delegate void ConnectionChangedDelegate(SenderEventArgs<DbConnectionTester> Parameter);

        public event SuccessDelegate Success;

        //public event FailureDelegate Failure;

        public event ConnectionChangedDelegate ConnectionChanged;

        DbConnection myConnection;

        object myLockObject = new object();

        //IChangeDbConnection myIChangeDbConnection;

        //bool myIsEnabled;

        /*
        public DbConnectionTester(IChangeDbConnection ChangeDbConnection)
        {

            myIChangeDbConnection = ChangeDbConnection;

        }
        */

        public DbConnectionTester() 
        {
        }

        public DbConnectionTester(DbConnection TheConnection)
        {

            myConnection = TheConnection;

        }


        void OnSuccess()
        {

            if (Success != null)
                Success(new MessageEventArgs<DbConnectionTester>(this, "Connection Succeeded!"));

        }

        void OnFailure(Exception e)
        {

            //if (Failure != null)
                //Failure(new ErrorEventArgs<DbConnectionTester>(this, e, "Connection Failed."));

        }

        void OnDbConnectionChanged() 
        {

            if (ConnectionChanged != null)
                ConnectionChanged(new SenderEventArgs<DbConnectionTester>(this));

        }

        public void Test()
        {

            lock (myLockObject)
            {

                if (myConnection != null)
                {

                    try
                    {

                        myConnection.Open();

                        OnSuccess();

                    }
                    catch (Exception e)
                    {

                        OnFailure(e);

                    }
                    finally
                    {

                        myConnection.Close();

                    }

                }

            }

        }

        public DbConnection Connection
        {

            get
            {

                return myConnection;

            }
            set 
            {

                lock (myLockObject)
                {

                    myConnection = value;

                    OnDbConnectionChanged();

                }
            }

        }

        public bool HasConnection() 
        {

            return myConnection != null;

        }

        /*
        void myIChangeDbConnection_DbConnectionChanged(DbConnectionEventArgs<IChangeDbConnection> Somethin)
        {
            myConnection = Somethin.Connection;
        }

        public void Enable()
        {
            if (myIsEnabled)
            {

                myIChangeDbConnection.DbConnectionChanged += myIChangeDbConnection_DbConnectionChanged;

                myIsEnabled = true;

            }
        }

        public bool IsEnabled
        {
            get
            {
                return myIsEnabled;
            }
            set
            {
                if (value)
                {

                    Enable();

                } else
                {

                    Disable();

                }
            }
        }

        public void Disable()
        {

            if (!myIsEnabled)
            {

                myIChangeDbConnection.DbConnectionChanged -= myIChangeDbConnection_DbConnectionChanged;

            }

        }
         * */

    }
}
