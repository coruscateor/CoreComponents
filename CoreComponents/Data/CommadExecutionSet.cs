using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Threading;
using CoreComponents.Items;

namespace CoreComponents.Data
{

    public class CommandExecutionSet<TConnection, TCommand, TParameter>
        where TConnection : DbConnection, new()
        where TCommand : DbCommand, new()
        where TParameter : DbParameter, new()
    {

        protected TConnection myConnection;

        //protected List<CommandProperties> myCommandList = new List<CommandProperties>();

        //protected List<TCommand> myDbCommandList = new List<TCommand>();

        protected Dictionary<CommandProperties, TCommand> myDbCommandSet = new Dictionary<CommandProperties, TCommand>();

        protected object myLockObject = new object();

        protected bool myHasCaughtException;

        protected Thread myCreatingThread;

        protected bool myIsAsyncExecuting;

        public CommandExecutionSet()
        {

            myCreatingThread = Thread.CurrentThread;

        }

        public void Add(CommandProperties TheCommand) 
        {

            lock (myLockObject)
            {

                //if (!myCommandList.Contains(TheCommand))
                if(!myDbCommandSet.ContainsKey(TheCommand))
                {

                    //myCommandList.Add(TheCommand);

                    TCommand DbCommand = new TCommand();

                    DbCommand.Connection = myConnection;

                    DbCommand.CommandText = TheCommand.CommandText;

                    DbCommand.CommandTimeout = TheCommand.CommandTimeout;

                    DbCommand.UpdatedRowSource = TheCommand.UpdatedRowSource;

                    DbCommand.Parameters.AddRange(TheCommand.ParameterCollectionToArray<TParameter>());

                    //myDbCommandList.Add(DbCommand);

                    myDbCommandSet.Add(TheCommand, DbCommand);

                }

            }

        }

        public void Remove(CommandProperties TheCommand)
        {

            lock (myLockObject)
            {

                if (myDbCommandSet.ContainsKey(TheCommand))
                {

                    myDbCommandSet[TheCommand].Dispose();

                    myDbCommandSet.Remove(TheCommand);

                }

            }

        }

        public void Clear()
        {

            lock (myLockObject)
            {

                foreach (KeyValuePair<CommandProperties, TCommand> CommandPair in myDbCommandSet)
                {

                    CommandPair.Value.Dispose();

                }

                myDbCommandSet.Clear();

            }

        }

        public bool HasCaughtException 
        {

            get 
            {

                return myHasCaughtException;

            }

        }

        public bool IsAsyncExecuting 
        {

            get 
            {

                return myIsAsyncExecuting;

            }

        }

        public ReadOnlyDictionary<CommandProperties, object> Execute() 
        {

            lock (myLockObject)
            {

                if (myCreatingThread != Thread.CurrentThread)
                    myIsAsyncExecuting = true;

                if (myHasCaughtException)
                    myHasCaughtException = false;

                Dictionary<CommandProperties, object> TheCommandResults = new Dictionary<CommandProperties, object>();

                foreach (KeyValuePair<CommandProperties, TCommand> CommandPair in myDbCommandSet) 
                {

                    CommandProperties TheCommandProperties = CommandPair.Key;

                    TCommand TheCommand = CommandPair.Value;

                    object CommandResult = null;

                    try
                    {

                        if (TheCommandProperties.CommandResultType == CommandResultType.NonQuery)
                        {

                            CommandResult = TheCommand.ExecuteNonQuery();

                        }
                        else if (TheCommandProperties.CommandResultType == CommandResultType.ResultSet)
                        {

                            CommandResult = TheCommand.ExecuteReader(TheCommandProperties.CommandBehavior);

                        }
                        else if (TheCommandProperties.CommandResultType == CommandResultType.Scalar)
                        {

                            CommandResult = TheCommand.ExecuteScalar();

                        }

                        TheCommandResults.Add(TheCommandProperties, CommandResult);

                    }
                    catch (Exception e)
                    {

                        CommandResult = e;

                        myHasCaughtException = true;

                        TheCommandResults.Add(TheCommandProperties, CommandResult);

                        break;

                    }

                }

                myIsAsyncExecuting = false;

                return new ReadOnlyDictionary<CommandProperties, object>(TheCommandResults);

            }

        }

    }

}
