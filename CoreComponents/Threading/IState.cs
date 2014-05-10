using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    public interface IState<TKey, TValue> : IReadOnlyState<TKey, TValue>, IEnumerable<KeyValuePair<TKey, TValue>>
    {

        void Clear();
        
        //TValue GetOrAdd(TKey key, Func<TKey, TValue> valueFactory);
        
        //TValue GetOrAdd(TKey key, TValue value);
        
        //KeyValuePair<TKey, TValue>[] ToArray();
        
        bool TryAdd(TKey key, TValue value);
        
        //bool TryGetValue(TKey key, out TValue value);

        bool TryRemove(TKey key);

        bool TryRemove(TKey key, out TValue value);

       //bool TryUpdate(TKey key, TValue newValue, TValue comparisonValue);

    }

}
