using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Items.Browsing
{
    public class TraverseonlyCountableIndexableBrowser<S, T> : TraverseonlySetBrowser<S, T>, ITraverseonlySetBrowser<S, T> where S : ICountableIndexable<T>
    {

    //    protected int myCurrentIndex = 0;

    //    protected S mySet;

    //    public TraverseonlyCountableIndexableBrowser(S Set)
    //    {

    //        mySet = Set;

    //        if (mySet.Count < 1)
    //            myCurrentIndex = -1;

    //    }

    //    #region ISetBrowser<T> Members

    //    //public event Gimmie<SenderEventArgs<ITraverseonlySetBrowser<S, T>>>.GimmieSomethin MaximumLimitReached;

    //    //public event Gimmie<SenderEventArgs<ITraverseonlySetBrowser<S, T>>>.GimmieSomethin MinimumLimitReached;

    //    //public event Gimmie<SenderEventArgs<ITraverseonlySetBrowser<S, T>>>.GimmieSomethin OutOfMinimumLimit;

    //    //public event Gimmie<SenderEventArgs<ITraverseonlySetBrowser<S, T>>>.GimmieSomethin OutOfMaximumLimit;

    //    //public event Gimmie<IndexChangedEventArgs<ITraverseonlySetBrowser<S, T>, T>>.GimmieSomethin ItemFetched;

    //    //public event Gimmie<SenderEventArgs<ITraverseonlySetBrowser<S, T>>>.GimmieSomethin OutOfBounds;

    //    //public event Gimmie<SenderEventArgs<ITraverseonlySetBrowser<S, T>>>.GimmieSomethin NoContent;

    //    //protected void OnMaximumLimitReached(T item)
    //    //{

    //    //    if (MaximumLimitReached != null)
    //    //        MaximumLimitReached(new IndexChangedEventArgs<ITraverseonlySetBrowser<S, T>, T>(this, item, myCurrentIndex));

    //    //}

    //    //protected void OnMinimumLimitReached(T item)
    //    //{

    //    //    if (MinimumLimitReached != null)
    //    //        MinimumLimitReached(new IndexChangedEventArgs<ITraverseonlySetBrowser<S, T>, T>(this, item, myCurrentIndex));

    //    //}

    //    //protected void OnItemFetched(T item)
    //    //{

    //    //    if (ItemFetched != null)
    //    //        ItemFetched((new IndexChangedEventArgs<ITraverseonlySetBrowser<S, T>, T>(this, item, myCurrentIndex)));

    //    //}

    //    //protected void OnOutOfBounds()
    //    //{

    //    //    if (OutOfBounds != null)
    //    //        OutOfBounds(new SenderEventArgs<ITraverseonlySetBrowser<S, T>>(this));

    //    //}

    //    //protected void OnNoContent()
    //    //{

    //    //    if (NoContent != null)
    //    //        NoContent(new SenderEventArgs<ITraverseonlySetBrowser<S, T>>(this));

    //    //}

    //    //public bool HasContents()
    //    //{

    //    //    if (MaximumIndex < MinimumIndex)
    //    //    {

    //    //        if (myCurrentIndex > -1)
    //    //            myCurrentIndex = -1;

    //    //        return false;

    //    //    } else if (myCurrentIndex == -1)
    //    //        myCurrentIndex = 0;

    //    //    return true;

    //    //}

    //    //public bool IsInExtremities()
    //    //{

    //    //    if (CurrentIndex <= MinimumIndex)
    //    //        return true;
    //    //    else if (CurrentIndex >= MaximumIndex)
    //    //        return true;

    //    //    return false;
            
    //    //}

    //    //void InavalidateIndex()
    //    //{

    //    //    if (mySet.Count < MinimumIndex)
    //    //    {

    //    //        myCurrentIndex = -1;

    //    //    }

    //    //}

    //    //up the index
    //    public void Forward()
    //    {

    //        if (HasContents())
    //        {

    //            int next = myCurrentIndex + 1;

    //            if (next <= MaximumIndex)
    //            {

    //                myCurrentIndex = next;

    //                T item = mySet[myCurrentIndex];

    //                if (myCurrentIndex == MaximumIndex)
    //                {

    //                    OnMaximumLimitReached(item);

    //                } else
    //                {

    //                    OnItemFetched(item);

    //                }

    //            } else
    //            {

    //                OnOutOfBounds();

    //            }

    //        } else
    //        {

    //            OnNoContent();

    //        }

    //    }

    //    public void Back()
    //    {

    //        if (HasContents())
    //        {

    //            int next = myCurrentIndex + 1;

    //            if (next >= MinimumIndex)
    //            {

    //                myCurrentIndex = next;

    //                T item = mySet[myCurrentIndex];

    //                if (myCurrentIndex == MinimumIndex)
    //                {

    //                    OnMinimumLimitReached(item);

    //                } else
    //                {

    //                    OnItemFetched(item);

    //                }

    //            } else
    //            {

    //                OnOutOfBounds();

    //            }

    //        } else
    //        {

    //            OnNoContent();

    //        }

    //    }

    //    public void First()
    //    {

    //        if (HasContents())
    //        {

    //            myCurrentIndex = MinimumIndex;

    //            T item = mySet[myCurrentIndex];

    //            OnMinimumLimitReached(item);

    //        } else
    //        {

    //            OnNoContent();

    //        }

    //    }

    //    public void Last()
    //    {

    //        if (HasContents())
    //        {

    //            myCurrentIndex = MaximumIndex;

    //            T item = mySet[MaximumIndex];

    //            OnMaximumLimitReached(item);

    //        } else
    //        {

    //            OnNoContent();

    //        }

    //    }

    //    public void Current()
    //    {

    //        if (HasContents())
    //        {

    //            OnItemFetched(mySet[myCurrentIndex]);

    //        } else
    //        {

    //            OnNoContent();

    //        }

    //    }

    //    public void SkipTo(int Index)
    //    {

    //        if (HasContents())
    //        {

    //            if (Index <= MaximumIndex && Index >= MinimumIndex)
    //            {

    //                myCurrentIndex = Index;

    //                T item = mySet[myCurrentIndex];

    //                if (myCurrentIndex == MinimumIndex)
    //                {

    //                    OnMinimumLimitReached(item);

    //                    return;

    //                } else if (myCurrentIndex == MaximumIndex)
    //                {

    //                    OnMaximumLimitReached(item);

    //                    return;

    //                }
    //                OnItemFetched(item);

    //            } else
    //            {

    //                OnOutOfBounds();

    //            }

    //        } else
    //        {

    //            OnNoContent();

    //        }

    //    }

    //    public void SkipForward(int Ammount)
    //    {

    //        if (Ammount < 0)
    //            SkipTo(myCurrentIndex + +Ammount);
    //        else if (Ammount > 0)
    //            SkipTo(myCurrentIndex + Ammount);

    //    }

    //    public void SkipBackward(int Ammount)
    //    {

    //        if (Ammount < 0)
    //            SkipTo(myCurrentIndex + Ammount);
    //        else if (Ammount > 0)
    //            SkipTo(myCurrentIndex + -Ammount);

    //    }

    //    public bool PeepNext()
    //    {

    //        return (myCurrentIndex + 1) <= MaximumIndex;

    //    }

    //    public bool PeepPrevious()
    //    {

    //        return (myCurrentIndex - 1) >= MinimumIndex;

    //    }

    //    public int CurrentIndex
    //    {
    //        get
    //        {

    //            return myCurrentIndex;

    //        }
    //    }

    //    public int Count
    //    {

    //        get
    //        {

    //            return mySet.Count;

    //        }

    //    }


    //    public int MaximumIndex
    //    {
    //        get
    //        {

    //            return mySet.Count - 1;

    //        }
    //    }

    //    public int MinimumIndex
    //    {
    //        get
    //        {

    //            return 0;

    //        }
    //    }

    //    #endregion

    //}

    //public class CountableNameableIndexableBrowser<S, T> : TraverseonlyCountableIndexableBrowser<S, T>, ITraverseonlyNamedSetBrowser<S, T> where S : ICountableNameableIndexable<T> where T : IReadonlyHasName 
    //{

    //    public CountableNameableIndexableBrowser(S Set) : base(Set)
    //    {
    //    }

    //    public void SkipTo(string name)
    //    {

    //        int location = -1;

    //        if (HasContents())
    //        {

    //            foreach (T item in mySet)
    //            {
    //                location++;

    //                if (item.Name == name)
    //                {

    //                    myCurrentIndex = location;

    //                    if (location == MinimumIndex)
    //                    {

    //                        OnMinimumLimitReached(item);

    //                        return;

    //                    } else if (location == MaximumIndex)
    //                    {

    //                        OnMaximumLimitReached(item);

    //                        return;

    //                    }

    //                    OnItemFetched(item);

    //                    return;

    //                }

    //            }

    //            OnOutOfBounds();

    //        } else
    //        {

    //            OnNoContent();

    //        }

        //}

    }
}
