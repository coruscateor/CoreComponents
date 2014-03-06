using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SchemaAndStatements
{

    public static class DiscreteTables
    {
        
        public static DbTable InitaliseParameterDataTable(bool IncludeUnixTimestampField = false)
        {

            DbTable Table = new DbTable("ParameterData");

            AddDataFields(Table, IncludeUnixTimestampField);

            return Table;

        }

        public static DbTable InitaliseFingerprintDataTable(bool IncludeUnixTimestampField = false)
        {

            DbTable Table = new DbTable("FingerprintData");

            AddDataFields(Table, IncludeUnixTimestampField);

            return Table;

        }

        public static DbTable InitaliseUnitCalibrationSamplesDataTable(bool IncludeUnixTimestampField = false)
        {

            DbTable Table = new DbTable("UnitCalibrationSamples");

            AddCalibrationFields(Table, IncludeUnixTimestampField);

            return Table;

        }

        public static DbTable InitaliseLabCalibrationSamplesDataTable(bool IncludeUnixTimestampField = false)
        {

            DbTable Table = new DbTable("LabCalibrationSamples");

            AddCalibrationFields(Table, IncludeUnixTimestampField);

            return Table;
            
        }

        static void AddDataFields(DbTable TheTable, bool IncludeUnixTimestampField)
        {

            AddTimestamp(TheTable, IncludeUnixTimestampField);

            TheTable.Columns.Add(new DbColumn("Status", SystemTypes.String, "Ok"));

        }
        
        static void AddCalibrationFields(DbTable TheTable, bool IncludeUnixTimestampField)
        {

            AddTimestamp(TheTable, IncludeUnixTimestampField);

            TheTable.Columns.Add(new DbColumn("SampleID"));

        }

        static void AddTimestamp(DbTable TheTable, bool IncludeUnixTimestampField)
        {

            TheTable.Columns.Add(new DbColumn("Timestamp", SystemTypes.DateTime));

            if (IncludeUnixTimestampField)
                TheTable.Columns.Add(new DbColumn("UnixTimestamp", SystemTypes.Ulong));

        }

        public static DbTable InitaliseEquipmentTable(bool IncludeUnixDetectedOnField = false)
        {

            DbTable Table = new DbTable("Equipment");

            Table.Columns.Add(new DbColumn("SerialNumber", SystemTypes.String));

            Table.Columns.Add(new DbColumn("PathLength", SystemTypes.Ushort));

            Table.Columns.Add(new DbColumn("HexValue", SystemTypes.String));

            Table.Columns.Add(new DbColumn("Type", SystemTypes.String));

            Table.Columns.Add(new DbColumn("GlobalCalibration", SystemTypes.String));

            Table.Columns.Add(new DbColumn("DetectedOn", SystemTypes.DateTime));

            if (IncludeUnixDetectedOnField)
                Table.Columns.Add(new DbColumn("UnixDetectedOn", SystemTypes.Uint));

            return Table;

        }

        public static DbTable InitaliseScanpointsTable(bool IncludeUnixDetectedOnField = false)
        {

            DbTable Table = new DbTable("Scanpoints");

            Table.Columns.Add(new DbColumn("Name", SystemTypes.String));

            Table.Columns.Add(new DbColumn("DetectedOn", SystemTypes.DateTime));

            if (IncludeUnixDetectedOnField)
                Table.Columns.Add(new DbColumn("UnixDetectedOn", SystemTypes.Uint));

            return Table;

        }

        public static DbTable InitaliseProcessingOptionsTable(bool IncludeUnixDetectedOnField = false)
        {

            DbTable Table = new DbTable("ProcessingOptions");

            Table.Columns.Add(new DbColumn("ParameterName", SystemTypes.String));

            Table.Columns.Add(new DbColumn("Plot", SystemTypes.Boolean));

            Table.Columns.Add(new DbColumn("SpreadSheet", SystemTypes.Boolean));

            Table.Columns.Add(new DbColumn("MaximumScale", SystemTypes.Double));

            Table.Columns.Add(new DbColumn("MinimumScale", SystemTypes.Double));

            Table.Columns.Add(new DbColumn("DetectedOn", SystemTypes.DateTime));

            if (IncludeUnixDetectedOnField)
                Table.Columns.Add(new DbColumn("UnixDetectedOn", SystemTypes.Ulong));

            return Table;

        }

        public static DbTable InitaliseGeneralProcessingOptionsTable()
        {

            DbTable Table = new DbTable("GeneralProcessingOptions");

            Table.Columns.Add(new DbColumn("TimespanPerplot", SystemTypes.TimeSpan));

            Table.Columns.Add(new DbColumn("TotalTimespan", SystemTypes.TimeSpan));

            return Table;

        }

        public static DbTable InitaliseExclusionOptionsTable(bool IncludeUnixFields = false)
        {

            DbTable Table = new DbTable("ExclusionOptions");

            Table.Columns.Add(new DbColumn("From", SystemTypes.DateTime));

            if (IncludeUnixFields)
                Table.Columns.Add(new DbColumn("UnixFrom", SystemTypes.Uint));

            Table.Columns.Add(new DbColumn("To", SystemTypes.DateTime));

            if (IncludeUnixFields)
                Table.Columns.Add(new DbColumn("UnixTo", SystemTypes.Uint));

            return Table;

        }

        public static DbTable InitaliseInductedFilesTable(bool IncludeUnixFields = false)
        {

            DbTable Table = new DbTable("InductedFiles");

            Table.Columns.Add(new DbColumn("FileName", SystemTypes.String));

            Table.Columns.Add(new DbColumn("BeginningRecordTimestamp", SystemTypes.DateTime));

            if(IncludeUnixFields)
                Table.Columns.Add(new DbColumn("UnixBeginningRecordTimestamp", SystemTypes.Uint));

            Table.Columns.Add(new DbColumn("EndingRecordTimestamp", SystemTypes.DateTime));

            if (IncludeUnixFields)
                Table.Columns.Add(new DbColumn("UnixEndingRecordTimestamp", SystemTypes.Uint));

            Table.Columns.Add(new DbColumn("FileSize", SystemTypes.Uint));

            Table.Columns.Add(new DbColumn("ModifiedDate", SystemTypes.DateTime));

            if(IncludeUnixFields)
                Table.Columns.Add(new DbColumn("UnixModifiedDate", SystemTypes.Uint));

            return Table;

        }

    }

}
