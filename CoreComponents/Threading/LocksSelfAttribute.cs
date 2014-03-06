using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    /// <summary>
    /// Indicates that the decorated reference oject, method or property locks itself or locks the class it it part of.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property)]
    public class LocksSelfAttribute : Attribute
    {

        public LocksSelfAttribute()
        {
        }

    }

}
