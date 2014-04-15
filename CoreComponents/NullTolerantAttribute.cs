using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents
{

    /// <summary>
    /// Indicates that a class, method, property, struct etc should be able to take one or many null values without there being an exception thrown as a result.
    /// </summary>
    public class NullTolerantAttribute : Attribute
    {

        public NullTolerantAttribute()
        {
        }

    }

}
