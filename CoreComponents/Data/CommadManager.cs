using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Reflection;
using System.Threading;

namespace CoreComponents.Data
{
    public class CommadManager<TConnection, TCommand, TParameter, TParameterCollection, TDataReader, TDataAdapter, TTransaction> : BaseCommadManager<TConnection, TCommand, TParameter, TParameterCollection, TDataReader, TDataAdapter, TTransaction>, IRunCommands, IDisposable
        where TConnection : DbConnection, new()
        where TCommand : DbCommand, new()
        where TParameter : DbParameter, new()
        where TParameterCollection : DbParameterCollection
        where TDataReader : DbDataReader
        where TDataAdapter : DbDataAdapter, new()
        where TTransaction : DbTransaction
    {

        //public delegate void SenderEventArgsDelegate(SenderEventArgs<CommadManager<TConnection, TCommand, TParameter, TParameterCollection, TDataReader, TDataAdapter, TTransaction>> Parameter);

        //public delegate void ResultsEventArgsDelegate(ResultsEventArgs<CommadManager<TConnection, TCommand, TParameter, TParameterCollection, TDataReader, TDataAdapter, TTransaction>, CommandResult> Parameter);

        //public delegate void BaseErrorEventArgsDelegate(ErrorEventArgs<CommadManager<TConnection, TCommand, TParameter, TParameterCollection, TDataReader, TDataAdapter, TTransaction>> Parameter);

        //public delegate void BaseSenderEventArgsDelegate(SenderEventArgs<CommadManager<TConnection, TCommand, TParameter, TParameterCollection, TDataReader, TDataAdapter, TTransaction>> Parameter);

        public delegate void SenderEventArgsDelegate(SenderEventArgs Parameter);

        //public delegate void ResultsEventArgsDelegate(ResultsEventArgs<CommadManager<TConnection, TCommand, TParameter, TParameterCollection, TDataReader, TDataAdapter, TTransaction>, CommandResult> Parameter);

        //public delegate void BaseErrorEventArgsDelegate(ErrorEventArgs<object> Parameter);

        public delegate void BaseSenderEventArgsDelegate(SenderEventArgs Parameter);

        public event SenderEventArgsDelegate BeganTransaction;

        //public event ResultsEventArgsDelegate CommitedTransaction;

        //public event ResultsEventArgsDelegate RolledBackTransaction;

        //public event BaseErrorEventArgsDelegate ErrorEvent;

        public event BaseSenderEventArgsDelegate ConnectionChanged;

        /*
        static CommadManager()
        {

            Type CommandType = typeof(TCommand);

        }
        */

        public CommadManager() 
        {
        }

        public CommadManager(TConnection TheConnection)
        {

            myConnection = TheConnection;
             
        }

        protected void OnBeganTransaction() 
        {
              //<CommadManager<TConnection, TCommand, TParameter, TParameterCollection, TDataReader, TDataAdapter, TTransaction>>
              if (BeganTransaction != null)
                  BeganTransaction(new SenderEventArgs(this));


        }

        protected void OnCommitedTransaction() 
        {
        
            //if (CommitedTransaction != null)
            //    CommitedTransaction(new ResultsEventArgs<CommadManager<TConnection, TCommand, TParameter, TParameterCollection, TDataReader, TDataAdapter, TTransaction>, CommandResult>(this, myCommandResults));

        }

        protected void OnRolledBackTransaction()
        {

            //if (RolledBackTransaction != null)
            //    CommitedTransaction(new ResultsEventArgs<CommadManager<TConnection, TCommand, TParameter, TParameterCollection, TDataReader, TDataAdapter, TTransaction>, CommandResult>(this, myCommandResults));

        }

        protected void OnErrorEvent(string Message)
        {
            //<CommadManager<TConnection, TCommand, TParameter, TParameterCollection, TDataReader, TDataAdapter, TTransaction>>
            //if (ErrorEvent != null)
            //    ErrorEvent(new ErrorEventArgs<object>(this, Message));

        }

        protected void OnErrorEvent(Exception e)
        {
            //<CommadManager<TConnection, TCommand, TParameter, TParameterCollection, TDataReader, TDataAdapter, TTransaction>>
            //if (ErrorEvent != null)
            //    ErrorEvent(new ErrorEventArgs<object>(this, e));

        }

        protected void OnConnectionChanged() 
        {
            //<CommadManager<TConnection, TCommand, TParameter, TParameterCollection, TDataReader, TDataAdapter, TTransaction>>
            if(ConnectionChanged != null)
                ConnectionChanged(new SenderEventArgs(this));

        }

        protected void OpenConnection()
        {

            try
            {

                lock (myLockObject)
                {

                    if (myConnection.State != ConnectionState.Open)
                    {

                        myConnection.Open();

                        //Connection Opend
                        //myConnection.
                    }

                }

            }
            catch (Exception e)
            {

                OnErrorEvent(e);

            }

            //return false;

        }

        public string ConnectionString 
        {


            get 
            {

                return myConnection.ConnectionString;

            }
            set 
            {

                lock (myLockObject) 
                {

                    myConnection.ConnectionString = value;

                }

            }

        }

        //public /*virtual*/ abstract TConnection Connection
        //{

            //get;
            //{

            //    return myConnection;

            //}
            //set
            //{

            //    if (!IsActive)
            //    {

            //        myConnection = value;

            //        OnConnectionChanged();

            //    }

            //}

        //}

        public virtual void SetConnection(ConnectionStringSettings CSSettings)
        {

            if (!IsActive)
            {

                TConnection TheNewConnection = new TConnection();

                TheNewConnection.ConnectionString = CSSettings.ConnectionString;

                myConnection = TheNewConnection;

                myDbCommand.Connection = myConnection;

                OnConnectionChanged();

            }

        }

        /*
        public bool HasConnection
        {
            get
            {

                return myCurrentTansaction != null;

            }

        }
        */

        public bool IsActive
        {

            get 
            {

                return myIsActive;

            }

        }

        public void BeginTransaction() 
        {

            //if (!OpenConnection())
            //   return;

            lock(myLockObject)
            {

                if (myCommandMode != CommandMode.Transaction)
                {

                    try
                    {

                        myCurrentTansaction = (TTransaction)myConnection.BeginTransaction();

                        myCommandMode = CommandMode.Transaction;

                        myCommandResults.Clear();

                        OnBeganTransaction();

                    }
                    catch (Exception e)
                    {

                        OnErrorEvent(e);

                    }

                }
                else
                {

                    EmitIsInTransaction();

                }

            }

        }

        public void BeginTransaction(IsolationLevel TheIsolatonLevel) 
        {

            //if (!OpenConnection())
            //    return;

            lock (myLockObject)
            {

                if (myCommandMode != CommandMode.Transaction)
                {

                    try
                    {

                        myCurrentTansaction = (TTransaction)myConnection.BeginTransaction(TheIsolatonLevel);

                        myCommandMode = CommandMode.Transaction;

                        myCommandResults.Clear();

                        OnBeganTransaction();

                    }
                    catch (Exception e)
                    {

                        OnErrorEvent(e);

                        RollBack();

                    }

                }
                else 
                {

                    EmitIsInTransaction();

                }

            }

        }

        protected void EmitIsInTransaction() 
        {

            OnErrorEvent("Transaction state is currently active"); //Write a better message.

        }

        public IsolationLevel TransactionIsolatonLevel 
        {

            get 
            {

                lock (myLockObject)
                {

                    if (myCurrentTansaction != null)
                    {

                        return myCurrentTansaction.IsolationLevel;

                    }

                }

                return IsolationLevel.Unspecified; //Find the standard isolation level.

            }

        }

        /*
        public void ExecuteNonQuery(TCommand TheCommand) 
        {

            if (TheCommand.Connection != myConnection)
                TheCommand.Connection = myConnection;

            try
            {

                myResults.Add(TheCommand, new KeyValuePair<MethodInfo, object>(staticExecuteNonQueryMethodInfo, TheCommand.ExecuteNonQuery()));

            }
            catch (Exception e) 
            {

                OnErrorEvent(e);

                RollBack();

            }

        }

        
        public void ExecuteNonQuery(string TheCommandText, TParameterCollection TheParameterCollection)
        {

            TCommand TheNewCommand = new TCommand();

            TheNewCommand.CommandText = TheCommandText;

            foreach (TParameter Parameter in TheParameterCollection)
            {

                TheNewCommand.Parameters.Add(Parameter);

            }

            try
            {

                myResults.Add(TheNewCommand, new KeyValuePair<MethodInfo, object>(staticExecuteNonQueryMethodInfo, TheNewCommand.ExecuteNonQuery()));

            }
            catch (Exception e)
            {

                OnErrorEvent(e);

                RollBack();

            }

        }
        */

        public override void Execute(CommandProperties TheCommadProperties)
        {

            lock (myLockObject)
            {

                try
                {

                    //TCommand TheNewCommand = new TCommand();

                    myDbCommand.CommandText = TheCommadProperties.CommandText;

                    //TheNewCommand.CommandText = TheCommadProperties.CommandText;

                    myDbCommand.CommandTimeout = TheCommadProperties.CommandTimeout;

                    //TheNewCommand.CommandTimeout = TheCommadProperties.CommandTimeout;

                    myDbCommand.CommandType = TheCommadProperties.CommandType;

                    //TheNewCommand.CommandType = TheCommadProperties.CommandType;

                    //if (TheCommadProperties.ParameterCollection.IsNotEmpty)
                    //{

                    myDbCommand.Parameters.AddRange(TheCommadProperties.ParameterCollectionToArray<TParameter>());

                        //TheNewCommand.Parameters.AddRange(TheCommadProperties.ParameterCollection.GetArray());

                    //}

                    //TheNewCommand.Connection = myConnection;

                    //foreach (TParameter Parameter in TheParameterCollection)
                    //{

                    //    TheNewCommand.Parameters.Add(Parameter);

                    //}

                    object CommandResult = null;

                    if (TheCommadProperties.CommandResultType == CommandResultType.NonQuery)
                    {

                        CommandResult = myDbCommand.ExecuteNonQuery();

                        //CommandResult = TheNewCommand.ExecuteNonQuery();

                    }
                    else if (TheCommadProperties.CommandResultType == CommandResultType.ResultSet)
                    {

                        CommandResult = myDbCommand.ExecuteReader(TheCommadProperties.CommandBehavior);

                        //CommandResult = TheNewCommand.ExecuteReader(TheCommadProperties.CommandBehavior);

                    }
                    else if (TheCommadProperties.CommandResultType == CommandResultType.Scalar)
                    {

                        CommandResult = myDbCommand.ExecuteScalar();

                        //CommandResult = TheNewCommand.ExecuteScalar();

                    }

                    myCommandResults.Add(new CommandResult(TheCommadProperties, CommandResult, this));

                    //myResults.Add(TheCommadProperties, CommandResult);

                    //myResults.Add(TheNewCommand, new KeyValuePair<MethodInfo, object>(staticExecuteNonQueryMethodInfo, TheNewCommand.ExecuteNonQuery()));

                }
                catch (Exception e)
                {

                    myCommandResults.Add(new CommandResult(TheCommadProperties, e, this));

                    OnErrorEvent(e);

                    //RollBack();

                }

            }

        }

        /*
        public TCommand[] PreviousCommands 
        {
            get
            {

                return myCommmandsExecuted.ToArray();

            }

        }
        */

        public void RollBack() 
        {

            lock(myLockObject)
            {

                if (IsActive)
                {

                    if (myCommandMode == CommandMode.Transaction)
                    {

                        try
                        {

                            myCurrentTansaction.Rollback();

                            myCurrentTansaction.Dispose();

                            myCurrentTansaction = null;

                            myCommandMode = CommandMode.Discrete;

                            OnRolledBackTransaction();

                        }
                        catch (Exception e)
                        {

                            OnErrorEvent(e);

                        }
                        finally
                        {

                            myConnection.Close();

                            myCommandResults.Clear();

                        }

                    }

                }

            }

        }

        public void Commit() 
        {

            lock(myLockObject)
            {

                if (myIsActive)
                {

                    if (myCommandMode == CommandMode.Transaction)
                    {

                        try
                        {

                            myCurrentTansaction.Commit();

                            myCurrentTansaction.Dispose();

                            myCurrentTansaction = null;

                            myCommandMode = CommandMode.Discrete;

                            OnCommitedTransaction();

                        }
                        catch (Exception e)
                        {

                            OnErrorEvent(e);

                        }
                        finally
                        {

                            myConnection.Close();

                            myCommandResults.Clear();

                        }

                    }

                }

            }

        }

        public override void Dispose()
        {

            lock (myLockObject)
            {

                if (myCommandMode == CommandMode.Transaction)
                    Commit();

                myDbCommand.Dispose();

            }

        }
    }

    public enum CommandMode 
    {

        Discrete,
        Transaction

    }

}
