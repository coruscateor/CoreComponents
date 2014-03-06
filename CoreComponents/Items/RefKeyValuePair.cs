using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Items
{
    public class RefKeyValuePair<TKey, TValue>
    {

        protected TKey myKey;
        protected TValue myValue;

        public RefKeyValuePair(TKey Key, TValue Value)
        {

            myKey = Key;
            myValue = Value;

        }

        public virtual TKey Key
        {

            get
            {

                return myKey;

            }


        }

        public virtual TValue Value
        {

            get
            {

                return myValue;

            }

        }

    }

    public class RefMalleableKeyValuePair<TKey, TValue>
    {

        //public Gimmie<ChangeEventArgs<TKey, RefMalleableKeyValuePair<TKey, TValue>>>.GimmieSomethin KeyChanging;

        public Action<SenderEventArgs<RefMalleableKeyValuePair<TKey, TValue>>> KeyChanged;

        public Action<ChangeEventArgs<TKey, RefMalleableKeyValuePair<TKey, TValue>>> ValueChanging;

        public Action<SenderEventArgs<RefMalleableKeyValuePair<TKey, TValue>>> ValueChanged;

        TKey myKey;

        TValue myValue;

        public RefMalleableKeyValuePair(TKey Key, TValue Value)
        {

            myKey = Key;
            myValue = Value;

        }

        /*
        protected void OnKeyChanging(TKey theItem)
        {

            if(KeyChanging != null)
                KeyChanging(new ChangeEventArgs<TKey, RefMalleableKeyValuePair<TKey,TValue>>(this, theItem));

        }
        */

        protected void OnKeyChanging()
        {
            /*
            if (KeyChanging != null)
                KeyChanging(new SenderEventArgs<SenderEventArgs<RefMalleableKeyValuePair<TKey,TValue>>>(this));
            */
        }

        /*
        protected void OnKeyChanging(TKey theItem)
        {

            if (KeyChanging != null)
                KeyChanging(new ChangeEventArgs<TKey, RefMalleableKeyValuePair<TKey, TValue>>(this, theItem));

        }
        */

        protected void OnKeyChanged()
        {
            /*
            if (KeyChanged != null)
                KeyChanged(new SenderEventArgs<SenderEventArgs<RefMalleableKeyValuePair<TKey, TValue>>>(this));
            */
        }

        public virtual TKey Key
        {

            get
            {

                return myKey;

            }
            set
            {

                //KeyChanging(new ChangeEventArgs<TKey,RefMalleableKeyValuePair<TKey,TValue>>(this, value));

                myKey = value;

                KeyChanged(new SenderEventArgs<RefMalleableKeyValuePair<TKey,TValue>>(this));

            }

        }

        public virtual TValue Value
        {

            get
            {

                return myValue;

            }
            set
            {
                //RefMalleableKeyValuePair<TKey,TValue>
                //ValueChanging(new ChangeEventArgs<TKey, TValue>(this, new RefMalleableKeyValuePair<TKey,TValue>(this, value)));

                myValue = value;

                ValueChanged(new SenderEventArgs<RefMalleableKeyValuePair<TKey,TValue>>(this));

            }

        }

    }

}
