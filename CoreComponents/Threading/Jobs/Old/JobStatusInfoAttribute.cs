using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.Jobs
{

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method)]
    public class JobStatusInfoAttribute : Attribute
    {

        public JobStatusInfoAttribute(string TheStatusName)
        {

            StatusName = TheStatusName;

        }

        public string StatusName
        {

            get;
            private set;

        }
    
    }

}
