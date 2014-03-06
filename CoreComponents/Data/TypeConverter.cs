using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data
{
    public abstract class TypeConverter
    {
        //http://npgsql.projects.postgresql.org/docs/manual/UserManual.html

        /*
        public static readonly string myInt32_Type;
        public static readonly string Int64_Type;
        public static readonly string Boolean_Type;
        public static readonly string Object_Type;
        public static readonly string Byte_Array_Type;
        public static readonly string DateTime_Type;
        public static readonly string Double_Type;
        public static readonly string Decimal_Type;
        public static readonly string Single_Type;
        public static readonly string String_Type;
        public static readonly string Guid_Type;
        public static readonly string Array_Type;
        */

        public event Action<ExceptionEventArgs<TypeConverter, Exception>>TypeNotListed;

        protected Dictionary<Type, string> myIndex = new Dictionary<Type,string>();

        public TypeConverter()
        {
        }

        void OnTypeNotListed(Type TheType, Exception e)
        {

            if (TypeNotListed != null)
                TypeNotListed(new ExceptionAndMessageEventArgs<TypeConverter, Exception>(this, e, "The type: " + TheType.FullName + " is not listed."));

        }

        public virtual string this[Type Obj]
        {
            get
            {

                try
                {

                    return myIndex[Obj];

                } catch (Exception e)
                {

                    OnTypeNotListed(Obj, e);
                    
                    return "null";

                }

            }
        }

    }
}
