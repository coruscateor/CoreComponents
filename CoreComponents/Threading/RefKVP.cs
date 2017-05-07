using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using CoreComponents.Items;

namespace CoreComponents.Threading
{

    public sealed class RefKVP<TKey, TValue> : BaseRefKVP<TKey, TValue>
    {

        public RefKVP()
        {
        }

        public RefKVP(TKey key, TValue value)
            : base(key, value)
        {
        }

        public void Set(TKey key, TValue value)
        {

            Volatile.Write<ImmutableKeyValuePair<TKey, TValue>>(ref myKVP, new ImmutableKeyValuePair<TKey, TValue>(key, value));

        }

    }

}
