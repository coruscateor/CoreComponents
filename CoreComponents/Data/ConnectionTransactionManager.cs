using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Reflection;

namespace CoreComponents.Data
{
    public class ConnectionTransactionManager<TConnection, TCommand, TParameter, TParameterCollection, TDataReader, TDataAdapter, TTransaction> : ConnectionBasedTransactionBase<TConnection, TCommand, TTransaction>, IDisposable
        where TConnection : DbConnection, new()
        where TCommand : DbCommand, new()
        where TParameter : DbParameter, new()
        where TParameterCollection : DbParameterCollection
        where TDataReader : DbDataReader
        where TDataAdapter : DbDataAdapter, new()
        where TTransaction : DbTransaction
    {

        public delegate void SenderEventArgsDelegate(SenderEventArgs<ConnectionTransactionManager<TConnection, TCommand, TParameter, TParameterCollection, TDataReader, TDataAdapter, TTransaction>> Parameter);

        //public delegate void ResultsEventArgsDelegate(ResultsEventArgs<ConnectionTransactionManager<TConnection, TCommand, TParameter, TParameterCollection, TDataReader, TDataAdapter, TTransaction>, KeyValuePair<TCommand, KeyValuePair<MethodInfo, object>>> Parameter);

        public event SenderEventArgsDelegate BeganTransaction;

        //public event ResultsEventArgsDelegate CommitedTransaction;

        //public event ResultsEventArgsDelegate RolledBackTransaction;

        //List<TCommand> myCommmandsExecuted = new List<TCommand>();

        public ConnectionTransactionManager() 
        {
        }

        public ConnectionTransactionManager(TConnection TheConnection)
        {

            myConnection = TheConnection;
             
        }

        protected void OnBeganTransaction() 
        {

              if (BeganTransaction != null)
                  BeganTransaction(new SenderEventArgs<ConnectionTransactionManager<TConnection, TCommand, TParameter, TParameterCollection, TDataReader, TDataAdapter, TTransaction>>(this));


        }

        protected void OnCommitedTransaction() 
        {

        
            //if (CommitedTransaction != null)
            //    CommitedTransaction(new ResultsEventArgs<ConnectionTransactionManager<TConnection, TCommand, TParameter, TParameterCollection, TDataReader, TDataAdapter, TTransaction>, KeyValuePair<TCommand, KeyValuePair<MethodInfo, object>>>(this, myResults)); //<KeyValuePair<TConnection, KeyValuePair<MethodInfo, object>>>

        }

        protected void OnRolledBackTransaction()
        {

            //if (RolledBackTransaction != null)
            //    RolledBackTransaction(new ResultsEventArgs<ConnectionTransactionManager<TConnection, TCommand, TParameter, TParameterCollection, TDataReader, TDataAdapter, TTransaction>, KeyValuePair<TCommand, KeyValuePair<MethodInfo, object>>>(this, myResults)); //<KeyValuePair<TConnection, KeyValuePair<MethodInfo, object>>>


        }

        public void Begin() 
        {

            if (!OpenConnection())
                return;

            try 
            {

                myCurrentTansaction = (TTransaction)myConnection.BeginTransaction();

                OnBeganTransaction();

            } catch(Exception e)
            {

                OnErrorEvent(e);

            }

        }

        public void Begin(IsolationLevel TheIsolatonLevel) 
        {

            if (!OpenConnection())
                return;

            try
            {

                myCurrentTansaction = (TTransaction)myConnection.BeginTransaction(TheIsolatonLevel);

                OnBeganTransaction();

            }
            catch (Exception e)
            {

                OnErrorEvent(e);

                RollBack();

            }

        }

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
        

        /*
        public TCommand[] PreviousCommands 
        {
            get
            {

                return myCommmandsExecuted.ToArray();

            }

        }
        */

        public override bool IsActive 
        {

            get 
            {

                return myCurrentTansaction != null;

            }

        }

        public void RollBack() 
        {

            if (IsActive)
            {

                try
                {

                    myCurrentTansaction.Rollback();

                    myCurrentTansaction = null;

                    OnRolledBackTransaction();

                }
                catch (Exception e)
                {

                    OnErrorEvent(e);

                }
                finally
                {

                    myConnection.Close();

                    myResults.Clear();

                }
            }

        }

        public void Commit() 
        {

            if (IsActive)
            {

                try
                {

                    myCurrentTansaction.Commit();

                    myCurrentTansaction = null;

                    OnCommitedTransaction();

                }
                catch (Exception e)
                {

                    OnErrorEvent(e);

                }
                finally
                {

                    myConnection.Close();

                    myResults.Clear();

                }
            }

        }

        //Assumes you'll commit. 
        public void Dispose()
        {
            Commit();
        }
    }
}
