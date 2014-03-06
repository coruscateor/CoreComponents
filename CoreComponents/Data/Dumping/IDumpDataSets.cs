using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;

namespace CoreComponents.Data.Dumping
{
    public interface IDumpDataSets
    {

        //OutputFormatting OutputFormat
        //{

        //    get;

        //}

        bool JustSchema
        {

            get;
            set;

        }

        void DumpDataSet(DataSet DS, string DumpLocation);

        void DumpDataTable(DataTable DT, string DumpLocation);

        void DumpDataColumn(DataColumn DC, string DumpLocation);


    }
}
