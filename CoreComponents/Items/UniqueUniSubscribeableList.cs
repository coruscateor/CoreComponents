using System;
using System.Collections.Generic;
using System.Text;
using CoreComponents;

namespace CoreComponents.Items
{
    public class UniqueUniSubscribeableList<T> : UniSubscribeableList<T>  //: IMalleableIndexable<T>
    {

        public UniqueUniSubscribeableList(Action<T> ItemAdded, Action<T> ItemRemoved, Action<IEnumerable<T>> RemovedSet)
            : base(ItemAdded, ItemRemoved, RemovedSet)
        {
        }

        public override void Add(T item)
        {
            lock (Items)
            {

                if (!IsContained(item))  //Prevent Duplicate entries
                {

                    base.Add(item);

                    //Items.Add(item);

                    //ItemAdded(item);

                }

            }

        }

        //public void Clear()
        //{
        //    lock(Items) {

        //        RemovedSet(new Queue<T>(Items));

        //        Items.Clear();

        //    }
        //}

        //public bool Contains(T item)
        //{
        //    return Items.Contains(item);
        //}

        //public void CopyTo(T[] array, int arrayIndex)
        //{
        //    Items.CopyTo(array, arrayIndex);
        //}

        //public int Count
        //{
        //    get
        //    {
        //        lock (Items)
        //        {

        //            return Items.Count;

        //        }
        //    }
        //}

        //public bool IsReadOnly
        //{
        //    get
        //    {
        //        return false;
        //    }
        //}

        //public bool Remove(T item)
        //{
        //    lock (Items)
        //    {
        //        //if (!IsContained(item))
        //        //{

        //            if (Items.Remove(item))
        //            {

        //                ItemRemoved(item);

        //                return true;

        //            }

        //        //}

        //        return false;
        //    }
        //}


        //public IEnumerator<T> GetEnumerator()
        //{
        //    lock (Items)
        //    {

        //        return Items.GetEnumerator();

        //    }
        //}


        //System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        //{

        //    lock (Items)
        //    {

        //        return Items.GetEnumerator();

        //    }
        //}

        bool IsContained(T TheItem)
        {

            foreach (T item in Items)
            {

                if (TheItem.Equals(item))
                {

                    return true;

                }

            }

            return false;

        }

    }
}
