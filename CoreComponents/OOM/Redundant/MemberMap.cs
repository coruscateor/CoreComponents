using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace CoreComponents.OOM
{
    public class MemberMap
    {

        protected MemberInfo myLeftMemberInfo;

        protected MemberInfo myRightMemberInfo;

        protected MemberInfoProperties<MemberInfo> myLeftMemberInfoProperties;

        protected MemberInfoProperties<MemberInfo> myRightMemberInfoProperties;

        protected ValueTransferenceDirection myValueTransferenceDirection = ValueTransferenceDirection.BothWays;

        //Todo: Setup as set of delegates to control how the members are mapped and vales are transfered;

        public MemberMap() 
        {

            //FieldInfo fi;

            //fi.

            //PropertyInfo pi;

            //pi.p

        }

        public MemberInfo LeftMemberInfo 
        {

            get 
            {

                return myLeftMemberInfo;

            }
            set
            {

                myLeftMemberInfo = value;

                myLeftMemberInfoProperties = new MemberInfoProperties(myLeftMemberInfo);

            }

        }

        public MemberInfo RightMemberInfo 
        {

            get
            {

                return myRightMemberInfo;

            }
            set
            {

                myRightMemberInfo = value;

                myRightMemberInfoProperties = new MemberInfoProperties(myRightMemberInfo);

            }

        }

        public MemberInfoProperties RightMemberInfoProperties
        {

            get 
            {

                return myRightMemberInfoProperties;

            }

        }

        public MemberInfoProperties LeftMemberInfoProperties
        {

            get
            {

                return myLeftMemberInfoProperties;

            }

        }

        public ValueTransferenceDirection ValueTransferenceDirection 
        {

            get 
            {

                return myValueTransferenceDirection;

            }
            set 
            {

                myValueTransferenceDirection = value;

            }

        }

        //public bool IsValid()
        //{

        //    return false;

        //}

        //TransferIfDifferent

        //TransferRegardless

        //ValueIsDifferent

    }

    public enum ValueTransferenceDirection
    {
    
        LeftToRight,
        RightToLeft,
        BothWays

    }

}
