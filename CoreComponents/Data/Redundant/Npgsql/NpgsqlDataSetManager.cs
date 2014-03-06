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
using System.Data.Common;
using Npgsql;

/// <summary>
/// Summary description for NpgsqlDataSetManager
/// </summary>
/// 

namespace CoreComponents.Data.Tables.Npgsql
{

    public class NpgsqlDataSetManager : DataSetManager<NpgsqlTableManager>
    {

        public NpgsqlDataSetManager()
        {
            DS = new DataSet();

            //DS.Tables.CollectionChanged += Tables_CollectionChanged;
        }

        public NpgsqlDataSetManager(NpgsqlConnection cn)
        {

            this.cn = (DbConnection)cn;


        }

        public NpgsqlDataSetManager(string DataSetName)
        {

            DS = new DataSet(DataSetName);

        }



 

        public NpgsqlConnection Connection
        {

            get
            {

                return (NpgsqlConnection)cn;

            }

        }
		
		public override DataProviderType Provider
		{
			
			get {
				
				return DataProviderType.Npgsql;
				
			}
		}

    }

}
