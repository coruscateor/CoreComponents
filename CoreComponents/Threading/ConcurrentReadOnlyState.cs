using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    //Exposes a restricted set of ConcurrentDictionary funtionaity.
    [Serializable]
    public class ConcurrentReadOnlyState<TKey, TValue> : IReadOnlyState<TKey, TValue>
    {

        protected ConcurrentDictionary<TKey, TValue> myDictionary;

        public ConcurrentReadOnlyState(ConcurrentDictionary<TKey, TValue> TheDictionary) 
        {

            myDictionary = TheDictionary;
            
        }

        public bool ContainsKey(TKey TheKey) 
        {

            return myDictionary.ContainsKey(TheKey);

        }

        public KeyValuePair<TKey, TValue>[] ToArray() 
        {

            return myDictionary.ToArray();
            
        }

        public bool TryGetValue(TKey TheKey, out TValue TheValue) 
        {

            return myDictionary.TryGetValue(TheKey, out TheValue);
            
        }

        public bool IsEmpty
        {

            get 
            {

                return myDictionary.IsEmpty;

            }

        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {

            return myDictionary.GetEnumerator();

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {

            return myDictionary.GetEnumerator();

        }

        public int Count
        {

            get 
            {

                return myDictionary.Count;

            }

        }
        
        public ICollection<TKey> Keys
        {

            get 
            {
                
                return myDictionary.Keys;
            
            }

        }

        public ICollection<TValue> Values
        {

            get
            {

                return myDictionary.Values;

            }

        }

        public virtual TValue this[TKey key]
        {

            get
            {

                return myDictionary[key];

            }

        }

    }

}
