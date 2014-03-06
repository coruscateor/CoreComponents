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
    public class TransactionCommandList<TConnection, TCommand, TParameter, TParameterCollection, TTransaction> : ConnectionBasedTransactionBase<TConnection, TCommand, TTransaction>
        where TConnection : DbConnection, new() 
        where TCommand : DbCommand, new()
        where TParameter : DbParameter, new()
        where TParameterCollection : DbParameterCollection
        where TTransaction : DbTransaction
    {

        protected List<TCommand> myCommandList = new List<TCommand>();

        public TransactionCommandList() 
        {
        }

        public void AddCommand(TCommand TheCommand) 
        {

            if (IsActive)
            {

                if (HasConnection)
                {

                    if (TheCommand.Connection != myConnection)
                        TheCommand.Connection = myConnection;

                    myCommandList.Add(TheCommand);

                }

            }

        }

        public void AddCommand(string TheCommandText) 
        {

            if (IsActive)
            {

                if (HasConnection)
                {

                    TCommand TheNewCommand = new TCommand();

                    TheNewCommand.Connection = myConnection;

                    TheNewCommand.CommandText = TheCommandText;

                }

            }

        }

        public void AddCommand(string TheCommandText, TParameterCollection TheParameterCollection)
        {

            if (IsActive)
            {

                if (HasConnection)
                {

                    TCommand TheNewCommand = new TCommand();

                    TheNewCommand.Connection = myConnection;

                    TheNewCommand.CommandText = TheCommandText;

                    foreach (TParameter Parameter in TheParameterCollection)
                    {

                        TheNewCommand.Parameters.Add(Parameter);

                    }

                }

            }

        }

        public void Execute() 
        {

            OpenConnection();

            try
            {

                myCurrentTansaction = (TTransaction)myConnection.BeginTransaction();

                foreach (TCommand Command in myCommandList)
                {

                    myResults.Add(Command, new KeyValuePair<MethodInfo, object>(staticExecuteNonQueryMethodInfo, Command.ExecuteNonQuery()));

                }

                myCurrentTansaction.Commit();

            }
            catch(Exception e)
            {

                myCurrentTansaction.Rollback();

                OnErrorEvent(e);

            }
            finally 
            {

                myConnection.Close();

                myResults.Clear();

            }

        }

        public override bool IsActive
        {

            get 
            {
                return myCurrentTansaction != null; 
            }

        }
    }
}
