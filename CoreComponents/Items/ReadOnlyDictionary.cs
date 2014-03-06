using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;
using System.Runtime.Serialization;

namespace CoreComponents.Items
{
    public class ReadOnlyDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
    {

        protected Dictionary<TKey, TValue> myDictionary;

        public ReadOnlyDictionary(Dictionary<TKey, TValue> TheDictionary)
        {


            myDictionary = TheDictionary;

        }

        public IEqualityComparer<TKey> Comparer 
        {
            get
            {

                return myDictionary.Comparer;

            }
        }

        public int Count 
        {
            get
            {

                return myDictionary.Count;

            } 
        }

        public Dictionary<TKey, TValue>.KeyCollection Keys 
        {
            get
            {

                return myDictionary.Keys;

            }
        }

        public Dictionary<TKey, TValue>.ValueCollection Values 
        {
            get
            {

                return myDictionary.Values;

            }
        }

        public TValue this[TKey key] 
        { 
            get
            {

                return myDictionary[key];

            }
        }


        public bool ContainsKey(TKey key)
        {

            return myDictionary.ContainsKey(key);

        }

        public bool ContainsValue(TValue value)
        {

            return myDictionary.ContainsValue(value);

        }

        public Dictionary<TKey, TValue>.Enumerator GetEnumerator()
        {

            return myDictionary.GetEnumerator();

        }

        [SecurityCritical]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {

            myDictionary.GetObjectData(info, context);

        }

        public bool TryGetValue(TKey key, out TValue value)
        {

            return myDictionary.TryGetValue(key, out value);

        }


        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
        {

            return myDictionary.GetEnumerator();

        }

        IEnumerator IEnumerable.GetEnumerator()
        {

            return myDictionary.GetEnumerator();

        }
    }
}
