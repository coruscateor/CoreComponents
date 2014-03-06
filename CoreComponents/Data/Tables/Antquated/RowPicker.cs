using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using CoreComponents;

#pragma warning disable 0162

namespace CoreComponents.Data.Tables
{
    public abstract class RowPicker : IRowPicker
    {

        public event Gimmie<ChangeEventArgs<int, RowPicker>>.GimmieSomethin RowsUpdated;

        protected DbCommand myCommand;

        protected DbDataAdapter myDataAdapter;

        protected DbCommandBuilder myCommandBuilder;

        protected DataTable myTable;

        protected int myRowCount;

        protected int myOffset;

        protected int myTotalRows;

        protected string myTableName;

        protected DbCommand myCountCommand;
		
		protected StringBuilder mySB = new StringBuilder();

        public static RowPicker Create(DataProviderType ConnectionProvider, ConnectionStringSettings ConnString, string TableName)
        {

            switch (ConnectionProvider)
            {

                case DataProviderType.Npgsql:

                    return new Npgsql.NpgsqlRowPicker(ConnString, TableName);

                    break;

                case DataProviderType.OleDb:

                    return null;

                    break;

                case DataProviderType.MySql:

                    return new MySql.MySqlRowPicker(ConnString, TableName);

                    break;

            }

            return null;

        }

        public static RowPicker Create(DataProviderType ConnectionProvider, ConnectionStringSettings ConnString, string Query, int RowCount)
        {

            switch (ConnectionProvider)
            {

                case DataProviderType.Npgsql:

                    return new Npgsql.NpgsqlRowPicker(ConnString, Query, RowCount);

                    break;

                case DataProviderType.OleDb:

                    return null;

                    break;

                case DataProviderType.MySql:

                    return new MySql.MySqlRowPicker(ConnString, Query, RowCount);

                    break;

            }

            return null;

        }

        public RowPicker()
        {
        }

        public DataTable Table
        {

            get
            {

                if (myTable == null)
                {

                    GetNext();

                }

                return myTable;

            }

        }

        public void GetNext()
        {

            int Next = myOffset + myRowCount;

            if (Next <= myTotalRows)
            {

                ChangeRowSet(Next);

            }

        }

        protected void OnRowsUpdated(int UpdatedRowCount)
        {

            if (RowsUpdated != null)
                RowsUpdated(new ChangeEventArgs<int,RowPicker>(this, UpdatedRowCount));

        }

        public void GetPrevious()
        {

            int Previous = myOffset - myRowCount;

            if (Previous >= 0)
            {

                ChangeRowSet(Previous);

            }

        }

        protected void ChangeRowSet(int Iteration)
        {

            try
            {

                CommitCurrent();

                myOffset = Iteration;

                AssembleFetchQuery();

                RefeshTable();

            } catch (Exception e)
            {

                throw e;

            }

        }

        public virtual void AssembleQuerys()
        {

            AssembleCountQuery();

            AssembleFetchQuery();

        }

        public abstract void AssembleCountQuery();

        public abstract void AssembleFetchQuery();

        public void RefeshTable()
        {

            myCommand.Connection.Open();

            myDataAdapter.Fill(myTable);

            myCommand.Connection.Close();

        }


        public int RowCount
        {
            get
            {

                return myRowCount;

            }

            set
            {

                myRowCount = value;

            }

        }

        public int Offset
        {

            get
            {

                return myOffset;


            }
            set
            {

                ChangeRowSet(value);

            }

        }

        public int TotalRows
        {

            get
            {

                return myTotalRows;

            }

        }

        public string TableName
        {

            get
            {

                return myTableName;

            }
            set
            {

                myTableName = value;

                AssembleQuerys();

                RefeshTotalRows();

            }

        }

        public string CommandText
        {

            get
            {

                return myCommand.CommandText;

            }

        }

        public string CountCommandText
        {

            get
            {

                return myCountCommand.CommandText;

            }

        }

        public void PrepareCommand()
        {

            myCommand.Prepare();

        }

        public int TotalRowsToRowCount()
        {

           return (int)System.Math.Ceiling((double)myTotalRows / RowCount);
            
        }

        public void RefeshTotalRows()
        {

            if (myCountCommand == null)
                AssembleCountQuery();

            myCommand.Connection.Open();

            DbDataReader dr = myCountCommand.ExecuteReader();

            myRowCount = (int)dr[0];

            myCommand.Connection.Close();

        }

        public void CommitCurrent()
        {

            try
            {

                myCommandBuilder.RefreshSchema();

                myCommandBuilder.GetInsertCommand();

                myCommandBuilder.GetUpdateCommand();

                myCommandBuilder.GetDeleteCommand();

                myCommand.Connection.Open();

                OnRowsUpdated(myDataAdapter.Update(myTable));

                myCommand.Connection.Close();

                return;

            } catch (Exception ex)
            {

                throw new Exception("NonQueryfail: " + ex.Message, ex);

            } finally
            {

                myCommand.Connection.Close();

            }

        }

        public abstract DataProviderType Provider
        {
            get;
        }


    }
}
