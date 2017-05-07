using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Items
{

    public sealed class ImmutableKeyValuePair<TKey, TValue> : IReadonlyKeyValuePair<TKey, TValue>
    {

        readonly TKey myKey;

        readonly TValue myValue;

        public ImmutableKeyValuePair()
        {

            myKey = default(TKey);

            myValue = default(TValue);

        }

        public ImmutableKeyValuePair(KeyValuePair<TKey, TValue> kvp)
        {

            myKey = kvp.Key;

            myValue = kvp.Value;

        }

        public ImmutableKeyValuePair(IReadonlyKeyValuePair<TKey, TValue> kvp)
        {

            myKey = kvp.Key;

            myValue = kvp.Value;

        }

        public ImmutableKeyValuePair(TKey key, TValue value)
        {

            myKey = key;

            myValue = value;

        }

        public TKey Key
        {

            get
            {

                return myKey;

            }

        }

        public TValue Value
        {

            get
            {

                return myValue;

            }

        }

        public System.Collections.Generic.KeyValuePair<TKey, TValue> ToKVP()
        {

            return new System.Collections.Generic.KeyValuePair<TKey, TValue>(myKey, myValue);

        }

    }

}
