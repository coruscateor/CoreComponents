using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace CoreComponents.Threading
{

    [Serializable]
    public class LockingDictionary<TKey, TValue>
    {
        
        protected object myLockObject = new object();

        protected Dictionary<TKey, TValue> myDictionary;

        public LockingDictionary()
        {

            myDictionary = new Dictionary<TKey,TValue>(); 

        }

        public LockingDictionary(IDictionary<TKey, TValue> dictionary)
        {

            myDictionary = new Dictionary<TKey,TValue>(dictionary);

        }

        public LockingDictionary(IEqualityComparer<TKey> comparer)
        {

            myDictionary = new Dictionary<TKey,TValue>(comparer);

        }

        public LockingDictionary(int capacity)
        {

            myDictionary = new Dictionary<TKey, TValue>(capacity);

        }

        public LockingDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
        {

            myDictionary = new Dictionary<TKey, TValue>(dictionary, comparer);

        }

        public LockingDictionary(int capacity, IEqualityComparer<TKey> comparer)
        {

            myDictionary = new Dictionary<TKey, TValue>(capacity, comparer);

        }

        public IEqualityComparer<TKey> Comparer
        {

            get
            {

                lock (myLockObject)
                {
                    
                    return myDictionary.Comparer;

                }

            }

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

        public TValue this[TKey key]
        {

            get
            {

                lock (myLockObject)
                {

                    return myDictionary[key];

                }

            }
            set
            {

                lock (myLockObject)
                {

                    myDictionary[key] = value;

                }

            }

        }

        public void Add(TKey key, TValue value)
        {

            lock (myLockObject)
            {

                myDictionary.Add(key, value);

            }

        }

        public void Clear()
        {

            lock (myLockObject)
            {

                myDictionary.Clear();

            }

        }

        public bool ContainsKey(TKey key)
        {

            lock (myLockObject)
            {

                return myDictionary.ContainsKey(key);

            }

        }

        public bool ContainsValue(TValue value)
        {

            lock (myLockObject)
            {

                return myDictionary.ContainsValue(value);

            }

        }

        public Dictionary<TKey, TValue>.Enumerator GetEnumerator()
        {

            return myDictionary.GetEnumerator();

        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {

            lock (myLockObject)
            {

                myDictionary.GetObjectData(info, context);

            }

        }

        public virtual void OnDeserialization(object sender)
        {

            lock (myLockObject)
            {

                myDictionary.OnDeserialization(sender);

            }

        }

        public bool Remove(TKey key)
        {

            lock (myLockObject)
            {

                return myDictionary.Remove(key);

            }

        }

        public bool TryGetValue(TKey key, out TValue value)
        {

            lock (myLockObject)
            {

                return myDictionary.TryGetValue(key, out value);

            }

        }

    }

}
