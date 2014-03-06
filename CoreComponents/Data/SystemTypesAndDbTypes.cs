using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CoreComponents.Data
{

    public static class SystemTypesAndDbTypes
    {

        public static Type GetTypeFor(DbType TheDbType)
        {

            switch (TheDbType)
            {

                case DbType.AnsiString:
                    return SystemTypes.String;

                case DbType.Binary:
                    return SystemTypes.ByteArray;

                case DbType.Byte:
                    return SystemTypes.Byte;

                case DbType.Boolean:
                    return SystemTypes.Boolean;

                case DbType.Currency:
                    return SystemTypes.Decimal;

                case DbType.Date:
                    return SystemTypes.DateTime;

                case DbType.DateTime:
                    return SystemTypes.DateTime;

                case DbType.Decimal:
                    return SystemTypes.Decimal;

                case DbType.Double:
                    return SystemTypes.Double;

                case DbType.Guid:
                    return SystemTypes.Guid;

                case DbType.Int16:
                    return SystemTypes.Short;

                case DbType.Int32:
                    return SystemTypes.Int;

                case DbType.Int64:
                    return SystemTypes.Long;

                case DbType.Object:
                    return SystemTypes.Object;

                case DbType.SByte:
                    return SystemTypes.Sbyte;

                case DbType.Single:
                    return SystemTypes.Float;

                case DbType.String:
                    return SystemTypes.String;

                case DbType.Time:
                    return SystemTypes.DateTime;

                case DbType.UInt16:
                    return SystemTypes.Ushort;

                case DbType.UInt32:
                    return SystemTypes.Uint;

                case DbType.UInt64:
                    return SystemTypes.Ulong;

                case DbType.VarNumeric:
                    return SystemTypes.Decimal;

                case DbType.AnsiStringFixedLength:
                    return SystemTypes.String;

                case DbType.StringFixedLength:
                    return SystemTypes.String;

                case DbType.Xml:
                    return SystemTypes.String;

                case DbType.DateTime2:
                    return SystemTypes.DateTime;

                case DbType.DateTimeOffset:
                    return SystemTypes.DateTimeOffset;

            }

            return SystemTypes.Object;

        }

        public static DbType GetDbTypeFor<T>()
        {

            return GetDbTypeFor(typeof(T));

        }

        public static DbType GetDbTypeFor(object TheObject)
        {

            return GetDbTypeFor(TheObject.GetType());

        }

        public static DbType GetDbTypeFor(Type TheType)
        {

            if (TheType == SystemTypes.String)
                return DbType.String;

            else if (TheType == SystemTypes.Byte)
                return DbType.Byte;

            else if (TheType == SystemTypes.Short)
                return DbType.Int16;

            else if (TheType == SystemTypes.Int)
                return DbType.Int32;

            else if (TheType == SystemTypes.Long)
                return DbType.Int64;

            else if (TheType == SystemTypes.Ushort)
                return DbType.UInt16;

            else if (TheType == SystemTypes.Uint)
                return DbType.UInt32;

            else if (TheType == SystemTypes.Uint)
                return DbType.UInt64;

            else if (TheType == SystemTypes.Char)
                return DbType.String;

            else if (TheType == SystemTypes.DateTime)
                return DbType.DateTime;

            else if (TheType == SystemTypes.DateTimeOffset)
                return DbType.DateTimeOffset;

            else if (TheType == SystemTypes.Decimal)
                return DbType.Decimal;

            else if (TheType == SystemTypes.Double)
                return DbType.Double;

            else if (TheType == SystemTypes.Guid)
                return DbType.Guid;

            else if (TheType == SystemTypes.Sbyte)
                return DbType.SByte;

            else if (TheType == SystemTypes.ByteArray)
                return DbType.Binary;

            return DbType.Object;

        }

    }

}
