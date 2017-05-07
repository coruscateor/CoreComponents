using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading
{

    public sealed class TaskFuncParameters<T, TResult> : BaseTaskFuncParameters<T, TResult>, IReset
    {
    }

    public sealed class TaskFuncParameters<T1, T2, TResult> : BaseTaskFuncParameters<T1, T2, TResult>, IReset
    {
    }

    public sealed class TaskFuncParameters<T1, T2, T3, TResult> : BaseTaskFuncParameters<T1, T2, T3, TResult>, IReset
    {
    }

    public sealed class TaskFuncParameters<T1, T2, T3, T4, TResult> : BaseTaskFuncParameters<T1, T2, T3, T4, TResult>, IReset
    {
    }

}
