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
    public abstract class ExpandoCommander<TConnection, TCommand, TParameter> : IDisposable //, TParameter, TParameterCollection, TDataReader, TDataAdapter, TTransaction
        where TConnection : DbConnection, new()
        where TCommand : DbCommand, new()
        where TParameter : DbParameter, new()
        //where TParameterCollection : DbParameterCollection
        //where TDataReader : DbDataReader
        //where TDataAdapter : DbDataAdapter, new()
        //where TTransaction : DbTransaction
    {

        public event Action<ErrorEventArgs> ErrorEvent;

        public event Action<ResultEventArgs<ExpandoObject>> CommandExecuted;

        protected TConnection myConnection;

        protected TCommand myCommand;

        protected Stopwatch myQueryStopwatch = new Stopwatch();

        public ExpandoCommander()
        {

            myConnection = new TConnection();

            myCommand = new TCommand();

            myCommand.Connection = myConnection;

        }

        public ExpandoCommander(TConnection TheConnection)
        {

            myConnection = TheConnection;

            myCommand.Connection = myConnection;

        }

        protected void OnErrorEvent(Exception e) 
        {

            if (ErrorEvent != null)
            {

                //Thread EventThread = new Thread( new ThreadStart( () => {

                ErrorEvent(new ErrorEventArgs(this, e));

                //}));

                //EventThread.Start();
                
            }

        }

        protected void OnCommandExecuted(dynamic TheResult)
        {

            if (CommandExecuted != null)
            {

                    Thread EventThread = new Thread( new ThreadStart( () => {

                    dynamic ResultCopy = new ExpandoObject();

                    if (((IDictionary<string, object>)TheResult).Keys.Contains("Results"))
                    {

                        ResultCopy.Results = TheResult.Results;

                    }
                    else 
                    {

                        ResultCopy.Result = TheResult.Result;

                    }

                    ResultCopy.Started = TheResult.Started;

                    ResultCopy.Milliseconds = TheResult.Milliseconds;

                    ResultCopy.HasRows = TheResult.HasRows;

                    ResultCopy.RecordsAffected = TheResult.RecordsAffected;

                    ResultCopy.HadException = TheResult.HadException;

                    ResultCopy.CommandExecuted = TheResult.CommandExecuted;

                    CommandExecuted(new ResultEventArgs<ExpandoObject>(this, TheResult));

                }));

                EventThread.Start();
            }

        }

        public TConnection Connection 
        {

            get
            {

                return myConnection;

            }

        }

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
        public ExpandoObject GetRowSet(CommandProperties TheCommand) 
        {

            //if (myCommand == null)
            //{

            //    myCommand = new TCommand();

            //    myCommand.Connection = myConnection();

            //}

            dynamic QueryResult = new ExpandoObject();
            
            List<ExpandoObject> Rows = new List<ExpandoObject>();

            myCommand.CommandText = TheCommand.CommandText;

            myCommand.CommandTimeout = TheCommand.CommandTimeout;

            myCommand.CommandType = TheCommand.CommandType;

            myCommand.Parameters.Clear();
            
            myCommand.Parameters.AddRange(TheCommand.ParameterCollectionToArray<TParameter>());
            
            DbDataReader DataReader = null;
            
            //Stopwatch QuerySW = null;

            try
            {

                QueryResult.Started = DateTime.Now;

                myQueryStopwatch.Restart();

                DataReader = myCommand.ExecuteReader(TheCommand.CommandBehavior);

                myQueryStopwatch.Stop();  

                if (DataReader.HasRows)
                {

                    while (DataReader.Read())
                    {

                        dynamic Row = new ExpandoObject();

                        int NumberOfColumns = DataReader.FieldCount;

                        for (int i = 0; i < NumberOfColumns; i++)
                        {

                            ((Dictionary<string, object>)Row).Add(DataReader.GetName(i), DataReader.GetValue(i));

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

            QueryResult.CommandExecuted = TheCommand;

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
        public ExpandoObject GetFirstRow(CommandProperties TheCommand) 
        {

            dynamic QueryResult = new ExpandoObject();

            dynamic Row = new ExpandoObject();

            myCommand.CommandText = TheCommand.CommandText;

            myCommand.CommandTimeout = TheCommand.CommandTimeout;

            myCommand.CommandType = TheCommand.CommandType;

            myCommand.Parameters.Clear();

            myCommand.Parameters.AddRange(TheCommand.ParameterCollectionToArray<TParameter>());

            DbDataReader DataReader = null;

            try
            {

                QueryResult.Started = DateTime.Now;

                myQueryStopwatch.Restart();

                DataReader = myCommand.ExecuteReader(TheCommand.CommandBehavior);

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

            QueryResult.CommandExecuted = TheCommand;

            //OnCommandExecuted(QueryResult);

            return Row;

        }


        public abstract ExpandoObject Update(string TheTable, ExpandoObject TheObject);
        //{

        //    return null;

        //}

        public abstract ExpandoObject Update(string TheTable, ExpandoObject TheObject, params string[] TheColumns);
        //{

        //    Update(TheTable, TheObject, TheColumns);

        //    return null;

        //}

        public abstract ExpandoObject Update(string TheTable, ExpandoObject TheObject, IEnumerable TheColumns);
        //{

        //    return null;

        //}

        public abstract ExpandoObject InsertInto(string TheTable, ExpandoObject TheObject);
        //{

        //    return null;

        //}

        public abstract ExpandoObject InsertInto(string TheTable, ExpandoObject TheObject, params string[] TheColumns);
        //{

        //    InsertInto(TheTable, TheObject, TheColumns);

        //    return null;

        //}

        public abstract ExpandoObject InsertInto(string TheTable, ExpandoObject TheObject, IEnumerable TheColumns);
        //{

        //    return null;

        //}

        /*
        public int Update(IEnumerable<ExpandoObject> TheObjects)
        {
        }
        */

        public void Dispose()
        {

            myCommand.Dispose();

        }
    }
}
