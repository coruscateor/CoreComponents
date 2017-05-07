using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Items
{

    public sealed class SConcurrentDictionary<TKey, TValue> : ConcurrentDictionary<TKey, TValue>
    {

        public SConcurrentDictionary()
            : base()
        {
        }

        public SConcurrentDictionary(IEqualityComparer<TKey> comparer)
            : base(comparer)
        {
        }

        public SConcurrentDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection)
            : base(collection)
        {
        }

        public SConcurrentDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection, IEqualityComparer<TKey> comparer)
            : base(collection, comparer)
        {
        }

        public SConcurrentDictionary(int concurrencyLevel, int capacity)
            : base(concurrencyLevel, capacity)
        {
        }

        public SConcurrentDictionary(int concurrencyLevel, int capacity, IEqualityComparer<TKey> comparer)
            : base(concurrencyLevel, capacity, comparer)
        {
        }

        public SConcurrentDictionary(int concurrencyLevel, IEnumerable<KeyValuePair<TKey, TValue>> collection, IEqualityComparer<TKey> comparer)
            : base(concurrencyLevel, collection, comparer)
        {
        }

        public bool TryRemove(TKey key)
        {

            TValue value;

            return TryRemove(key, out value);

        }

        public bool TrySet(TKey key, TValue value)
        {

            if(ContainsKey(key))
            {

                try
                {

                    this[key] = value;

                    return true;

                }
                catch(KeyNotFoundException)
                {

                    return TryAdd(key, value);

                }

            }
            else
                return TryAdd(key, value);

        }

        public void Set(TKey key, TValue value)
        {

            while(!TrySet(key, value))
            {
            }

        }

    }

}
