using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;

namespace CoreComponents.Data
{
    public sealed class SystemDotDataFileDumper
    {

        delegate void ConvertDataSet(DataSet DS, StringBuilder SB);

        delegate void ConvertDataTable(DataTable DT, StringBuilder SB);

        delegate void ConvertDataColumn(DataColumn DC, StringBuilder SB);

        ConvertDataSet myConvertDataSet;

        ConvertDataTable myConvertDataTable;

        ConvertDataColumn myConvertDataColumn;

        //OutputFormatting myFormat;

        bool myJustSchema;

        //string myDumpLocation;

        //public SystemDotDataFileDumper()
        //{

        //    OutputFormat = OutputFormatting.text;

        //}

        //public SystemDotDataDumper(string DumpLocation)
        //{

        //    myFormat = OutputFormatting.text;

        //    myDumpLocation = DumpLocation;

        //}

        //public SystemDotDataFileDumper(OutputFormatting Format)
        //{

        //    OutputFormat = Format;

        //}

        //public SystemDotDataDumper(OutputFormatting Format, string DumpLocation)
        //{

        //    myFormat = Format;

        //    myDumpLocation = DumpLocation;

        //}

        //public OutputFormatting OutputFormat
        //{

        //    get
        //    {

        //        return myFormat;

        //    }
        //    set
        //    {

        //        myFormat = value;

        //        SetFormattingEtc(myJustSchema, myFormat);

        //    }

        //}

        //public bool JustSchema
        //{

        //    get
        //    {

        //        return myJustSchema;
        //    }

        //    set
        //    {

        //        myJustSchema = value;

        //        SetFormattingEtc(myJustSchema, myFormat);

        //    }

        //}

        void ConvertDataSetSchemaToText(DataSet DS, StringBuilder SB)
        {

            SB.AppendLine(DS.DataSetName);

            foreach (DataTable DT in DS.Tables)
            {

                ConvertDataTableSchemaToText(DT, SB);

            }

        }

        void ConvertDataTableSchemaToText(DataTable DT, StringBuilder SB)
        {

            SB.AppendLine(DT.TableName);

            foreach (DataColumn DC in DT.Columns)
            {

                ConvertDataColumnSchemaToText(DC, SB);

            }

            SB.AppendLine();

        }

        void ConvertDataColumnSchemaToText(DataColumn DC, StringBuilder SB)
        {

            SB.Append(DC.ColumnName);
            SB.Append(",\t\t");
            SB.AppendLine(Convert.ToString(DC.DataType));

        }

        void ConvertDataSetSchemaToHtml(DataSet DS, StringBuilder SB)
        {

            SB.Append("<table>");

            if (DS.DataSetName.Length > 0)
            {

                SB.Append("<tr><th>");
                SB.Append(DS.DataSetName);
                SB.AppendLine("</th></tr>");

            }

            foreach (DataTable DT in DS.Tables)
            {

                ConvertDataTableSchemaToText(DT, SB);

            }

            SB.Append("</table>");

        }

        void ConvertDataTableSchemaToHtml(DataTable DT, StringBuilder SB)
        {



        }

        void ConvertDataColumnSchemaToHtml(DataColumn DC, StringBuilder SB)
        {

            

        }

        //public string OutputLocation
        //{

        //    get
        //    {

        //        return myDumpLocation;

        //    }
        //    set
        //    {

        //        myDumpLocation = value;

        //    }

        //}

        public void DumpDataSet(DataSet DS, string DumpLocation)
        {

            if (DS != null && DS.Tables.Count > 0)
            {

                StringBuilder SB = new StringBuilder();

                myConvertDataSet(DS, SB);

                Dump(SB, DumpLocation);

            }

        }

        public void DumpDataTable(DataTable DT, string DumpLocation)
        {

            if (DT != null && DT.Columns.Count > 0)
            {

                StringBuilder SB = new StringBuilder();

                myConvertDataTable(DT, SB);

                Dump(SB, DumpLocation);


            }

        }

        public void DumpDataColumn(DataColumn DC, string DumpLocation)
        {

            if (DC != null)
            {

                StringBuilder SB = new StringBuilder();

                myConvertDataColumn(DC, SB);

                Dump(SB, DumpLocation);

            }

        }

        void Dump(StringBuilder SB, string DumpLocation)
        {

            StreamWriter writer = new StreamWriter(DumpLocation);

            writer.Write(SB.ToString());

            writer.Close();

        }

        //void SetFormattingEtc(bool JustSchema, OutputFormatting Format)
        //{


        //    if (JustSchema)
        //    {

        //        switch (myFormat)
        //        {

        //            case OutputFormatting.html:

        //                myConvertDataSet = ConvertDataSetSchemaToHtml;

        //                myConvertDataTable = ConvertDataTableSchemaToHtml;

        //                myConvertDataColumn = ConvertDataColumnSchemaToHtml;

        //                break;

        //            case OutputFormatting.text:

        //                myConvertDataSet = ConvertDataSetSchemaToText;

        //                myConvertDataTable = ConvertDataTableSchemaToText;

        //                myConvertDataColumn = ConvertDataColumnSchemaToText;

        //                break;
        //        }

        //    } else
        //    {

        //        switch (myFormat)
        //        {

        //            case OutputFormatting.html:

        //                //myConvertDataSet = ConvertDataSetSchemaToHtml;

        //                //myConvertDataTable = ConvertDataTableSchemaToHtml;

        //                //myConvertDataColumn = ConvertDataColumnSchemaToHtml;

        //                break;

        //            case OutputFormatting.text:

        //                //myConvertDataSet = ConvertDataSetSchemaToText;

        //                //myConvertDataTable = ConvertDataTableSchemaToText;

        //                //myConvertDataColumn = ConvertDataColumnSchemaToText;

        //                break;
        //        }

        //    }

    }

}
