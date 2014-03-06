using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{
    public class KeyValueEventArgs<TSender, TKey, TValue> : SenderEventArgs<TSender>
    {

        protected KeyValuePair<TKey, TValue> myKeyValuePair;

        public KeyValueEventArgs(TSender TheSender, KeyValuePair<TKey, TValue> TheKeyValuePair)
            : base(TheSender)
        {

            myKeyValuePair = TheKeyValuePair;

        }

        public KeyValuePair<TKey, TValue> KeyValuePair 
        {

            get 
            {

                return myKeyValuePair;

            }

        }

    }
}
