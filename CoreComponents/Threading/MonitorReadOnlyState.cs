using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    public class MonitorReadOnlyState<TKey, TValue> : IReadOnlyState<TKey, TValue>
    {

        protected object myLockObject;

        protected IDictionary<TKey, TValue> myDictionary;

        public MonitorReadOnlyState(IDictionary<TKey, TValue> TheDictionary, object TheLockObject)
        {

            myDictionary = TheDictionary;

            myLockObject = TheLockObject;

        }
        
        public bool ContainsKey(TKey TheKey)
        {

            lock (myLockObject)
            {

                return myDictionary.ContainsKey(TheKey);

            }

        }

        public bool TryGetValue(TKey TheKey, out TValue TheValue)
        {

            lock (myLockObject)
            {

                return myDictionary.TryGetValue(TheKey, out TheValue);

            }

        }

        public bool IsEmpty
        {
            get 
            {

                lock (myLockObject)
                {

                    return myDictionary.Count < 1;

                }

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

                lock (myLockObject)
                {

                    return myDictionary.Keys;

                }
                
            }

        }

        public ICollection<TValue> Values
        {

            get
            {

                lock (myLockObject)
                {

                    return myDictionary.Values;

                }

            }

        }

        public virtual TValue this[TKey key]
        {

            get
            {

                lock (myLockObject)
                {

                    return myDictionary[key];

                }

            }

        }

    }

}
