using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;

namespace CoreComponents.Data.Dumping
{
    public class DumpDataSetToHtml : DumpDataSetData
    {

        public DumpDataSetToHtml() : base(true)
        {
        }

        void ConvertDataSetSchemaToHtml(DataSet DS, StringBuilder SB)
        {


            foreach (DataTable DT in DS.Tables)
            {

                ConvertDataTableSchemaToHtml(DT, SB);

            }

        }

        void ConvertDataTableSchemaToHtml(DataTable DT, StringBuilder SB)
        {

            AddDataTableTitle(DT, SB);

            OpenTable(SB);

            SB.Append("<tr><th>Column Name</th><th>Data Type</th></tr>");

            SB.AppendLine();

            foreach (DataColumn DC in DT.Columns)
            {

                ConvertDataColumnSchemaToHtml(DC, SB);

            }

            CloseTable(SB);

            InsertBreak(SB);

        }

        void ConvertDataColumnSchemaToHtml(DataColumn DC, StringBuilder SB)
        {

            OpenRowAndCell(SB);

            SB.Append(DC.ColumnName);

            CloseCell(SB);

            OpenCell(SB);

            SB.Append(Convert.ToString(DC.DataType));

            CloseCellAndRow(SB);

            SB.AppendLine();

        }

        void ConvertDataSetToHtml(DataSet DS, StringBuilder SB)
        {

            //SB.AppendLine(DS.DataSetName);

            foreach (DataTable DT in DS.Tables)
            {

                ConvertDataTableToHtml(DT, SB);

            }

        }

        void ConvertDataTableToHtml(DataTable DT, StringBuilder SB)
        {

            AddDataTableTitle(DT, SB);

            OpenTable(SB);

            OpenRow(SB);

            foreach (DataColumn DC in DT.Columns)
            {

                OpenHeading(SB);

                SB.Append(DC.ColumnName);

                CloseHeading(SB);

            }

            CloseRow(SB);

            SB.AppendLine();

            DataRowCollection Rows = DT.Rows;

            foreach (DataRow DR in Rows)
            {

                OpenRow(SB);

                object[] items = DR.ItemArray;

                foreach (object item in items)
                {

                    OpenCell(SB);

                    SB.Append(item);

                    CloseCell(SB);

                }

                CloseRow(SB);

                SB.AppendLine();

            }

            CloseTable(SB);

            InsertBreak(SB);

            SB.AppendLine();

        }

        void ConvertDataColumnToHtml(DataColumn DC, StringBuilder SB)
        {

            if (DC.Table != null)
            {

                AddDataTableTitle(DC.Table, SB);

                OpenTable(SB);

                OpenRowAndHeading(SB);

                SB.Append(DC.ColumnName);

                CloseHeadingAndRow(SB);

                DataRowCollection Rows = DC.Table.Rows;

                foreach (DataRow DR in Rows)
                {

                    //OpenRow(SB);

                    object[] items = DR.ItemArray;

                    //OpenCell(SB);

                    OpenRowAndCell(SB);

                    SB.Append(items[DC.Ordinal]);

                    CloseCellAndRow(SB);

                    //CloseCell(SB);

                    //CloseRow(SB);

                    SB.AppendLine();

                }

                CloseTable(SB);

                SB.AppendLine();

                InsertBreak(SB);

            }

        }

        void AddDataSetTitle(DataSet DS, StringBuilder SB)
        {

            if (DS.DataSetName.Length > 0)
            {

                //SB.Append("<tr><th>");

                //SB.Append(DS.DataSetName);

                //SB.AppendLine("</tr></th>");

                InsertTitle(DS.DataSetName, SB);

            } else
            {

                EmptyHead(SB);

            }

        }

        void AddDataTableTitle(DataTable DT, StringBuilder SB)
        {

            if (DT.TableName.Length > 0)
            {

                //OpenRowAndHeading(SB);

                SB.Append("<h2>");

                SB.Append(DT.TableName);

                SB.Append("</h2>");

                //CloseHeadingAndRow(SB);

                SB.AppendLine();

            }

        }

        void AddDataColumnTitle(DataColumn DC, StringBuilder SB)
        {


            //if (DC.ColumnName.Length > 0)
            //{

            OpenRowAndHeading(SB);

            SB.Append(DC.ColumnName);

            CloseHeadingAndRow(SB);

            //} 

        }

        void OpenRow(StringBuilder SB)
        {

            SB.Append("<tr>");

        }

