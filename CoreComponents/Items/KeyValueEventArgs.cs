using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Items
{
    public class KeyValueEventArgs<TSender, TKey, TValue> : SenderEventArgs<TSender>
    {

        protected TKey myKey;
        protected TValue myValue;

        public KeyValueEventArgs(TSender Sender, TKey Key, TValue Value) : base(Sender)
        {

            myKey = Key;
            myValue = Value;

        }

        public TKey Key
        {

            get
            {

                return myKey;

            }

        }

        public TValue Value
        {

            get
            {

                return myValue;

            }

        }

    }
}
