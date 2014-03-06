using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents;
using CoreComponents.Items;

namespace CoreComponents.Items.Browsing
{

    public interface ITraverseonlySetBrowser<S, T>
    {

        //event Gimmie<SenderEventArgs<ITraverseonlySetBrowser<S, T>>>.GimmieSomethin MaximumLimitReached;

        //event Gimmie<SenderEventArgs<ITraverseonlySetBrowser<S, T>>>.GimmieSomethin MinimumLimitReached;

        //event Gimmie<SenderEventArgs<ITraverseonlySetBrowser<S, T>>>.GimmieSomethin OutOfMinimumLimit;

        //event Gimmie<SenderEventArgs<ITraverseonlySetBrowser<S, T>>>.GimmieSomethin OutOfMaximumLimit;

        //event Gimmie<IndexChangedEventArgs<ITraverseonlySetBrowser<S, T>, T>>.GimmieSomethin ItemFetched;

        //event Gimmie<SenderEventArgs<ITraverseonlySetBrowser<S, T>>>.GimmieSomethin OutOfBounds;

        //event Gimmie<SenderEventArgs<ITraverseonlySetBrowser<S, T>>>.GimmieSomethin NoContent;

        event Create<SenderEventArgs<ITraverseonlySetBrowser<S, T>>>.ADelegate MaximumLimitReached;

        event Create<SenderEventArgs<ITraverseonlySetBrowser<S, T>>>.ADelegate MinimumLimitReached;

        event Create<SenderEventArgs<ITraverseonlySetBrowser<S, T>>>.ADelegate OutOfMinimumLimit;

        event Create<SenderEventArgs<ITraverseonlySetBrowser<S, T>>>.ADelegate OutOfMaximumLimit;

        event Create<IndexChangedEventArgs<ITraverseonlySetBrowser<S, T>, T>>.ADelegate ItemFetched;

        event Create<SenderEventArgs<ITraverseonlySetBrowser<S, T>>>.ADelegate OutOfBounds;

        event Create<SenderEventArgs<ITraverseonlySetBrowser<S, T>>>.ADelegate NoContent;

        event Create<SenderEventArgs<ITraverseonlySetBrowser<S, T>>>.ADelegate SetChanged;

        bool HasContents
        {
            get;
        }

        bool IsInExtremities
        {
            get;
        }

        bool IsAtMaximumLimit
        {
            get;
        }

        bool IsAtMinimumLimit
        {
            get;
        }

        bool IsFetching
        {
            get;
        }

        void Forward();

        void Back();

        void First();

        void Last();

        void Current();

        void SkipTo(int Index);

        void SkipForward(int Ammount);

        void SkipBackward(int Ammount);

        bool PeepNext();

        bool PeepPrevious();

        int CurrentIndex
        {

            get;

        }

        int Count
        {

            get;

        }

        int MaximumIndex
        {

            get;

        }

        int MinimumIndex
        {

            get;

        }

    }

    public interface ITraverseonlyNamedSetBrowser<S, T> : ITraverseonlySetBrowser<S, T>
    {

        void SkipTo(string name);

    }

    public interface IReadonlySetBrowser<S, T> : ITraverseonlySetBrowser<S, T>
    {

        //event Gimmie<SenderEventArgs<ITraverseonlySetBrowser<S, T>>>.GimmieSomethin SetChanged;

        S Set
        {

            get;

        }

    }

    public interface ISetBrowser<S, T> : IReadonlySetBrowser<S, T>
    {

        new S Set
        {

            get;
            set;

        }

    }
}
