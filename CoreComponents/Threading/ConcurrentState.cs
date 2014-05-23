using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    public class ConcurrentState<TKey, TValue> : ConcurrentReadOnlyState<TKey, TValue>, IState<TKey, TValue>
    {

        //ConcurrentDictionary<TKey, TValue> myDictionary;

        public ConcurrentState()
            : base(new ConcurrentDictionary<TKey, TValue>())
        {

            //myDictionary = TheDictionary;

        }

        public ConcurrentState(ConcurrentDictionary<TKey, TValue> TheDictionary)
            : base(TheDictionary)
        {

            //myDictionary = TheDictionary;

        }

        public void Clear()
        {

            myDictionary.Clear();

        }

        //public bool ContainsKey(TKey key)
        //{

        //    return myDictionary.ContainsKey(key);

        //}

        //public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        //{

        //    return myDictionary.GetEnumerator();

        //}

        public bool TryAdd(TKey key, TValue value)
        {

            return myDictionary.TryAdd(key, value);

        }

        public bool TryRemove(TKey key)
        {

            TValue Item;

            return myDictionary.TryRemove(key, out Item);
            
        }

        public bool TryRemove(TKey key, out TValue value)
        {

            return myDictionary.TryRemove(key, out value);

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {

            return myDictionary.GetEnumerator();

        }
        
        //public bool TryGetValue(TKey TheKey, out TValue TheValue)
        //{

        //    return myDictionary.TryGetValue(TheKey, out TheValue);

        //}

        //public bool IsEmpty
        //{

        //    get
        //    {

        //        return myDictionary.IsEmpty;

        //    }

        //}

        //public int Count
        //{

        //    get
        //    {

        //        return myDictionary.Count;

        //    }

        //}

        public new TValue this[TKey key]
        {

            get
            {


                return myDictionary[key];

            }
            set
            {

                myDictionary[key] = value;

            }

        }

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
