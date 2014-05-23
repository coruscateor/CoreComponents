using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    public class MonitorState<TKey, TValue> : MonitorReadOnlyState<TKey, TValue>, IState<TKey, TValue>
    {

        //protected object myLockObject;

        //protected Dictionary<TKey, TValue> myDictionary;

        public MonitorState() : base(new Dictionary<TKey, TValue>(), new object())
        {

            //myLockObject = new object();

            //myDictionary = new Dictionary<TKey, TValue>();

        }

        public MonitorState(Dictionary<TKey, TValue> TheDictionary, object TheLockObject)
            : base(TheDictionary, TheLockObject)
        {

            //myDictionary = TheDictionary;

            //myLockObject = TheLockObject;

        }

        public void Clear()
        {

            lock (myLockObject)
            {

                myDictionary.Clear();

            }

        }

        //public bool ContainsKey(TKey key)
        //{

        //    lock(myLockObject)
        //    {

        //        return myDictionary.ContainsKey(key);

        //    }

        //}

        //public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        //{

        //    return myDictionary.GetEnumerator();

        //}

        public bool TryAdd(TKey key, TValue value)
        {

            lock (myLockObject)
            {

                try
                {

                    myDictionary.Add(key, value);

                    return true;

                }
                catch 
                {

                    return false;

                }

            }

        }

        public bool TryRemove(TKey key)
        {

            lock (myLockObject)
            {

                return myDictionary.Remove(key);

            }

        }

        public bool TryRemove(TKey key, out TValue value)
        {

            lock (myLockObject)
            {

                if (myDictionary.ContainsKey(key))
                {

                    value = myDictionary[key];

                    return myDictionary.Remove(key);

                }
                else
                {

                    value = default(TValue);

                }

                return false;

            }

        }


        public new TValue this[TKey key]
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

        //System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        //{
        //    throw new NotImplementedException();
        //}

        //public bool TryGetValue(TKey TheKey, out TValue TheValue)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool IsEmpty
        //{
        //    get { throw new NotImplementedException(); }
        //}

        //public int Count
        //{
        //    get { throw new NotImplementedException(); }
        //}

        //public ICollection<TKey> Keys
        //{
        //    get { throw new NotImplementedException(); }
        //}

        //public ICollection<TValue> Values
        //{
        //    get { throw new NotImplementedException(); }
        //}

        //public TValue this[TKey key]
        //{
        //    get { throw new NotImplementedException(); }
        //}

    }

}
