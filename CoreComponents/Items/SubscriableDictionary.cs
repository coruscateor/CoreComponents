using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Items
{

    public interface ISubscriableDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {

        event Action<KeyValueEventArgs<ISubscriableDictionary<TKey, TValue>, TKey, TValue>> Added;

        event Action<KeyValueEventArgs<ISubscriableDictionary<TKey, TValue>, TKey, TValue>> Adding;

        event Action<KeyValueEventArgs<ISubscriableDictionary<TKey, TValue>, TKey, TValue>> Removed;

        event Action<KeyValueEventArgs<ISubscriableDictionary<TKey, TValue>, TKey, TValue>>Removing;

        event Action<SenderEventArgs<ISubscriableDictionary<TKey, TValue>>> Clearing;

        event  Action<SenderEventArgs<ISubscriableDictionary<TKey, TValue>>> Cleared;

        void Add(TKey key, TValue value);

        void Remove(TKey key);

        void Clear();

        int Count
        {

            get;

        }


    }

    public class SubscriableDictionary<TKey, TValue>: ISubscriableDictionary<TKey, TValue>
    {

        public event Action<KeyValueEventArgs<ISubscriableDictionary<TKey, TValue>, TKey, TValue>> Added;

        public event Action<KeyValueEventArgs<ISubscriableDictionary<TKey, TValue>, TKey, TValue>> Adding;

        public event Action<KeyValueEventArgs<ISubscriableDictionary<TKey, TValue>, TKey, TValue>> Removed;

        public event Action<KeyValueEventArgs<ISubscriableDictionary<TKey, TValue>, TKey, TValue>> Removing;

        public event Action<SenderEventArgs<ISubscriableDictionary<TKey, TValue>>> Clearing;

        public event Action<SenderEventArgs<ISubscriableDictionary<TKey, TValue>>> Cleared;

        protected Dictionary<TKey, TValue> myList;

        public SubscriableDictionary()
        {
            
            initalise();

        }

        protected void initalise()
        {

            myList = new Dictionary<TKey, TValue>();

        }

        protected void OnAdding(TKey KeyItem, TValue ValueItem)
        {


            if (Adding != null)
                Adding(new KeyValueEventArgs<ISubscriableDictionary<TKey, TValue>, TKey, TValue>(this, KeyItem, ValueItem));

        }

        protected void OnAdded(TKey KeyItem, TValue ValueItem)
        {

            if (Added != null)
                Added(new KeyValueEventArgs<ISubscriableDictionary<TKey, TValue>, TKey, TValue>(this, KeyItem, ValueItem));

        }

        protected void OnRemoving(TKey KeyItem, TValue ValueItem)
        {

            if (Removing != null)
                Removing(new KeyValueEventArgs<ISubscriableDictionary<TKey, TValue>, TKey, TValue>(this, KeyItem, ValueItem));

        }

        protected void OnRemoved(TKey KeyItem, TValue ValueItem)
        {

            if (Removed != null)
                Removed(new KeyValueEventArgs<ISubscriableDictionary<TKey, TValue>, TKey, TValue>(this, KeyItem, ValueItem));

        }

        protected void OnClearing()
        {

            if (Clearing != null)
                Clearing(new SenderEventArgs<ISubscriableDictionary<TKey, TValue>>(this));

        }

        protected void OnCleared()
        {

            if (Cleared != null)
                Clearing(new SenderEventArgs<ISubscriableDictionary<TKey, TValue>>(this));

        }


        public virtual void Add(TKey KeyItem, TValue ValueItem)
        {

            if (!myList.ContainsKey(KeyItem))
            {

                OnAdding(KeyItem, ValueItem);

                myList.Add(KeyItem, ValueItem);

                OnAdded(KeyItem, ValueItem);

            } else
            {
            }

        }

        public virtual void Remove(TKey KeyItem)
        {

            if (myList.ContainsKey(KeyItem))
            {

                TValue ValueItem = myList[KeyItem];

                OnRemoving(KeyItem, ValueItem);

                myList.Remove(KeyItem);

                OnRemoved(KeyItem, ValueItem);

            } else
            {
            }
        }

        public virtual void Clear()
        {

            OnClearing();

            OnCleared();

        }


        public int Count
        {

            get
            {

                return myList.Count;

            }

        }

        public bool ContainsKey(TKey KeyItem)
        {

            return myList.ContainsKey(KeyItem);

        }

        public bool ContainsKey(TValue ValueItem)
        {

            return myList.ContainsValue(ValueItem);

        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {

            return myList.GetEnumerator();

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {

            return myList.GetEnumerator();

        }

    }
}
