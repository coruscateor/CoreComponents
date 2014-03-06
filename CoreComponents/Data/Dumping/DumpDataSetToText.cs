using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;

namespace CoreComponents.Data.Dumping
{
    public class DumpDataSetToText : DumpDataSetData
    {

        public DumpDataSetToText() : base(true)
        {
        }


        void ConvertDataSetSchemaToText(DataSet DS, StringBuilder SB)
        {

            if (DSName(DS, SB))
            {

                SB.AppendLine();

            }

            foreach (DataTable DT in DS.Tables)
            {

                ConvertDataTableSchemaToText(DT, SB);

                SB.AppendLine();

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

        void ConvertDataSetToText(DataSet DS, StringBuilder SB)
        {

            SB.AppendLine(DS.DataSetName);

            foreach (DataTable DT in DS.Tables)
            {

                ConvertDataTableToText(DT, SB);

            }

        }

        void ConvertDataTableToText(DataTable DT, StringBuilder SB)
        {

            TableName(DT, SB);

            foreach (DataColumn DC in DT.Columns)
            {

                SB.Append(DC.ColumnName);

                if (DC.Ordinal != DT.Columns.Count)
                    SB.Append(", ");

            }

            SB.AppendLine();

            SB.AppendLine();

            DataRowCollection Rows = DT.Rows;

            foreach (DataRow DR in Rows)
            {

                object[] items = DR.ItemArray;

                int itemsCount = items.Count() - 1;

                int location = 0;

                foreach (object item in items)
                {

                    SB.Append(item);

                    location++;

                    if (location != itemsCount)
                        SB.Append(", ");

                }

                SB.AppendLine();

            }

        }

        void ConvertDataColumnToText(DataColumn DC, StringBuilder SB)
        {


            //SB.AppendLine(DC.TableName);

            SB.AppendLine(DC.ColumnName);

            SB.AppendLine();

            DataRowCollection Rows = DC.Table.Rows;

            foreach (DataRow DR in Rows)
            {

                object[] items = DR.ItemArray;

                SB.Append(items[DC.Ordinal]);

                SB.AppendLine();

            }

        }

        //void AddDataSetTitle(DataSet DS, StringBuilder SB)
        //{

        //    if (DS.DataSetName.Length > 0)
        //    {

        //        SB.AppendLine(DS.DataSetName);

        //    } 

        //}

        void TableName(DataTable DT, StringBuilder SB)
        {

            if (DT.TableName.Length > 0)
            {

                SB.AppendLine(DT.TableName);

            } 

        }

        void ColumnName(DataColumn DC, StringBuilder SB)
        {


            //if (DC.ColumnName.Length > 0)
            //{

                SB.Append(DC.ColumnName);

            //} 

        }

        protected override void ConvertDataSetSchema(DataSet DS, StringBuilder SB)
        {

            ConvertDataSetSchemaToText(DS, SB);

        }

        protected override void ConvertDataTableSchema(DataTable DT, StringBuilder SB)
        {

            ConvertDataTableSchemaToText(DT, SB);

        }

        protected override void ConvertDataColumnSchema(DataColumn DC, StringBuilder SB)
        {

            SB.Append(DC.ColumnName);
            SB.Append(",\t\t");
            SB.AppendLine(Convert.ToString(DC.DataType));

        }

        protected override void ConvertDataSet(DataSet DS, StringBuilder SB)
        {

            if (DSName(DS, SB))
            {

                SB.AppendLine();

            }

            foreach (DataTable DT in DS.Tables)
            {

                ConvertDataTableToText(DT, SB);

                SB.AppendLine();

            }

        }

        protected override void ConvertDataTable(DataTable DT, StringBuilder SB)
        {

            if (DSName(DT, SB))
            {

                SB.AppendLine();

            }

            ConvertDataTableToText(DT, SB);

        }

        protected override void ConvertDataColumn(DataColumn DC, StringBuilder SB)
        {

            if (DC.Table != null)
            {

                if (DSName(DC.Table, SB))
                {

                    SB.AppendLine();

                }


                ConvertDataColumnToText(DC, SB);
            }

        }

        bool DSName(DataSet DS, StringBuilder SB)
        {

            if (DS != null)
            {

                if (DS.DataSetName.Length > 0)
                {
                    SB.AppendLine(DS.DataSetName);

                    return true;

                }

            }

            return false;
        }

        bool DSName(DataTable DT, StringBuilder SB)
        {

            if (DT.DataSet != null)
            {

                if (DT.DataSet.DataSetName.Length > 0)
                {
                    SB.AppendLine(DT.DataSet.DataSetName);

                    return true;

                }
            }

            return false;
        }

    }
}
