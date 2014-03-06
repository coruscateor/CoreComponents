using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CoreComponents.Data.Tables
{
    public interface IRowPicker
    {

        //event Gimmie<ChangeEventArgs<int, IRowPicker>>.GimmieSomethin RowsUpdated;

        DataTable Table
        {

            get;

        }

        void GetNext();

        void GetPrevious();

        void AssembleQuerys();

        void AssembleCountQuery();

        void AssembleFetchQuery();

        void RefeshTable();


        int RowCount
        {

            get;
            set;

        }

        int Offset
        {

            get;
            set;

        }

        int TotalRows
        {

            get;

        }

        string TableName
        {

            get;
            set;
        }

        string CommandText
        {

            get;

        }

        string CountCommandText
        {

            get;

        }

        void PrepareCommand();

        int TotalRowsToRowCount();

        void RefeshTotalRows();

        void CommitCurrent();

        DataProviderType Provider
        {
            get;
        }

    }
}
