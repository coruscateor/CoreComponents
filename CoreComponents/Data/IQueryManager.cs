using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
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

/// <summary>
/// Summary description for ICRUDManager
/// </summary>
/// 

namespace CoreComponents.Data
{


    public interface IQueryManager
    {

        //IDbCommand CloneToCommand();

        DataTable GetNewDataTable();

        void FillDataTable(DataTable TheTable);

        
        //int CommandTimeOut
        //{
            //get;
            /*set;*/
        //}

        int ExecuteNonQuery();

        T ExecuteScalar<T>();

        //DbDataReader GetDbDataReader();

		/*
        int Update(DataTable Data);

        int Update(DataTable Data, DataUpdateSelection Selection);
		 
		
        DataProviderType Provider
        {
            get;
        }
		*/

    }

    public enum DataUpdateSelection
    {

        INSERT,
        UPDATE,
        DELETE,
        INSERT_UPDATE,
        INSERT_DELETE,
        UPDATE_DELETE,
        ALL

    }

    /*
    public interface IQueryManager<TDataReader, TDataAdapter, TCommand, TConnection, TParameter, TParameters>
        where TDataReader : IDataReader
        where TDataAdapter : IDataAdapter
        where TCommand : IDbCommand
        where TConnection : IDbConnection
        where TParameter : IDbDataParameter
        //where TParameters : IList<TParameter>
    {

        TCommand Command
        {

            get;
            set;

        }

        TConnection CommandConnection
        {

            get;
            set;

        }

        TParameters CommandParameters
        {

            get;

        }

        TDataReader GetDataReader();

        DataTable GetDataTable();

        int CommandTimeOut
        {
            get;
            set;
        }

        int ExecuteNonQuery();

        T ExecuteScalar<T>();

        int Update(DataTable Data);

        UpdateRowSource UpdatedRowSource
        {

            get;
            set;

        }

    }
    */

    public enum SQLCommandType
    {
        SELECT,
        INSERT,
        UPDATE,
        DROP

    }

}







