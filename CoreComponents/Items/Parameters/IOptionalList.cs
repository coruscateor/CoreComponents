using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Items.Parameters
{
    public interface IOptionalList<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
    {

        int Count
        {
            get;
        }

        TValue this[TKey key]
        {
            get;
            set;
        }


        IList<TKey> Keys
        {
            get;
        }

        IList<TValue> Values
        {
            get;
        }
        bool ContainsKey(TKey key);

        bool ContainsValue(TValue value);

    }
}
