using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace CoreComponents.OOM
{
    public class MemberInfoProperties<TMemberInfo> where TMemberInfo : MemberInfo
    {

        protected TMemberInfo myMemberInfo;

        //public MemberInfoProperties()
        //{
        //}

        public MemberInfoProperties(TMemberInfo TheMemberInfo)
        {

            myMemberInfo = TheMemberInfo;
            
        }

        /*
        public MemberInfo MemberInfo 
        {

            get 
            {

                return myMemberInfo;

            }

        }
        */

        public bool IsNull()
        {

            return myMemberInfo == null;

        }

        public bool IsNotNull() 
        {

            return myMemberInfo != null;

        }

        public bool IsTypeOf<TMemberInfoType>() where TMemberInfoType : MemberInfo 
        {

            return typeof(TMemberInfoType) == myMemberInfo.GetType();

        }


    }
}
