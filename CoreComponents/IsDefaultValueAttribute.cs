using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{

    //Indicates whetther the default value of this filed contains the default value.
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    public class IsDefaultValueAttribute : Attribute
    {

        public IsDefaultValueAttribute() 
        {
        }

    }

}
