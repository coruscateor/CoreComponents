using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading
{

    public sealed class TemporalReferenceDictionary<TKey, TValue> : BaseTemporalReference<TValue>, IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
        where TValue : class
    {

        Dictionary<TKey, CollectionItem<TValue>> myDictionary = new Dictionary<TKey, CollectionItem<TValue>>();

        public TemporalReferenceDictionary()
            : base(false)
        {
        }

        protected override void CheckAndDeReference(object TheState, bool TimedOut)
        {

            if(!TimedOut)
                return;

            lock(myLockObject)
            {

                if(myDictionary.Count > 0)
                {

                    List<TKey> ItemsToRemove = new List<TKey>();

                    foreach(var Item in myDictionary)
                    {

                        var ItemValue = Item.Value;

                        long Result = ItemValue.Time - myTimeOutInterval;

                        if(Result <= 0L)
                            ItemsToRemove.Add(Item.Key);
                        else
                            ItemValue.Time = Result;

                    }

                    if(IsIDisposable)
                    {

                        foreach(var Item in ItemsToRemove)
                        {

                            var CurrentKVP = myDictionary[Item];

                            myDictionary.Remove(Item);

                            Dispose(CurrentKVP.Value);

                        }

                    }
                    else
                    {

                        foreach(var Item in ItemsToRemove)
                        {

                            myDictionary.Remove(Item);

                        }

                    }

                    if(myDictionary.Count < 1)
                        Unregister();

                }
                else
                {

                    Unregister();

                }

            }

        }

        public void Add(TKey key, TValue value)
        {
            
            lock(myLockObject)
            {

                myDictionary.Add(key, new CollectionItem<TValue>(value, myDefaultTime));

                SetupIfInActive();

            }

        }

        public void Add(TKey key, TValue value, long TheTime)
        {

            lock(myLockObject)
            {

                myDictionary.Add(key, new CollectionItem<TValue>(value, TheTime));

                SetupIfInActive();

            }

        }

        public bool ContainsKey(TKey key)
        {
            
            lock(myLockObject)
            {

                return myDictionary.ContainsKey(key);

            }

        }

        public ICollection<TKey> Keys
        {

            get
            {

                lock(myLockObject)
                {

                    return new List<TKey>(myDictionary.Keys);

                }

            }

        }

        public bool TryGetValue(TKey key, out TValue value)
        {

            bool Result;

            CollectionItem<TValue> CurrentItem;

            lock(myLockObject)
            {

                Result = myDictionary.TryGetValue(key, out CurrentItem);

            }

            value = CurrentItem.Value;

            return Result;

        }

        public ICollection<TValue> Values
        {

            get
            {

                lock(myLockObject)
                {

                    List<TValue> NewList = new List<TValue>(myDictionary.Count);

                    foreach(var Item in myDictionary)
                    {

                        NewList.Add(Item.Value.Value);

                    }

                    return NewList;

                }
                
            }

        }

        public TValue this[TKey key]
        {

            get
            {

                lock(myLockObject)
                {

                    return myDictionary[key].Value;

                }

            }
            set
            {

                lock(myLockObject)
                {

                    if(IsIDisposable)
                    {

                        var CurrentItem = myDictionary[key];

                        Dispose(CurrentItem.Value);

                    }

                    myDictionary[key] = new CollectionItem<TValue>(value, myDefaultTime); //(long)Environment.TickCount,

                }

            }

        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            
            lock(myLockObject)
            {

                myDictionary.Add(item.Key, new CollectionItem<TValue>(item.Value, myDefaultTime));

            }

        }

        public void Clear()
        {

            lock(myLockObject)
            {

                Unregister();

                if(IsIDisposable)
                {

                    foreach(var Item in myDictionary)
                    {

                        Dispose(Item.Value.Value);

                    }

                    myDictionary.Clear();

                }
                else
                    myDictionary.Clear();

            }

        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {

            lock(myLockObject)
            {

                foreach(var Item in myDictionary)
                {

                    if(object.Equals(Item.Key, item.Key) && object.Equals(Item.Value.Value, item.Value))
                        return true;

                }

            }

            return false;

        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {

            throw new NotImplementedException();

        }

        public int Count
        {

            get
            {

                lock(myLockObject)
                {

                    return myDictionary.Count;

                }

            }

        }

        public bool IsReadOnly
        {

            get
            {
                
                return false;
            
            }

        }

        public bool Remove(TKey ItemKey)
        {

            lock(myLockObject)
            {

                return myDictionary.Remove(ItemKey);

            }

        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {

            TKey CurrentItem = default(TKey);

            bool FoundItem = false;

            lock(myLockObject)
            {

                foreach(var Item in myDictionary)
                {

                    if(object.Equals(Item.Key, item.Key) && object.Equals(Item.Value.Value, item.Value))
                    {

                        CurrentItem = Item.Key;

                        FoundItem = true;

                        break;

                    }

                }

                if(FoundItem)
                {

                    myDictionary.Remove(CurrentItem);

                    return true;

                }

            }

            return false;

        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {

            lock(myLockObject)
            {

                foreach(var Item in myDictionary)
                {

                    yield return new KeyValuePair<TKey, TValue>(Item.Key, Item.Value.Value);

                }

            }

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            
            return GetEnumerator();

        }

    }

}
