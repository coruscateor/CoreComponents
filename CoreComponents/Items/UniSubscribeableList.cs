using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents;

namespace CoreComponents.Items
{
    public class UniSubscribeableList<T> : IIndexableCollection<T>
    {
        protected Action<T> ItemAdded;

        protected Action<T> ItemRemoved;

        protected Action<IEnumerable<T>> RemovedSet;

        protected List<T> Items = new List<T>();

        public UniSubscribeableList(Action<T> ItemAdded, Action<T> ItemRemoved, Action<IEnumerable<T>> RemovedSet)
        {

            this.ItemAdded = ItemAdded;
            this.ItemRemoved = ItemRemoved;
            this.RemovedSet = RemovedSet;

        }

        public virtual T this[int index]
        {
            get
            {
                return Items[index];
            }
        }

        //public int this[T item]
        //{
        //    get
        //    {
        //        return Items.FindIndex(delegate(T TheItem)
        //        {
        //        }));
        //    }
        //}

        public virtual void Add(T item)
        {
            lock (Items)
            {

                Items.Add(item);

                ItemAdded(item);

            }

        }

        public virtual void Clear()
        {
            lock (Items)
            {

                RemovedSet(new Queue<T>(Items));

                Items.Clear();

            }
        }

        public virtual bool Contains(T item)
        {
            return Items.Contains(item);
        }

        public virtual void CopyTo(T[] array, int arrayIndex)
        {
            Items.CopyTo(array, arrayIndex);
        }

        public virtual int Count
        {
            get
            {

                lock (Items)
                {

                    return Items.Count;

                }
            }
        }

        public virtual bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public virtual bool Remove(T item)
        {
            lock (Items)
            {


                if (Items.Remove(item))
                {

                    ItemRemoved(item);

                    return true;
                }

                return false;
            }
        }


        public virtual IEnumerator<T> GetEnumerator()
        {
            lock (Items)
            {
                return Items.GetEnumerator();

            }
        }


        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {

            lock (Items)
            {

                return Items.GetEnumerator();

            }
        }

    }
}