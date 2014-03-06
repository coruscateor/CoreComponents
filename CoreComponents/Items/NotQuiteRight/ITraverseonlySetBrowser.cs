using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Items
{
    public interface ISetBrowser<S, T>
    {
        event Gimmie<SenderEventArgs<ISetBrowser<S, T>>>.GimmieSomethin MaximumLimitReached;

        event Gimmie<SenderEventArgs<ISetBrowser<S, T>>>.GimmieSomethin MinimumLimitReached;

        event Gimmie<SenderEventArgs<ISetBrowser<S, T>>>.GimmieSomethin MaximumLimitBreached;

        event Gimmie<SenderEventArgs<ISetBrowser<S, T>>>.GimmieSomethin MinimumLimitBreached;

        event Gimmie<SenderEventArgs<ISetBrowser<S, T>>>.GimmieSomethin LackingInContent;

        bool HasContents();

        T Forward();

        T Back();

        T First();

        T Last();

        T Current();

        T SkipTo(int Index);

        T SkipForward(int Ammount);

        T SkipBackward(int Ammount);

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

    public interface INamedSetBrowser<S, T> : ISetBrowser<S, T>
    {

        T SkipTo(string name);

    }
}
