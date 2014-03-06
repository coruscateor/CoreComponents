using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Items
{
    public class VolumeConstrainedList<T> : IVolumeConstrainedList<T>
    {

        int myLimit;

        List<T> TheList;

        //bool myLimitIsReached;

        //public VolumeConstrainedList()
        //{

        //    myLimit = 10;

        //    TheList = new List<T>(myLimit);

        //}

        public VolumeConstrainedList(int theLimit)
        {

            myLimit = theLimit;

            TheList = new List<T>(myLimit);

        }

        void OnLimitReached()
        {

            if (LimitReached != null)
                LimitReached(new SenderEventArgs<IVolumeConstrainedList<T>>(this));

        }


        #region IVolumeConstrainedList<T> Members

        public event Action<SenderEventArgs<IVolumeConstrainedList<T>>> LimitReached;

        public int Limit
        {

            get
            {

                return myLimit;

            }

        }

        #endregion

        #region IEditableList<T> Members

        public void AddRange(IEnumerable<T> items)
        {

            TheList.AddRange(items);
          
        }

        public void RemoveRange(int index, int count)
        {

            TheList.RemoveRange(index, count);
            
        }

        public void RemoveAll(Predicate<T> match)
        {

            TheList.RemoveAll(match);

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

        #endregion

        #region IList<T> Members

        public int IndexOf(T item)
        {

            return TheList.IndexOf(item);

        }

        public void Insert(int index, T item)
        {

            TheList.Insert(index, item);

        }

        public void RemoveAt(int index)
        {

            TheList.RemoveAt(index);

        }

        public T this[int index]
        {

            get
            {

                return TheList[index];

            }
            set
            {

                TheList[index] = value;

            }

        }

        #endregion

        #region ICollection<T> Members

        public void Add(T item)
        {

            TheList.Add(item);

        }

        public void Clear()
        {

            TheList.Clear();

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

                //return _Limit > TheList.Count;
                //return myLimitIsReached;
                return false;

            }

        }

        public bool Remove(T item)
        {
            return TheList.Remove(item);
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
    }
}
