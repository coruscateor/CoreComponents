using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using CoreComponents;
using CoreComponents.Data;
using CoreComponents.Items;

namespace CoreComponents.Data.SchemaRetrieval
{
    public class SchemaRetriever : IActivateDeactivate
    {

        DbSeshFactory mySesh;

        DbConnection myConnection;

        public event Gimmie<SenderEventArgs<SchemaRetriever>>.GimmieSomethin ProviderChanged;

        public event Gimmie<SenderEventArgs<SchemaRetriever>>.GimmieSomethin ConnectionStringChanged;


        public SchemaRetriever()
        {

            mySesh = new DbSeshFactory(DataProviderType.Npgsql);

            myConnection = mySesh.GetConnector();

            Activate();

        }

        //public SchemaRetriever(string TheCollectionName)
        //{

        //    myCollectionName = TheCollectionName;

        //    myRestrictionValues = new List<string>();

        //    mySchemaRetrivalType = SchemaRetrivalType.Named;

        //    mySesh = new DbSeshFactory(DataProviderType.Npgsql);

        //    myConnection = mySesh.GetConnector();

        //    Activate();

        //}

        //public SchemaRetriever(string TheCollectionName, IList<string> TheRestrictionValues)
        //{

        //    myCollectionName = TheCollectionName;

        //    myRestrictionValues = TheRestrictionValues;

        //    mySchemaRetrivalType = SchemaRetrivalType.Restricted;

        //    mySesh = new DbSeshFactory(DataProviderType.Npgsql);

        //    myConnection = mySesh.GetConnector();

        //    Activate();

        //}

        public SchemaRetriever(DataProviderType ProviderType)
        {

            mySesh = new DbSeshFactory(ProviderType);

            myConnection = mySesh.GetConnector();

            Activate();

        }

        public SchemaRetriever(DataProviderType ProviderType, string ConnString)
        {

            mySesh = new DbSeshFactory(ProviderType);

            myConnection = mySesh.GetConnector();

            myConnection.ConnectionString = ConnString;

            Activate();

        }

        void OnConnectionStringChanged()
        {

            if (ConnectionStringChanged != null)
                ConnectionStringChanged(new SenderEventArgs<SchemaRetriever>(this));

        }

        void mySesh_ProviderChanged(SenderEventArgs<DbSeshFactory> args)
        {

            myConnection = args.Sender.GetConnector();

            OnProviderChanged();

        }

        void OnProviderChanged()
        {

            if (ProviderChanged != null)
                ProviderChanged(new SenderEventArgs<SchemaRetriever>(this));

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

        public DbSeshFactory sesh
        {

            get
            {

                return mySesh;

            }

        }

        public DataTable GetSchemaTable(ISchemaSubCollection SubCollection)
        {

            myConnection.Open();

            DataTable Schema = null;

            //if (mySchemaRetrivalType == SchemaRetrivalType.Default)
            //    Schema = myConnection.GetSchema(); //"MetaDataCollections" "Restrictions"

            if (SubCollection.UseRestrictionValues)
                if(SubCollection.CanProcureValues())
                    Schema = myConnection.GetSchema(SubCollection.Name, SubCollection.RestrictionValues());

            else
                Schema = myConnection.GetSchema(SubCollection.Name);

            myConnection.Close();

            return Schema;

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

        public KeyValuePair<bool, string> Test()
        {

            KeyValuePair<bool, string> Result;

            try
            {

                myConnection.Open();

                Result = new KeyValuePair<bool, string>(true, "Success, Connection Succeeded!");


            } catch (Exception e)
            {

                Result = new KeyValuePair<bool, string>(true, "Connection Failure: " + e.Message);

            } finally
            {

                myConnection.Close();

            }

            return Result;
        }

        public bool QuickTest()
        {

            bool Result;

            try
            {

                myConnection.Open();

                Result = true;

            } finally
            {

                myConnection.Close();

            }

            return Result;
        }

        #region IActivateable Members

        public void Activate()
        {

            mySesh.ProviderChanged += mySesh_ProviderChanged;

        }


        #endregion

        #region IDeactivateable Members

        public void Deactivate()
        {
            mySesh.ProviderChanged -= mySesh_ProviderChanged;
        }

        #endregion

    }
}
