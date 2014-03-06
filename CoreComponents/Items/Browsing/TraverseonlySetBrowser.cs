using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Items.Browsing
{
    public abstract class TraverseonlySetBrowser<S, T> : ITraverseonlySetBrowser<S, T>
    {

        protected int myCurrentIndex = 0;

        protected S mySet;

        bool isAtMaximum;

        bool isAtMinimum;

        protected bool isFetching;

        //public event Gimmie<SenderEventArgs<ITraverseonlySetBrowser<S, T>>>.GimmieSomethin MaximumLimitReached;

        //public event Gimmie<SenderEventArgs<ITraverseonlySetBrowser<S, T>>>.GimmieSomethin MinimumLimitReached;

        //public event Gimmie<SenderEventArgs<ITraverseonlySetBrowser<S, T>>>.GimmieSomethin OutOfMinimumLimit;

        //public event Gimmie<SenderEventArgs<ITraverseonlySetBrowser<S, T>>>.GimmieSomethin OutOfMaximumLimit;

        //public event Gimmie<IndexChangedEventArgs<ITraverseonlySetBrowser<S, T>, T>>.GimmieSomethin ItemFetched;

        //public event Gimmie<SenderEventArgs<ITraverseonlySetBrowser<S, T>>>.GimmieSomethin OutOfBounds;

        //public event Gimmie<SenderEventArgs<ITraverseonlySetBrowser<S, T>>>.GimmieSomethin NoContent;

        //public event Gimmie<SenderEventArgs<ITraverseonlySetBrowser<S, T>>>.GimmieSomethin SetChanged;


        public event Create<SenderEventArgs<ITraverseonlySetBrowser<S, T>>>.ADelegate MaximumLimitReached;

        public event Create<SenderEventArgs<ITraverseonlySetBrowser<S, T>>>.ADelegate MinimumLimitReached;

        public event Create<SenderEventArgs<ITraverseonlySetBrowser<S, T>>>.ADelegate OutOfMinimumLimit;

        public event Create<SenderEventArgs<ITraverseonlySetBrowser<S, T>>>.ADelegate OutOfMaximumLimit;

        public event Create<IndexChangedEventArgs<ITraverseonlySetBrowser<S, T>, T>>.ADelegate ItemFetched;

        public event Create<SenderEventArgs<ITraverseonlySetBrowser<S, T>>>.ADelegate OutOfBounds;

        public event Create<SenderEventArgs<ITraverseonlySetBrowser<S, T>>>.ADelegate NoContent;

        public event Create<SenderEventArgs<ITraverseonlySetBrowser<S, T>>>.ADelegate SetChanged;

        protected void OnMaximumLimitReached()
        {


            if (!isAtMaximum)
            {
                isAtMaximum = true;

                if (isAtMinimum)
                    isAtMinimum = false;
            }

            if (MaximumLimitReached != null)
                MaximumLimitReached(new SenderEventArgs<ITraverseonlySetBrowser<S, T>>(this));

        }

        protected void OnMinimumLimitReached()
        {

            if (!isAtMinimum)
            {
                isAtMinimum = true;

                if (isAtMaximum)
                    isAtMaximum = false;
            }

            if (MinimumLimitReached != null)
                MinimumLimitReached(new SenderEventArgs<ITraverseonlySetBrowser<S, T>>(this));

        }

        protected void OnOutOfMaximumLimit()
        {

            isAtMaximum = false;

            if (OutOfMaximumLimit != null)
                OutOfMaximumLimit(new SenderEventArgs<ITraverseonlySetBrowser<S, T>>(this));


        }

        protected void OnOutOfMinimumLimit()
        {

            isAtMinimum = false;


            if (OutOfMinimumLimit != null)
                OutOfMinimumLimit(new SenderEventArgs<ITraverseonlySetBrowser<S, T>>(this));


        }

        protected void OnItemFetched(T item)
        {

            if (ItemFetched != null)
                ItemFetched(new IndexChangedEventArgs<ITraverseonlySetBrowser<S, T>, T>(this, item, myCurrentIndex));

        }

        protected void OnOutOfBounds()
        {

            isAtMinimum = false;
            isAtMaximum = false;

            if (OutOfBounds != null)
                OutOfBounds(new SenderEventArgs<ITraverseonlySetBrowser<S, T>>(this));

        }

        protected void OnNoContent()
        {

            if (isAtMinimum)
                isAtMinimum = false;

            if (isAtMaximum)
                isAtMaximum = false;

            if (NoContent != null)
                NoContent(new SenderEventArgs<ITraverseonlySetBrowser<S, T>>(this));

        }

        protected void OnSetChanged()
        {

            if (SetChanged != null)
                SetChanged(new SenderEventArgs<ITraverseonlySetBrowser<S, T>>(this));

        }

        public bool IsAtMaximumLimit
        {

            get
            {

                return isAtMaximum;

            }
        }

        public bool IsAtMinimumLimit
        {
            get
            {

                return isAtMinimum;

            }
        }

        public bool IsFetching
        {
            get
            {

                return isFetching;

            }
        }

        public bool PeepNext()
        {

            return (myCurrentIndex + 1) <= MaximumIndex;

        }

        public bool PeepPrevious()
        {

            return (myCurrentIndex - 1) >= MinimumIndex;

        }

        public virtual bool HasContents
        {

            get
            {

                if (mySet != null)
                {

                    if (MaximumIndex < MinimumIndex)
                    {

                        if (myCurrentIndex > 0)
                            myCurrentIndex = 0;

                        return false;

                    } else if (myCurrentIndex <= -1)
                    {
                        myCurrentIndex = 0;

                        return false;
                    }

                    return true;

                }

                return false;

            }

        }

        public virtual bool IsInExtremities
        {

            get
            {

                if (isAtMaximum)
                    return true;
                else if (isAtMinimum)
                    return true;

                return false;

            }
        }

        protected virtual void InavalidateIndex()
        {

            //if (mySet.Tables.Count < MinimumIndex)
            //{

            //    myCurrentIndex = 0;

            //}

        }

        protected void Reset(S NewSet)
        {

            if (!isFetching)
            {

                mySet = NewSet;

                First();

                OnSetChanged();

            }

        }

        public virtual int Count
        {
            get
            {
                //if (mySet != null)
                //    return mySet.Tables.Count;
                //else
                return 0;
            }
        }

        public virtual int CurrentIndex
        {
            get
            {

                return myCurrentIndex;

            }
        }

        public virtual int MaximumIndex
        {

            get
            {
                //if (mySet != null)
                //    return mySet.Tables.Count - 1;
                //else
                    return 0;

            }

        }

        public virtual int MinimumIndex
        {
            get
            {
                return 0;
            }
        }

        public virtual void Forward()
        {

            //if (HasContents())
            //{

            //    int next = myCurrentIndex + 1;

            //    if (next <= MaximumIndex)
            //    {

            //        myCurrentIndex = next;

            //        T item = mySet[myCurrentIndex];

            //        if (myCurrentIndex == MaximumIndex)
            //        {

            //            OnMaximumLimitReached(item);

            //        } else
            //        {

            //            OnItemFetched(item);

            //        }

            //    } else
            //    {

            //        OnOutOfBounds();

            //    }

            //} else
            //{

            //    OnNoContent();

            //}

        }

        public virtual void Back()
        {

            //if (HasContents())
            //{

            //    int next = myCurrentIndex + 1;

            //    if (next >= MinimumIndex)
            //    {

            //        myCurrentIndex = next;

            //        T item = mySet[myCurrentIndex];

            //        if (myCurrentIndex == MinimumIndex)
            //        {

            //            OnMinimumLimitReached(item);

            //        } else
            //        {

            //            OnItemFetched(item);

            //        }

            //    } else
            //    {

            //        OnOutOfBounds();

            //    }

            //} else
            //{

            //    OnNoContent();

            //}

        }

        public virtual void First()
        {

            //if (HasContents())
            //{

            //    myCurrentIndex = MinimumIndex;

            //    T item = mySet[myCurrentIndex];

            //    OnMinimumLimitReached(item);

            //} else
            //{

            //    OnNoContent();

            //}

        }

        public virtual void Last()
        {

            //if (HasContents())
            //{

            //    myCurrentIndex = MaximumIndex;

            //    T item = mySet[MaximumIndex];

            //    OnMaximumLimitReached(item);

            //} else
            //{

            //    OnNoContent();

            //}

        }

        public virtual void Current()
        {

            //if (HasContents())
            //{

            //    OnItemFetched(mySet[myCurrentIndex]);

            //} else
            //{

            //    OnNoContent();

            //}

        }

        public virtual void SkipTo(int Index)
        {

            //if (HasContents())
            //{

            //    if (Index <= MaximumIndex && Index >= MinimumIndex)
            //    {

            //        myCurrentIndex = Index;

            //        T item = mySet[myCurrentIndex];

            //        if (myCurrentIndex == MinimumIndex)
            //        {

            //            OnMinimumLimitReached(item);

            //            return;

            //        } else if (myCurrentIndex == MaximumIndex)
            //        {

            //            OnMaximumLimitReached(item);

            //            return;

            //        }
            //        OnItemFetched(item);

            //    } else
            //    {

            //        OnOutOfBounds();

            //    }

            //} else
            //{

            //    OnNoContent();

            //}

        }

        public virtual void SkipForward(int Ammount)
        {

            if (Ammount < 0)
                SkipTo(myCurrentIndex + +Ammount);
            else if (Ammount > 0)
                SkipTo(myCurrentIndex + Ammount);

        }

        public virtual void SkipBackward(int Ammount)
        {

            if (Ammount < 0)
                SkipTo(myCurrentIndex + Ammount);
            else if (Ammount > 0)
                SkipTo(myCurrentIndex + -Ammount);

        }

    }

    public class SetBrowser<S, T> : TraverseonlySetBrowser<S, T>
    {

        public virtual S Set
        {
            get
            {

                return mySet;

            }
            set
            {

                Reset(value);

            }
        }

    }
}
