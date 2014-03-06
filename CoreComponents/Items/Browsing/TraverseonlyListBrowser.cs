using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Items.Browsing
{

    public class TraverseonlyListBrowser<S, T> : TraverseonlySetBrowser<S, T> where S : IList<T>
    {

        //protected int myCurrentIndex;

        //protected S mySet;

        public TraverseonlyListBrowser(S Set)
        {

            //mySet = Set;

            Reset(Set);

            //if (mySet.Count < 1)
            //    myCurrentIndex = -1;

        }

        #region ISetBrowser<T> Members

        //public event Gimmie<SenderEventArgs<ITraverseonlySetBrowser<S, T>>>.GimmieSomethin MaximumLimitReached;

        //public event Gimmie<SenderEventArgs<ITraverseonlySetBrowser<S, T>>>.GimmieSomethin MinimumLimitReached;

        //public event Gimmie<IndexChangedEventArgs<ITraverseonlySetBrowser<S, T>, T>>.GimmieSomethin ItemFetched;

        //public event Gimmie<SenderEventArgs<ITraverseonlySetBrowser<S, T>>>.GimmieSomethin OutOfBounds;

        //public event Gimmie<SenderEventArgs<ITraverseonlySetBrowser<S, T>>>.GimmieSomethin NoContent;

        //protected void OnMaximumLimitReached(T item)
        //{

        //    if (MaximumLimitReached != null)
        //        MaximumLimitReached(new IndexChangedEventArgs<ITraverseonlySetBrowser<S, T>, T>(this, item, myCurrentIndex));

        //}

        //protected void OnMinimumLimitReached(T item)
        //{

        //    if (MinimumLimitReached != null)
        //        MinimumLimitReached(new IndexChangedEventArgs<ITraverseonlySetBrowser<S, T>, T>(this, item, myCurrentIndex));

        //}

        //protected void OnItemFetched(T item)
        //{

        //    if (ItemFetched != null)
        //        ItemFetched((new IndexChangedEventArgs<ITraverseonlySetBrowser<S, T>, T>(this, item, myCurrentIndex)));

        //}

        //protected void OnOutOfBounds()
        //{

        //    if (OutOfBounds != null)
        //        OutOfBounds(new SenderEventArgs<ITraverseonlySetBrowser<S, T>>(this));

        //}

        //protected void OnNoContent()
        //{

        //    if (NoContent != null)
        //        NoContent(new SenderEventArgs<ITraverseonlySetBrowser<S, T>>(this));

        //}

        //public override bool HasContents()
        //{

        //    if (mySet != null)
        //    {

        //        if (MaximumIndex < MinimumIndex)
        //        {

        //            if (myCurrentIndex > -1)
        //                myCurrentIndex = -1;

        //            return false;

        //        } else if (myCurrentIndex == -1)
        //            myCurrentIndex = 0;

        //        return true;

        //    }

        //    return false;

        //}

        //public override bool IsInExtremities
        //{
        //    get
        //    {

        //        if (CurrentIndex <= MinimumIndex)
        //            return true;
        //        else if (CurrentIndex >= MaximumIndex)
        //            return true;

        //        return false;

        //    }

        //}

        protected override void InavalidateIndex()
        {

            if (mySet.Count < MinimumIndex)
            {

                myCurrentIndex = MinimumIndex;

            }

        }

        //up the index
        public override void Forward()
        {

            if(!isFetching)
            {

                if (HasContents)
                {

                    int next = myCurrentIndex + 1;

                    if (next <= MaximumIndex)
                    {

                        isFetching = true;

                        if (myCurrentIndex == MinimumIndex)
                        {

                            OnOutOfMinimumLimit();

                        }

                        myCurrentIndex = next;

                        T item = mySet[myCurrentIndex];

                        OnItemFetched(item);

                        isFetching = false;

                        if (myCurrentIndex == MaximumIndex)
                        {

                            OnMaximumLimitReached();

                        }

                    } else
                    {

                        OnOutOfBounds();

                    }

                } else
                {

                    OnNoContent();

                }

            }

        }

        public override void Back()
        {

            if(!isFetching)
            {

                if (HasContents)
                {

                    int next = myCurrentIndex - 1;

                    if (next >= MinimumIndex)
                    {

                        isFetching = true;

                        if (myCurrentIndex == MaximumIndex)
                        {

                            OnOutOfMaximumLimit();

                        }

                        myCurrentIndex = next;

                        T item = mySet[myCurrentIndex];

                        OnItemFetched(item);

                        isFetching = false;

                        if (myCurrentIndex == MinimumIndex)
                        {

                            OnMinimumLimitReached();

                        }

                    } else
                    {

                        OnOutOfBounds();

                    }

                } else
                {

                    OnNoContent();

                }
            }

        }

        public override void First()
        {

            
            if (!isFetching)
            {

                if (HasContents)
                {

                    isFetching = true;

                    if (myCurrentIndex == MaximumIndex)
                    {

                        OnOutOfMaximumLimit();

                    }

                    myCurrentIndex = MinimumIndex;

                    OnItemFetched(mySet[myCurrentIndex]);

                    isFetching = false;

                    OnMinimumLimitReached();

                } else
                {

                    OnNoContent();

            }

            }

        }

        public override void Last()
        {

           if (!isFetching)
           {

                if (HasContents)
                {

                    isFetching = true;

                    if (myCurrentIndex == MinimumIndex)
                    {

                        OnOutOfMinimumLimit();

                    }

                    myCurrentIndex = MaximumIndex;

                    OnItemFetched(mySet[MaximumIndex]);

                    isFetching = false;

                    OnMaximumLimitReached();

                    

                } else
                {

                    OnNoContent();

                }
          }

        }

        public override void Current()
        {


            //if(!isFetching)
            //{

                if (HasContents)
                {

                    isFetching = true;

                    OnItemFetched(mySet[myCurrentIndex]);

                    isFetching = false;

                } else
                {

                    OnNoContent();

                }

            //}

        }

        public override void SkipTo(int Index)
        {

            if (!isFetching)
            {

                if (HasContents)
                {

                    if (Index != myCurrentIndex) 
                    {

                            if (Index <= MaximumIndex && Index >= MinimumIndex)
                            {

                                isFetching = true;

                                //int lastIndex = myCurrentIndex;

                                if (myCurrentIndex == MinimumIndex)
                                {

                                    OnOutOfMinimumLimit();

                                } else if (myCurrentIndex == MaximumIndex)
                                {

                                    OnOutOfMaximumLimit();

                                }

                                myCurrentIndex = Index;

                                OnItemFetched(mySet[myCurrentIndex]);

                                isFetching = false;

                                if (myCurrentIndex == MinimumIndex)
                                {

                                    OnMinimumLimitReached();

                                    return;

                                } else if (myCurrentIndex == MaximumIndex)
                                {

                                    OnMaximumLimitReached();

                                    return;

                                }
                                //OnItemFetched(item);

                        } else
                        {

                            OnOutOfBounds();

                        }

                    }
                }

            } else
            {

                OnNoContent();

            }

         }

        public override int MaximumIndex
        {
            get
            {
                if (mySet != null)
                {

                    if (mySet.Count > 1)
                        return mySet.Count - 1;
                    else
                        return 0;

                } else
                    return 0;

            }
        }

        public override int MinimumIndex
        {
            get
            {
                if (mySet != null)
                {

                    if (mySet.Count >= 1)
                        return 1;
                    else
                        return 0;

                } else
                    return 0;

            }
        }

        //public void SkipForward(int Ammount)
        //{

        //        if (Ammount < 0)
        //           SkipTo(myCurrentIndex + +Ammount);
        //        else if (Ammount > 0)
        //           SkipTo(myCurrentIndex + Ammount);

        //}

        //public void SkipBackward(int Ammount)
        //{

        //    if (Ammount < 0)
        //        SkipTo(myCurrentIndex + Ammount);
        //    else if (Ammount > 0)
        //        SkipTo(myCurrentIndex + -Ammount);

        //}

        //public bool PeepNext()
        //{

        //    return (myCurrentIndex + 1) <= MaximumIndex;

        //}

        //public bool PeepPrevious()
        //{

        //    return (myCurrentIndex - 1) >= MinimumIndex;

        //}

        //public int CurrentIndex
        //{
        //    get
        //    {

        //        return myCurrentIndex;

        //    }
        //}

        //public int Count
        //{

        //    get
        //    {

        //        return mySet.Count;

        //    }

        //}


        //public int MaximumIndex
        //{
        //    get
        //    {

        //        return mySet.Count - 1;

        //    }
        //}

        //public int MinimumIndex
        //{
        //    get
        //    {

        //        return 0;

        //    }
        //}

        #endregion

    }
}
