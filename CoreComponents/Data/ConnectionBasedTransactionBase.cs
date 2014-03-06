using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Reflection;

namespace CoreComponents.Data
{
    public abstract class ConnectionBasedTransactionBase<TConnection, TCommand, TTransaction>
        where TConnection : DbConnection, new()
        where TCommand : DbCommand, new()
        where TTransaction : DbTransaction
    {

        //public delegate void BaseErrorEventArgsDelegate(ErrorEventArgs<ConnectionBasedTransactionBase<TConnection, TCommand, TTransaction>> Parameter);

        public delegate void BaseSenderEventArgsDelegate(SenderEventArgs<ConnectionBasedTransactionBase<TConnection, TCommand, TTransaction>> Parameter);

        //public event BaseErrorEventArgsDelegate ErrorEvent;

        public event BaseSenderEventArgsDelegate ConnectionChanged;

        protected TConnection myConnection;

        protected TTransaction myCurrentTansaction;

        protected Dictionary<TCommand, KeyValuePair<MethodInfo, object>> myResults = new Dictionary<TCommand, KeyValuePair<MethodInfo, object>>();

        protected static readonly MethodInfo staticExecuteNonQueryMethodInfo;

        static ConnectionBasedTransactionBase()
        {

            Type CommandType = typeof(TCommand);

            staticExecuteNonQueryMethodInfo = CommandType.GetMethod("ExecuteNonQuery");

        }

        public ConnectionBasedTransactionBase() 
        {
        }

        protected void OnErrorEvent(Exception e)
        {

            //if (ErrorEvent != null)
            //    ErrorEvent(new ErrorEventArgs<ConnectionBasedTransactionBase<TConnection, TCommand, TTransaction>>(this, e));

        }

        protected void OnConnectionChanged() 
        {

            if(ConnectionChanged != null)
                ConnectionChanged(new SenderEventArgs<ConnectionBasedTransactionBase<TConnection, TCommand, TTransaction>>(this));

        }

        protected bool OpenConnection()
        {

            try
            {

                myConnection.Open();

                return true;

            }
            catch (Exception e)
            {

                OnErrorEvent(e);

            }

            return false;

        }

        public virtual TConnection Connection 
        {

            get 
            {

                return myConnection;

            }
            set 
            {

                if (!IsActive)
                {

                    myConnection = value;

                    OnConnectionChanged();

                }

            }

        }

        public virtual void SetConnection(ConnectionStringSettings CSSettings) 
        {

            if (!IsActive) 
            {

                TConnection TheNewConnection = new TConnection();

                TheNewConnection.ConnectionString = CSSettings.ConnectionString;

                myConnection = TheNewConnection;

                OnConnectionChanged();

            }

        }

        public bool HasConnection 
        {
            get 
            {

                return myCurrentTansaction != null;

            }

        }

        public abstract bool IsActive
        {

            get;

        }

    }
}
