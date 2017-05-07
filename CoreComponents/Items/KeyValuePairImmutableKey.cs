using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Items
{

    public class KeyValuePairImmutableKey<TKey, TValue> : IReadonlyKeyValuePair<TKey, TValue>
    {

        readonly TKey myKey;

        TValue myValue;

        public KeyValuePairImmutableKey()
        {

            myKey = default(TKey);

            myValue = default(TValue);

        }

        public KeyValuePairImmutableKey(System.Collections.Generic.KeyValuePair<TKey, TValue> kvp)
        {

            myKey = kvp.Key;

            myValue = kvp.Value;

        }

        public KeyValuePairImmutableKey(TKey key, TValue value)
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
            set
            {

                myValue = value;

            }

        }

        public System.Collections.Generic.KeyValuePair<TKey, TValue> ToKVP()
        {

            return new System.Collections.Generic.KeyValuePair<TKey, TValue>(myKey, myValue);

        }

    }

}
