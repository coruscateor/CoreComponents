using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading
{

    /// <summary>
    /// Indicates that the decorated method, property class or struct is thread safe.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Class | AttributeTargets.Struct)]
    public sealed class ThreadSafe : Attribute
    {
    }

}
