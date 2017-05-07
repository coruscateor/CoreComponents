using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public sealed class ByRef<T> : BaseByRef<T>, IReset
    {

        public ByRef()
        {
        }

        public ByRef(T @ref) : base(@ref)
        {
        }

    }

}
