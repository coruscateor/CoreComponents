using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;
using System.Reflection;
using CoreComponents;
using CoreComponents.Items;

namespace CoreComponents.Data
{
    public abstract class SchemaRetriever
    {

        protected DbConnection myConnection;

        public event Action<SenderEventArgs<SchemaRetriever>> ConnectionStringChanged;

        //public SchemaRetriever()
        //{

        //    Activate();

        //}

        //public SchemaRetriever(string ConnString)
        //{

        //    myConnection = mySesh.GetConnector();

        //    myConnection.ConnectionString = ConnString;

        //    Activate();

        //}

        //public SchemaRetriever(ConnectionStringSettings ConnString)
        //{

        //    //myConnection = ;

        //    myConnection.ConnectionString = ConnString;

        //    Activate();

        //}

        void OnConnectionStringChanged()
        {

            if (ConnectionStringChanged != null)
                ConnectionStringChanged(new SenderEventArgs<SchemaRetriever>(this));

        }

        public string ConnectionString
        {

            get
            {

                return myConnection.ConnectionString;

            }
            set
            {

                myConnection.ConnectionString = value;

                OnConnectionStringChanged();
                
            }

        }

        public DataTable GetSchemaIndex()
        {

            myConnection.Open();

            DataTable Schema = myConnection.GetSchema();

            myConnection.Close();

            return Schema;

        }

        public DataSet GetSchemaDataSet()
        {

            DataSet DbSchema = new DataSet();

            myConnection.Open();

            DataTable SchemaIndex = myConnection.GetSchema();

            foreach (DataRow IndexRow in SchemaIndex.Rows)
            {

                DbSchema.Tables.Add(myConnection.GetSchema(Convert.ToString(IndexRow.ItemArray.ElementAt(0))));

            }

            myConnection.Close();

            return DbSchema;

        }

        public string UniqueName()
        {

            StringBuilder SB = new StringBuilder();

            SB.Append(myConnection.ToString());

            SB.Append("_");

            SB.Append(DateTime.Now.Ticks);

            return SB.ToString();

        }


    }
}
