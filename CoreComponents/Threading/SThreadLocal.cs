using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public sealed class SThreadLocal<T> : ThreadLocal<T>, IDisposable
    {

        public SThreadLocal()
            : base()
        {
        }

        public SThreadLocal(bool trackAllValues)
            : base(trackAllValues)
        {
        }

        public SThreadLocal(Func<T> valueFactory)
            : base(valueFactory)
        {
        }

        public SThreadLocal(Func<T> valueFactory, bool trackAllValues)
            : base(valueFactory, trackAllValues)
        {
        }

        public bool TryGetValue(out T value)
        {

            value = Value;

            return value != null;

        }

    }

}
