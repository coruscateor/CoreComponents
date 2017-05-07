using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public sealed class TemporalReferenceList<T> : BaseTemporalReference<T>, IList<T>
        where T : class
    {

        List<CollectionItem<T>> myList;

        public TemporalReferenceList()
            : base(false)
        {

            myLockObject = new object();

            myList = new List<CollectionItem<T>>();

            myDefaultTime = myConstDefaultTime;

            myTimeOutInterval = myConstTimeOutInterval;

        }

        public TemporalReferenceList(int TheCapacity)
            : base(false)
        {

            myLockObject = new object();

            myList = new List<CollectionItem<T>>(TheCapacity);

            myDefaultTime = myConstDefaultTime;

            myTimeOutInterval = myConstTimeOutInterval;

        }

        public TemporalReferenceList(object TheLockObject)
            : base(false)
        {

            myLockObject = TheLockObject;

            myList = new List<CollectionItem<T>>();

            myDefaultTime = myConstDefaultTime;

            myTimeOutInterval = myConstTimeOutInterval;

        }

        public TemporalReferenceList(object TheLockObject, int TheCapacity)
            : base(false)
        {

            myLockObject = TheLockObject;

            myList = new List<CollectionItem<T>>(TheCapacity);

            myDefaultTime = myConstDefaultTime;

            myTimeOutInterval = myConstTimeOutInterval;

        }

        protected override void CheckAndDeReference(object TheState, bool TimedOut)
        {

            if(!TimedOut)
                return;

            lock(myLockObject)
            {

                if(myList.Count > 0)
                {

                    List<CollectionItem<T>> ItemsToRemove = new List<CollectionItem<T>>();

                    foreach(var Item in myList)
                    {

                        long Result = Item.Time - myTimeOutInterval;

                        if(Result <= 0L)
                            ItemsToRemove.Add(Item);
                        else
                            Item.Time = Result;

                    }

                    foreach(var Item in ItemsToRemove)
                    {

                        myList.Remove(Item);

                        if(IsIDisposable)
                            Dispose(Item.Value);

                    }

                    if(myList.Count < 1)
                        Unregister();

                }
                else
                {

                    Unregister();       

                }

            }

        }

        public T Retrive(int TheIndex)
        {

            lock(myLockObject)
            {

                var Item = myList[TheIndex];

                if(IsIDisposable)
                    Dispose(Item.Value);

                myList.RemoveAt(TheIndex);

                return Item.Value;

            }

        }

        public T RetriveFirst(int TheIndex)
        {

            return Retrive(0);

        }

        public T RetriveLast(int TheIndex)
        {

            return Retrive(myList.Count - 1);

        }

        public bool TryRetrive(int TheIndex, out T TheItem)
        {

            lock(myLockObject)
            {

                if(TheIndex > -1 && myList.Count > TheIndex)
                {

                    var Item = myList[TheIndex];

                    if(IsIDisposable)
                        Dispose(Item.Value);

                    myList.RemoveAt(TheIndex);

                    TheItem = Item.Value;

                }

            }

            TheItem = null;

            return false;

        }

        public bool TryRetriveFirst(out T TheItem)
        {

            return TryRetrive(0, out TheItem);

        }

        public bool TryRetriveLast(out T TheItem)
        {

            return TryRetrive(myList.Count - 1, out TheItem);

        }

        public int IndexOf(T item)
        {

            int ItemIndex = 0;

            lock(myLockObject)
            {

                foreach(var ListItem in myList)
                {

                    if(!object.ReferenceEquals(ListItem.Value, item))
                    {

                        ++ItemIndex;

                    }
                    else
                    {

                        return ItemIndex;

                    }

                }

            }

            return -1;

        }

        public void Insert(int index, T item)
        {

            lock(myLockObject)
            {

                myList.Insert(index, new CollectionItem<T>(item, myDefaultTime));

                SetupIfInActive();

            }

        }

        public void Insert(int index, T item, long TheTimeLimit)
        {

            lock(myLockObject)
            {

                myList.Insert(index, new CollectionItem<T>(item, TheTimeLimit));

                SetupIfInActive();

            }

        }

        public void RemoveAt(int index)
        {
            
            lock(myLockObject)
            {

                if(IsIDisposable)
                {

                    var CurrentItem = myList[index];

                    Dispose(CurrentItem.Value);

                }

                myList.RemoveAt(index);

            }

        }

        public T this[int index]
        {

            get
            {

                lock(myLockObject)
                {

                    return myList[index].Value;

                }

            }
            set
            {

                lock(myLockObject)
                {

                    if(IsIDisposable)
                    {

                        var CurrentItem = myList[index];

                        Dispose(CurrentItem.Value);

                    }

                    myList[index] = new CollectionItem<T>(value, myDefaultTime); //(long)Environment.TickCount,

                }

            }

        }

        public void Add(T item)
        {

            lock(myLockObject)
            {

                myList.Add(new CollectionItem<T>(item, myDefaultTime)); //(long)Environment.TickCount,

                SetupIfInActive();

            }

        }

        public void Add(T item, long TheTimeLimit)
        {

            lock(myLockObject)
            {

                myList.Add(new CollectionItem<T>(item, TheTimeLimit));

                SetupIfInActive();

            }

        }

        public void Clear()
        {

            lock(myLockObject)
            {

                Unregister();


                if(IsIDisposable)
                {

                    foreach(var Item in myList)
                    {

                        Dispose(Item.Value);

                    }

                    myList.Clear();

                }
                else
                    myList.Clear();

            }

        }

        public bool Contains(T item)
        {

            lock(myLockObject)
            {

                foreach(var ListItem in myList)
                {

                    if(object.Equals(ListItem.Value, item))
                        return true;

                }

            }

            return false;

        }

        public void CopyTo(T[] array, int arrayIndex)
        {

            throw new NotImplementedException();

        }

        public int Count
        {

            get
            {

                lock(myLockObject)
                {

                    return myList.Count;

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

        public bool Remove(T item)
        {

            int ItemIndex = -1;

            lock(myLockObject)
            {

                foreach(var ListItem in myList)
                {

                    ++ItemIndex;

                    if(object.ReferenceEquals(ListItem.Value, item))
                        break; 

                }

                if(ItemIndex > -1)
                {

                    myList.RemoveAt(ItemIndex);

                    return true;

                }

            }

            return false;

        }

        public IEnumerator<T> GetEnumerator()
        {
            
           lock(myLockObject)
           {

               foreach(var Item in myList)
               {

                   yield return Item.Value;

               }

           }

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {

            return GetEnumerator();

        }
        
    }

}
