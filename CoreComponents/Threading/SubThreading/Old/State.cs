using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading.SubThreading
{

    public class State<TKey, TValue> : IState<TKey, TValue>
    {

        protected ConcurrentDictionary<TKey, TValue> myDictionary;

        public State()
        {

            myDictionary = new ConcurrentDictionary<TKey, TValue>();

        }

        public State(ConcurrentDictionary<TKey, TValue> TheDictionary)
        {

            myDictionary = TheDictionary;

        }

        public void Clear()
        {

            myDictionary.Clear();

        }

        public bool ContainsKey(TKey key)
        {

            return myDictionary.ContainsKey(key);

        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {

            return myDictionary.GetEnumerator();

        }

        public bool TryAdd(TKey key, TValue value)
        {

            return myDictionary.TryAdd(key, value);

        }


        public bool TryRemove(TKey key)
        {

            TValue TheObject;
            
            return myDictionary.TryRemove(key, out TheObject);

        }

        public bool TryRemove(TKey key, out TValue value)
        {
            
            return myDictionary.TryRemove(key, out value);

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {

            return myDictionary.GetEnumerator();

        }

    }

}
