using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace CoreComponents.Data
{
    public class ConnectionStringTester<TConnection> where TConnection : DbConnection, new()
    {

        public event Action<MessageEventArgs<ConnectionStringTester<TConnection>>> Success;

        //public event Create<ErrorEventArgs<ConnectionStringTester<TConnection>>>.ADelegate Failure;

        public event Action<SenderEventArgs<ConnectionStringTester<TConnection>>> ConnectionStringChanged;

        protected object myLockObject;

        protected string myConnectionString;

        public ConnectionStringTester() 
        {
        }

        public ConnectionStringTester(string theConnectionString) 
        {

            myConnectionString = theConnectionString;

        }

        void OnSuccess()
        {

            if (Success != null)
                Success(new MessageEventArgs<ConnectionStringTester<TConnection>>(this, "Connection Succeeded!"));

        }

        void OnFailure(Exception e)
        {

            //if (Failure != null)
            //    Failure(new ErrorEventArgs<ConnectionStringTester<TConnection>>(this, e));

        }

        void OnConnectionStringChanged() 
        {

            if (ConnectionStringChanged != null) 
            {

                if (ConnectionStringChanged != null)
                    ConnectionStringChanged(new SenderEventArgs<ConnectionStringTester<TConnection>>(this));

            }

        }

        public void Test()
        {

            lock (myLockObject)
            {


                if(myConnectionString.Length > 0) {

                TConnection theConnection = new TConnection();

                theConnection.ConnectionString = myConnectionString;

                    try
                    {

                        theConnection.Open();

                        OnSuccess();

                    }
                    catch (Exception e)
                    {

                        OnFailure(e);

                    }
                    finally
                    {

                        theConnection.Close();

                        theConnection.Dispose();

                    }

                }

            }

        }

        public string ConnectionString 
        {

            get 
            {

                return myConnectionString;

            }
            set 
            {

                lock (myLockObject) 
                {

                    myConnectionString = value;

                    OnConnectionStringChanged();

                }

            }


        }

    }
}
