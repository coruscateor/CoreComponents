
using System;
using System.Collections;
using System.Collections.Generic;

namespace CoreComponents.Items.Parameters
{
	
	
	public class NoOptionNonList<TKey, TValue> : IOptionalList<TKey, TValue>
	{
		
		public NoOptionNonList()
		{
		}
		
		public int Count
        {
            get
			{
				return 0;
			}
        }

        public TValue this[TKey key]
        {
            get
			{
				return default(TValue);
			}
            set
			{
				
			}
        }


        public IList<TKey> Keys
        {
            get
			{
				return null;	
			}
			
        }

        public IList<TValue> Values
        {
			
            get
			{
				
				return null;
				
			}
			
        }
		
        public bool ContainsKey(TKey key)
		{
			return false;
		}

        public bool ContainsValue(TValue value)
		{
			return false;
		}
		
		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
			
            return (new Dictionary<TKey, TValue>()).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (new Dictionary<TKey, TValue>()).GetEnumerator();
        }
		
	}
}
