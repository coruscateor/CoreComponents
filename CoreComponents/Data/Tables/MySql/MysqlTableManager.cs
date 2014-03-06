using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;
using CoreComponents;
using CoreComponents.Caching;
using System.Data.Common;
using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for MySqlArbitrarayQueryExecutor
/// </summary>
/// 

namespace CoreComponents.Data.Tables.MySql
{

    public class MySqlTableManager : TableManager
    {
		
        public MySqlTableManager()
        {

            myCommand = new MySqlCommand();

            Initialise((MySqlCommand)myCommand);

            myTable = new DataTable();

        }

        public MySqlTableManager(string TableName)
        {

            myCommand = new MySqlCommand();

            Initialise((MySqlCommand)myCommand);

            myTable = new DataTable(TableName);

        }

        public MySqlTableManager(MySqlConnection cn, string SelectCommand)
        {

            myCommand = new MySqlCommand(SelectCommand, cn);

            Initialise((MySqlCommand)myCommand);

            myTable = new DataTable();

        }

        public MySqlTableManager(MySqlConnection cn, string SelectCommand, string TableName)
        {

            myCommand = new MySqlCommand(SelectCommand, cn);

            Initialise((MySqlCommand)myCommand);

            myTable = new DataTable(TableName);

        }
/*
        public MySqlTableManager(MySqlConnection cn, string SelectCommand, DataTable Table)
        {

            myCommand = new MySqlCommand(SelectCommand, cn);

            Initialise((MySqlCommand)myCommand);

            myTable = Table;

        }
*/
        public MySqlTableManager(ConnectionStringSettings ConnString)
        {

            myCommand = new MySqlCommand();

            myCommand.Connection = new MySqlConnection(ConnString.ConnectionString);

            Initialise((MySqlCommand)myCommand);

        }

        public MySqlTableManager(ConnectionStringSettings ConnString, string CommandString)
        {

            myCommand = new MySqlCommand(CommandString, new MySqlConnection(ConnString.ConnectionString));

            Initialise((MySqlCommand)myCommand);

        }
		
		public MySqlTableManager(ConnectionStringSettings ConnString, string CommandString, DataTable Table)
        {

            myCommand = new MySqlCommand(CommandString, new MySqlConnection(ConnString.ConnectionString));

            Initialise((MySqlCommand)myCommand);

            myTable = Table;

        }

        public MySqlTableManager(MySqlCommand Command)
        {

            this.myCommand = Command;

            Initialise((MySqlCommand)myCommand);

            myTable = new DataTable();

        }

        public MySqlTableManager(MySqlCommand Command, string TableName)
        {

            myCommand = Command;

            Initialise((MySqlCommand)myCommand);

            myTable = new DataTable();

            myTable.TableName = TableName;

        }

        public MySqlTableManager(MySqlCommand Command, DataTable Table)
        {

            myCommand = Command;

            Initialise((MySqlCommand)myCommand);

            myTable = Table;

        }


        void Initialise(MySqlCommand myCommand)
        {

            myDataAdapter = new MySqlDataAdapter(myCommand);

            myCommandBuilder = new MySqlCommandBuilder((MySqlDataAdapter)myDataAdapter);

            //myDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

        }

        //void Refresh(MySqlCommand cmd) {


        //    Initialise(cmd);

        //    DT.Clear();

        //}

        public MySqlCommand Command
        {

            get
            {

                return (MySqlCommand)myCommand;

            }
            set
            {

                myCommand = value;

                Initialise((MySqlCommand)myCommand);

            }

        }

        public MySqlConnection Connection
        {

            get
            {

                return (MySqlConnection)myCommand.Connection;

            }

        }

        public MySqlParameterCollection CommandParameters
        {

            get
            {

                return (MySqlParameterCollection)myCommand.Parameters;

            }
        }

        public override DataProviderType Provider
        {
            get
            {

                return DataProviderType.MySql;

            }
        }

    }

}
