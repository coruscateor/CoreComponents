using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using CoreComponents.Items;

namespace CoreComponents.Threading
{

    public sealed class RefKVPTicks<TValue> : BaseRefKVP<int, TValue>
    {

        public RefKVPTicks()
        {
        }

        public RefKVPTicks(TValue value)
        {

            myKVP = new ImmutableKeyValuePair<int, TValue>(Environment.TickCount, value);

        }

        public void Set(TValue value)
        {

            Volatile.Write<ImmutableKeyValuePair<int, TValue>>(ref myKVP, new ImmutableKeyValuePair<int, TValue>(Environment.TickCount, value));

        }

    }

}
