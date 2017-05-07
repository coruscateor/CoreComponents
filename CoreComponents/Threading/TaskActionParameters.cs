using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading
{

    public sealed class TaskActionParameters<T> : BaseTaskActionParameters<T>, IReset
    {
    }

    public sealed class TaskActionParameters<T1, T2> : BaseTaskActionParameters<T1, T2>, IReset
    {
    }

    public sealed class TaskActionParameters<T1, T2, T3> : BaseTaskActionParameters<T1, T2, T3>, IReset
    {
    }

    public sealed class TaskActionParameters<T1, T2, T3, T4> : BaseTaskActionParameters<T1, T2, T3, T4>, IReset
    {
    }

}
