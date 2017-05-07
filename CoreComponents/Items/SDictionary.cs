using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Items
{

    public sealed class SDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IDictionary<TKey, TValue>, IHasCount
    {

        public SDictionary()
            : base()
        {
        }

        public SDictionary(IDictionary<TKey, TValue> dictionary)
            : base(dictionary)
        {
        }

        public SDictionary(IEqualityComparer<TKey> comparer)
            : base(comparer)
        {
        }

        public SDictionary(int capacity)
            : base(capacity)
        {
        }

        public SDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
            : base(dictionary, comparer)
        {
        }

        public SDictionary(int capacity, IEqualityComparer<TKey> comparer)
            : base(capacity, comparer)
        {
        }

        public void Set(TKey key, TValue value)
        {

            if(ContainsKey(key))
                this[key] = value;
            else
                Add(key, value);

        }

        public ImmutableDictionary<TKey, TValue> ToReadonly()
        {

            return new ImmutableDictionary<TKey, TValue>(this);

        }

    }

}
