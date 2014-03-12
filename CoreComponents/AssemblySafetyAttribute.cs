using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents
{
    
    //Indicates whether or not the assembly is used in an unsafe context 

    [AttributeUsage(AttributeTargets.Assembly)]
    public class AssemblySafetyAttribute : Attribute
    {

        protected readonly Safety mySafety; 

        public AssemblySafetyAttribute(Safety TheSafty)
        {

            mySafety = TheSafty;

        }

        public Safety Safety
        {

            get
            {

                return mySafety;

            }

        }

    }

}
