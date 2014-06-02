using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public interface IWaitableValueContainer<T> : IValueContainer<T>, IWaitable
    {
    }

}
