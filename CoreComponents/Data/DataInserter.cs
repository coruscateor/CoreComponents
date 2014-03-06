using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using CoreComponents.Text;

namespace CoreComponents.Data
{
    public abstract class DataInserter
    {

        protected DbCommand myCommand;

        protected IDataReader myReader;

        protected string myTableName;

        protected SenderEventArgs<DataInserter> myInsertionCompleteEventArgs;

        public event Gimmie<SenderEventArgs<DataInserter>>.GimmieSomethin InsertionComplete;

        public event Gimmie<ExceptionEventArgs<DataInserter, Exception>>.GimmieSomethin ReadException;

        public DataInserter(DbCommand command, string tablename)
        {

            myCommand = command;

            myTableName = tablename;

            initalise();

        }

        public DataInserter(DbCommand command, string tablename, IDataReader reader)
        {

            myCommand = command;

            myTableName = tablename;

            myReader = reader;

            initalise();

        }

        void initalise()
        {

            myInsertionCompleteEventArgs = new SenderEventArgs<DataInserter>(this);

        }

        /*
        public DataInserter(DbConnection connection, string tablename)
        {

            myCommand = new 

        }
        */

        protected void OnInsertionComplete()
        {

            if (InsertionComplete != null)
                InsertionComplete(myInsertionCompleteEventArgs);

        }

        protected void OnReadException(Exception e)
        {

            if (ReadException != null)
                ReadException(new ExceptionAndMessageEventArgs<DataInserter, Exception>(this, e, e.Message));

        }

        public virtual void Run()
        {

            try
            {

                myCommand.Connection.Open();

                DbTransaction Transaction = myCommand.Connection.BeginTransaction();

                object[] RowData = null;

                while (myReader.Read())
                {

                    myReader.GetValues(RowData);

                    myCommand.Parameters.AddRange(RowData);

                    myCommand.ExecuteNonQuery();

                    myCommand.Parameters.Clear();

                }

                Transaction.Commit();

            } finally
            {

                myCommand.Connection.Close();

                OnInsertionComplete();

            }

            

        }

        public virtual void UpdateCommandText()
        {

            StringBuilder SB = new StringBuilder();

            SB.Append("INSERT INTO ");

            SB.Append(myTableName);

            SB.Append(" VALUES(");

            int i = 1;

            int fieldCount = myReader.FieldCount;

            while (i <= fieldCount)
            {

                SB.Append("@");

                SB.Append(i);

                if (i != fieldCount)
                    SB.Append(", ");

            }

            SB.Append(");");

            myCommand.CommandText = SB.ToString();

            myCommand.Prepare();

        }

        public string CurrentTable
        {

            get
            {

                return myTableName;

            }
            set
            {

                myTableName = value;

                UpdateCommandText();

            }

        }

        public IDataReader Reader
        {

            get
            {

                return myReader;

            }
            set
            {

                myReader = value;

            }

        }

    }
}
