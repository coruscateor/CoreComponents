using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents;

namespace CoreComponents
{
    public class KeyValueChangedEventArgs<S, TKey, TValue> : SenderEventArgs<S>
    {

        TKey myKey;

        TValue myValue;

        //S mySender;

        public KeyValueChangedEventArgs(S Sender, TKey Key, TValue Value) : base(Sender)
        {

            //mySender = Sender;

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

        //public override S Sender
        //{

        //    get
        //    {

        //        return mySender;

        //    }

        //}

        public KeyValuePair<TKey, TValue> GetAsPair()
        {

            return new KeyValuePair<TKey, TValue>(myKey, myValue);

        }

    }
}
