using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.Common;
using Npgsql;
using CoreComponents;
using CoreComponents.Caching;
//using CoreComponents.Data.Npgsql.WorkAround;

namespace CoreComponents.Data
{

    public delegate DbConnection GetADBConnection();

    public class DbSeshFactory
    {

        GetADBConnection TheConnector;

        public event Gimmie<SenderEventArgs<DbSeshFactory>>.GimmieSomethin ProviderChanged;

        public DbSeshFactory(DataProviderType Provider)
        {

            SetProvider(Provider);

        }

        public DataProviderType Provider
        {

            get
            {

                return GetProvider();

            }
            set
            {

                SetProvider(value);

            }

        }

        private void SetProvider(DataProviderType TheProviderType)
        {

            switch (TheProviderType)
            {

                case DataProviderType.Npgsql:

                    TheConnector = NpgsqlConnector;

                    break;

                case DataProviderType.OleDb:

                    TheConnector = OleDbConnector;

                    break;

            }

            OnPorviderChanged(TheProviderType);

        }

        private DataProviderType GetProvider()
        {

            if (TheConnector == NpgsqlConnector)
            {

                return DataProviderType.Npgsql;

            } 
            else
            {

                return DataProviderType.OleDb;

            }


        }

        public DbConnection GetConnector()
        {

            return TheConnector();

        }

        private NpgsqlConnection NpgsqlConnector()
        {

            return new NpgsqlConnection();

        }
		
        //private DbConnection NpgsqlConnector()
        //{

        //    return new NpgsqlConnectionWrapper();

        //}

        private OleDbConnection OleDbConnector()
        {

            return new OleDbConnection();

        }

        private void OnPorviderChanged(DataProviderType TheProviderType) //(DbConnection NewProvider)
        {

            if (ProviderChanged != null)
                ProviderChanged(new SenderEventArgs<DbSeshFactory>(this));

        }

        public string UniqueName()
        {

            StringBuilder SB = new StringBuilder();

            SB.Append(GetProvider().ToString());

            SB.Append("_");

            SB.Append(DateTime.Now.Ticks);

            return SB.ToString();

        }

    }

}

