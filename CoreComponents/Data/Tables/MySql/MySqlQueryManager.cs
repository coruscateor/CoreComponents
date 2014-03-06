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
using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for MySqlCRUDManager
/// </summary>
/// 

namespace CoreComponents.Data.Tables.MySql
{

    public class MySqlQueryManager : QueryManager, IMySqlQueryManager
    {
        
        public MySqlQueryManager(string ConnString)
        {

            myCommand = new MySqlCommand();

            Initalise();

            myCommand.Connection = new MySqlConnection(ConnString);

        }

        public MySqlQueryManager(string ConnString, string CommandString)
        {

            myCommand = new MySqlCommand(CommandString);

            Initalise();

            myCommand.Connection = new MySqlConnection(ConnString);

        }

        public MySqlQueryManager(ConnectionStringSettings ConnString)
        {

            myCommand = new MySqlCommand();

            Initalise();

            Initalise(ConnString);

        }

        public MySqlQueryManager(ConnectionStringSettings ConnString, string CommandString)
        {

            myCommand = new MySqlCommand(CommandString);

            Initalise();

            Initalise(ConnString);

        }

        public MySqlQueryManager(ConnectionStringSettings ConnString, MySqlCommand command)
        {

            myCommand = command;

            Initalise();

            Initalise(ConnString);

        }


        public MySqlQueryManager(MySqlCommand command)
        {

            myCommand = command;

            Initalise();

        }

        public MySqlQueryManager(MySqlConnection connection)
        {

            myCommand = new MySqlCommand();

            myCommand.Connection = connection;

            Initalise();

        }

        void Initalise()
        {

            myDataAdapter = new MySqlDataAdapter((MySqlCommand)myCommand);

            myCommandBuilder = new MySqlCommandBuilder((MySqlDataAdapter)myDataAdapter);

        }

        void Initalise(ConnectionStringSettings ConnString)
        {

            myCommand.Connection = new MySqlConnection(ConnString.ConnectionString);

        }

        public MySqlConnection CommandConnection
        {

            get
            {

                return (MySqlConnection)myCommand.Connection;

            }
            set
            {

                myCommand.Connection = value;

            }

        }

        public MySqlCommand Command
        {

            get
            {

                return (MySqlCommand)myCommand;

            }

            set
            {


                myCommand = value;

                Initalise();

            }
        }

        public MySqlParameterCollection CommandParameters
        {

            get
            {

                return (MySqlParameterCollection)myCommand.Parameters;

            }
        }


        public MySqlDataReader GetDataReader()
        {
            MySqlDataReader Reader;

            try
            {
                myCommand.Connection.Open();

                myCommand.Prepare();

                Reader = (MySqlDataReader)myCommand.ExecuteReader();

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

                return DataProviderType.MySql;

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
