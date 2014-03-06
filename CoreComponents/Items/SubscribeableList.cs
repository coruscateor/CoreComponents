using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace CoreComponents.Items
{
	
	public interface ISubscribeableList<T> : ISubscribeableIndexable<T, SubscribeableList<T>>, IEditableList<T>
	{
	}
	
    public class SubscribeableList<T> : ISubscribeableList<T>, IEditableList<T>
    {

        protected List<T> TheList;

        //public virtual event ChangedHandlers<T, SubscribeableList<T>>.ChangedRangeHandler AddedSet;

        //public virtual event ChangedHandlers<T, SubscribeableList<T>>.ChangedRangeHandler AddingSet;

        //public virtual event ChangedHandlers<T, SubscribeableList<T>>.ChangedRangeHandler RemovedSet;

        //public virtual event ChangedHandlers<T, SubscribeableList<T>>.ChangedRangeHandler RemovingSet;

        //public event Gimmie<SenderEventArgs<SubscribeableList<T>>>.GimmieSomethin Clearing;

        //public event Gimmie<SenderEventArgs<SubscribeableList<T>>>.GimmieSomethin Cleared;

        public delegate void ChangeRangeEventArgsDelegate(ChangeRangeEventArgs<T, SubscribeableList<T>> Parameter);

        public delegate void SenderEventArgsDelegate(SenderEventArgs<SubscribeableList<T>> Parameter);

        public delegate void ChangeEventArgsDelegate(ChangeEventArgs<T, SubscribeableList<T>> Parameter);

        //public virtual event Create<ChangeRangeEventArgs<T, SubscribeableList<T>>>.ADelegate AddedSet;

        //public virtual event Create<ChangeEventArgs<T, SubscribeableList<T>>>.ADelegate Added;

        public virtual event ChangeEventArgsDelegate Added;

        //public virtual event Create<ChangeEventArgs<T, SubscribeableList<T>>>.ADelegate Removed;

        public virtual event ChangeEventArgsDelegate Removed;

        public virtual event ChangeRangeEventArgsDelegate AddedSet;

        //public virtual event Create<ChangeRangeEventArgs<T, SubscribeableList<T>>>.ADelegate RemovedSet;

        public virtual event ChangeRangeEventArgsDelegate RemovedSet;

        //public event Create<SenderEventArgs<SubscribeableList<T>>>.ADelegate Cleared;

        public event SenderEventArgsDelegate Cleared;

        public SubscribeableList()
        {

            TheList = new List<T>();

        }

        public SubscribeableList(int capacity)
        {

            TheList = new List<T>(capacity);

        }

        public SubscribeableList(IEnumerable<T> collection)
        {

            TheList = new List<T>(collection);

        }

        private void OnAdded(T item)
        {

            if (Added != null)
                Added(new ChangeEventArgs<T,SubscribeableList<T>>(this, item));

        }

        //private void OnAdding(T item)
        //{

        //    if (Adding != null)
        //        Adding(new ChangeEventArgs<T, SubscribeableList<T>>(this, item));

        //}

        private void OnAddedSet(IEnumerable<T> items)
        {

          if (AddedSet!= null)
                AddedSet(new ChangeRangeEventArgs<T,SubscribeableList<T>>(this, items));

        }

        //private void OnAddingSet(IEnumerable<T> items)
        //{

        //    if (AddingSet != null)
        //        AddingSet(new ChangeRangeEventArgs<T, SubscribeableList<T>>(this, items));

        //}

        private void OnRemoved(T item)
        {

            if (Removed != null)
                Removed(new ChangeEventArgs<T,SubscribeableList<T>>(this, item));

        }

        //private void OnRemoving(T item)
        //{

        //    if (Removing != null)
        //        Removing(new ChangeEventArgs<T, SubscribeableList<T>>(this, item));

        //}

        private void OnRemovedSet(IEnumerable<T> items)
        {

                if (RemovedSet != null)
                    RemovedSet(new ChangeRangeEventArgs<T, SubscribeableList<T>>(this, items));

        }

        //private void OnRemovingSet(IEnumerable<T> items)
        //{

        //    if (RemovingSet != null)
        //        RemovingSet(new ChangeRangeEventArgs<T, SubscribeableList<T>>(this, items));

        //}

        //protected void OnClearing()
        //{

        //    if (Clearing != null)
        //        Clearing(new SenderEventArgs<SubscribeableList<T>>(this));

        //}

        protected void OnCleared()
        {

            if (Cleared != null)
                Cleared(new SenderEventArgs<SubscribeableList<T>>(this));

        }

        #region IList<T> Members

        public int IndexOf(T item)
        {

            return TheList.IndexOf(item);

        }

        public virtual void Insert(int index, T item)
        {

            //OnAdding(item);

            TheList.Insert(index, item);

            OnAdded(item);

        }

        public virtual void RemoveAt(int index)
        {

            T item = TheList[index];

            //OnRemoving(item);

            TheList.RemoveAt(index);

            OnRemoved(item);

        }

        public T this[int index]
        {
            get
            {

                return TheList[index];

            }
            set
            {

                T item = TheList[index];

                //OnAdding(value);

                //OnRemoving(item);

                TheList[index] = value;

                OnAdded(value);

                OnRemoved(item);

            }
        }

        #endregion

        #region ICollection<T> Members

        public virtual void Add(T item)
        {

            //OnAdding(item);

            TheList.Add(item);

            OnAdded(item);

        }

        public virtual void Clear()
        {

            //OnRemovingSet(this);

            //OnClearing();

            TheList.Clear(); //Mo Events

            OnCleared();

            //OnRemovedSet(this);

        }

        public bool Contains(T item)
        {
            return TheList.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            TheList.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get
            {
                return TheList.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public virtual bool Remove(T item)
        {

            //OnRemoving(item);

            if (TheList.Remove(item))
            {

                OnRemoved(item);

                return true;
            }

            return false;
        }

        #endregion

        #region IEnumerable<T> Members

        public IEnumerator<T> GetEnumerator()
        {
            return TheList.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return TheList.GetEnumerator();
        }

        #endregion

        #region ISubscribeableIndexable<T> Members


        public int this[T item]
        {
            get
            {
                int i = 0;

                foreach (T ListItem in TheList)
                {
                    i++;

                    if (ListItem.Equals(item))
                    {

                        return i;

                    }

                }

                return -1;
            }
        }

        #endregion

        #region ISubscribeableSet<T, Sender> Members

        //public virtual event ChangedHandlers<T, SubscribeableList<T>>.ChangedHandler Added;

        //public virtual event ChangedHandlers<T, SubscribeableList<T>>.ChangedHandler Adding;

        //public virtual event ChangedHandlers<T, SubscribeableList<T>>.ChangedHandler Removed;

        //public virtual event ChangedHandlers<T, SubscribeableList<T>>.ChangedHandler Removing;




        #endregion

        //#region ICloneable Members

        //public object Clone()
        //{
        //    return;
        //}

        //#endregion

        #region IEditableList<T> Members

        public virtual void AddRange(IEnumerable<T> items)
        {

            //OnAddingSet(items);

            TheList.AddRange(items);

            OnAddedSet(items);

        }

        public virtual void RemoveRange(int index, int count)
        {

           //List<T> items = null;

           //if (RemovingSet != null) {

           //    items = (List<T>)GetSetList(index, count);

           //    RemovingSet(new ChangeRangeEventArgs<T, SubscribeableList<T>>(this, items));

           //} else if(RemovedSet != null)
           //{

           //    items = (List<T>)GetSetList(index, count);
            
           //}

            List<T> items = (List<T>)GetSetList(index, count);

            TheList.RemoveRange(index, count);

            OnRemovedSet(items);

        }

        IEnumerable<T> GetSetList(int index, int count) {

            List<T> items = new List<T>();

            int LastLocation = index + count;

            for (int i = index; i <= LastLocation; i++)
                items.Add(TheList[i]);

            return items;
        
        }

        public void Reverse()
        {
            TheList.Reverse();
        }

        public void Reverse(int index, int count)
        {
            TheList.Reverse(index, count);
        }

        public IList<T> RetriveReversed()
        {

            List<T> NewList = new List<T>(TheList);

            NewList.Reverse();

            return NewList;

        }

        public IList<T> RetriveReversed(int index, int count)
        {

            List<T> NewList = new List<T>(TheList);

            NewList.Reverse(index, count);

            return NewList;
        }

        public void RemoveAll(Predicate<T> match)
        {
            TheList.RemoveAll(match);
        }

        #endregion
    }
}
