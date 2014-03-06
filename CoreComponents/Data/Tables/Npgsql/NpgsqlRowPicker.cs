using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using Npgsql;
using CoreComponents.Text;

namespace CoreComponents.Data.Tables.Npgsql
{
    public class NpgsqlRowPicker : RowPicker
    {

        public NpgsqlRowPicker(string TableName)
        {

            myTableName = TableName;

            myRowCount = 50;

            myOffset = 0;

            myCommand = new NpgsqlCommand();

            Initalise();

            //myTable = new DataTable();

        }

        public NpgsqlRowPicker(string TableName, int RowCount, int Offset)
        {

            myTableName = TableName;

            myRowCount = RowCount;

            myOffset = Offset;

            myCommand = new NpgsqlCommand();

            Initalise();

            //myTable = new DataTable();

        }

        public NpgsqlRowPicker(string ConnString, string TableName)
        {

            myTableName = TableName;

            myRowCount = 50;

            myOffset = 0;

            myCommand = new NpgsqlCommand();

            myCommand.Connection = new NpgsqlConnection(ConnString);

            Initalise();

           // myTable = new DataTable();

        }

        public NpgsqlRowPicker(ConnectionStringSettings ConnString, string TableName)
        {

            myTableName = TableName;

            myRowCount = 50;

            myOffset = 0;

            myCommand = new NpgsqlCommand();

            Initalise();

        }

        public NpgsqlRowPicker(ConnectionStringSettings ConnString, string TableName, int myRowCount)
        {

            myTableName = TableName;

            myRowCount = RowCount;

            myOffset = 0;

            myCommand = new NpgsqlCommand();

            Initalise();

        }

        public NpgsqlRowPicker(NpgsqlConnection connection, string TableName, int myRowCount)
        {

            myTableName = TableName;

            myRowCount = RowCount;

            myOffset = 0;

            myCommand = new NpgsqlCommand();

            myCommand.Connection = connection;

            Initalise();

        }


        void Initalise()
        {

            myDataAdapter = new NpgsqlDataAdapter((NpgsqlCommand)myCommand);

            myCommandBuilder = new NpgsqlCommandBuilder((NpgsqlDataAdapter)myDataAdapter);

            RefeshTotalRows();

        }

        public override void AssembleCountQuery()
        {

            StringBuilder SB = new StringBuilder();

            SB.Append("SELECT count(*) FROM ");

            SB.Append(myTableName);

            SB.AppendLine(";");

            myCountCommand = new NpgsqlCommand(SB.ToString(), (NpgsqlConnection)myCommand.Connection);

        }

        public override void AssembleFetchQuery()
        {

            TextEntity.Clear(mySB);

            mySB.Remove(0, mySB.Length);

            mySB.Append("SELECT * FROM ");

            mySB.Append(myTableName);

            mySB.Append("OFFSET ");

            mySB.Append(myOffset);

            mySB.Append("ROWS FETCH NEXT ");

            mySB.Append(myRowCount);

            mySB.Append(" ONLY");

            mySB.AppendLine(";");

            myCommand.CommandText = mySB.ToString();

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
