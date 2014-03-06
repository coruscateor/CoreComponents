using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents
{
    public class IDictionaryEventArgs<TSender, TKey, TValue> : SenderEventArgs<TSender>
    {

        protected IDictionary<TKey, TValue> myKeyValueSet;

        public IDictionaryEventArgs(TSender TheSender, IDictionary<TKey, TValue> TheKeyValueSet)
            : base(TheSender) 
        {

            myKeyValueSet = TheKeyValueSet;

        }
        //KeyValueEventArgs.cs
        public IDictionary<TKey, TValue> KeyValueSet 
        {

            get 
            {

                return myKeyValueSet;

            }

        }

    }
}
