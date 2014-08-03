using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading
{
    
    /// <summary>
    /// Indicates that no syncronisation is involved with whatever this attribute is applied to.  
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Field | AttributeTargets.Property)]
    public class InAccurateAttribute : Attribute
    {

        public InAccurateAttribute()
        {
        }

    }

}
