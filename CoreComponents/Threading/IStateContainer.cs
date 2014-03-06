using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    public interface IStateContainer<TKey, TValue>
    {

        int Count
        {
            
            get;
        
        }
        
        bool IsEmpty
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
            set;
        
        }

        //TValue AddOrUpdate(TKey key, Func<TKey, TValue> addValueFactory, Func<TKey, TValue, TValue> updateValueFactory);

        //TValue AddOrUpdate(TKey key, TValue addValue, Func<TKey, TValue, TValue> updateValueFactory);
        
        void Clear();
        
        bool ContainsKey(TKey key);

        IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator();

        //TValue GetOrAdd(TKey key, Func<TKey, TValue> valueFactory);

        //TValue GetOrAdd(TKey key, TValue value);

        //KeyValuePair<TKey, TValue>[] ToArray();

        bool TryAdd(TKey key, TValue value);

        bool TryGetValue(TKey key, out TValue value);

        bool TryRemove(TKey key, out TValue value);

        bool TryUpdate(TKey key, TValue newValue, TValue comparisonValue);

    }

}
