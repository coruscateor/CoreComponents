using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Diagnostics;

namespace CoreComponents.Data
{

    public class ConnectionAndCommandManager<TConnection, TCommand, TParameter, TTransaction> : IConnectionAndCommandManager
        where TConnection : DbConnection, new()
        where TCommand : DbCommand, new()
        where TParameter : DbParameter, new()
        where TTransaction : DbTransaction
    {

        public event Action<ErrorEventArgs> Error;

        public const string ConnectionSucceeded = "Connection Succeeded!";

        public const string ConnectionFailed = "Connection Failed";

        public const string ConnectionFailedColon = "Connection Failed:";

        protected TCommand myCommand;

        protected TTransaction myTransaction;

        protected ConnectionType myConnectionType = ConnectionType.QuickDiscrete;

        protected Action myOpenAction;

        protected Action myCloseAction;

        protected Func<int> myExecuteNonQueryAction;

        protected Func<string, int> myExecuteNonQuery;

        protected Func<string, IEnumerable<object>, int> myExecuteNonQueryParameters;

        protected Func<IEnumerable<object>, int> myExecuteNonQueryParametersOnly;

        protected Func<DbDataReader> myExecuteReaderAction;

        protected Func<string, DbDataReader> myExecuteReader;

        protected Func<string, IEnumerable<object>, DbDataReader> myExecuteReaderParameters;

        protected Func<IEnumerable<object>, DbDataReader> myExecuteReaderParametersOnly;

        protected Func<object> myExecuteScalarAction;

        protected Func<string, object> myExecuteScalar;

        protected Func<string, IEnumerable<object>, object> myExecuteScalarParameters;

        protected Func<IEnumerable<object>, object> myExecuteScalarParametersOnly;

        protected Func<DataTable> myExecuteDataTableAction;

        protected Func<string, DataTable> myExecuteDataTable;

        protected Func<string, IEnumerable<object>, DataTable> myExecuteDataTableParameters;

        protected Func<IEnumerable<object>, DataTable> myExecuteDataTableParametersOnly;

        protected bool myIsActive;

        //protected bool myIsEngaged;

        protected IsolationLevel myIsolationLevel = IsolationLevel.Unspecified;

        protected TransactionAction myTransactionAction = TransactionAction.Commit;

        protected bool myRetainParameters;

        //protected ParameterChache<TParameter> myParameterChache = new ParameterChache<TParameter>();

        protected void OnError(Exception TheException)
        {

            if(TheException != null)
                Error(new ErrorEventArgs(TheException));

        }

        protected void OnError(string TheMessage)
        {

            if(Error != null)
                Error(new ErrorEventArgs(TheMessage));

        }

        public ConnectionAndCommandManager()
        {

            Initalise();

        }

        public ConnectionAndCommandManager(string TheConnectionString)
        {

            Initalise();

            myCommand.Connection.ConnectionString = TheConnectionString;

        }

        public ConnectionAndCommandManager(ConnectionType TheConnectionType)
        {

            myConnectionType = TheConnectionType;

            Initalise();

        }

        public ConnectionAndCommandManager(string TheConnectionString, ConnectionType TheConnectionType)
        {

            myConnectionType = TheConnectionType;

            Initalise();

        }

        protected void Initalise()
        {

            myCommand = new TCommand();

            myCommand.Connection = new TConnection();

            SetConnectionDelegates();

        }

        //public void Engage()
        //{
        //}

        //public void DisEngage()
        //{
        //}

        public void Open()
        {

            myOpenAction();

        }

        public void Close()
        {

            myCloseAction();

        }

        public ConnectionType ConnectionType
        {

            get
            {

                return myConnectionType;

            }
            set
            {

                if(!myIsActive && (myConnectionType != value))
                {

                    myConnectionType = value;

                    SetConnectionDelegates();

                }

            }

        }

        protected void SetConnectionDelegates()
        {

            switch(myConnectionType)
            {

                case ConnectionType.Discrete:

                    myOpenAction = DiscreteOpen;

                    myCloseAction = DiscreteClose;

                    //ExecuteNonQuery

                    myExecuteNonQueryAction = DiscreteExecuteNonQuery;

                    myExecuteNonQuery = DiscreteExecuteNonQuery;

                    myExecuteNonQueryParametersOnly = DiscreteExecuteNonQuery;

                    myExecuteNonQueryParameters = DiscreteExecuteNonQuery;

                    //ExecuteReader

                    myExecuteReaderAction = DiscreteExecuteReader;

                    myExecuteReader = DiscreteExecuteReader;

                    myExecuteReaderParametersOnly = DiscreteExecuteReader;

                    myExecuteReaderParameters = DiscreteExecuteReader;

                    //ExecuteScalar

                    myExecuteScalarAction = DiscreteExecuteScalar;

                    myExecuteScalar = DiscreteExecuteScalar;

                    myExecuteScalarParametersOnly = DiscreteExecuteScalar;

                    myExecuteScalarParameters = DiscreteExecuteScalar;

                    //ExecuteDataTable

                    myExecuteDataTableAction = DiscreteExecuteDataTable;

                    myExecuteDataTable = DiscreteExecuteDataTable;

                    myExecuteDataTableParametersOnly = DiscreteExecuteDataTable;

                    myExecuteDataTableParameters = DiscreteExecuteDataTable;

                    break;
                case ConnectionType.QuickDiscrete:

                    myOpenAction = () => { };

                    myCloseAction = myOpenAction;

                    //ExecuteNonQuery

                    myExecuteNonQueryAction = QuickDiscreteExecuteNonQuery;

                    myExecuteNonQuery = QuickDiscreteExecuteNonQuery;

                    myExecuteNonQueryParametersOnly = QuickDiscreteExecuteNonQuery;

                    myExecuteNonQueryParameters = QuickDiscreteExecuteNonQuery;

                    //ExecuteReader

                    myExecuteReaderAction = QuickDiscreteExecuteReader;

                    myExecuteReader = QuickDiscreteExecuteReader;

                    myExecuteReaderParametersOnly = QuickDiscreteExecuteReader;

                    myExecuteReaderParameters = QuickDiscreteExecuteReader;

                    //ExecuteScalar

                    myExecuteScalarAction = QuickDiscreteExecuteScalar;

                    myExecuteScalar = QuickDiscreteExecuteScalar;

                    myExecuteScalarParametersOnly = QuickDiscreteExecuteScalar;

                    myExecuteScalarParameters = QuickDiscreteExecuteScalar;

                    //ExecuteDataTable

                    myExecuteDataTableAction = QuickDiscreteExecuteDataTable;

                    myExecuteDataTable = QuickDiscreteExecuteDataTable;

                    myExecuteDataTableParametersOnly = QuickDiscreteExecuteDataTable;

                    myExecuteDataTableParameters = QuickDiscreteExecuteDataTable;

                    break;
                case ConnectionType.Transactional:

                    myOpenAction = TransactionalOpen;

                    myCloseAction = TransactionalClose;

                    //ExecuteNonQuery

                    myExecuteNonQueryAction = TransactionalExecuteNonQuery;

                    myExecuteNonQuery = TransactionalExecuteNonQuery;

                    myExecuteNonQueryParametersOnly = TransactionalExecuteNonQuery;

                    myExecuteNonQueryParameters = TransactionalExecuteNonQuery;

                    //ExecuteReader

                    myExecuteReaderAction = TransactionalExecuteReader;

                    myExecuteReader = TransactionalExecuteReader;

                    myExecuteReaderParametersOnly = TransactionalExecuteReader;

                    myExecuteReaderParameters = TransactionalExecuteReader;

                    //ExecuteScalar

                    myExecuteScalarAction = TransactionalExecuteScalar;

                    myExecuteScalar = TransactionalExecuteScalar;

                    myExecuteScalarParametersOnly = TransactionalExecuteScalar;

                    myExecuteScalarParameters = TransactionalExecuteScalar;

                    //ExecuteDataTable

                    myExecuteDataTableAction = TransactionalExecuteDataTable;

                    myExecuteDataTable = TransactionalExecuteDataTable;

                    myExecuteDataTableParametersOnly = TransactionalExecuteDataTable;

                    myExecuteDataTableParameters = TransactionalExecuteDataTable;

                    break;

            }

        }

        //public TConnection Connection
        //{

        //    get
        //    {

        //        return (TConnection)myCommand.Connection;

        //    }
        //    set
        //    {

        //        myCommand.Connection = (TConnection)value;
        //        //myCommand.Connection.
        //    }

        //}

        public string ConnectionString
        {

            get
            {

                return myCommand.Connection.ConnectionString;

            }
            set
            {

                //if (!myIsActive)
                //{

                myCommand.Connection.ConnectionString = value;

                //}

            }

        }

        public string Database
        {

            get
            {

                return myCommand.Connection.Database;

            }
            set
            {

                if(myIsActive)
                {

                    myCommand.Connection.ChangeDatabase(value);

                }

            }

        }

        public string DataSource
        {

            get
            {

                return myCommand.Connection.DataSource;

            }

        }

        public string ServerVersion
        {

            get
            {

                return myCommand.Connection.ServerVersion;

            }

        }

        public ConnectionState ConnectionState
        {

            get
            {

                return myCommand.Connection.State;

            }

        }

        public bool IsActive
        {

            get
            {

                return myIsActive;

            }

        }

        public bool ConnectionIsActive
        {

            get
            {

                ConnectionState State = myCommand.Connection.State;

                return State == ConnectionState.Open || State == ConnectionState.Connecting || State == ConnectionState.Executing || State == ConnectionState.Fetching;

            }

        }

        public bool ConnectionIsHeldOpen
        {

            get
            {

                return myConnectionType == ConnectionType.Discrete;

            }

        }

        public bool TestConnection()
        {

            if(!myIsActive)
            {

                try
                {

                    myIsActive = true;

                    myCommand.Connection.Open();

                }
                catch
                {

                    return false;

                }
                finally
                {

                    myCommand.Connection.Close();

                    myIsActive = false;

                }

            }

            return true;

        }

        public bool TestConnectionGetError()
        {

            if(!myIsActive)
            {

                try
                {

                    myIsActive = true;

                    myCommand.Connection.Open();

                }
                catch(Exception e)
                {

                    OnError(e);

                    return false;

                }
                finally
                {

                    myCommand.Connection.Close();

                    myIsActive = false;

                }

            }

            return true;

        }

        public string TestConnectionVerbose(bool RecordStackTrace = false)
        {

            if(!myIsActive)
            {

                try
                {

                    myIsActive = true;

                    myCommand.Connection.Open();

                }
                catch(Exception e)
                {

                    StringBuilder SB = new StringBuilder();

                    SB.AppendLine(ConnectionFailedColon);

                    SB.AppendLine();

                    SB.AppendLine(e.Message);

                    if(RecordStackTrace)
                    {

                        SB.AppendLine();

                        SB.AppendLine(e.StackTrace);

                    }

                    return SB.ToString();

                }
                finally
                {

                    myCommand.Connection.Close();

                    myIsActive = false;

                }

            }

            return ConnectionSucceeded;

        }

        public string TestConnectionVerboseAndGetError(bool RecordStackTrace = false)
        {

            if(!myIsActive)
            {

                try
                {

                    myIsActive = true;

                    myCommand.Connection.Open();

                }
                catch(Exception e)
                {

                    OnError(e);

                    StringBuilder SB = new StringBuilder();

                    SB.AppendLine(ConnectionFailedColon);

                    SB.AppendLine();

                    SB.AppendLine(e.Message);

                    if(RecordStackTrace)
                    {

                        SB.AppendLine();

                        SB.AppendLine(e.StackTrace);

                    }

                    return SB.ToString();

                }
                finally
                {

                    myCommand.Connection.Close();

                    myIsActive = false;

                }

            }

            return ConnectionSucceeded;

        }

        public int ConnectionTimeout
        {

            get
            {

                return myCommand.Connection.ConnectionTimeout;

            }

        }

        public int CommandTimeout
        {

            get
            {

                return myCommand.CommandTimeout;

            }
            set
            {

                if(!myIsActive)
                {

                    myCommand.CommandTimeout = value;

                }

            }

        }

        public void Prepare()
        {

            myCommand.Prepare();

        }

        public CommandType CommandType
        {

            get
            {

                return myCommand.CommandType;

            }
            set
            {

                if(!myIsActive)
                {

                    myCommand.CommandType = value;

                }

            }

        }

        public IsolationLevel IsolationLevel
        {

            get
            {

                return myIsolationLevel;

            }
            set
            {

                if(!myIsActive)
                {

                    myIsolationLevel = value;

                }

            }

        }

        public TransactionAction TransactionAction
        {

            get
            {

                return myTransactionAction;

            }
            set
            {

                if(!myIsActive)
                {

                    myTransactionAction = value;

                }

            }

        }

        public string CommandText
        {

            get
            {

                return myCommand.CommandText;

            }
            set
            {

                myCommand.CommandText = value;

            }

        }

        public void SetCommandText(StringBuilder SB)
        {

            myCommand.CommandText = SB.ToString();

        }

        public IEnumerable<object> ParameterValues
        {

            get
            {

                if(myCommand.Parameters.Count > 0)
                {

                    object[] Items = new object[myCommand.Parameters.Count];

                    for(int i = 0; i < myCommand.Parameters.Count; i++)
                    {

                        Items[i] = myCommand.Parameters[i].Value;

                    }

                    return Items;

                }

                return new object[0];

            }
            set
            {

                SetParameterValues(value);

            }

        }

        public void ClearParameters()
        {

            if(myCommand.Parameters.Count > 0)
            {

                myCommand.Parameters.Clear();

            }

            //myParameterChache.Clear(myCommand.Parameters);

        }

        protected void ResetParameters()
        {

            if(!myRetainParameters)
            {

                ClearParameters();

                //myParameterChache.Clear(myCommand.Parameters);

            }

        }

        public bool RetainParameters
        {

            get
            {

                return myRetainParameters;

            }
            set
            {

                if(!myIsActive)
                {

                    myRetainParameters = value;

                }

            }

        }

        public void SetParameterValues(IEnumerable<object> TheParameters)
        {

            ClearParameters();

            foreach(object Item in TheParameters)
            {

                TParameter NewParameter = new TParameter();

                NewParameter.Value = Item;

                myCommand.Parameters.Add(NewParameter);

            }

            //if (TheParameters != null)
            //{

            //    List<object> Items = new List<object>();

            //    foreach (object Item in TheParameters)
            //    {

            //        Items.Add(Item);

            //    }

            //    if (Items.Count > myCommand.Parameters.Count)
            //    {

            //        int Difference = Items.Count - myCommand.Parameters.Count;

            //        myParameterChache.FetchInto(myCommand.Parameters, Difference);

            //    }
            //    else if (Items.Count < myCommand.Parameters.Count)
            //    {

            //        int Difference = myCommand.Parameters.Count - Items.Count;

            //        myParameterChache.RetriveFrom(myCommand.Parameters, Difference);

            //    }

            //    for (int i = 0; i < Items.Count; i++)
            //    {

            //        myCommand.Parameters[i].Value = Items[i];

            //    }

            //}
            //else
            //{

            //    myParameterChache.Clear(myCommand.Parameters);

            //}

        }

        public void SetParameterValuesParams(params object[] TheParameters)
        {

            SetParameterValues(TheParameters);

        }

        public void SetParameterNamesAndValues(IEnumerable<KeyValuePair<string, object>> TheParameters)
        {

            if(!myIsActive)
            {

                ClearParameters();

                foreach(KeyValuePair<string, object> Item in TheParameters)
                {

                    TParameter NewParameter = new TParameter();

                    NewParameter.Value = Item.Value;

                    NewParameter.ParameterName = Item.Key;

                    myCommand.Parameters.Add(NewParameter);

                }

                //Queue<KeyValuePair<string, object>> myParameterQueue = new Queue<KeyValuePair<string, object>>(TheParameterDetails);

                //KeyValuePair<string, object> NewItemValues;

                //if (myCommand.Parameters.Count > myParameterQueue.Count)
                //{

                //    myParameterChache.RetriveFrom(myCommand.Parameters, myCommand.Parameters.Count - myParameterQueue.Count);

                //}

                //foreach (DbParameter Item in myCommand.Parameters)
                //{

                //    NewItemValues = myParameterQueue.Dequeue();

                //    Item.ParameterName = NewItemValues.Key;

                //    Item.Value = NewItemValues.Value;

                //}

                //if (myParameterQueue.Count > 0)
                //{

                //    for (int i = myParameterQueue.Count; i > 0; i--)
                //    {

                //        NewItemValues = myParameterQueue.Dequeue();

                //        myCommand.Parameters.Add(myParameterChache.Fetch(NewItemValues.Value, NewItemValues.Key));

                //    }

                //}

            }

        }

        public void SetParameterNamesAndValuesParams(params KeyValuePair<string, object>[] TheParameters)
        {

            SetParameterNamesAndValues(TheParameters);

        }

        public IEnumerable<KeyValuePair<string, object>> GetParameterNamesAndValues()
        {

            Queue<KeyValuePair<string, object>> myParameterQueue = new Queue<KeyValuePair<string, object>>();

            foreach(DbParameter Item in myCommand.Parameters)
            {

                myParameterQueue.Enqueue(new KeyValuePair<string, object>(Item.ParameterName, Item.Value));

            }

            return myParameterQueue;

        }

        public void GetParameterNamesAndValuesInto(ICollection<KeyValuePair<string, object>> TheParameterSet)
        {

            foreach(DbParameter Item in myCommand.Parameters)
            {

                TheParameterSet.Add(new KeyValuePair<string, object>(Item.ParameterName, Item.Value));

            }

        }

        public void GetParameterNamesAndValuesInto(IDictionary<string, object> TheParameterSet)
        {

            foreach(DbParameter Item in myCommand.Parameters)
            {

                TheParameterSet.Add(Item.ParameterName, Item.Value);

            }

        }

        public bool HasParameterWithName(string TheName)
        {

            return myCommand.Parameters.Contains(TheName);

        }

        public bool HasParameterWithValue(string TheValue)
        {

            return myCommand.Parameters.Contains(TheValue);

        }

        public object GetValueOfParameter(string TheName)
        {

            if(myCommand.Parameters.Contains(TheName))
            {

                return myCommand.Parameters[TheName].Value;

            }

            return null;

        }

        public bool HasParameters
        {

            get
            {

                return myCommand.Parameters.Count > 0;

            }

        }

        protected DataTable GetDataTable(DbDataReader TheDbDataReader)
        {

            DataTable DT = new DataTable();

            if(TheDbDataReader.HasRows && !TheDbDataReader.IsClosed)
            {

                //if (TheDbDataReader.Read())
                //{

                object[] Values; // = null;

                int NumberOfRows = TheDbDataReader.FieldCount;

                //object[] Values = new object[NumberOfRows]();

                for(int i = 0; i < NumberOfRows; i++)
                {

                    DT.Columns.Add(TheDbDataReader.GetName(i), TheDbDataReader.GetFieldType(i));

                }

                //TheDbDataReader.GetValues(Values);

                //DT.Rows.Add(Values);

                while(TheDbDataReader.Read())
                {

                    Values = new object[NumberOfRows];

                    TheDbDataReader.GetValues(Values);

                    DT.Rows.Add(Values);

                }

                //}

            }

            TheDbDataReader.Close();

            //TheDbDataReader.Dispose();

            return DT;

        }

        public int ExecuteNonQuery()
        {

            return myExecuteNonQueryAction();

        }

        public int ExecuteNonQuery(Stopwatch TheStopWatch)
        {

            try
            {

                if(TheStopWatch.IsRunning)
                    TheStopWatch.Restart();
                else
                    TheStopWatch.Start();

                return myExecuteNonQueryAction();

            }
            finally
            {

                TheStopWatch.Stop();

            }

        }

        public int ExecuteNonQuery(string TheCommand)
        {

            return myExecuteNonQuery(TheCommand);

        }

        public int ExecuteNonQuery(string TheCommand, Stopwatch TheStopWatch)
        {

            try
            {

                if(TheStopWatch.IsRunning)
                    TheStopWatch.Restart();
                else
                    TheStopWatch.Start();

                return myExecuteNonQuery(TheCommand);

            }
            finally
            {

                TheStopWatch.Stop();

            }

        }

        public int ExecuteNonQuery(StringBuilder TheCommandStringBuilder)
        {

            return myExecuteNonQuery(TheCommandStringBuilder.ToString());

        }

        public int ExecuteNonQuery(StringBuilder TheCommandStringBuilder, Stopwatch TheStopWatch)
        {

            try
            {

                if(TheStopWatch.IsRunning)
                    TheStopWatch.Restart();
                else
                    TheStopWatch.Start();

                return myExecuteNonQuery(TheCommandStringBuilder.ToString());

            }
            finally
            {

                TheStopWatch.Stop();

            }

        }

        public int ExecuteNonQuery(IEnumerable<object> TheParameters)
        {

            return myExecuteNonQueryParametersOnly(TheParameters);

        }

        public int ExecuteNonQuery(IEnumerable<object> TheParameters, Stopwatch TheStopWatch)
        {

            try
            {

                if(TheStopWatch.IsRunning)
                    TheStopWatch.Restart();
                else
                    TheStopWatch.Start();

                return myExecuteNonQueryParametersOnly(TheParameters);

            }
            finally
            {

                TheStopWatch.Stop();

            }

        }

        //public int ExecuteNonQuery(IEnumerable<KeyValuePair<string, object>> TheParameters)
        //{

        //    //return myExecuteNonQueryParameters(TheCommandStringBuilder.ToString(), TheParameters);

        //    return 0;

        //}

        public int ExecuteNonQuery(string TheCommand, IEnumerable<object> TheParameters)
        {

            return myExecuteNonQueryParameters(TheCommand, TheParameters);

        }

        public int ExecuteNonQuery(string TheCommand, IEnumerable<object> TheParameters, Stopwatch TheStopWatch)
        {

            try
            {

                if(TheStopWatch.IsRunning)
                    TheStopWatch.Restart();
                else
                    TheStopWatch.Start();

                return myExecuteNonQueryParameters(TheCommand, TheParameters);

            }
            finally
            {

                TheStopWatch.Stop();

            }

        }

        //public int ExecuteNonQuery(string TheCommand, IEnumerable<KeyValuePair<string, object>> TheParameters)
        //{

        //    //return myExecuteNonQueryParameters(TheCommandStringBuilder.ToString(), TheParameters);

        //    return 0;

        //}

        public int ExecuteNonQuery(StringBuilder TheCommandStringBuilder, IEnumerable<object> TheParameters)
        {

            return myExecuteNonQueryParameters(TheCommandStringBuilder.ToString(), TheParameters);

        }

        public int ExecuteNonQuery(StringBuilder TheCommandStringBuilder, IEnumerable<object> TheParameters, Stopwatch TheStopWatch)
        {

            try
            {

                if(TheStopWatch.IsRunning)
                    TheStopWatch.Restart();
                else
                    TheStopWatch.Start();

                return myExecuteNonQueryParameters(TheCommandStringBuilder.ToString(), TheParameters);

            }
            finally
            {

                TheStopWatch.Stop();

            }

        }

        //public int ExecuteNonQuery(StringBuilder TheCommandStringBuilder, IEnumerable<KeyValuePair<string, object>> TheParameters)
        //{

        //    //return myExecuteNonQueryParameters(TheCommandStringBuilder.ToString(), TheParameters);

        //    return 0;

        //}

        //-- Talking Params Arrays

        public int ExecuteNonQueryParamsOnly(params object[] TheParameters)
        {

            return myExecuteNonQueryParametersOnly(TheParameters);

        }

        public int ExecuteNonQueryTimedParamsOnly(Stopwatch TheStopWatch, params object[] TheParameters)
        {

            try
            {

                if(TheStopWatch.IsRunning)
                    TheStopWatch.Restart();
                else
                    TheStopWatch.Start();

                return myExecuteNonQueryParametersOnly(TheParameters);

            }
            finally
            {

                TheStopWatch.Stop();

            }

        }

        public int ExecuteNonQueryParams(string TheCommand, params object[] TheParameters)
        {

            return myExecuteNonQueryParameters(TheCommand, TheParameters);

        }

        public int ExecuteNonQueryTimedParams(string TheCommand, Stopwatch TheStopWatch, params object[] TheParameters)
        {

            try
            {

                if(TheStopWatch.IsRunning)
                    TheStopWatch.Restart();
                else
                    TheStopWatch.Start();

                return myExecuteNonQueryParametersOnly(TheParameters);

            }
            finally
            {

                TheStopWatch.Stop();

            }

        }

        public int ExecuteNonQueryParams(StringBuilder TheCommandStringBuilder, params object[] TheParameters)
        {

            return myExecuteNonQueryParameters(TheCommandStringBuilder.ToString(), TheParameters);

        }

        public int ExecuteNonQueryTimedParams(StringBuilder TheCommandStringBuilder, Stopwatch TheStopWatch, params object[] TheParameters)
        {

            try
            {

                if(TheStopWatch.IsRunning)
                    TheStopWatch.Restart();
                else
                    TheStopWatch.Start();

                return myExecuteNonQueryParameters(TheCommandStringBuilder.ToString(), TheParameters);

            }
            finally
            {

                TheStopWatch.Stop();

            }

        }

        //public int ExecuteNonQueryParams(StringBuilder TheCommandStringBuilder, params KeyValuePair<string, object>[] TheParameters)
        //{

        //    return myExecuteNonQueryParameters(TheCommandStringBuilder.ToString(), TheParameters);

        //}

        //--

        public DbDataReader ExecuteReader()
        {

            return myExecuteReaderAction();

        }

        public DbDataReader ExecuteReader(Stopwatch TheStopWatch)
        {

            try
            {

                if(TheStopWatch.IsRunning)
                    TheStopWatch.Restart();
                else
                    TheStopWatch.Start();

                return myExecuteReaderAction();

            }
            finally
            {

                TheStopWatch.Stop();

            }

        }

        public DbDataReader ExecuteReader(string TheCommand)
        {

            return myExecuteReader(TheCommand);

        }

        public DbDataReader ExecuteReader(string TheCommand, Stopwatch TheStopWatch)
        {

            try
            {

                if(TheStopWatch.IsRunning)
                    TheStopWatch.Restart();
                else
                    TheStopWatch.Start();

                return myExecuteReader(TheCommand);

            }
            finally
            {

                TheStopWatch.Stop();

            }

        }

        public DbDataReader ExecuteReader(StringBuilder TheCommandStringBuilder)
        {

            return myExecuteReader(TheCommandStringBuilder.ToString());

        }

        public DbDataReader ExecuteReader(StringBuilder TheCommandStringBuilder, Stopwatch TheStopWatch)
        {

            try
            {

                if(TheStopWatch.IsRunning)
                    TheStopWatch.Restart();
                else
                    TheStopWatch.Start();

                return myExecuteReader(TheCommandStringBuilder.ToString());

            }
            finally
            {

                TheStopWatch.Stop();

            }

        }

        public DbDataReader ExecuteReader(IEnumerable<object> TheParameters)
        {

            return myExecuteReaderParametersOnly(TheParameters);

        }

        public DbDataReader ExecuteReader(IEnumerable<object> TheParameters, Stopwatch TheStopWatch)
        {

            try
            {

                if(TheStopWatch.IsRunning)
                    TheStopWatch.Restart();
                else
                    TheStopWatch.Start();

                return myExecuteReaderParametersOnly(TheParameters);

            }
            finally
            {

                TheStopWatch.Stop();

            }

        }

        public DbDataReader ExecuteReader(string TheCommand, IEnumerable<object> TheParameters)
        {

            return myExecuteReaderParameters(TheCommand, TheParameters);

        }

        public DbDataReader ExecuteReader(string TheCommand, IEnumerable<object> TheParameters, Stopwatch TheStopWatch)
        {

            try
            {

                if(TheStopWatch.IsRunning)
                    TheStopWatch.Restart();
                else
                    TheStopWatch.Start();

                return myExecuteReaderParameters(TheCommand, TheParameters);

            }
            finally
            {

                TheStopWatch.Stop();

            }

        }

        public DbDataReader ExecuteReader(StringBuilder TheCommandStringBuilder, IEnumerable<object> TheParameters)
        {

            return myExecuteReaderParameters(TheCommandStringBuilder.ToString(), TheParameters);

        }

        public DbDataReader ExecuteReader(StringBuilder TheCommandStringBuilder, IEnumerable<object> TheParameters, Stopwatch TheStopWatch)
        {

            try
            {

                if(TheStopWatch.IsRunning)
                    TheStopWatch.Restart();
                else
                    TheStopWatch.Start();

                return myExecuteReaderParameters(TheCommandStringBuilder.ToString(), TheParameters);

            }
            finally
            {

                TheStopWatch.Stop();

            }

        }

        //public DbDataReader ExecuteReader(StringBuilder TheCommandStringBuilder, params KeyValuePair<string, object>[] TheParameters)
        //{

        //    return myExecuteReaderParameters(TheCommandStringBuilder.ToString(), TheParameters);

        //}

        //-- Talking Params Arrays

        public DbDataReader ExecuteReaderParamsOnly(params object[] TheParameters)
        {

            return myExecuteReaderParametersOnly(TheParameters);

        }

        //public DbDataReader ExecuteReaderParams(params KeyValuePair<string, object>[] TheParameters)
        //{

        //    return myExecuteReaderParameters(TheParameters);

        //}

        public DbDataReader ExecuteReaderParams(string TheCommand, params object[] TheParameters)
        {

            return myExecuteReaderParameters(TheCommand, TheParameters);

        }

        public DbDataReader ExecuteReaderTimedParams(Stopwatch TheStopWatch, string TheCommand, params object[] TheParameters)
        {

            try
            {

                if(TheStopWatch.IsRunning)
                    TheStopWatch.Restart();
                else
                    TheStopWatch.Start();

                return myExecuteReaderParameters(TheCommand, TheParameters);

            }
            finally
            {

                TheStopWatch.Stop();

            }

        }

        //public DbDataReader ExecuteReaderParams(string TheCommand, params KeyValuePair<string, object>[] TheParameters)
        //{

        //    return myExecuteReaderParameters(TheCommand, TheParameters);

        //}

        public DbDataReader ExecuteReaderParams(StringBuilder TheCommandStringBuilder, params object[] TheParameters)
        {

            return myExecuteReaderParameters(TheCommandStringBuilder.ToString(), TheParameters);

        }

        public DbDataReader ExecuteReaderTimedParams(Stopwatch TheStopWatch, StringBuilder TheCommandStringBuilder, params object[] TheParameters)
        {

            try
            {

                if(TheStopWatch.IsRunning)
                    TheStopWatch.Restart();
                else
                    TheStopWatch.Start();

                return myExecuteReaderParameters(TheCommandStringBuilder.ToString(), TheParameters);

            }
            finally
            {

                TheStopWatch.Stop();

            }

        }

        //public DbDataReader ExecuteReaderParams(StringBuilder TheCommandStringBuilder, params KeyValuePair<string, object>[] TheParameters)
        //{

        //    return myExecuteReaderParameters(TheCommandStringBuilder.ToString(), TheParameters);

        //}

        //--

        public object ExecuteScalar()
        {

            return myExecuteScalarAction();

        }

        public object ExecuteScalar(Stopwatch TheStopWatch)
        {

            try
            {

                if(TheStopWatch.IsRunning)
                    TheStopWatch.Restart();
                else
                    TheStopWatch.Start();

                return myExecuteScalarAction();

            }
            finally
            {

                TheStopWatch.Stop();

            }

        }

        public object ExecuteScalar(string TheCommand)
        {

            return myExecuteScalar(TheCommand);

        }

        public object ExecuteScalar(string TheCommand, Stopwatch TheStopWatch)
        {

            try
            {

                if(TheStopWatch.IsRunning)
                    TheStopWatch.Restart();
                else
                    TheStopWatch.Start();

                return myExecuteScalar(TheCommand);

            }
            finally
            {

                TheStopWatch.Stop();

            }

        }

        public object ExecuteScalar(StringBuilder TheCommandStringBuilder)
        {

            return myExecuteScalar(TheCommandStringBuilder.ToString());

        }

        public object ExecuteScalar(StringBuilder TheCommandStringBuilder, Stopwatch TheStopWatch)
        {

            try
            {

                if(TheStopWatch.IsRunning)
                    TheStopWatch.Restart();
                else
                    TheStopWatch.Start();

                return myExecuteScalar(TheCommandStringBuilder.ToString());

            }
            finally
            {

                TheStopWatch.Stop();

            }

        }

        public object ExecuteScalar(IEnumerable<object> TheParameters)
        {

            return myExecuteScalarParametersOnly(TheParameters);

        }

        public object ExecuteScalar(IEnumerable<object> TheParameters, Stopwatch TheStopWatch)
        {

            try
            {

                if(TheStopWatch.IsRunning)
                    TheStopWatch.Restart();
                else
                    TheStopWatch.Start();

                return myExecuteScalarParametersOnly(TheParameters);

            }
            finally
            {

                TheStopWatch.Stop();

            }

        }

        public object ExecuteScalar(string TheCommand, IEnumerable<object> TheParameters)
        {

            return myExecuteScalarParameters(TheCommand, TheParameters);

        }

        public object ExecuteScalar(string TheCommand, IEnumerable<object> TheParameters, Stopwatch TheStopWatch)
        {

            try
            {

                if(TheStopWatch.IsRunning)
                    TheStopWatch.Restart();
                else
                    TheStopWatch.Start();

                return myExecuteScalarParameters(TheCommand, TheParameters);

            }
            finally
            {

                TheStopWatch.Stop();

            }

        }

        //public object ExecuteScalar(string TheCommand, params KeyValuePair<string, object>[] TheParameters)
        //{

        //    return myExecuteScalarParameters(TheCommand, TheParameters);

        //}

        public object ExecuteScalar(StringBuilder TheCommandStringBuilder, IEnumerable<object> TheParameters)
        {

            return myExecuteScalarParameters(TheCommandStringBuilder.ToString(), TheParameters);

        }

        public object ExecuteScalar(StringBuilder TheCommandStringBuilder, IEnumerable<object> TheParameters, Stopwatch TheStopWatch)
        {

            try
            {

                if(TheStopWatch.IsRunning)
                    TheStopWatch.Restart();
                else
                    TheStopWatch.Start();

                return myExecuteScalarParameters(TheCommandStringBuilder.ToString(), TheParameters);

            }
            finally
            {

                TheStopWatch.Stop();

            }

        }

        //public object ExecuteScalar(StringBuilder TheCommandStringBuilder, params KeyValuePair<string, object>[] TheParameters)
        //{

        //    return myExecuteScalarParameters(TheCommandStringBuilder.ToString(), TheParameters);

        //}

        //-- Talking Params Arrays

        public object ExecuteScalarParamsOnly(params object[] TheParameters)
        {

            return myExecuteScalarParametersOnly(TheParameters);

        }

        public object ExecuteScalarTimedParamsOnly(Stopwatch TheStopWatch, params object[] TheParameters)
        {

            try
            {

                if(TheStopWatch.IsRunning)
                    TheStopWatch.Restart();
                else
                    TheStopWatch.Start();

                return myExecuteScalarParametersOnly(TheParameters);

            }
            finally
            {

                TheStopWatch.Stop();

            }

        }

        public object ExecuteScalarParams(string TheCommand, params object[] TheParameters)
        {

            return myExecuteScalarParameters(TheCommand, TheParameters);

        }

        public object ExecuteScalarTimedParamsOnly(Stopwatch TheStopWatch, string TheCommand, params object[] TheParameters)
        {

            try
            {

                if(TheStopWatch.IsRunning)
                    TheStopWatch.Restart();
                else
                    TheStopWatch.Start();

                return myExecuteScalarParameters(TheCommand, TheParameters);

            }
            finally
            {

                TheStopWatch.Stop();

            }

        }

        public object ExecuteScalarParams(StringBuilder TheCommandStringBuilder, params object[] TheParameters)
        {

            return myExecuteScalarParameters(TheCommandStringBuilder.ToString(), TheParameters);

        }

        public object ExecuteScalarTimedParams(Stopwatch TheStopWatch, StringBuilder TheCommandStringBuilder, params object[] TheParameters)
        {

            try
            {

                if(TheStopWatch.IsRunning)
                    TheStopWatch.Restart();
                else
                    TheStopWatch.Start();

                return myExecuteScalarParameters(TheCommandStringBuilder.ToString(), TheParameters);

            }
            finally
            {

                TheStopWatch.Stop();

            }

        }

        //public object ExecuteScalarParams(StringBuilder TheCommandStringBuilder, params KeyValuePair<string, object>[] TheParameters)
        //{

        //    return myExecuteScalarParameters(TheCommandStringBuilder.ToString(), TheParameters);

        //}

        //--

        public DataTable ExecuteDataTable()
        {

            return myExecuteDataTableAction();

        }

        public DataTable ExecuteDataTable(Stopwatch TheStopWatch)
        {

            try
            {

                if(TheStopWatch.IsRunning)
                    TheStopWatch.Restart();
                else
                    TheStopWatch.Start();

                return myExecuteDataTableAction();

            }
            finally
            {

                TheStopWatch.Stop();

            }

        }

        public DataTable ExecuteDataTable(string TheCommand)
        {

            return myExecuteDataTable(TheCommand);

        }

        public DataTable ExecuteDataTable(string TheCommand, Stopwatch TheStopWatch)
        {

            try
            {

                if(TheStopWatch.IsRunning)
                    TheStopWatch.Restart();
                else
                    TheStopWatch.Start();

                return myExecuteDataTable(TheCommand);

            }
            finally
            {

                TheStopWatch.Stop();

            }

        }

        public DataTable ExecuteDataTable(StringBuilder TheCommandStringBuilder)
        {

            return myExecuteDataTable(TheCommandStringBuilder.ToString());

        }

        public DataTable ExecuteDataTable(StringBuilder TheCommandStringBuilder, Stopwatch TheStopWatch)
        {

            try
            {

                if(TheStopWatch.IsRunning)
                    TheStopWatch.Restart();
                else
                    TheStopWatch.Start();

                return myExecuteDataTable(TheCommandStringBuilder.ToString());

            }
            finally
            {

                TheStopWatch.Stop();

            }

        }

        public DataTable ExecuteDataTable(IEnumerable<object> TheParameters)
        {

            return myExecuteDataTableParametersOnly(TheParameters);

        }

        public DataTable ExecuteDataTable(IEnumerable<object> TheParameters, Stopwatch TheStopWatch)
        {

            try
            {

                if(TheStopWatch.IsRunning)
                    TheStopWatch.Restart();
                else
                    TheStopWatch.Start();

                return myExecuteDataTableParametersOnly(TheParameters);

            }
            finally
            {

                TheStopWatch.Stop();

            }

        }

        public DataTable ExecuteDataTable(string TheCommand, IEnumerable<object> TheParameters)
        {

            return myExecuteDataTableParameters(TheCommand, TheParameters);

        }

        public DataTable ExecuteDataTable(string TheCommand, IEnumerable<object> TheParameters, Stopwatch TheStopWatch)
        {

            try
            {

                if(TheStopWatch.IsRunning)
                    TheStopWatch.Restart();
                else
                    TheStopWatch.Start();

                return myExecuteDataTableParameters(TheCommand, TheParameters);

            }
            finally
            {

                TheStopWatch.Stop();

            }

        }

        public DataTable ExecuteDataTable(StringBuilder TheCommandStringBuilder, IEnumerable<object> TheParameters)
        {

            return myExecuteDataTableParameters(TheCommandStringBuilder.ToString(), TheParameters);

        }

        public DataTable ExecuteDataTable(StringBuilder TheCommandStringBuilder, IEnumerable<object> TheParameters, Stopwatch TheStopWatch)
        {

            try
            {

                if(TheStopWatch.IsRunning)
                    TheStopWatch.Restart();
                else
                    TheStopWatch.Start();

                return myExecuteDataTableParameters(TheCommandStringBuilder.ToString(), TheParameters);

            }
            finally
            {

                TheStopWatch.Stop();

            }

        }

        //-- Talking Params Arrays

        public DataTable ExecuteDataTableParamsOnly(params object[] TheParameters)
        {

            return myExecuteDataTableParametersOnly(TheParameters);

        }

        public DataTable ExecuteDataTableTimedParamsOnly(Stopwatch TheStopWatch, params object[] TheParameters)
        {

            try
            {

                if(TheStopWatch.IsRunning)
                    TheStopWatch.Restart();
                else
                    TheStopWatch.Start();

                return myExecuteDataTableParametersOnly(TheParameters);

            }
            finally
            {

                TheStopWatch.Stop();

            }

        }

        public DataTable ExecuteDataTableParams(string TheCommand, params object[] TheParameters)
        {

            return myExecuteDataTableParameters(TheCommand, TheParameters);

        }

        public DataTable ExecuteDataTableTimedParams(Stopwatch TheStopWatch, string TheCommand, params object[] TheParameters)
        {

            try
            {

                if(TheStopWatch.IsRunning)
                    TheStopWatch.Restart();
                else
                    TheStopWatch.Start();

                return myExecuteDataTableParameters(TheCommand, TheParameters);

            }
            finally
            {

                TheStopWatch.Stop();

            }

        }

        public DataTable ExecuteDataTableParams(StringBuilder TheCommandStringBuilder, params object[] TheParameters)
        {

            return myExecuteDataTableParameters(TheCommandStringBuilder.ToString(), TheParameters);

        }

        public DataTable ExecuteDataTableTimedParams(Stopwatch TheStopWatch, StringBuilder TheCommandStringBuilder, params object[] TheParameters)
        {

            try
            {

                if(TheStopWatch.IsRunning)
                    TheStopWatch.Restart();
                else
                    TheStopWatch.Start();

                return myExecuteDataTableParameters(TheCommandStringBuilder.ToString(), TheParameters);

            }
            finally
            {

                TheStopWatch.Stop();

            }

        }

        //--

        //protected void QuickDiscreteOpen()
        //{

        //    //Error!

        //}

        //protected void QuickDiscreteClose()
        //{

        //    //Error!

        //}

        protected int QuickDiscreteExecuteNonQuery()
        {

            if(!myIsActive)
            {

                try
                {

                    myIsActive = true;

                    ResetParameters();

                    myCommand.Connection.Open();

                    return myCommand.ExecuteNonQuery();

                }
                catch(Exception e)
                {

                    OnError(e);

                }
                finally
                {

                    myCommand.Connection.Close();

                    myIsActive = false;

                }

            }

            return 0;

        }

        protected int QuickDiscreteExecuteNonQuery(string TheCommand)
        {

            if(!myIsActive)
            {

                try
                {

                    myIsActive = true;

                    myCommand.CommandText = TheCommand;

                    ResetParameters();

                    myCommand.Connection.Open();

                    return myCommand.ExecuteNonQuery();

                }
                catch(Exception e)
                {

                    OnError(e);

                }
                finally
                {

                    myCommand.Connection.Close();

                    myIsActive = false;

                }

            }

            return 0;

        }

        protected int QuickDiscreteExecuteNonQuery(IEnumerable<object> TheParameters)
        {

            if(!myIsActive)
            {

                try
                {

                    myIsActive = true;

                    SetParameterValues(TheParameters);

                    myCommand.Connection.Open();

                    return myCommand.ExecuteNonQuery();

                }
                catch(Exception e)
                {

                    OnError(e);

                }
                finally
                {

                    myCommand.Connection.Close();

                    myIsActive = false;

                }

            }

            return 0;

        }

        protected int QuickDiscreteExecuteNonQuery(string TheCommand, IEnumerable<object> TheParameters)
        {

            if(!myIsActive)
            {

                try
                {

                    myIsActive = true;

                    myCommand.CommandText = TheCommand;

                    SetParameterValues(TheParameters);

                    myCommand.Connection.Open();

                    return myCommand.ExecuteNonQuery();

                }
                catch(Exception e)
                {

                    OnError(e);

                }
                finally
                {

                    myCommand.Connection.Close();

                    myIsActive = false;

                }

            }

            return 0;

        }

        protected DbDataReader QuickDiscreteExecuteReader()
        {

            if(!myIsActive)
            {

                try
                {

                    myIsActive = true;

                    ResetParameters();

                    myCommand.Connection.Open();

                    return myCommand.ExecuteReader();

                }
                catch(Exception e)
                {

                    OnError(e);

                }
                finally
                {

                    myCommand.Connection.Close();

                    myIsActive = false;

                }

            }

            return null;

        }

        protected DbDataReader QuickDiscreteExecuteReader(string TheCommand)
        {

            if(!myIsActive)
            {

                try
                {

                    myIsActive = true;

                    myCommand.CommandText = TheCommand;

                    ResetParameters();

                    myCommand.Connection.Open();

                    return myCommand.ExecuteReader();

                }
                catch(Exception e)
                {

                    OnError(e);

                }
                finally
                {

                    myCommand.Connection.Close();

                    myIsActive = false;

                }

            }

            return null;

        }

        protected DbDataReader QuickDiscreteExecuteReader(IEnumerable<object> TheParameters)
        {

            if(!myIsActive)
            {

                try
                {

                    myIsActive = true;

                    SetParameterValues(TheParameters);

                    myCommand.Connection.Open();

                    return myCommand.ExecuteReader();

                }
                catch(Exception e)
                {

                    OnError(e);

                }
                finally
                {

                    myCommand.Connection.Close();

                    myIsActive = false;

                }

            }

            return null;

        }

        protected DbDataReader QuickDiscreteExecuteReader(string TheCommand, IEnumerable<object> TheParameters)
        {

            if(!myIsActive)
            {

                try
                {

                    myIsActive = true;

                    myCommand.CommandText = TheCommand;

                    SetParameterValues(TheParameters);

                    myCommand.Connection.Open();

                    return myCommand.ExecuteReader();

                }
                catch(Exception e)
                {

                    OnError(e);

                }
                finally
                {

                    myCommand.Connection.Close();

                    myIsActive = false;

                }

            }

            return null;

        }

        protected object QuickDiscreteExecuteScalar()
        {

            if(!myIsActive)
            {

                try
                {

                    myIsActive = true;

                    ResetParameters();

                    myCommand.Connection.Open();

                    return myCommand.ExecuteScalar();

                }
                catch(Exception e)
                {

                    OnError(e);

                }
                finally
                {

                    myCommand.Connection.Close();

                    myIsActive = false;

                }

            }

            return null;

        }

        protected object QuickDiscreteExecuteScalar(string TheCommand)
        {

            if(!myIsActive)
            {

                try
                {

                    myIsActive = true;

                    myCommand.CommandText = TheCommand;

                    ResetParameters();

                    myCommand.Connection.Open();

                    return myCommand.ExecuteScalar();

                }
                catch(Exception e)
                {

                    OnError(e);

                }
                finally
                {

                    myCommand.Connection.Close();

                    myIsActive = false;

                }

            }

            return null;

        }

        protected object QuickDiscreteExecuteScalar(IEnumerable<object> TheParameters)
        {

            if(!myIsActive)
            {

                try
                {

                    myIsActive = true;

                    SetParameterValues(TheParameters);

                    myCommand.Connection.Open();

                    return myCommand.ExecuteScalar();

                }
                catch(Exception e)
                {

                    OnError(e);

                }
                finally
                {

                    myCommand.Connection.Close();

                    myIsActive = false;

                }

            }

            return null;

        }

        protected object QuickDiscreteExecuteScalar(string TheCommand, IEnumerable<object> TheParameters)
        {

            if(!myIsActive)
            {

                try
                {

                    myIsActive = true;

                    myCommand.CommandText = TheCommand;

                    SetParameterValues(TheParameters);

                    myCommand.Connection.Open();

                    return myCommand.ExecuteScalar();

                }
                catch(Exception e)
                {

                    OnError(e);

                }
                finally
                {

                    myCommand.Connection.Close();

                    myIsActive = false;

                }

            }

            return null;

        }

        protected DataTable QuickDiscreteExecuteDataTable()
        {

            if(!myIsActive)
            {

                try
                {

                    myIsActive = true;

                    ResetParameters();

                    myCommand.Connection.Open();

                    return GetDataTable(myCommand.ExecuteReader());

                }
                catch(Exception e)
                {

                    OnError(e);

                }
                finally
                {

                    myCommand.Connection.Close();

                    myIsActive = false;

                }

            }

            return null;

        }

        protected DataTable QuickDiscreteExecuteDataTable(string TheCommand)
        {

            if(!myIsActive)
            {

                try
                {

                    myIsActive = true;

                    myCommand.CommandText = TheCommand;

                    ResetParameters();

                    myCommand.Connection.Open();

                    return GetDataTable(myCommand.ExecuteReader());

                }
                catch(Exception e)
                {

                    OnError(e);

                }
                finally
                {

                    myCommand.Connection.Close();

                    myIsActive = false;

                }

            }

            return null;

        }

        protected DataTable QuickDiscreteExecuteDataTable(IEnumerable<object> TheParameters)
        {

            if(!myIsActive)
            {

                try
                {

                    myIsActive = true;

                    SetParameterValues(TheParameters);

                    myCommand.Connection.Open();

                    return GetDataTable(myCommand.ExecuteReader());

                }
                catch(Exception e)
                {

                    OnError(e);

                }
                finally
                {

                    myCommand.Connection.Close();

                    myIsActive = false;

                }

            }

            return null;

        }

        protected DataTable QuickDiscreteExecuteDataTable(string TheCommand, IEnumerable<object> TheParameters)
        {

            if(!myIsActive)
            {

                try
                {

                    myIsActive = true;

                    myCommand.CommandText = TheCommand;

                    SetParameterValues(TheParameters);

                    myCommand.Connection.Open();

                    return GetDataTable(myCommand.ExecuteReader());

                }
                catch(Exception e)
                {

                    OnError(e);

                }
                finally
                {

                    myCommand.Connection.Close();

                    myIsActive = false;

                }

            }

            return null;

        }

        protected void DiscreteOpen()
        {

            if(!myIsActive) // && myIsEngaged)
            {

                try
                {

                    myCommand.Connection.Open();

                    myIsActive = true;

                }
                catch(Exception e)
                {

                    myCommand.Connection.Close();

                    OnError(e);

                }

            }
            else
            {

                //Error!

            }

        }

        protected void DiscreteClose()
        {

            if(myIsActive)
            {

                try
                {

                    myCommand.Connection.Close();

                }
                finally
                {

                    myIsActive = false;

                }

            }
            else
            {

                //Error!

            }

        }

        protected int DiscreteExecuteNonQuery()
        {

            if(myIsActive)
            {

                //try
                //{

                ResetParameters();

                return myCommand.ExecuteNonQuery();

                //}
                //catch (Exception e)
                //{

                //    DiscreteClose();

                //    OnError(e);

                //}

            }

            return 0;

        }

        protected int DiscreteExecuteNonQuery(string TheCommand)
        {

            if(myIsActive)
            {

                //try
                //{

                myCommand.CommandText = TheCommand;

                ResetParameters();

                return myCommand.ExecuteNonQuery();

                //}
                //catch (Exception e)
                //{

                //    DiscreteClose();

                //    OnError(e);

                //}

            }

            return 0;

        }

        protected int DiscreteExecuteNonQuery(IEnumerable<object> TheParameters)
        {

            if(myIsActive)
            {

                //try
                //{

                SetParameterValues(TheParameters);

                return myCommand.ExecuteNonQuery();

                //}
                //catch (Exception e)
                //{

                //    DiscreteClose();

                //    OnError(e);

                //}

            }

            return 0;

        }

        protected int DiscreteExecuteNonQuery(string TheCommand, IEnumerable<object> TheParameters)
        {

            if(myIsActive)
            {

                //try
                //{

                myCommand.CommandText = TheCommand;

                SetParameterValues(TheParameters);

                return myCommand.ExecuteNonQuery();

                //}
                //catch (Exception e)
                //{

                //    DiscreteClose();

                //    OnError(e);

                //}

            }

            return 0;

        }

        protected DbDataReader DiscreteExecuteReader()
        {

            if(myIsActive)
            {

                //try
                //{

                ResetParameters();

                return myCommand.ExecuteReader();

                //}
                //catch (Exception e)
                //{

                //    DiscreteClose();

                //    OnError(e);

                //}

            }

            return null;

        }

        protected DbDataReader DiscreteExecuteReader(string TheCommand)
        {

            if(myIsActive)
            {

                //try
                //{

                myCommand.CommandText = TheCommand;

                ResetParameters();

                return myCommand.ExecuteReader();

                //}
                //catch (Exception e)
                //{

                //    DiscreteClose();

                //    OnError(e);

                //}

            }

            return null;

        }

        protected DbDataReader DiscreteExecuteReader(IEnumerable<object> TheParameters)
        {

            if(myIsActive)
            {

                //try
                //{

                SetParameterValues(TheParameters);

                return myCommand.ExecuteReader();

                //}
                //catch (Exception e)
                //{

                //    DiscreteClose();

                //    OnError(e);

                //}

            }

            return null;

        }

        protected DbDataReader DiscreteExecuteReader(string TheCommand, IEnumerable<object> TheParameters)
        {

            if(myIsActive)
            {

                //try
                //{

                myCommand.CommandText = TheCommand;

                SetParameterValues(TheParameters);

                return myCommand.ExecuteReader();

                //}
                //catch (Exception e)
                //{

                //    DiscreteClose();

                //    OnError(e);

                //}

            }

            return null;

        }

        protected object DiscreteExecuteScalar()
        {

            if(myIsActive)
            {

                //try
                //{

                ResetParameters();

                return myCommand.ExecuteScalar();

                //}
                //catch (Exception e)
                //{

                //    DiscreteClose();

                //    OnError(e);

                //}

            }

            return null;

        }

        protected object DiscreteExecuteScalar(string TheCommand)
        {

            if(myIsActive)
            {

                //try
                //{

                myCommand.CommandText = TheCommand;

                ResetParameters();

                return myCommand.ExecuteScalar();

                //}
                //catch (Exception e)
                //{

                //    DiscreteClose();

                //    OnError(e);

                //}

            }

            return null;

        }

        protected object DiscreteExecuteScalar(IEnumerable<object> TheParameters)
        {

            if(myIsActive)
            {

                //try
                //{

                SetParameterValues(TheParameters);

                return myCommand.ExecuteScalar();

                //}
                //catch (Exception e)
                //{

                //    DiscreteClose();

                //    OnError(e);

                //}


            }

            return null;

        }

        protected object DiscreteExecuteScalar(string TheCommand, IEnumerable<object> TheParameters)
        {

            if(myIsActive)
            {

                //try
                //{

                myCommand.CommandText = TheCommand;

                SetParameterValues(TheParameters);

                return myCommand.ExecuteScalar();

                //}
                //catch (Exception e)
                //{

                //    DiscreteClose();

                //    OnError(e);

                //}


            }

            return null;

        }

        protected DataTable DiscreteExecuteDataTable()
        {

            if(myIsActive)
            {

                //try
                //{

                ResetParameters();

                return GetDataTable(myCommand.ExecuteReader());

                //}
                //catch (Exception e)
                //{

                //    DiscreteClose();

                //    OnError(e);

                //}

            }

            return null;

        }

        protected DataTable DiscreteExecuteDataTable(string TheCommand)
        {

            if(myIsActive)
            {

                //try
                //{

                myCommand.CommandText = TheCommand;

                ResetParameters();

                return GetDataTable(myCommand.ExecuteReader());

                //}
                //catch (Exception e)
                //{

                //    DiscreteClose();

                //    OnError(e);

                //}

            }

            return null;

        }

        protected DataTable DiscreteExecuteDataTable(IEnumerable<object> TheParameters)
        {

            if(myIsActive)
            {

                //try
                //{

                SetParameterValues(TheParameters);

                return GetDataTable(myCommand.ExecuteReader());

                //}
                //catch (Exception e)
                //{

                //    DiscreteClose();

                //    OnError(e);

                //}

            }

            return null;

        }

        protected DataTable DiscreteExecuteDataTable(string TheCommand, IEnumerable<object> TheParameters)
        {

            if(myIsActive)
            {

                //try
                //{

                myCommand.CommandText = TheCommand;

                SetParameterValues(TheParameters);

                return GetDataTable(myCommand.ExecuteReader());

                //}
                //catch (Exception e)
                //{

                //    DiscreteClose();

                //    OnError(e);

                //}

            }

            return null;

        }

        protected void TransactionalOpen()
        {

            if(!myIsActive) //&& myIsEngaged)
            {

                //try
                //{

                myIsActive = true;

                myCommand.Connection.Open();

                if(myTransactionAction != TransactionAction.Commit)
                    myTransactionAction = TransactionAction.Commit;

                myTransaction = (TTransaction)myCommand.Connection.BeginTransaction(myIsolationLevel);

                //}
                //catch (Exception e)
                //{

                //    //myTransaction.Rollback();

                //    //myCommand.Connection.Close();

                //    //myTransaction.Dispose();

                //    //myIsActive = false;

                //    TransactionFailure();

                //    OnError(e);

                //}

            }
            else
            {

                //Error!

            }

        }

        protected void TransactionalClose()
        {

            if(myIsActive)
            {

                try
                {

                    switch(myTransactionAction)
                    {

                        case TransactionAction.Commit:

                            myTransaction.Commit();

                            break;
                        case TransactionAction.Rollback:

                            myTransaction.Rollback();

                            break;

                    }

                }
                catch(Exception e)
                {

                    //Error!

                    OnError(e);

                }
                finally
                {

                    myCommand.Connection.Close();

                    myTransaction.Dispose();

                    myIsActive = false;

                }

            }
            else
            {

                //Error!

            }

        }

        protected void TransactionFailure()
        {

            myTransaction.Rollback();

            myCommand.Connection.Close();

            myTransaction.Dispose();

            myIsActive = false;

        }

        protected int TransactionalExecuteNonQuery()
        {

            if(myIsActive)
            {

                try
                {

                    ResetParameters();

                    return myCommand.ExecuteNonQuery();

                }
                catch(Exception e)
                {

                    TransactionFailure();

                    OnError(e);

                }

            }

            return 0;

        }

        protected int TransactionalExecuteNonQuery(string TheCommand)
        {

            if(myIsActive)
            {

                try
                {

                    myCommand.CommandText = TheCommand;

                    ResetParameters();

                    return myCommand.ExecuteNonQuery();

                }
                catch(Exception e)
                {

                    TransactionFailure();

                    OnError(e);

                }

            }

            return 0;

        }

        protected int TransactionalExecuteNonQuery(IEnumerable<object> TheParameters)
        {

            if(myIsActive)
            {

                try
                {

                    SetParameterValues(TheParameters);

                    return myCommand.ExecuteNonQuery();

                }
                catch(Exception e)
                {

                    TransactionFailure();

                    OnError(e);

                }

            }

            return 0;

        }

        protected int TransactionalExecuteNonQuery(string TheCommand, IEnumerable<object> TheParameters)
        {

            if(myIsActive)
            {

                try
                {

                    myCommand.CommandText = TheCommand;

                    SetParameterValues(TheParameters);

                    return myCommand.ExecuteNonQuery();

                }
                catch(Exception e)
                {

                    TransactionFailure();

                    OnError(e);

                }

            }

            return 0;

        }

        protected DbDataReader TransactionalExecuteReader()
        {

            if(myIsActive)
            {

                try
                {

                    ResetParameters();

                    return myCommand.ExecuteReader();

                }
                catch(Exception e)
                {

                    TransactionFailure();

                    OnError(e);

                }

            }

            return null;

        }

        protected DbDataReader TransactionalExecuteReader(string TheCommand)
        {

            if(myIsActive)
            {

                try
                {

                    myCommand.CommandText = TheCommand;

                    return myCommand.ExecuteReader();

                }
                catch(Exception e)
                {

                    TransactionFailure();

                    OnError(e);

                }

            }

            return null;

        }

        protected DbDataReader TransactionalExecuteReader(IEnumerable<object> TheParameters)
        {

            if(myIsActive)
            {

                try
                {

                    SetParameterValues(TheParameters);

                    return myCommand.ExecuteReader();

                }
                catch(Exception e)
                {

                    TransactionFailure();

                    OnError(e);

                }

            }

            return null;

        }

        protected DbDataReader TransactionalExecuteReader(string TheCommand, IEnumerable<object> TheParameters)
        {

            if(myIsActive)
            {

                try
                {

                    myCommand.CommandText = TheCommand;

                    SetParameterValues(TheParameters);

                    return myCommand.ExecuteReader();

                }
                catch(Exception e)
                {

                    TransactionFailure();

                    OnError(e);

                }

            }

            return null;

        }

        protected object TransactionalExecuteScalar()
        {

            if(myIsActive)
            {

                try
                {

                    ResetParameters();

                    return myCommand.ExecuteReader();

                }
                catch(Exception e)
                {

                    TransactionFailure();

                    OnError(e);

                }

            }

            return null;

        }

        protected object TransactionalExecuteScalar(string TheCommand)
        {

            if(myIsActive)
            {

                try
                {

                    myCommand.CommandText = TheCommand;

                    ResetParameters();

                    return myCommand.ExecuteReader();

                }
                catch(Exception e)
                {

                    TransactionFailure();

                    OnError(e);

                }

            }

            return null;

        }

        protected object TransactionalExecuteScalar(IEnumerable<object> TheParameters)
        {

            if(myIsActive)
            {

                try
                {

                    SetParameterValues(TheParameters);

                    return myCommand.ExecuteReader();

                }
                catch(Exception e)
                {

                    TransactionFailure();

                    OnError(e);

                }

            }

            return null;

        }

        protected object TransactionalExecuteScalar(string TheCommand, IEnumerable<object> TheParameters)
        {

            if(myIsActive)
            {

                try
                {

                    myCommand.CommandText = TheCommand;

                    SetParameterValues(TheParameters);

                    return myCommand.ExecuteReader();

                }
                catch(Exception e)
                {

                    TransactionFailure();

                    OnError(e);

                }

            }

            return null;

        }

        protected DataTable TransactionalExecuteDataTable()
        {

            if(myIsActive)
            {

                try
                {

                    ResetParameters();

                    return GetDataTable(myCommand.ExecuteReader());

                }
                catch(Exception e)
                {

                    TransactionFailure();

                    OnError(e);

                }

            }

            return null;

        }

        protected DataTable TransactionalExecuteDataTable(string TheCommand)
        {

            if(myIsActive)
            {

                try
                {

                    myCommand.CommandText = TheCommand;

                    return GetDataTable(myCommand.ExecuteReader());

                }
                catch(Exception e)
                {

                    TransactionFailure();

                    OnError(e);

                }

            }

            return null;

        }

        protected DataTable TransactionalExecuteDataTable(IEnumerable<object> TheParameters)
        {

            if(myIsActive)
            {

                try
                {

                    SetParameterValues(TheParameters);

                    return GetDataTable(myCommand.ExecuteReader());

                }
                catch(Exception e)
                {

                    TransactionFailure();

                    OnError(e);

                }

            }

            return null;

        }

        protected DataTable TransactionalExecuteDataTable(string TheCommand, IEnumerable<object> TheParameters)
        {

            if(myIsActive)
            {

                try
                {

                    myCommand.CommandText = TheCommand;

                    SetParameterValues(TheParameters);

                    return GetDataTable(myCommand.ExecuteReader());

                }
                catch(Exception e)
                {

                    TransactionFailure();

                    OnError(e);

                }

            }

            return null;

        }

        public void Dispose()
        {

            if(myCommand.Connection != null)
            {

                myCommand.Connection.Dispose();

            }

            myCommand.Dispose();

            //if (myTransaction != null)
            //{

            //    myTransaction.Dispose();

            //}

        }

    }

    public enum ConnectionType
    {

        Transactional,
        Discrete,
        QuickDiscrete

    }

    public enum TransactionAction
    {

        Commit,
        Rollback

    }

}