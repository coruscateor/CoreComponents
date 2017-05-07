using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Items
{

    public sealed class ImmutableDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IToDictionary<TKey, TValue>
    {

        readonly TKey[] myKeys;

        readonly TValue[] myValues;

        readonly int myCount;

        readonly IEqualityComparer<TKey> myKeyComparer;

        readonly IEqualityComparer<TValue> myValueComparer;

        public ImmutableDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> keyComparer = null, IEqualityComparer<TValue> valueComparer = null)
        {

            int count = dictionary.Count;

            TKey[] keys = new TKey[count];

            TValue[] values = new TValue[count];

            if(count > 0)
            {

                int i = 0;

                foreach(var item in dictionary)
                {

                    keys[i] = item.Key;

                    values[i] = item.Value;

                }

            }

            if(keyComparer != null)
                myKeyComparer = keyComparer;
            else
                myKeyComparer = EqualityComparer<TKey>.Default;

            if(valueComparer != null)
                myValueComparer = valueComparer;
            else
                myValueComparer = EqualityComparer<TValue>.Default;

            myCount = keys.Length;

            myKeys = keys;

            myValues = values;
            
        }

        public ImmutableDictionary(IEnumerable<KeyValuePair<TKey, TValue>> items, IEqualityComparer<TKey> keyComparer = null, IEqualityComparer<TValue> valueComparer = null)
        {

            int count = items.Count();

            TKey[] keys = new TKey[count];

            TValue[] values = new TValue[count];

            if(count > 0)
            {

                int i = 0;

                foreach(var item in items)
                {

                    keys[i] = item.Key;

                    values[i] = item.Value;

                }

            }

            if(keyComparer != null)
                myKeyComparer = keyComparer;
            else
                myKeyComparer = EqualityComparer<TKey>.Default;

            if(valueComparer != null)
                myValueComparer = valueComparer;
            else
                myValueComparer = EqualityComparer<TValue>.Default;

            myCount = keys.Length;

            myKeys = keys;

            myValues = values;

        }

        public TValue this[TKey key]
        {

            get
            {

                int index = -1;

                for(int i = 0; i < myCount; i++)
                {

                    if(object.Equals(key, myKeys[i]))
                    {

                        index = i;

                    }

                }

                if(index < 0)
                    throw new Exception();

                return myValues[index];

            }
            set
            {

                throw new NotSupportedException();

            }

        }

        public int Count
        {

            get
            {

                return myCount;

            }

        }

        public bool IsReadOnly
        {

            get
            {

                return true;

            }

        }

        public ICollection<TKey> Keys
        {

            get
            {

                return new SList<TKey>(myKeys);

            }

        }

        public ICollection<TValue> Values
        {

            get
            {

                return new SList<TValue>(myValues);

            }

        }

        [NotSupported]
        public void Add(KeyValuePair<TKey, TValue> item)
        {

            throw new NotSupportedException();

        }

        [NotSupported]
        public void Add(TKey key, TValue value)
        {

            throw new NotSupportedException();

        }

        [NotSupported]
        public void Clear()
        {

            throw new NotSupportedException();

        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {

            TKey key = item.Key;

            for(int i = 0; i < myCount; i++)
            {

                if(myKeyComparer.Equals(key, myKeys[i]))
                {

                    if(myValueComparer.Equals(myValues[i], item.Value))
                        return true;
                    else
                        return false;

                }

            }

            return false;

        }

        public bool ContainsKey(TKey key)
        {

            for(int i = 0; i < myCount; i++)
            {

                if(object.Equals(key, myKeys[i]))
                    return true;

            }

            return false;

        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {

            throw new NotImplementedException();

        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {

            int index = 0;

            int maxIndex = myCount - 1;

            while(index < maxIndex)
            {

                yield return new KeyValuePair<TKey, TValue>(myKeys[index], myValues[index]);

                index++;

            }

        }

        [NotSupported]
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {

            throw new NotSupportedException();

        }

        [NotSupported]
        public bool Remove(TKey key)
        {

            throw new NotSupportedException();

        }

        public bool TryGetValue(TKey key, out TValue value)
        {

            int index = -1;

            for(int i = 0; i < myCount; i++)
            {

                if(myKeyComparer.Equals(key, myKeys[i]))
                {

                    index = i;

                }

            }

            if(index < 0)
            {

                value = default(TValue);

                return false;

            }

            value = myValues[index];

            return true;

        }

        IEnumerator IEnumerable.GetEnumerator()
        {

            return GetEnumerator();

        }

        public IDictionary<TKey, TValue> ToDictionary()
        {

            return new SDictionary<TKey, TValue>(this);

        }

        public SDictionary<TKey, TValue> ToSDictionary()
        {

            return new SDictionary<TKey, TValue>(this);

        }

    }

}
