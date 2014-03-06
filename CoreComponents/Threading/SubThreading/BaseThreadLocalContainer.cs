using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading.SubThreading
{

    public abstract class BaseThreadLocal<T>
    {

        protected ThreadLocal<T> myLocal;

    }

}
