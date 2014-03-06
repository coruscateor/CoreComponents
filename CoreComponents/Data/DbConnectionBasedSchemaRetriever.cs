using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace CoreComponents.Data
{

    public class DbConnectionBasedSchemaRetriever<TConnection> where TConnection : DbConnection
    {

        //public delegate void ErrorEventArgsDelegate(ErrorEventArgs<DbConnectionBasedSchemaRetriever<TConnection>> Parameter);

        //public event ErrorEventArgsDelegate ErrorEvent;

        protected TConnection myConnection;

        protected object myLockObject = new object();

        public DbConnectionBasedSchemaRetriever() 
        {
        }

        public DbConnectionBasedSchemaRetriever(TConnection TheConnection)
        {

            myConnection = TheConnection;

        }

        protected void OnErrorEvent(string Message)
        {

            //if (ErrorEvent != null)
            //    ErrorEvent(new ErrorEventArgs<DbConnectionBasedSchemaRetriever<TConnection>>(this, Message));

        }

        protected void OnErrorEvent(Exception ex)
        {

            //if (ErrorEvent != null)
            //    ErrorEvent(new ErrorEventArgs<DbConnectionBasedSchemaRetriever<TConnection>>(this, ex));

        }

        public TConnection Connection 
        {

            get 
            {

                return myConnection;

            }

            set 
            {

                if (myConnection != value)
                {

                    lock (myLockObject)
                    {

                        myConnection = value;

                        //Event

                    }

                }

            }

        }

        public virtual DataTable GetSchemaIndexDataTable()
        {

            lock (myLockObject)
            {

                DataTable SchemaDataTable = null;

                try
                {

                    myConnection.Open();

                    SchemaDataTable = myConnection.GetSchema();

                }
                catch (Exception ex)
                {

                    OnErrorEvent(ex);

                }
                finally
                {

                    myConnection.Close();

                }

                return SchemaDataTable;

            }

        }

        public virtual DataTable GetSchemaCollectionDataTable(string CollectionName)
        {

            lock (myLockObject)
            {

                DataTable SchemaDataTable = null;

                try
                {

                    myConnection.Open();

                    SchemaDataTable = myConnection.GetSchema(CollectionName);

                }
                catch (Exception ex)
                {

                    OnErrorEvent(ex);

                }
                finally
                {

                    myConnection.Close();

                }

                return SchemaDataTable;

            }

        }

        public virtual DataTable GetSchemaCollectionDataTable(string CollectionName, string[] RestrictionValues)
        {

            lock (myLockObject)
            {

                DataTable SchemaDataTable = null;

                try
                {

                    myConnection.Open();

                    SchemaDataTable = myConnection.GetSchema(CollectionName, RestrictionValues);

                }
                catch (Exception ex)
                {

                    OnErrorEvent(ex);

                }
                finally
                {

                    myConnection.Close();

                }

                return SchemaDataTable;

            }

        }

        public virtual DataSet GetSchemaDataSet()
        {

            lock (myLockObject)
            {

                DataSet DbSchema = new DataSet();

                try
                {

                    myConnection.Open();

                    DataTable SchemaIndex = myConnection.GetSchema();

                    foreach (DataRow IndexRow in SchemaIndex.Rows)
                    {

                        DbSchema.Tables.Add(myConnection.GetSchema(Convert.ToString(IndexRow.ItemArray.ElementAt(0))));

                    }

                }
                catch (Exception ex)
                {

                    OnErrorEvent(ex);

                }
                finally
                {

                    myConnection.Close();

                }

                return DbSchema;
            }

        }


    }

}
