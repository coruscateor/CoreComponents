using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Items.Parameters
{
    public abstract class OptionalList<TKey, TValue> : IOptionalList<TKey, TValue>
    {

        public event Gimmie<ChangeEventArgs<ExceptionEventArgs<OptionalList<TKey, TValue>, Exception>, OptionalList<TKey, TValue>>>.GimmieSomethin Error;

        public event Gimmie<KeyValueChangedEventArgs<OptionalList<TKey, TValue>, TKey, TValue>>.GimmieSomethin OptionChanged;

        protected Dictionary<TKey, TValue> myItemList;

        //public OptionalItemList()
        //{

        //    myItemList = new Dictionary<TKey, TValue>();

        //}

        //public OptionalItemList()
        //{

        //    myItemList = new Dictionary<TKey, TValue>();

        //}

        protected void OnError(ExceptionEventArgs<OptionalList<TKey, TValue>, Exception> error)  //(string ErrorMessage, Exception e)
        {

            if (Error != null)
                Error(new ChangeEventArgs<ExceptionEventArgs<OptionalList<TKey, TValue>, Exception>, OptionalList<TKey,TValue>>(this, error));

        }

        protected void OnOptionChanged(TKey Key, TValue Value)
        {

            if(OptionChanged != null)
                OptionChanged(new KeyValueChangedEventArgs<OptionalList<TKey, TValue>, TKey, TValue>(this, Key, Value));

        }

        public int Count
        {
            get
            {

                return myItemList.Count;

            }
        }

        public TValue this[TKey key]
        {
            get
            {

                //try
                //{

                return myItemList[key];

                //}

            }
            set
            {

                myItemList[key] = value;

                OnOptionChanged(key, value);

            }
        }

        
        public IList<TKey> Keys
        {

            get
            {

                return new List<TKey>(myItemList.Keys);

            }

        }

        public IList<TValue> Values
        {
            get
            {

                return new List<TValue>(myItemList.Values);

            }
        }

        public bool ContainsKey(TKey key)
        {

            return myItemList.ContainsKey(key);

        }

        public bool ContainsValue(TValue value)
        {

            return myItemList.ContainsValue(value);

        }

        #region IEnumerable<KeyValuePair<TKey, TValue>> Members

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return myItemList.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return myItemList.GetEnumerator();
        }

        #endregion
    }
}
