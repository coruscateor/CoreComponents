using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    [AttributeUsage(AttributeTargets.Method)]
    public class CallingMethodDeclaringTypeAttribute : Attribute
    {

        Type myDeclaringType;

        public CallingMethodDeclaringTypeAttribute(Type TheDeclaringType)
        {

            myDeclaringType = TheDeclaringType;

        }

        public Type DeclaringType
        {

            get
            {

                return myDeclaringType;

            }
 
        }

    }

}
