using System;
using System.Collections;
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
    public abstract class ExpandoCommander //<TConnection, TCommand, TParameter, TParameterCollection> : IDisposable //, TParameter, TParameterCollection, TDataReader, TDataAdapter, TTransaction
        //where TConnection : DbConnection, new()
        //where TCommand : DbCommand, new()
        //where TParameter : DbParameter, new()
        //where TParameterCollection : DbParameterCollection
        //where TDataReader : DbDataReader
        //where TDataAdapter : DbDataAdapter, new()
        //where TTransaction : DbTransaction
    {

        //public event Action<ErrorEventArgs<ExpandoCommander>> ErrorEvent;  //<TConnection, TCommand, TParameter, TParameterCollection>

        //public event Action<ResultEventArgs<ExpandoObject>> CommandExecuted;

        public event Action<KeyValueEventArgs<ExpandoCommander, string, object>> PropertyChanged; //<TConnection, TCommand, TParameter, TParameterCollection>

        //public event Action<

        //protected TConnection myConnection;

        //protected TCommand myCommand;

        protected DbCommand myCommand;

        protected Stopwatch myQueryStopwatch = new Stopwatch();

        protected CommandBehavior myCommandBehavior = CommandBehavior.Default;

        protected dynamic myParameters = new ExpandoObject();

        //public ExpandoCommander()
        //{

        //    //myConnection = new TConnection();

        //    //myCommand = new TCommand();

        //    //myCommand.Connection = myConnection;

        //}

        //public ExpandoCommander(TConnection TheConnection)
        //{

        //    //myConnection = TheConnection;

        //    //myCommand.Connection = myConnection;

        //    myCommand.Connection = (DbConnection)TheConnection;

        //}

        public ExpandoCommander() 
        {

            CreateNewCommand();

        }

        public ExpandoCommander(DbConnection TheConnection)
        {

            CreateNewCommand();

            myCommand.Connection = TheConnection;

        }

        protected void OnErrorEvent(Exception TheException) 
        {

            //if (ErrorEvent != null)
            //{

            //    //Thread EventThread = new Thread( new ThreadStart( () => {

            //    ErrorEvent(new ErrorEventArgs<ExpandoCommander>(this, TheException)); //<TConnection, TCommand, TParameter, TParameterCollection> //, new StackFrame(1)

            //    //}));

            //    //EventThread.Start();
                
            //}

        }

        protected abstract void CreateNewCommand();

        //protected void OnPropertyChanged(KeyValuePair<string, object> TheChangedProperty)
        //{

        //    if(PropertyChanged != null)
        //        PropertyChanged(new KeyValueEventArgs<ExpandoCommander<TConnection,TCommand,TParameter,TParameterCollection>,string,object>(this, TheChangedProperty));

        //}

        //protected void OnCommandExecuted(dynamic TheResult)
        //{

        //    if (CommandExecuted != null)
        //    {

        //            Thread EventThread = new Thread( new ThreadStart( () => {

        //            dynamic ResultCopy = new ExpandoObject();

        //            if (((IDictionary<string, object>)TheResult).Keys.Contains("Results"))
        //            {

        //                ResultCopy.Results = TheResult.Results;

        //            }
        //            else 
        //            {

        //                ResultCopy.Result = TheResult.Result;

        //            }

        //            ResultCopy.Started = TheResult.Started;

        //            ResultCopy.Milliseconds = TheResult.Milliseconds;

        //            ResultCopy.HasRows = TheResult.HasRows;

        //            ResultCopy.RecordsAffected = TheResult.RecordsAffected;

        //            ResultCopy.HadException = TheResult.HadException;

        //            ResultCopy.CommandExecuted = TheResult.CommandExecuted;

        //            CommandExecuted(new ResultEventArgs<ExpandoObject>(this, TheResult));

        //        }));

        //        EventThread.Start();
        //    }

        //}

        //public TConnection Connection 
        //{

        //    get
        //    {

        //        return (TConnection)myCommand.Connection;

        //    }
        //    set 
        //    {

        //        myCommand.Connection = value;

        //    }

        //}

        public DbConnection DbConnection
        {

            get
            {

                return myCommand.Connection;

            }
            set
            {

                myCommand.Connection = value;

            }

        }

        //Command Properties

        public string CommandText 
        {

            get 
            {

                return myCommand.CommandText;

            }
            set 
            {

                myCommand.CommandText = value;

                //StackFrame SF = new StackFrame();

                //KeyValuePair<string, object> TheKeyValuePair = new KeyValuePair<string, object>(SF.GetMethod().Name, value);

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

                myCommand.CommandTimeout = value;

            }

        }

        public CommandType CommandType
        {

            get 
            {

                return myCommand.CommandType;

            }
            set 
            {

                myCommand.CommandType = value;

            }

        }

        //public DbConnection Connection { get; set; }

        //protected abstract DbConnection DbConnection { get; set; }

        //protected abstract DbParameterCollection DbParameterCollection { get; }

        //protected abstract DbTransaction DbTransaction { get; set; }

        //public bool DesignTimeVisible 

        //public TParameterCollection Parameters
        //{

        //    get
        //    {

        //        return (TParameterCollection)myCommand.Parameters;

        //    }

        //}

        public DbParameterCollection DbParameters
        {

            get
            {

                return myCommand.Parameters;

            }

        }

        //public dynamic Parameters 
        //{

        //    get 
        //    {

        //        return myParameters;

        //    }

        //}

        //public IDictionary<string, object> ParametersToIDictionary
        //{

        //    get
        //    {

        //        return (IDictionary<string, object>)myParameters;

        //    }

        //}

        //public void AddOrUpdateParameterValue(string TheName, object TheValue)
        //{

        //    IDictionary<string, object> TheParameters = (IDictionary<string, object>)myParameters;

        //    if (TheParameters.ContainsKey(TheName))
        //    {

        //        TheParameters[TheName] = TheValue;
                
        //    }
        //    else 
        //    {

        //        TheParameters.Add(new KeyValuePair<string, object>(TheName, TheValue));

        //    }

        //}

        //public void RemoveParameter(string TheName)
        //{

        //    IDictionary<string, object> TheParameters = (IDictionary<string, object>)myParameters;

        //    if (TheParameters.ContainsKey(TheName))
        //    {

        //        TheParameters.Remove(TheName);

        //    }

        //}

        //public bool ContainsParameter(string TheName) 
        //{

        //    return ((IDictionary<string, object>)myParameters).ContainsKey(TheName);

        //}

        //public void ClearParameters()
        //{

        //    ((IDictionary<string, object>)myParameters).Clear();

        //}

        //protected void UpdateParameters() 
        //{

        //    IDictionary<string, object> myParametersAsIDictionary = (IDictionary<string, object>)myParameters;

        //    //if (myCommand.Parameters.Count > 0)
        //    //{
        //    //    myCommand.Parameters.Clear();
        //    //}

        //    if (myParametersAsIDictionary.Count > 0) 
        //    {

        //        IDictionary<string, object> Parameters = (IDictionary<string, object>)myParameters;

        //        foreach (KeyValuePair<string, object> TheParameter in Parameters) 
        //        {

        //            if (myCommand.Parameters.Contains(TheParameter.Key))
        //            {

        //                myCommand.Parameters[TheParameter.Key].Value = TheParameter.Value;

        //            }
        //            else 
        //            {

        //                TParameter NewParameter = new TParameter();

        //                NewParameter.ParameterName = TheParameter.Key;

        //                //[TheParameter.Key].Value = TheParameter.Value;

        //                //myCommand.Parameters.Add( 
        //            }

        //            //NewParameter.Value = TheParameter.Value;

        //            //myCommand.Parameters.Add(NewParameter);

        //        }

        //    }

        //}

        //public DbTransaction Transaction { get; set; } //- Internal

        public UpdateRowSource UpdatedRowSource 
        {

            get 
            {

                return myCommand.UpdatedRowSource;

            }
            set 
            {

                myCommand.UpdatedRowSource = value;

            }

        }

        public void Cancel() 
        {

            myCommand.Cancel();

        }

        public CommandBehavior CommandBehavior 
        {

            get 
            {

                return myCommandBehavior;

            }
            set 
            {

                myCommandBehavior = value;

            }


        }

        //protected abstract DbParameter CreateDbParameter();

        //public DbParameter CreateParameter();

        //protected abstract DbDataReader ExecuteDbDataReader(CommandBehavior behavior);

        //public abstract int ExecuteNonQuery();

        //public DbDataReader ExecuteReader();

        //public DbDataReader ExecuteReader(CommandBehavior behavior);

        //public abstract object ExecuteScalar();

        public void Prepare() 
        {

            myCommand.Prepare();

        }

        //Connection Properties

        /// <summary>
        /// 
        /// Returns a "QueryResult" which contains the results of the query aswell as circumstantial information about it.
        /// 
        /// Properties if sucessfull:
        /// 
        /// Results
        ///
        /// Milliseconds
        ///
        /// HasRows
        ///
        /// RecordsAffected
        ///
        /// HadException (Always false)
        /// 
        /// CommandExecuted
        /// 
        /// Properties if unsucessfull:
        /// 
        /// HadException (Always true)
        ///
        /// Exception
        /// 
        /// CommandExecuted
        /// 
        /// </summary>
        /// <param name="TheCommand"></param>
        /// <returns>ExpandoObject</returns>
        public dynamic GetRowSet() 
        {

            dynamic QueryResult = new ExpandoObject();

            //dynamic Row = new ExpandoObject();
            
            DbDataReader DataReader = null;
            
            //Stopwatch QuerySW = null;

            try
            {

                //UpdateParameters();

                QueryResult.Started = DateTime.Now;

                myQueryStopwatch.Restart();

                DataReader = myCommand.ExecuteReader(myCommandBehavior);

                myQueryStopwatch.Stop();  

                if (DataReader.HasRows)
                {

                    List<dynamic> Rows = new List<dynamic>();

                    while (DataReader.Read())
                    {

                        dynamic Row = new ExpandoObject();

                        int NumberOfColumns = DataReader.FieldCount;

                        for (int i = 0; i < NumberOfColumns; i++)
                        {

                            ((IDictionary<string, object>)Row).Add(DataReader.GetName(i), DataReader.GetValue(i));

                            Rows.Add(Row);

                        }

                    }

                    QueryResult.Results = Rows;

                    QueryResult.Milliseconds = myQueryStopwatch.ElapsedMilliseconds;

                    QueryResult.HasRows = DataReader.HasRows;

                    QueryResult.RecordsAffected = DataReader.RecordsAffected;

                    QueryResult.HadException = false;

                }

            }
            catch (Exception e)
            {

                if (myQueryStopwatch.IsRunning)
                    myQueryStopwatch.Stop();

                QueryResult.HadException = true;

                QueryResult.Exception = e;

                OnErrorEvent(e);

            }
            finally
            {

                if(DataReader != null)
                    DataReader.Close();

            }

            //QueryResult.CommandExecuted = TheCommand;

            //OnCommandExecuted(QueryResult);

            return QueryResult;

        }

        /// <summary>
        /// 
        /// Returns a "QueryResult" which contains the results of the query aswell as circumstantial information about it.
        /// 
        /// This method is for scalar queries or time when you just want the top row.
        /// 
        /// Properties if sucessfull:
        /// 
        /// Started
        /// 
        /// Result
        ///
        /// Milliseconds
        ///
        /// HasRows
        ///
        /// RecordsAffected
        ///
        /// HadException (Always false)
        /// 
        /// CommandExecuted
        /// 
        /// Properties if unsucessfull:
        /// 
        /// Started
        /// 
        /// HadException (Always true)
        ///
        /// Exception
        /// 
        /// CommandExecuted
        /// 
        /// </summary>
        /// <param name="TheCommand"></param>
        /// <returns>ExpandoObject</returns>
        public ExpandoObject GetFirstRow() //CommandProperties TheCommand 
        {

            dynamic QueryResult = new ExpandoObject();

            dynamic Row = new ExpandoObject();

            //myCommand.CommandText = TheCommand.CommandText;

            //myCommand.CommandTimeout = TheCommand.CommandTimeout;

            //myCommand.CommandType = TheCommand.CommandType;

            //myCommand.Parameters.Clear();

            //myCommand.Parameters.AddRange(TheCommand.ParameterCollectionToArray<TParameter>());

            DbDataReader DataReader = null;

            try
            {

                //UpdateParameters();

                QueryResult.Started = DateTime.Now;

                myQueryStopwatch.Restart();

                DataReader = myCommand.ExecuteReader(myCommandBehavior);

                myQueryStopwatch.Stop();

                if (DataReader.HasRows)
                {

                    if (DataReader.Read())
                    {

                    int NumberOfColumns = DataReader.FieldCount;

                    for (int i = 0; i < NumberOfColumns; i++)
                    {

                        ((Dictionary<string, object>)Row).Add(DataReader.GetName(i), DataReader.GetValue(i));

                    }

                }

                QueryResult.Result = Row;

                QueryResult.Milliseconds = myQueryStopwatch.ElapsedMilliseconds;

                QueryResult.HasRows = DataReader.HasRows;

                QueryResult.RecordsAffected = DataReader.RecordsAffected;

                QueryResult.HadException = false;

            }

            }
            catch (Exception e)
            {

                if (myQueryStopwatch.IsRunning)
                    myQueryStopwatch.Stop();

                QueryResult.HadException = true;

                QueryResult.Exception = e;
                
                //StackFrame SF = new StackFrame();

                //SF.
                //System.Diagnostics
                OnErrorEvent(e);

            }
            finally
            {

                if (DataReader != null)
                    DataReader.Close();

            }

            //QueryResult.CommandExecuted = TheCommand;

            //OnCommandExecuted(QueryResult);

            return Row;

        }

        public void Dispose()
        {

            myCommand.Dispose();

            //myConnection.Dispose();

        }
    }
}
