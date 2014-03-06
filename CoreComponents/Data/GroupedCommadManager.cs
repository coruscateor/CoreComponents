using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using CoreComponents.Items;

namespace CoreComponents.Data
{
    public class GroupedCommadManager<TConnection, TCommand, TParameter, TParameterCollection, TDataReader, TDataAdapter, TTransaction> //: IDisposable
        where TConnection : DbConnection, new()
        where TCommand : DbCommand, new()
        where TParameter : DbParameter, new()
        where TParameterCollection : DbParameterCollection
        where TDataReader : DbDataReader
        where TDataAdapter : DbDataAdapter, new()
        where TTransaction : DbTransaction
    {

        protected Dictionary<CommandExecutionSet<TConnection, TCommand, TParameter>, Task<ReadOnlyDictionary<CommandProperties, object>>> myCommandTaskSet = new Dictionary<CommandExecutionSet<TConnection, TCommand, TParameter>, Task<ReadOnlyDictionary<CommandProperties, object>>>();

        //protected List<CommandExecutionSet<TConnection, TCommand>> CommandExecutionSetList = new List<CommandExecutionSet<TConnection,TCommand>>();

        protected ConcurrentDictionary<CommandExecutionSet<TConnection, TCommand, TParameter>, ReadOnlyDictionary<CommandProperties, object>> myPreviousResults = new ConcurrentDictionary<CommandExecutionSet<TConnection,TCommand, TParameter>, ReadOnlyDictionary<CommandProperties, object>>();

        protected object myLockObject = new object();

        public GroupedCommadManager() 
        {
        }

        public void Add(CommandExecutionSet<TConnection, TCommand, TParameter> TheCommandExecutionSet)
        {

            lock (myLockObject)
            {

                if (!myCommandTaskSet.ContainsKey(TheCommandExecutionSet)) 
                {

                    myCommandTaskSet.Add(TheCommandExecutionSet, new Task<ReadOnlyDictionary<CommandProperties,object>>(new Func<ReadOnlyDictionary<CommandProperties,object>>((TheCommandExecutionSet.Execute))));

                }

            }

        }

        public void Remove(CommandExecutionSet<TConnection, TCommand, TParameter> TheCommandExecutionSet)
        {

            lock (myLockObject)
            {

                if (myCommandTaskSet.ContainsKey(TheCommandExecutionSet))
                {

                    myCommandTaskSet[TheCommandExecutionSet].Dispose();

                    myCommandTaskSet.Remove(TheCommandExecutionSet);

                }

            }

        }

        public void Execute()
        {

            lock (myLockObject)
            {

                foreach (var CommandTask in myCommandTaskSet.Values)
                {

                    CommandTask.Start();
                    
                }

                Task.WaitAll(myCommandTaskSet.Values.ToArray());

                foreach (var CommandTask in myCommandTaskSet)
                {
                    if (!myCommandTaskSet.ContainsKey(CommandTask.Key))
                    {

                        myCommandTaskSet.Add(CommandTask.Key, CommandTask.Value);

                    }
                    else 
                    {

                        myCommandTaskSet[CommandTask.Key] = CommandTask.Value;

                    }


                }

            }

        }

        public void Clear()
        {

            lock (myLockObject)
            {

                foreach (var CommandTask in myCommandTaskSet.Values)
                {

                    CommandTask.Dispose();
                    
                }

                myCommandTaskSet.Clear();

            }

        }

        //public void 

    }

}
