using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;

namespace CoreComponents.Data.Dumping
{
    public abstract class DumpDataSetData : IDumpDataSets
    {

        delegate void delConvertDataSet(DataSet DS, StringBuilder SB);

        delegate void delConvertDataTable(DataTable DT, StringBuilder SB);

        delegate void delConvertDataColumn(DataColumn DC, StringBuilder SB);

        delConvertDataSet myConvertDataSet;

        delConvertDataTable myConvertDataTable;

        delConvertDataColumn myConvertDataColumn;

        bool myJustSchema;

        public DumpDataSetData()
        {
        }

        public DumpDataSetData(bool JustOutputSchema)
        {

            JustSchema = JustOutputSchema;

        }

        #region IDumpDataSets Members

        //public virtual OutputFormatting OutputFormat
        //{
        //    get
        //    {

        //        return OutputFormatting.text;

        //    }
        //}

        public virtual bool JustSchema
        {
            get
            {

                return myJustSchema;

            }
            set
            {

                myJustSchema = value;

                JustOutputSchema(myJustSchema);

            }
        }

        public void DumpDataSet(DataSet DS, string DumpLocation)
        {

            StringBuilder SB = new StringBuilder();

            myConvertDataSet(DS, SB);

            Dump(SB, DumpLocation);

        }

        public void DumpDataTable(DataTable DT, string DumpLocation)
        {

            StringBuilder SB = new StringBuilder();

            myConvertDataTable(DT, SB);

            Dump(SB, DumpLocation);

        }

        public void DumpDataColumn(DataColumn DC, string DumpLocation)
        {

            StringBuilder SB = new StringBuilder();

            myConvertDataColumn(DC, SB);

            Dump(SB, DumpLocation);

        }

        #endregion

        protected void Dump(StringBuilder SB, string DumpLocation)
        {

            StreamWriter writer = new StreamWriter(DumpLocation);

            writer.Write(SB.ToString());

            writer.Close();

        }

        void JustOutputSchema(bool JustSchema)
        {


            if (JustSchema)
            {

                myConvertDataSet = ConvertDataSetSchema;

                myConvertDataTable = ConvertDataTableSchema;

                myConvertDataColumn = ConvertDataColumnSchema;

            } else
            {

                myConvertDataSet = ConvertDataSet;

                myConvertDataTable = ConvertDataTable;

                myConvertDataColumn = ConvertDataColumn;

            }

        }

        protected abstract void ConvertDataSetSchema(DataSet DS, StringBuilder SB);

        protected abstract void ConvertDataTableSchema(DataTable DT, StringBuilder SB);

        protected abstract void ConvertDataColumnSchema(DataColumn DC, StringBuilder SB);

        protected abstract void ConvertDataSet(DataSet DS, StringBuilder SB);

        protected abstract void ConvertDataTable(DataTable DT, StringBuilder SB);

        protected abstract void ConvertDataColumn(DataColumn DC, StringBuilder SB);
		
    }
}
