using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Items
{

    public class ItemsTraverser<T> : IItemsTraverser<T>
    {

        public event Event<ItemsTraverser<T>> PlaceChanged;

        public event Event<ItemsTraverser<T>> ItemsChanged;

        protected T[] myItems;

        protected long myIndex;

        protected T myCurrentItem;

        protected PlaceMessageText myPlaceMessageText = PlaceMessageText.OutOf;

        public ItemsTraverser()
        {

            SetPlaceAndCurrentItem();

        }

        public ItemsTraverser(IEnumerable<T> TheItems)
        {

            myItems = TheItems.ToArray();

            SetPlaceAndCurrentItem();

        }

        public ItemsTraverser(List<T> TheItems)
        {

            myItems = TheItems.ToArray();

            SetPlaceAndCurrentItem();

        }

        public ItemsTraverser(Queue<T> TheItems)
        {

            myItems = TheItems.ToArray();

            SetPlaceAndCurrentItem();

        }

        public ItemsTraverser(Stack<T> TheItems)
        {

            myItems = TheItems.ToArray();

            SetPlaceAndCurrentItem();

        }

        public ItemsTraverser(T[] TheItems)
        {

            myItems = (T[])TheItems.Clone();

            SetPlaceAndCurrentItem();

        }

        protected void OnPlaceChanged()
        {

            if(PlaceChanged != null)
                PlaceChanged(this);

        }

        protected void OnItemsChanged()
        {

            if(ItemsChanged != null)
                ItemsChanged(this);

        }

        protected void SetPlaceAndCurrentItem()
        {

            if(myItems != null && myItems.Length > 0)
            {

                if(myIndex != 0)
                    myIndex = 0;

                myCurrentItem = myItems[myIndex];

            }
            else
            {

                myIndex = -1;

                myCurrentItem = default(T);

            }

        }

        public T[] ToArray()
        {

            return (T[])myItems.Clone();

        }

        public long Count
        {

            get
            {

                return myItems.LongLength;

            }

        }

        public long Index
        {

            get
            {

                return myIndex;

            }

        }

        public long Place
        {

            get
            {

                return myIndex + 1;

            }

        }

        public bool HasValidIndex
        {

            get
            {

                return myIndex > -1;

            }

        }

        public T CurrentItem
        {

            get
            {

                return myCurrentItem;

            }

        }

        public bool HasItems
        {

            get
            {

                return myItems != null && myItems.Length > 0;

            }

        }

        public bool Next()
        {

            unchecked
            {

                long NextIndex = myIndex + 1;

                if(NextIndex < myItems.LongLength)
                {

                    myCurrentItem = myItems[NextIndex];

                    myIndex = NextIndex;

                    OnPlaceChanged();

                    return true;

                }

            }

            return false;

        }

        public bool Previous()
        {

            if(myIndex > 0)
            {

                myIndex--;

                myCurrentItem = myItems[myIndex];

                OnPlaceChanged();

                return true;

            }

            return false;

        }

        public void First()
        {

            if(myIndex != 0)
            {

                myIndex = 0;

                myCurrentItem = myItems[myIndex];

                OnPlaceChanged();

            }

        }

        public void Last()
        {

            int LastPlace = myItems.Length - 1;

            if(myIndex != LastPlace)
            {

                myIndex = LastPlace;

                myCurrentItem = myItems[myIndex];

                OnPlaceChanged();

            }

        }

        public bool SkipTo(int ThePlace)
        {

            if(ThePlace < myItems.Length && ThePlace > 0)
            {

                myIndex = ThePlace;

                myCurrentItem = myItems[myIndex];

                OnPlaceChanged();

                return true;

            }

            return false;

        }

        public bool SkipTo(long ThePlace)
        {

            if(ThePlace < myItems.LongLength && ThePlace > 0)
            {

                myIndex = ThePlace;

                myCurrentItem = myItems[myIndex];

                OnPlaceChanged();

                return true;

            }

            return false;

        }

        public bool IsAtBeginning
        {

            get
            {

                return myIndex == 0;

            }

        }

        public bool IsAtEnd
        {

            get
            {

                return myIndex == myItems.Length - 1;

            }

        }

        protected void Reset()
        {

            if(myItems != null && myItems.Length > 0)
            {

                if(myIndex != 0)
                    myIndex = 0;

                myCurrentItem = myItems[myIndex];

                OnPlaceChanged();

            }
            else
            {

                myIndex = -1;

                myCurrentItem = default(T);

            }

        }

        protected void SetItemsArray(T[] ItemsArray)
        {

            myItems = ItemsArray;

            Reset();

            OnItemsChanged();

            //if (ItemsArray.Length > 0)
            //{

            //    myItems = ItemsArray;

            //    Reset();

            //}
            //else
            //{

            //    myIndex = 0;

            //    myCurrentItem = default(T);

            //}

        }

        public void SetItems(IEnumerable<T> TheItems)
        {

            SetItemsArray(TheItems.ToArray());

        }

        public void SetItems(T[] TheItems)
        {

            SetItemsArray((T[])TheItems.Clone());

        }

        public void SetItems(List<T> TheItems)
        {

            SetItemsArray(TheItems.ToArray());

        }

        public void SetItems(Queue<T> TheItems)
        {

            SetItemsArray(TheItems.ToArray());

        }

        public void SetItems(Stack<T> TheItems)
        {

            SetItemsArray(TheItems.ToArray());

        }

        public void SetEmpty()
        {

            if(myItems.Length > 0)
            {

                SetItemsArray(new T[0]);

            }

        }

        //public void RemoveItems()
        //{

        //    if(myItems.Length > 0)
        //    {

        //        myItems = new T[0];

        //        Reset();

        //        OnItemsChanged();

        //    }

        //}

        public PlaceMessageText PlaceMessageText
        {

            get
            {

                return myPlaceMessageText;

            }
            set
            {

                myPlaceMessageText = value;

            }

        }

        public string GetMessage()
        {

            unchecked
            {

                switch(myPlaceMessageText)
                {

                    case PlaceMessageText.Of:
                        return Place + " of " + myItems.LongLength;
                    case PlaceMessageText.OutOf:
                        return Place + " out of " + myItems.LongLength;
                    case PlaceMessageText.Slash:
                        return Place + " / " + myItems.LongLength;

                }

            }

            return string.Empty;

        }

    }

    public enum PlaceMessageText
    {

        Of,
        OutOf,
        Slash

    }

}
