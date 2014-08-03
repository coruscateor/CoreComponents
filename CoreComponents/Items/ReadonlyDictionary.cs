using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Items
{

    public class ReadonlyDictionary<TKey, TValue> : IReadOnlyDictionary<TKey, TValue>
    {

        protected Dictionary<TKey, TValue> myItems;

        public ReadonlyDictionary()
        {

            myItems = new Dictionary<TKey, TValue>();

        }

        public bool ContainsKey(TKey TheKey)
        {

            return myItems.ContainsKey(TheKey);

        }

        public IEnumerable<TKey> Keys
        {

            get
            {

                return myItems.Keys;

            }

        }

        public bool TryGetValue(TKey TheKey, out TValue TheValue)
        {

            TValue FoundValue;

            if(myItems.TryGetValue(TheKey, out FoundValue))
            {

                TheValue = FoundValue;

                return true;

            }

            TheValue = default(TValue);

            return false;

        }

        public IEnumerable<TValue> Values
        {

            get
            {

                return myItems.Values;

            }

        }

        public TValue this[TKey TheKey]
        {

            get
            {

                return myItems[TheKey];

            }

        }

        public int Count
        {

            get
            {

                return myItems.Count;

            }

        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            
            return myItems.GetEnumerator();

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {

            return myItems.GetEnumerator();

        }

    }

}
