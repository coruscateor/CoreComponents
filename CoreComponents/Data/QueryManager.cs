using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Diagnostics;

#pragma warning disable 0162

namespace CoreComponents.Data
{

    public abstract class QueryManager<TConnection, TCommand, TParameterCollection, TDataReader, TDataAdapter, TCommandBuilder> : IQueryManager, IDisposable
        where TConnection : DbConnection, new()
        where TCommand : DbCommand, new()
        where TParameterCollection : DbParameterCollection
        where TDataReader : DbDataReader
        where TDataAdapter : DbDataAdapter, new()
        where TCommandBuilder : DbCommandBuilder, new()
    {

        //public event Create<ErrorEventArgs<QueryManager<TConnection, TCommand, TParameterCollection, TDataReader, TDataAdapter, TCommandBuilder>>>.ADelegate CaughtExecption;

        //public delegate void ErrorEventArgsDelegate(ErrorEventArgs<QueryManager<TConnection, TCommand, TParameterCollection, TDataReader, TDataAdapter, TCommandBuilder>> Parameter);

        //public event ErrorEventArgsDelegate ErrorEvent;

        protected TCommand myCommand; //Also used as the locking object.

        protected TDataAdapter myDataAdapter;

        protected TCommandBuilder myCommandBuilder;

        public QueryManager(string ConnString)
        {

            myCommand = new TCommand();

            Initalise();

            myCommand.Connection = new TConnection();

            myCommand.Connection.ConnectionString = ConnString;

        }

        public QueryManager(string ConnString, string CommandString)
        {

            myCommand = new TCommand();

            myCommand.CommandText = CommandString;

            Initalise();

            myCommand.Connection = new TConnection();

            myCommand.Connection.ConnectionString = ConnString;

        }

        public QueryManager(ConnectionStringSettings ConnString)
        {

            myCommand = new TCommand();

            Initalise();

            Initalise(ConnString);

        }

        public QueryManager(ConnectionStringSettings ConnString, string CommandString)
        {

            myCommand = new TCommand();

            myCommand.CommandText = CommandString;

            Initalise();

            Initalise(ConnString);

        }

        public QueryManager(ConnectionStringSettings ConnString, TCommand command)
        {

            myCommand = command;

            Initalise();

            Initalise(ConnString);

        }


        public QueryManager(TCommand command)
        {

            myCommand = command;

            Initalise();

        }

        public QueryManager(TConnection connection)
        {

            myCommand = new TCommand();

            myCommand.Connection = connection;

            Initalise();

        }

        protected virtual void Initalise()
        {

            myDataAdapter = new TDataAdapter();

            myDataAdapter.SelectCommand = myCommand; //need to determane command type.

            //myDataAdapter.

            myCommandBuilder = new TCommandBuilder();
            
            myCommandBuilder.DataAdapter = myDataAdapter;

        }

        protected virtual void Initalise(ConnectionStringSettings ConnString)
        {

            myCommand.Connection = new TConnection();

            myCommand.Connection.ConnectionString = ConnString.ConnectionString;

        }

        /*
        protected void OnCaughtExecption(ErrorEventArgs<QueryManager<TConnection, TCommand, TParameterCollection, TDataReader, TDataAdapter, TCommandBuilder>> TheExceptionEventArgs)
        {

            if (CaughtExecption != null)
                CaughtExecption(TheExceptionEventArgs);

        }
        */

        protected void OnErrorEvent(string Message)
        {

            //if (ErrorEvent != null)
            //    ErrorEvent(new ErrorEventArgs<QueryManager<TConnection, TCommand, TParameterCollection, TDataReader, TDataAdapter, TCommandBuilder>>(this, Message));

        }

        protected void OnErrorEvent(Exception ex) 
        {

            //if (ErrorEvent != null)
            //    ErrorEvent(new ErrorEventArgs<QueryManager<TConnection, TCommand, TParameterCollection, TDataReader, TDataAdapter, TCommandBuilder>>(this, ex));

        }

        public TCommand Command
        {

            get
            {

                return myCommand;

            }

            set
            {

                lock (myCommand)
                {

                    myCommand = value;

                    Initalise();
                }

            }
        }

        //public TConnection CommandConnection
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

        /*
        public int CommandTimeOut
        {


            get
            {

                return myCommand.CommandTimeout;

            }*/
            /*set
            {

                myCommand.CommandTimeout = value;

            }*/
        /*
        }*/

		/*
		public string CommandText
		{
			
			get
			{
				return myCommand.CommandText;
			}
			
		}
        */

        public TParameterCollection CommandParameters
        {

            get
            {

                return (TParameterCollection)myCommand.Parameters;

            }
        }

        public DataTable GetNewDataTable()
        {

            lock (myCommand)
            {

                DataTable TheTable = new DataTable();

                try
                {
                    myCommand.Connection.Open();

                    myDataAdapter.Fill(TheTable);

                    //myCommand.Connection.Close();

                    //return Results;

                }
                catch (Exception ex)
                {

                    OnErrorEvent(ex);


                }
                finally
                {

                    myCommand.Connection.Close();

                }

                return TheTable;

            }

        }

        public void FillDataTable(DataTable TheTable)
        {

            lock (myCommand)
            {

                if (Return.IsNotNull(TheTable))
                {

                    try
                    {
                        myCommand.Connection.Open();

                        myDataAdapter.Fill(TheTable);

                        //myCommand.Connection.Close();

                        //return Results;

                    }
                    catch (Exception ex)
                    {

                        OnErrorEvent(ex);


                    }
                    finally
                    {

                        myCommand.Connection.Close();

                    }

                }

            }

        }

        public void PrepareCommand()
        {

            lock (myCommand)
            {

                try
                {

                    myCommand.Connection.Open();

                    myCommand.Prepare();

                }
                finally
                {

                    myCommand.Connection.Close();

                }
            }
        }

        public int ExecuteNonQuery()
        {

            lock (myCommand)
            {

                int RowsAffected = 0;

                try
                {
                    myCommand.Connection.Open();

                    //myCommand.Prepare();

                    RowsAffected = myCommand.ExecuteNonQuery();

                    //myCommand.Connection.Close();

                    //return RowsAffected;

                }
                catch (Exception ex)
                {

                    OnErrorEvent(ex);

                }
                finally
                {

                    myCommand.Connection.Close();

                }

                return RowsAffected;

            }

        }

        public T ExecuteScalar<T>()
        {

            lock (myCommand)
            {

                T Result = default(T);

                try
                {
                    myCommand.Connection.Open();

                    //myCommand.Prepare();

                    Result = (T)myCommand.ExecuteScalar();

                    //myCommand.Connection.Close();

                    //return Result;

                }
                catch (Exception ex)
                {

                    OnErrorEvent(ex);

                }
                finally
                {

                    myCommand.Connection.Close();

                }

                return Result;

            }

        }

        public TDataReader GetDataReader()
        {  

            lock (myCommand)
            {

                TDataReader Reader = default(TDataReader);

                try
                {
                    myCommand.Connection.Open();

                    Reader = (TDataReader)myCommand.ExecuteReader();

                }
                catch (Exception ex)
                {

                    OnErrorEvent(ex);

                }
                finally
                {

                    myCommand.Connection.Close();

                }

                return Reader;

            }

        }
		
        /*
		public DbDataReader GetDbDataReader()
        {

            DbDataReader Reader = null; 

            lock (myCommand)
            {

                try
                {
                    myCommand.Connection.Open();

                    Reader = myCommand.ExecuteReader();

                    //myCommand.Connection.Close();

                    //return Reader;

                }
                catch (Exception ex)
                {

                    //throw new Exception("GetDataReader: " + ex.Message, ex);

                    OnCaughtExecption(new ErrorEventArgs<QueryManager<TConnection, TCommand, TParameterCollection, TDataReader, TDataAdapter, TCommandBuilder>>(this, ex));

                }
                finally
                {

                    myCommand.Connection.Close();

                }

            }

            return Reader;

        }
        */

        //public virtual DataTable GetSchemaIndex() 
        //{

        //    lock (myCommand) 
        //    {

        //        DataTable SchemaDataTable = null;

        //        try
        //        {

        //            myCommand.Connection.Open();

        //            SchemaDataTable = myCommand.Connection.GetSchema();

        //        }
        //        catch (Exception ex)
        //        {

        //            OnErrorEvent(ex);

        //        }
        //        finally 
        //        {

        //            myCommand.Connection.Close();

        //        }

        //        return SchemaDataTable;

        //    }
        
        //}

        //public virtual DataTable GetSchemaCollection(string CollectionName)
        //{

        //    lock (myCommand)
        //    {

        //        DataTable SchemaDataTable = null;

        //        try
        //        {

        //            myCommand.Connection.Open();

        //            SchemaDataTable = myCommand.Connection.GetSchema(CollectionName);

        //        }
        //        catch (Exception ex)
        //        {

        //            OnErrorEvent(ex);

        //        }
        //        finally
        //        {

        //            myCommand.Connection.Close();

        //        }

        //        return SchemaDataTable;

        //    }

        //}

        //public virtual DataTable GetSchemaCollection(string CollectionName, string[] RestrictionValues)
        //{

        //    lock (myCommand)
        //    {

        //        DataTable SchemaDataTable = null;

        //        try
        //        {

        //            myCommand.Connection.Open();

        //            SchemaDataTable = myCommand.Connection.GetSchema(CollectionName, RestrictionValues);

        //        }
        //        catch (Exception ex)
        //        {

        //            OnErrorEvent(ex);

        //        }
        //        finally
        //        {

        //            myCommand.Connection.Close();

        //        }

        //        return SchemaDataTable;

        //    }

        //}

        //public virtual DataSet GetSchemaDataSet()
        //{

        //    lock (myCommand)
        //    {

        //        DataSet DbSchema = new DataSet();

        //        try
        //        {

        //            myCommand.Connection.Open();

        //            DataTable SchemaIndex = myCommand.Connection.GetSchema();

        //            foreach (DataRow IndexRow in SchemaIndex.Rows)
        //            {

        //                DbSchema.Tables.Add(myCommand.Connection.GetSchema(Convert.ToString(IndexRow.ItemArray.ElementAt(0))));

        //            }

        //        }
        //        catch (Exception ex)
        //        {

        //            OnErrorEvent(ex);

        //        }
        //        finally
        //        {

        //            myCommand.Connection.Close();

        //        }

        //        return DbSchema;
        //    }

        //}

        public void Dispose()
        {

            if(myCommand.Connection != null)
                myCommand.Connection.Dispose();

            myCommand.Dispose();

            myCommandBuilder.Dispose();

            myDataAdapter.Dispose();
        }

    }

}