        void OpenCell(StringBuilder SB)
        {

            SB.Append("<td>");

        }

        void CloseCell(StringBuilder SB)
        {

            SB.Append("</td>");

        }

        void OpenHeading(StringBuilder SB)
        {

            SB.Append("<th>");

        }

        void CloseHeading(StringBuilder SB)
        {

            SB.Append("</th>");

        }

        void CloseRow(StringBuilder SB)
        {

            SB.Append("</tr>");

        }

        void OpenRowAndCell(StringBuilder SB)
        {

            SB.Append("<tr><td>");

        }

        void CloseCellAndRow(StringBuilder SB)
        {

            SB.Append("</td></tr>");

        }

        void OpenRowAndHeading(StringBuilder SB)
        {

            SB.Append("<tr><th>");

        }

        void CloseHeadingAndRow(StringBuilder SB)
        {

            SB.Append("</th></tr>");

        }

        void OpenHtml(StringBuilder SB)
        {
            SB.AppendLine("<html>");
        }

        void CloseHtml(StringBuilder SB)
        {
            SB.AppendLine("</html>");
        }

        void InsertTitle(string text, StringBuilder SB)
        {

            SB.AppendLine("<head>");

            SB.Append("<title>");

            SB.Append(text);

            SB.AppendLine("</title>");

            SB.AppendLine("</head>");

        }

        void EmptyHead(StringBuilder SB)
        {

            SB.AppendLine("<head>");

            SB.AppendLine("</head>");

        }

        void OpenBody(StringBuilder SB)
        {
            SB.AppendLine("<body>");
        }

        void CloseBody(StringBuilder SB)
        {
            SB.AppendLine("</body>");
        }

        void OpenTable(StringBuilder SB)
        {
            SB.AppendLine(@"<table border=""1"">");
        }

        void CloseTable(StringBuilder SB)
        {
            SB.AppendLine("</table>");
        }

        void InsertBreak(StringBuilder SB)
        {
            SB.AppendLine("<br />");
        }


        #region IDumpDataSets Members

        //public override OutputFormatting OutputFormat
        //{
        //    get
        //    {
        //        return OutputFormatting.html;
        //    }
        //}

        protected override void ConvertDataSetSchema(DataSet DS, StringBuilder SB)
        {

            OpenHtml(SB);

            AddDataSetTitle(DS, SB);

            OpenBody(SB);

            ConvertDataSetSchemaToHtml(DS, SB);

            CloseBody(SB);

            CloseHtml(SB);

        }

        protected override void ConvertDataTableSchema(DataTable DT, StringBuilder SB)
        {

            OpenHtml(SB);

            if(DT.DataSet != null)
                AddDataSetTitle(DT.DataSet, SB);
            else
                EmptyHead(SB);

            OpenBody(SB);

            ConvertDataTableSchemaToHtml(DT, SB);

            CloseBody(SB);

            CloseHtml(SB);

        }

        protected override void ConvertDataColumnSchema(DataColumn DC, StringBuilder SB)
        {

            OpenTable(SB);

            ConvertDataColumnSchemaToHtml(DC, SB);

            CloseTable(SB);

        }

        protected override void ConvertDataSet(DataSet DS, StringBuilder SB)
        {

            OpenHtml(SB);

            AddDataSetTitle(DS, SB);

            OpenBody(SB);

            InsertBreak(SB);

            ConvertDataSetToHtml(DS, SB);

            InsertBreak(SB);

            CloseBody(SB);

            CloseHtml(SB);

        }

        protected override void ConvertDataTable(DataTable DT, StringBuilder SB)
        {

            OpenHtml(SB);

            InsertBreak(SB);

            if (DT.DataSet != null)
                AddDataSetTitle(DT.DataSet, SB);
            else
                EmptyHead(SB);

            OpenBody(SB);

            ConvertDataTableToHtml(DT, SB);

            CloseBody(SB);

            CloseHtml(SB);

        }

        protected override void ConvertDataColumn(DataColumn DC, StringBuilder SB)
        {
            OpenHtml(SB);

            if (DC.Table != null)
            {

                if (DC.Table.DataSet != null)
                    AddDataSetTitle(DC.Table.DataSet, SB);
                else
                    EmptyHead(SB);

            } else
            {

                EmptyHead(SB);

            }

            OpenBody(SB);

            InsertBreak(SB);

            ConvertDataColumnToHtml(DC, SB);

            CloseBody(SB);

            CloseHtml(SB);
        }

        #endregion
    }
}
