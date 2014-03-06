using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    public interface IReadOnlyState<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {

        bool ContainsKey(TKey TheKey);

        bool TryGetValue(TKey TheKey, out TValue TheValue);

        bool IsEmpty
        {

            get;

        }

        int Count
        {

            get;

        }
        
        ICollection<TKey> Keys 
        {
            
            get;
        
        }

        ICollection<TValue> Values 
        {
            
            get;
        
        }

        TValue this[TKey key]
        {

            get;

        }

    }

}
