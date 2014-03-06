using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.Jobs
{

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method)]
    public class JobParameterInfoAttribute : Attribute
    {

        public JobParameterInfoAttribute(string TheParameterName)
        {

            ParameterName = TheParameterName;

        }

        public string ParameterName
        {

            get;
            private set;

        }

    }

}
