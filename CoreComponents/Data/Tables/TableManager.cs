using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

#pragma warning disable 0162

namespace CoreComponents.Data.Tables
{
    public abstract class TableManager : ITableManager
    {

        protected DbCommand myCommand;

        protected DbDataAdapter myDataAdapter;

        protected DbCommandBuilder myCommandBuilder;

        protected DataTable myTable;

        public static TableManager Create(DataProviderType ConnectionProvider, ConnectionStringSettings ConnString, string Query)
        {

            switch (ConnectionProvider)
            {

                case DataProviderType.Npgsql:

                    return new Npgsql.NpgsqlTableManager(ConnString, Query);

                    break;

                case DataProviderType.OleDb:

                    return null;

                    break;

				case DataProviderType.MySql:

                    return new MySql.MySqlTableManager(ConnString, Query);

                    break;
            }

            return null;

        }
		/*
		public static TableManager Create(DataProviderType ConnectionProvider, ConnectionStringSettings ConnString, string Query, string TableName)
        {

            switch (ConnectionProvider)
            {

                case DataProviderType.Npgsql:

                    return new Npgsql.NpgsqlTableManager(ConnString, Query, TableName);

                    break;

                case DataProviderType.OleDb:

                    return null;

                    break;

				case DataProviderType.MySql:

                    return MySql.MySqlTableManager(ConnString, Query, TableName);

                    break;
            }

            return null;

        }
        */
		/*
		public static TableManager Create(DataProviderType ConnectionProvider, DbConnection Conn, string Query, string TableName)
        {

            switch (ConnectionProvider)
            {

                case DataProviderType.Npgsql:

                    return new Npgsql.NpgsqlTableManager((Npgsql.NpgsqlConnection)Conn, Query, TableName);

                    break;

                case DataProviderType.OleDb:

                    return null;

                    break;

				case DataProviderType.MySql:

                    return MySql.MySqlTableManager((MySql.Data.MySqlClient.MySqlConnection)Conn, Query, TableName);

                    break;
            }

            return null;

        }
*/
        public TableManager()
        {
        }

        public DataTable Table
        {

            get
            {

                if (myTable == null)
                {

                    FillTable();

                }

                return myTable;

            }

        }

        public string Name
        {

            get
            {

                return myTable.TableName;

            }

        }

        public DataColumn[] PrimaryKey
        {

            get
            {

                return myTable.PrimaryKey;
            }

        }

        public bool Owns(DataTable Data)
        {

            return myTable == Data;

        }

        public bool PrimaryKeyIsComposite()
        {

            return myTable.PrimaryKey.Length > 1;

        }
        /*
        public void Execute()
        {

            try
            {

                //myDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                FillTable();

            } catch (Exception ex)
            {

                throw new Exception("GetDataTable: " + ex.Message, ex);

            }

        }
        */

        public MissingSchemaAction MissingSchema
        {

            get
            {

                return myDataAdapter.MissingSchemaAction;

            }

            set
            {

                myDataAdapter.MissingSchemaAction = value;

            }

        }

        public void PrepareCommand()
        {

            myCommand.Prepare();

        }

        /*
        public void Execute(params int[] Locations)
        {

            try
            {

                if (myTable != null)
                    FillDT();

                if (Locations.Length > 1)
                    SetPKs(Locations);
                else
                    SetPK(Locations[0]);


            } catch (Exception ex)
            {

                throw new Exception("GetDataTable: " + ex.Message, ex);

            }

        }
         * */

        public void SetPKs(params int[] Columns)
        {

            SetPKs(Columns);

        }

        public void SetPKs(IEnumerable<int> Columns)
        {

            List<DataColumn> RowSet = new List<DataColumn>();

            foreach (int Column in Columns)
            {

                if (myTable.Columns.Count <= Column)
                    RowSet.Add(myTable.Columns[Column]);

            }

            myTable.PrimaryKey = RowSet.ToArray();

        }

        public void SetPK(int Location)
        {

            if (myTable.Columns.Count >= Location)
                myTable.PrimaryKey = new DataColumn[1] { myTable.Columns[Location] };

        }

        public void AddConstarint(ForeignKeyConstraint Con)
        {

            myTable.Constraints.Add(Con);

            //DT.Constraints.Add(new ForeignKeyConstraint(

        }

        public void AddConstarint(string constraintName, DataColumn parentColumn, DataColumn childColumn)
        {

            myTable.Constraints.Add(new ForeignKeyConstraint(constraintName, parentColumn, childColumn));

        }

        public void AddConstarint(string constraintName, DataColumn[] parentColumns, DataColumn[] childColumns)
        {

            myTable.Constraints.Add(new ForeignKeyConstraint(constraintName, parentColumns, childColumns));

        }

        public void FillTable()
        {

            myCommand.Connection.Open();

            myDataAdapter.Fill(myTable);

            myCommand.Connection.Close();

        }

        public int Update()
        {

            try
            {
                //using (myCommand.Connection)
                //{

                myCommandBuilder.RefreshSchema();

                myCommandBuilder.GetInsertCommand();

                myCommandBuilder.GetUpdateCommand();

                myCommandBuilder.GetDeleteCommand();

                myCommand.Connection.Open();

                int RowsAffected = myDataAdapter.Update(myTable);

                myCommand.Connection.Close();

                return RowsAffected;

                //}

            } catch (Exception ex)
            {

                throw new Exception("NonQueryfail: " + ex.Message, ex);

            } finally
            {

                myCommand.Connection.Close();

            }
        }

		/*
        public int Update(DataUpdateSelection Selection)
        {

            int RowsAffected;

            try
            {

                myCommandBuilder.RefreshSchema();

                switch (Selection)
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

                RowsAffected = myDataAdapter.Update(myTable);

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
		
        public void Clear()
        {

            myTable.Clear();

        }

        public abstract DataProviderType Provider
        {
            get;
        }

    }
}
