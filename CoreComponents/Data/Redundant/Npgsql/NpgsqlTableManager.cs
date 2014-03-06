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
using Npgsql;
using CoreComponents;
using CoreComponents.Items;
using System.Data.Common;

/// <summary>
/// Summary description for NpgsqlArbitrarayQueryExecutor
/// </summary>
/// 

namespace CoreComponents.Data.Tables.Npgsql
{

    public class NpgsqlTableManager : TableManager
    {
        public NpgsqlTableManager()
        {

            myCommand = new NpgsqlCommand();

            Initialise((NpgsqlCommand)myCommand);

            myTable = new DataTable();

        }

        public NpgsqlTableManager(string TableName)
        {

            myCommand = new NpgsqlCommand();

            Initialise((NpgsqlCommand)myCommand);

            myTable = new DataTable(TableName);

        }

        public NpgsqlTableManager(NpgsqlConnection cn, string SelectCommand)
        {

            myCommand = new NpgsqlCommand(SelectCommand, cn);

            Initialise((NpgsqlCommand)myCommand);

            myTable = new DataTable();

        }

        public NpgsqlTableManager(NpgsqlConnection cn, string SelectCommand, string TableName)
        {

            myCommand = new NpgsqlCommand(SelectCommand, cn);

            Initialise((NpgsqlCommand)myCommand);

            myTable = new DataTable(TableName);

        }
/*
        public NpgsqlTableManager(NpgsqlConnection cn, string SelectCommand, DataTable Table)
        {

            myCommand = new NpgsqlCommand(SelectCommand, cn);

            Initialise((NpgsqlCommand)myCommand);

            myTable = Table;

        }
*/
        public NpgsqlTableManager(ConnectionStringSettings ConnString)
        {

            myCommand = new NpgsqlCommand();

            myCommand.Connection = new NpgsqlConnection(ConnString.ConnectionString);

            Initialise((NpgsqlCommand)myCommand);

        }

        public NpgsqlTableManager(ConnectionStringSettings ConnString, string CommandString)
        {

            myCommand = new NpgsqlCommand(CommandString, new NpgsqlConnection(ConnString.ConnectionString));

            Initialise((NpgsqlCommand)myCommand);

        }
		
		/*
		public NpgsqlTableManager(ConnectionStringSettings ConnString, string SelectCommand, DataTable Table)
        {

            myCommand = new NpgsqlCommand(SelectCommand, new NpgsqlConnection(ConnString.ConnectionString));

            Initialise((NpgsqlCommand)myCommand);

            myTable = Table;

        }
		*/
		
        public NpgsqlTableManager(NpgsqlCommand Command)
        {

            this.myCommand = Command;

            Initialise((NpgsqlCommand)myCommand);

            myTable = new DataTable();

        }

        public NpgsqlTableManager(NpgsqlCommand Command, string TableName)
        {

            myCommand = Command;

            Initialise((NpgsqlCommand)myCommand);

            myTable = new DataTable();

            myTable.TableName = TableName;

        }
/*
        public NpgsqlTableManager(NpgsqlCommand Command, DataTable Table)
        {

            myCommand = Command;

            Initialise((NpgsqlCommand)myCommand);

            myTable = Table;

        }
*/

        void Initialise(NpgsqlCommand myCommand)
        {

            myDataAdapter = new NpgsqlDataAdapter(myCommand);

            myCommandBuilder = new NpgsqlCommandBuilder((NpgsqlDataAdapter)myDataAdapter);

            //myDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

        }

        //void Refresh(NpgsqlCommand cmd) {


        //    Initialise(cmd);

        //    DT.Clear();

        //}

        public NpgsqlCommand Command
        {

            get
            {

                return (NpgsqlCommand)myCommand;

            }
            set
            {

                myCommand = value;

                Initialise((NpgsqlCommand)myCommand);

            }

        }

        public NpgsqlConnection Connection
        {

            get
            {

                return (NpgsqlConnection)myCommand.Connection;

            }

        }

        public NpgsqlParameterCollection CommandParameters
        {

            get
            {

                return (NpgsqlParameterCollection)myCommand.Parameters;

            }
        }

        public override DataProviderType Provider
        {
            get
            {

                return DataProviderType.Npgsql;

            }
        }

    }

}
