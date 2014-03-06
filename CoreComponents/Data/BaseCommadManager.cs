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
    public abstract class BaseCommadManager<TConnection, TCommand, TParameter, TParameterCollection, TDataReader, TDataAdapter, TTransaction> : IRunCommands, IDisposable
        where TConnection : DbConnection, new()
        where TCommand : DbCommand, new()
        where TParameter : DbParameter, new()
        where TParameterCollection : DbParameterCollection
        where TDataReader : DbDataReader
        where TDataAdapter : DbDataAdapter, new()
        where TTransaction : DbTransaction
    {

        protected TConnection myConnection;

        protected TTransaction myCurrentTansaction;

        protected List<CommandResult> myCommandResults = new List<CommandResult>();

        protected CommandMode myCommandMode;

        protected object myLockObject = new object();

        protected bool myIsActive;

        protected TCommand myDbCommand = new TCommand();

        public BaseCommadManager() 
        {
        }


        public abstract void Execute(CommandProperties TheCommadProperties);

        public abstract void Dispose();
    }
}
