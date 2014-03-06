using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Diagnostics;
using System.Dynamic;
using System.Threading;

namespace CoreComponents.Data
{

    public class ConnectionManager<TConnection> where TConnection : DbConnection, new()
    {

        //public event Action<ErrorEventArgs<ConnectionManager<TConnection>>> ErrorEvent;

        public event Action<SenderEventArgs<ConnectionManager<TConnection>>> ConnectionOpened;

        protected TConnection myConnection;

        public ConnectionManager()
        {

            myConnection = new TConnection();

        }

        public ConnectionManager(TConnection TheConnection) 
        {

            myConnection = TheConnection;

        }

        protected void OnErrorEvent(Exception TheException) 
        {

            //if(ErrorEvent != null)
            //    ErrorEvent(new ErrorEventArgs<ConnectionManager<TConnection>>(this, TheException));

        }

        protected void OnConnectionOpened()
        {

            if (ConnectionOpened != null)
                ConnectionOpened(new SenderEventArgs<ConnectionManager<TConnection>>(this));

        }

        public TConnection Connection 
        {

            get 
            {

                return myConnection;
                
            }

        }

        //public void Enable() 
        //{
        //}

        //public void Disable()
        //{
        //}

        public void OpenConnection()
        {

            try
            {

                //myConnection.BeginTransaction(

                //myConnection.StateChange += myConnection_StateChange;

                myConnection.Open();

                OnConnectionOpened();

                myConnection.Close();

                //myConnection.StateChange -= myConnection_StateChange;

            }
            catch (Exception e)
            {

                OnErrorEvent(e);

                myConnection.Close();

            }

        }

        //void myConnection_StateChange(object sender, StateChangeEventArgs e)
        //{
        //    if(e.CurrentState == ConnectionState.O
        //}

    }

}
