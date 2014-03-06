using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Items
{
    public class CountableIndexableBrowser<S, T> : ISetBrowser<S, T> where S : ICountableIndexable<T>
    {

        protected int myCurrentIndex;

        protected S mySet;

        public CountableIndexableBrowser(S Set)
        {

            mySet = Set;

            if (mySet.Count < 1)
                myCurrentIndex = -1;

        }

        #region ISetBrowser<T> Members

        public event Gimmie<SenderEventArgs<ISetBrowser<S, T>>>.GimmieSomethin MaximumLimitReached;

        public event Gimmie<SenderEventArgs<ISetBrowser<S, T>>>.GimmieSomethin MinimumLimitReached;

        public event Gimmie<SenderEventArgs<ISetBrowser<S, T>>>.GimmieSomethin MaximumLimitBreached;

        public event Gimmie<SenderEventArgs<ISetBrowser<S, T>>>.GimmieSomethin MinimumLimitBreached;

        public event Gimmie<SenderEventArgs<ISetBrowser<S, T>>>.GimmieSomethin LackingInContent;

        protected void OnMaximumLimitReached()
        {

            if (MaximumLimitReached != null)
                MaximumLimitReached(new SenderEventArgs<ISetBrowser<S, T>>(this));

        }

        protected void OnMinimumLimitReached()
        {

            if (MinimumLimitReached != null)
                MinimumLimitReached(new SenderEventArgs<ISetBrowser<S, T>>(this));

        }

        protected void OnMaximumLimitBreached()
        {

            if (MaximumLimitBreached != null)
                MaximumLimitBreached(new SenderEventArgs<ISetBrowser<S, T>>(this));

        }

        protected void OnMinimumLimitBreached()
        {

            if (MinimumLimitBreached != null)
                MinimumLimitBreached(new SenderEventArgs<ISetBrowser<S, T>>(this));

        }

        protected void OnLackingInContent()
        {

            if (LackingInContent != null)
                LackingInContent(new SenderEventArgs<ISetBrowser<S, T>>(this));

        }

        public bool HasContents()
        {

            if (MaximumIndex < MinimumIndex)
            {

                if (myCurrentIndex > -1)
                    myCurrentIndex = -1;

                OnLackingInContent();

                return false;

            } else if (myCurrentIndex == -1)
                myCurrentIndex = 0;

            return true;

        }

        public T Forward()
        {

            if (HasContents())
            {

                int next = myCurrentIndex + 1;

                if (next <= MaximumIndex)
                {

                    myCurrentIndex = next;

                    T item = mySet[myCurrentIndex];

                    if (myCurrentIndex == MinimumIndex)
                        OnMinimumLimitReached();

                    return item;

                } else
                {

                    if (mySet.Count < MinimumIndex)
                    {

                        myCurrentIndex = -1;

                    }


                    OnMaximumLimitBreached();

                }

            }

            return default(T);

        }

        public T Back()
        {

            if (HasContents())
            {


                int next = myCurrentIndex - 1;

                if (next >= MinimumIndex)
                {

                    myCurrentIndex = next;

                    T item = mySet[myCurrentIndex];

                    if (myCurrentIndex == MinimumIndex)
                        OnMinimumLimitReached();

                    return item;

                } else if (next < MinimumIndex)
                {

                    OnMinimumLimitBreached();

                }

            }

            return default(T);

        }

        public T First()
        {

            if (HasContents())
            {

                myCurrentIndex = MinimumIndex;

                T item = mySet[myCurrentIndex];

                OnMinimumLimitReached();

                return item;

            }

            return default(T);

        }

        public T Last()
        {

            if (HasContents())
            {

                myCurrentIndex = MaximumIndex;

                T item = mySet[MaximumIndex];

                OnMaximumLimitReached();

                return item;

            }

            return default(T);

        }

        public T Current()
        {
            if (HasContents())
            {

                return mySet[myCurrentIndex];

            }

            return default(T);

        }

        public T SkipTo(int Index)
        {

            if (HasContents())
            {

                if (Index <= MaximumIndex && Index >= MinimumIndex)
                {

                    myCurrentIndex = Index;

                    T item = mySet[myCurrentIndex];

                    if (myCurrentIndex == MinimumIndex)
                        OnMinimumLimitReached();
                    else if (myCurrentIndex == MaximumIndex)
                        OnMaximumLimitReached();

                    return item;

                }

            }

            return default(T);

        }

        public T SkipForward(int Ammount)
        {

            if (Ammount < 0)
                return SkipTo(myCurrentIndex + +Ammount);
            else if (Ammount > 0)
                return SkipTo(myCurrentIndex + Ammount);

            return mySet[myCurrentIndex];

        }

        public T SkipBackward(int Ammount)
        {

            if (Ammount < 0)
                return SkipTo(myCurrentIndex + Ammount);
            else if (Ammount > 0)
                return SkipTo(myCurrentIndex + -Ammount);

            return mySet[myCurrentIndex];


        }

        public bool PeepNext()
        {

            return (myCurrentIndex + 1) <= MaximumIndex;

        }

        public bool PeepPrevious()
        {

            return (myCurrentIndex - 1) >= MinimumIndex;

        }

        public int CurrentIndex
        {
            get
            {

                return myCurrentIndex;

            }
        }

        public int Count
        {

            get
            {

                return mySet.Count;

            }

        }


        public int MaximumIndex
        {
            get
            {

                return mySet.Count - 1;

            }
        }

        public int MinimumIndex
        {
            get
            {

                return 0;

            }
        }

        #endregion

    }

    public class CountableNameableIndexableBrowser<S, T> : CountableIndexableBrowser<S, T>, INamedSetBrowser<S, T> where S : ICountableNameableIndexable<T> where T : IReadonlyHasName 
    {

        public CountableNameableIndexableBrowser(S Set) : base(Set)
        {
        }

        public T SkipTo(string name)
        {

            int location = -1;

            if (HasContents())
            {

                foreach (T item in mySet)
                {
                    location++;

                    if (item.Name == name)
                    {

                        if (location == MinimumIndex)
                        {

                            OnMinimumLimitReached();

                        } else if (location == MaximumIndex)
                        {

                            OnMaximumLimitReached();

                        }

                        myCurrentIndex = location;

                        return item;
                        
                    }

                }

            }

            return default(T);

        }

    }
}
