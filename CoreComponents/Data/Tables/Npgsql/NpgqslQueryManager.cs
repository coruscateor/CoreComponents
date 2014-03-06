using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.Common;
using Npgsql;

/// <summary>
/// Summary description for NpgqslCRUDManager
/// </summary>
/// 

namespace CoreComponents.Data.Tables.Npgsql
{

    public class NpgqslQueryManager : QueryManager, INpgsqlQueryManager
    {

        public NpgqslQueryManager(string ConnString)
        {

            myCommand = new NpgsqlCommand();

            Initalise();

            myCommand.Connection = new NpgsqlConnection(ConnString);

        }

        public NpgqslQueryManager(string ConnString, string CommandString)
        {

            myCommand = new NpgsqlCommand(CommandString);

            Initalise();

            myCommand.Connection = new NpgsqlConnection(ConnString);

        }

        public NpgqslQueryManager(ConnectionStringSettings ConnString)
        {

            myCommand = new NpgsqlCommand();

            Initalise();

            Initalise(ConnString);

        }

        public NpgqslQueryManager(ConnectionStringSettings ConnString, string CommandString)
        {

            myCommand = new NpgsqlCommand(CommandString);

            Initalise();

            Initalise(ConnString);

        }

        public NpgqslQueryManager(ConnectionStringSettings ConnString, NpgsqlCommand command)
        {

            myCommand = command;

            Initalise();

            Initalise(ConnString);

        }


        public NpgqslQueryManager(NpgsqlCommand command)
        {

            myCommand = command;

            Initalise();

        }

        public NpgqslQueryManager(NpgsqlConnection connection)
        {

            myCommand = new NpgsqlCommand();

            myCommand.Connection = connection;

            Initalise();

        }

        void Initalise()
        {

            myDataAdapter = new NpgsqlDataAdapter((NpgsqlCommand)myCommand);

            myCommandBuilder = new NpgsqlCommandBuilder((NpgsqlDataAdapter)myDataAdapter);

        }

        void Initalise(ConnectionStringSettings ConnString)
        {

            myCommand.Connection = new NpgsqlConnection(ConnString.ConnectionString);

        }

        public NpgsqlConnection CommandConnection
        {

            get
            {

                return (NpgsqlConnection)myCommand.Connection;

            }
            set
            {

                myCommand.Connection = value;

            }

        }

        public NpgsqlCommand Command
        {

            get
            {

                return (NpgsqlCommand)myCommand;

            }

            set
            {


                myCommand = value;

                Initalise();

            }
        }

        public NpgsqlParameterCollection CommandParameters
        {

            get
            {

                return (NpgsqlParameterCollection)myCommand.Parameters;

            }
        }


        public NpgsqlDataReader GetDataReader()
        {
            NpgsqlDataReader Reader;

            try
            {
                myCommand.Connection.Open();

                myCommand.Prepare();

                Reader = (NpgsqlDataReader)myCommand.ExecuteReader();

                myCommand.Connection.Close();

                return Reader;

            } catch (Exception ex)
            {

                throw new Exception("GetDataReader: " + ex.Message, ex);

            } finally
            {

                myCommand.Connection.Close();

            }

        }

        public override DataProviderType Provider
        {
            get
            {

                return DataProviderType.Npgsql;

            }
        }

        /*
        public DataTable GetDataTable()
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

        public int ExecuteNonQuery()
        {

            int RowsAffected;

            try
            {
                myCommand.Connection.Open();

                myCommand.Prepare();

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

                myCommand.Prepare();

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

        public int Update(DataTable Data, NpgsqlCommandBuilder cb)
        {

            int RowsAffected;

            if (cb.DataAdapter != myDataAdapter)
                cb.DataAdapter = myDataAdapter;

            try
            {
                myCommand.Connection.Open();

                cb.GetInsertCommand();

                cb.GetUpdateCommand();

                cb.GetDeleteCommand();

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
         * */

    }
}
