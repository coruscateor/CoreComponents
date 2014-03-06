using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{
    public static class PrimativeConstants
    {

        static List<Type> TypeList;

        public static readonly Type byte_Type;

        public static readonly Type ushort_Type;

        public static readonly Type uint_Type;

        public static readonly Type ulong_Type;

        public static readonly Type sbyte_Type;

        public static readonly Type short_Type;

        public static readonly Type int_Type;

        public static readonly Type long_Type;

        public static readonly Type string_Type;

        public static readonly Type bool_Type;

        public static readonly Type char_Type;

        public static readonly Type float_Type;

        public static readonly Type double_Type;

        public static readonly Type object_Type;

        public static readonly Type DateTime_Type;

        public static readonly Type TimeSpan_Type;

        public static readonly Type Decimal_Type;

        public static readonly Type Guid_Type;

        public static readonly Type Array_Type;

        public static readonly Type decimal_Type;

        static PrimativeConstants()
        {

            byte_Type = typeof(byte);

            ushort_Type = typeof(ushort);

            uint_Type = typeof(uint);

            ulong_Type = typeof(ulong);

            sbyte_Type = typeof(sbyte);

            short_Type = typeof(short);

            int_Type = typeof(int);

            long_Type = typeof(long);

            string_Type = typeof(string);

            bool_Type = typeof(bool);

            byte_Type = typeof(byte);

            char_Type = typeof(char);

            float_Type = typeof(float);

            double_Type = typeof(double);

            object_Type = typeof(object);

            DateTime_Type = typeof(DateTime);

            TimeSpan_Type = typeof(TimeSpan);

            decimal_Type = typeof(decimal);

            Guid_Type = typeof(Guid);

            Array_Type = typeof(Array);

            TypeList = new List<Type>();

            TypeList.Add(byte_Type);
            TypeList.Add(ushort_Type);
            TypeList.Add(uint_Type);
            TypeList.Add(ulong_Type);
            TypeList.Add(sbyte_Type);
            TypeList.Add(short_Type);
            TypeList.Add(int_Type);
            TypeList.Add(long_Type);
            TypeList.Add(string_Type);
            TypeList.Add(byte_Type);
            TypeList.Add(char_Type);
            TypeList.Add(float_Type);
            TypeList.Add(double_Type);
            TypeList.Add(object_Type);
            TypeList.Add(DateTime_Type);
            TypeList.Add(TimeSpan_Type);
            TypeList.Add(decimal_Type);
            TypeList.Add(Guid_Type);
            TypeList.Add(Array_Type);

        }

        public static Type[] GetTypeArray()
        {

            return TypeList.ToArray();

        }

    }
}
