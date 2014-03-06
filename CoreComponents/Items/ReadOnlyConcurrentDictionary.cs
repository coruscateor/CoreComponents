using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;

namespace CoreComponents.Items
{
    public class ReadOnlyConcurrentDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
    {

        ConcurrentDictionary<TKey, TValue> myConcurrentDictionary;

        public ReadOnlyConcurrentDictionary(ConcurrentDictionary<TKey, TValue> TheConcurrentDictionary) 
        {

            myConcurrentDictionary = TheConcurrentDictionary;

        }

        public bool TryGetValue(TKey key, out TValue value) 
        {

            return myConcurrentDictionary.TryGetValue(key, out value);

        }

        public int Count 
        {

            get 
            {

                return myConcurrentDictionary.Count;

            }

        }

        public bool IsEmpty 
        {

            get 
            {

                return myConcurrentDictionary.IsEmpty;

            }

        }

        public ICollection<TKey> Keys 
        {

            get 
            {

                return myConcurrentDictionary.Keys;

            }

        }

        public ICollection<TValue> Values 
        {

            get 
            {

                return myConcurrentDictionary.Values;

            }

        }

        public TValue this[TKey key] 
        {

            get 
            {

                return myConcurrentDictionary[key];

            }

        }

        public bool ContainsKey(TKey key) 
        {

            return myConcurrentDictionary.ContainsKey(key);

        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() 
        {

            return myConcurrentDictionary.GetEnumerator();

        }

        public KeyValuePair<TKey, TValue>[] ToArray() 
        {

            return myConcurrentDictionary.ToArray();

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return myConcurrentDictionary.GetEnumerator();
        }
    }
}
