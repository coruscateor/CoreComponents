using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

#pragma warning disable 0162

namespace CoreComponents.Data.Tables
{

    public abstract class QueryManager : IQueryManager
    {

        protected DbCommand myCommand;

        protected DbDataAdapter myDataAdapter;

        protected DbCommandBuilder myCommandBuilder;


        public static QueryManager Create(DataProviderType ConnectionProvider, ConnectionStringSettings ConnString, string Query)
        {

            switch (ConnectionProvider)
            {

                case DataProviderType.Npgsql:

                    return new Npgsql.NpgqslQueryManager(ConnString, Query);

                    break;

                case DataProviderType.OleDb:

                    return null;

                    break;
				
				case DataProviderType.MySql:

                    return new MySql.MySqlQueryManager(ConnString, Query);

                    break;

            }

            return null;

        }

        public int CommandTimeOut
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

        public DataTable GetTable()
        {

            DataTable Results = new DataTable();
            
            try
            {
                myCommand.Connection.Open();

                myDataAdapter.Fill(Results);

                myCommand.Connection.Close();

                return Results;

            } catch (Exception ex)
            {

                throw new Exception("GetDataTable: " + ex.Message, ex);

            } finally
            {

                myCommand.Connection.Close();

            }

        }

        public void PrepareCommand()
        {

            myCommand.Prepare();

        }

        public int ExecuteNonQuery()
        {

            int RowsAffected;

            try
            {
                myCommand.Connection.Open();

                //myCommand.Prepare();

                RowsAffected = myCommand.ExecuteNonQuery();

                myCommand.Connection.Close();

                return RowsAffected;

            } catch (Exception ex)
            {

                throw new Exception("NonQueryfail: " + ex.Message, ex);

            } finally
            {

                myCommand.Connection.Close();

            }

        }

        public T ExecuteScalar<T>()
        {

            T Result;

            try
            {
                myCommand.Connection.Open();

                //myCommand.Prepare();

                Result = (T)myCommand.ExecuteScalar();

                myCommand.Connection.Close();

                return Result;

            } catch (Exception ex)
            {

                throw new Exception("NonQueryfail: " + ex.Message, ex);

            } finally
            {

                myCommand.Connection.Close();

            }

        }

        public int Update(DataTable Data)
        {

            int RowsAffected;

            try
            {

                myCommandBuilder.RefreshSchema();

                myCommandBuilder.GetInsertCommand();

                myCommandBuilder.GetUpdateCommand();

                myCommandBuilder.GetDeleteCommand();

                myCommand.Connection.Open();

                RowsAffected = myDataAdapter.Update(Data);

                myCommand.Connection.Close();

                return RowsAffected;

            } catch (Exception ex)
            {

                throw new Exception("NonQueryfail: " + ex.Message, ex);

            } finally
            {

                myCommand.Connection.Close();

            }

        }

		/*
        public int Update(DataTable Data, DataUpdateSelection Selection)
        {

            int RowsAffected;

            try
            {

                myCommandBuilder.RefreshSchema();

                switch(Selection)
                {
                    case DataUpdateSelection.INSERT:

                        myCommandBuilder.GetInsertCommand();

                        break;

                    case DataUpdateSelection.UPDATE:

                        myCommandBuilder.GetUpdateCommand();

                        break;

                    case DataUpdateSelection.DELETE:

                        myCommandBuilder.GetDeleteCommand();

                        break;

                    case DataUpdateSelection.INSERT_DELETE:

                        myCommandBuilder.GetInsertCommand();

                        myCommandBuilder.GetDeleteCommand();

                        break;

                    case DataUpdateSelection.INSERT_UPDATE:

                        myCommandBuilder.GetInsertCommand();

                        myCommandBuilder.GetUpdateCommand();

                        break;

                    case DataUpdateSelection.UPDATE_DELETE:

                        myCommandBuilder.GetUpdateCommand();

                        myCommandBuilder.GetDeleteCommand();

                        break;

                    case DataUpdateSelection.ALL:

                        myCommandBuilder.GetInsertCommand();

                        myCommandBuilder.GetUpdateCommand();

                        myCommandBuilder.GetDeleteCommand();

                        break;

                }

                myCommand.Connection.Open();

                RowsAffected = myDataAdapter.Update(Data);

                myCommand.Connection.Close();

                return RowsAffected;

            } catch (Exception ex)
            {

                throw new Exception("NonQueryfail: " + ex.Message, ex);

            } finally
            {

                myCommand.Connection.Close();

            }

        }
		 */
		/*
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
        */

        public abstract DataProviderType Provider
        {
            get;
        }

    }

}
