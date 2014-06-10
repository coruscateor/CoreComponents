using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents
{
    
    /// <summary>
    /// Indicates that the object or member won't do anything bad i.e. crash the programme.
    /// </summary>
    public class TrustMeAttribute : Attribute
    {

        public TrustMeAttribute()
        {
        }

    }

}
