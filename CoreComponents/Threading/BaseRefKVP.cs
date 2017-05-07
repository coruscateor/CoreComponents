using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using CoreComponents.Items;

namespace CoreComponents.Threading
{

    public abstract class BaseRefKVP<TKey, TValue>
    {

        protected ImmutableKeyValuePair<TKey, TValue> myKVP;

        public BaseRefKVP()
        {

            myKVP = new ImmutableKeyValuePair<TKey, TValue>();

        }

        public BaseRefKVP(TKey key, TValue value)
        {

            myKVP = new ImmutableKeyValuePair<TKey, TValue>(key, value);

        }

        public ImmutableKeyValuePair<TKey, TValue> KVP
        {

            get
            {

                return Volatile.Read<ImmutableKeyValuePair<TKey, TValue>>(ref myKVP);

            }

        }

        public IsItNull<ImmutableKeyValuePair<TKey, TValue>> IsItNull
        {

            get
            {

                return new IsItNull<ImmutableKeyValuePair<TKey, TValue>>(Volatile.Read<ImmutableKeyValuePair<TKey, TValue>>(ref myKVP));

            }

        }

        public bool Has
        {

            get
            {

                return Volatile.Read<ImmutableKeyValuePair<TKey, TValue>>(ref myKVP) != null;

            }

        }

        public bool TryGet(out ImmutableKeyValuePair<TKey, TValue> kvp)
        {

            kvp = Volatile.Read<ImmutableKeyValuePair<TKey, TValue>>(ref myKVP);

            return kvp != null;

        }

    }

}
