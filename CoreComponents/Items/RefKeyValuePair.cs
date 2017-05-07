using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Items
{

    public class RefKeyValuePair<TKey, TValue> : IKeyValuePair<TKey, TValue>, IReadonlyKeyValuePair<TKey, TValue>
    {

        TKey myKey;

        TValue myValue;

        public RefKeyValuePair()
        {

            myKey = default(TKey);

            myValue = default(TValue);

        }

        public RefKeyValuePair(KeyValuePair<TKey, TValue> kvp)
        {

            myKey = kvp.Key;

            myValue = kvp.Value;

        }

        public RefKeyValuePair(IReadonlyKeyValuePair<TKey, TValue> kvp)
        {

            myKey = kvp.Key;

            myValue = kvp.Value;

        }

        public RefKeyValuePair(TKey key, TValue value)
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
            set
            {

                myKey = value;

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

        public KeyValuePair<TKey, TValue> ToKVP()
        {

            return new KeyValuePair<TKey, TValue>(myKey, myValue);

        }

    }

}
