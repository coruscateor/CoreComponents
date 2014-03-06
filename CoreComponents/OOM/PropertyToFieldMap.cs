using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace CoreComponents.OOM
{
    public class PropertyToFieldMap //<PropertyOwner, MemberOwner>
    {

        //Type myPropertyOwnerType;

        //Type myMemberOwnerType;

        protected object myPropertyOwner;

        protected object myFieldOwner;

        protected PropertyInfo myPropertyInfo;

        protected FieldInfo myFieldInfo;

        protected MemberInfoProperties<PropertyInfo> myPropertyInfoProperties;

        protected MemberInfoProperties<FieldInfo> myFieldInfoProperties;

        public PropertyToFieldMap()
        {
        }

        //public PropertyToMemberMapper(Type ThePropertyOwnerType, Type TheMemberOwnerType) 
        //{

        //    myPropertyOwnerType = ThePropertyOwnerType;

        //    myMemberOwnerType = TheMemberOwnerType;

        //}

        //public Type PropertyOwnerType 
        //{

        //    get 
        //    {

        //        return myPropertyOwnerType;

        //    }

        //}

        //public Type MemberOwnerType 
        //{

        //    get 
        //    {

        //        return myMemberOwnerType;

        //    }

        //}

        public void SetMemberAndOwner(object TheFieldOwner, string TheFieldName, BindingFlags TheBindingFlags = BindingFlags.Default) 
        {

            myFieldInfo = TheFieldOwner.GetType().GetField(TheFieldName, TheBindingFlags);

            myFieldOwner = TheFieldOwner;

        }

        public void SetPropertyAndOwner(object ThePropertyOwner, string TheMemberName, BindingFlags TheBindingFlags = BindingFlags.Default)
        {

            myPropertyInfo = ThePropertyOwner.GetType().GetProperty(TheMemberName, TheBindingFlags);

            myPropertyOwner = ThePropertyOwner;

        }

        public object PropertyOwner
        {

            get 
            {

                return myPropertyOwner;

            }

        }

        public object FieldOwner 
        {

            get 
            {

                return myFieldOwner;

            }

        }

        public PropertyInfo PropertyInfo 
        {

            get 
            {

                return myPropertyInfo;

            }

        }

        public FieldInfo FieldInfo 
        {

            get 
            {

                return myFieldInfo;

            }

        }

    }
}
