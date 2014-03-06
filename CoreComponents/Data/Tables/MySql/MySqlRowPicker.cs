using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using CoreComponents.Text;

namespace CoreComponents.Data.Tables.MySql
{
    public class MySqlRowPicker : RowPicker
    {

        public MySqlRowPicker(string TableName)
        {

            myTableName = TableName;

            myRowCount = 50;

            myOffset = 0;

            myCommand = new MySqlCommand();

            Initalise();

            //myTable = new DataTable();

        }

        public MySqlRowPicker(string TableName, int RowCount, int Offset)
        {

            myTableName = TableName;

            myRowCount = RowCount;

            myOffset = Offset;

            myCommand = new MySqlCommand();

            Initalise();

            //myTable = new DataTable();

        }

        public MySqlRowPicker(string ConnString, string TableName)
        {

            myTableName = TableName;

            myRowCount = 50;

            myOffset = 0;

            myCommand = new MySqlCommand();

            myCommand.Connection = new MySqlConnection(ConnString);

            Initalise();

           // myTable = new DataTable();

        }

        public MySqlRowPicker(ConnectionStringSettings ConnString, string TableName)
        {

            myTableName = TableName;

            myRowCount = 50;

            myOffset = 0;

            myCommand = new MySqlCommand();

            Initalise();

        }

        public MySqlRowPicker(ConnectionStringSettings ConnString, string TableName, int myRowCount)
        {

            myTableName = TableName;

            myRowCount = RowCount;

            myOffset = 0;

            myCommand = new MySqlCommand();

            Initalise();

        }

        public MySqlRowPicker(MySqlConnection connection, string TableName, int myRowCount)
        {

            myTableName = TableName;

            myRowCount = RowCount;

            myOffset = 0;

            myCommand = new MySqlCommand();

            myCommand.Connection = connection;

            Initalise();

        }


        void Initalise()
        {

            myDataAdapter = new MySqlDataAdapter((MySqlCommand)myCommand);

            myCommandBuilder = new MySqlCommandBuilder((MySqlDataAdapter)myDataAdapter);

            RefeshTotalRows();

        }

        public override void AssembleCountQuery()
        {

            TextEntity.Clear(mySB);

            mySB.Append("SELECT count(*) FROM ");

            mySB.Append(myTableName);

            mySB.AppendLine(";");

            myCountCommand = new MySqlCommand(mySB.ToString(), (MySqlConnection)myCommand.Connection);

        }

        public override void AssembleFetchQuery()
        {
			
			TextEntity.Clear(mySB);
			
            mySB.Append("SELECT * FROM ");

            mySB.Append(myTableName);

            mySB.Append(" LIMIT ");
			
			mySB.Append(myRowCount);
			
			mySB.Append(" OFFSET ");
			
            mySB.Append(myOffset);

            mySB.AppendLine(";");

            myCommand.CommandText = mySB.ToString();

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
