
using System;
using System.Collections;
using System.Collections.Generic;

namespace CoreComponents.Items
{

    public class ParentedList<TParent, TChild> : RO_ParentedList<TParent, TChild>, IParentedList<TParent, TChild> where TChild : IChild<TParent>
	{

        public delegate void ChangeRangeEventArgsDelegate(ChangeRangeEventArgs<TChild, IParentedList<TParent, TChild>> Parameter);

        public delegate void SenderEventArgsDelegate(SenderEventArgs<IParentedList<TParent, TChild>> Parameter);

        public delegate void ChangeEventArgsDelegate(ChangeEventArgs<TChild, IParentedList<TParent, TChild>> Parameter);

        public delegate void IndexChangedEventArgsDelegate(IndexChangedEventArgs<IParentedList<TParent, TChild>, TChild> Parameter);

        //public event Gimmie<ChangeEventArgs<TChild, IParentedList<TParent, TChild>>>.GimmieSomethin Added;

        public event ChangeEventArgsDelegate Added;

        //public event Gimmie<ChangeEventArgs<TChild, IParentedList<TParent, TChild>>>.GimmieSomethin Adding;

        //public event Gimmie<ChangeEventArgs<TChild, IParentedList<TParent, TChild>>>.GimmieSomethin Removed;

        public event ChangeEventArgsDelegate Removed;

        //public event Gimmie<ChangeEventArgs<TChild, IParentedList<TParent, TChild>>>.GimmieSomethin Removing;

        //public event Gimmie<ChangeRangeEventArgs<TChild, IParentedList<TParent, TChild>>>.GimmieSomethin AddedSet;

        public event ChangeRangeEventArgsDelegate AddedSet;

        //public event Gimmie<ChangeRangeEventArgs<TChild, IParentedList<TParent, TChild>>>.GimmieSomethin AddingSet;

        //public event Gimmie<ChangeRangeEventArgs<TChild, IParentedList<TParent, TChild>>>.GimmieSomethin RemovedSet;

        public event ChangeRangeEventArgsDelegate RemovedSet;

        //public event Gimmie<ChangeRangeEventArgs<TChild, IParentedList<TParent, TChild>>>.GimmieSomethin RemovingSet;

        //public event Gimmie<SenderEventArgs<IParentedList<TParent, TChild>>>.GimmieSomethin Clearing;
        
        //public event Gimmie<SenderEventArgs<IParentedList<TParent, TChild>>>.GimmieSomethin Cleared;

        public event SenderEventArgsDelegate Cleared;

        //public event Gimmie<SenderEventArgs<IParentedList<TParent, TChild>>>.GimmieSomethin Sorting;

        //public event Gimmie<SenderEventArgs<IParentedList<TParent, TChild>>>.GimmieSomethin Sorted;

        public event SenderEventArgsDelegate Sorted;

        //public event Gimmie<IndexChangedEventArgs<IParentedList<TParent, TChild>, TChild>>.GimmieSomethin Inserting;

        //public event Gimmie<IndexChangedEventArgs<IParentedList<TParent, TChild>, TChild>>.GimmieSomethin Inserted;

        public event IndexChangedEventArgsDelegate Inserted;

        //public event Gimmie<IndexChangedEventArgs<IParentedList<TParent, TChild>, TChild>>.GimmieSomethin Extracting;

        //public event Gimmie<IndexChangedEventArgs<IParentedList<TParent, TChild>, TChild>>.GimmieSomethin Extracted;

        public event IndexChangedEventArgsDelegate Extracted;

        //public event Gimmie<ChangeEventArgs<TChild, IParentedList<TParent, TChild>>>.GimmieSomethin AddingNullError;

        public event ChangeEventArgsDelegate AddingNullError;

        TChild myItem; //Item I'm adding or removing.
		
		public ParentedList(TParent Parent) : base(Parent)
		{
		}

        //protected void OnAdding(TChild item)
        //{
        //    SetItem(item);

        //    if (Adding != null)
        //        Adding(new ChangeEventArgs<TChild, IParentedList<TParent, TChild>>(this, item));

        //}

        protected void OnAdded(TChild item)
        {

            UnSetItem();

            if (Added != null)
                Added(new ChangeEventArgs<TChild, IParentedList<TParent, TChild>>(this, item));

        }

        //protected void OnRemoving(TChild item)
        //{

        //    SetItem(item);

        //    if (Removing != null)
        //        Removing(new ChangeEventArgs<TChild, IParentedList<TParent, TChild>>(this, item));

        //}

        protected void OnRemoved(TChild item)
        {

            UnSetItem();

            if (Removed != null)
                Removed(new ChangeEventArgs<TChild, IParentedList<TParent, TChild>>(this, item));

        }


        protected void OnAddedSet(IEnumerable<TChild> items)
        {

            if (AddedSet != null)
                AddedSet(new ChangeRangeEventArgs<TChild, IParentedList<TParent, TChild>>(this, items));

        }

        //protected void OnAddingSet(IEnumerable<TChild> items)
        //{

        //    if (AddingSet != null)
        //        AddingSet(new ChangeRangeEventArgs<TChild, IParentedList<TParent, TChild>>(this, items));

        //}

        protected void OnRemovedSet(IEnumerable<TChild> items)
        {

            if (RemovedSet != null)
                RemovedSet(new ChangeRangeEventArgs<TChild, IParentedList<TParent, TChild>>(this, items));

        }

        //protected void OnRemovingSet(IEnumerable<TChild> items)
        //{

        //    if (RemovingSet != null)
        //        RemovingSet(new ChangeRangeEventArgs<TChild, IParentedList<TParent, TChild>>(this, items));

        //}

        //protected void OnClearing()
        //{

        //    if (Clearing != null)
        //        Clearing(new SenderEventArgs<IParentedList<TParent, TChild>>(this));

        //}

        protected void OnCleared()
        {

            if (Cleared != null)
                Cleared(new SenderEventArgs<IParentedList<TParent, TChild>>(this));

        }

        //protected void OnSorting()
        //{

        //    if (Sorting != null)
        //        Sorting(new SenderEventArgs<IParentedList<TParent, TChild>>(this));

        //}

        protected void OnSorted()
        {

            if (Sorted != null)
                Sorted(new SenderEventArgs<IParentedList<TParent, TChild>>(this));

        }


        //protected void OnInserting(TChild Item, int Index)
        //{

        //    if (Inserting != null)
        //        Inserting(new IndexChangedEventArgs<IParentedList<TParent, TChild>, TChild>(this, Item, Index));

        //}

        protected void OnInserted(TChild Item, int Index)
        {

            if (Inserted != null)
                Inserted(new IndexChangedEventArgs<IParentedList<TParent, TChild>, TChild>(this, Item, Index));

        }

        //protected void OnExtracting(TChild Item, int Index)
        //{

        //    if (Extracting != null)
        //        Extracting(new IndexChangedEventArgs<IParentedList<TParent, TChild>, TChild>(this, Item, Index));

        //}

        protected void OnExtracted(TChild Item, int Index)
        {

            if (Extracted != null)
                Extracted(new IndexChangedEventArgs<IParentedList<TParent, TChild>, TChild>(this, Item, Index));

        }

        protected void OnAddingNullError(TChild Item)
        {

            if (AddingNullError != null)
                AddingNullError(new ChangeEventArgs<TChild, IParentedList<TParent, TChild>>(this, Item));

        }

        public virtual void Insert(int index, TChild item)
        {

            //OnInserting(item, index);

            if (!item.Parent.Equals(Owner))
                item.Parent = Owner;

            myChildren.Insert(index, item);

            OnInserted(item, index);

        }

        public virtual void RemoveAt(int index)
        {

            TChild Item = myChildren[index];

            //OnExtracting(Item, index);

            Remove(Item);

            OnExtracted(Item, index);

            /*
            TChild item = myChildern[index];

            OnRemoving(item);

            item.Parent = null;

            myChildern.RemoveAt(index);

            OnRemoved(item);
             * */

        }

        public virtual new TChild this[int index]
        {
            get
            {

                return myChildren[index];

            }
            set
            {

                if (!object.Equals(value, default(TChild)))
                {

                    TChild item = myChildren[index];

                    Remove(item);

                    //OnAdding(value);

                    myChildren.Insert(index, value);

                    item.Parent = myOwner;

                    OnAdded(value);

                } else
                {

                    OnAddingNullError(value);

                }

            }

        }

        public virtual void Add(TChild item)
        {

            if (!object.Equals(item, default(TChild)))
            {

                //OnAdding(item);

                myChildren.Add(item);

                if (!object.Equals(item.Parent, myOwner))
                    item.Parent = Owner;

                OnAdded(item);

            } else
            {

                OnAddingNullError(item);

            }

        }

        public virtual void Clear()
        {

            //OnClearing();

            foreach (TChild Child in myChildren)
            {

                Remove(Child);

            }

            OnCleared();

        }

        public virtual bool Remove(TChild item)
        {

            if (!object.Equals(item, default(TChild)))
            {

                //OnRemoving(item);

                if (myChildren.Remove(item))
                {

                    if (object.Equals(item.Parent, myOwner))
                        item.Parent = default(TParent);

                    OnRemoved(item);

                    return true;
                }

            }

            return false;

        }

        public TChild FocusedChild() //The Item being added or removed.
        {

            //get
            //{

                return myItem;

            //}

        }

        void SetItem(TChild Item)
        {

            myItem = Item;

        }

        void UnSetItem()
        {

            myItem = default(TChild);

        }

        public virtual void AddRange(IEnumerable<TChild> items)
        {

            //OnAddingSet(items);

            foreach(TChild Child in items){

                Add(Child);

            }

            OnAddedSet(items);

        }

        public virtual void RemoveRange(int index, int count)
        {

           List<TChild> items = (List<TChild>)GetSetList(index, count);
           
           //OnRemovingSet(items);

           foreach(TChild Child in items)
           {

                Remove(Child);

            }
           
           OnRemovedSet(items);
           
        }

        public IEnumerable<TChild> GetSetList(int index, int count) {

            List<TChild> items = new List<TChild>();

            int LastLocation = index + count;

            for (int i = index; i <= LastLocation; i++)
                items.Add(myChildren[i]);

            return items;
        
        }

        public bool IsReadOnly
        {

            get
            {

                return false;

            }

        }

        public void Sort()
        {

            //OnSorting();

            myChildren.Sort();

            OnSorted();

        }

        public void Sort(Comparison<TChild> comparason)
        {

            //OnSorting();

            myChildren.Sort(comparason);

            OnSorted();

        }

        public void Sort(IComparer<TChild> comparer)
        {

            //OnSorting();

            myChildren.Sort(comparer);

            OnSorted();

        }

        public void Sort(int index, int count, IComparer<TChild> comparer)
        {

            //OnSorting();

            myChildren.Sort(index, Count, comparer);

            OnSorted();

        }

        /*
        public void MatchList(ICollection<IROHasItem<TChild>> List)
        {
        }
        
        public void MatchList(ICollection List)
        {
        }
        
        */

        /*
        public static implicit operator ParentedList<TParent, TChild>(IParentedList<TParent, TChild> AList)
        {
            return (ParentedList<TParent, TChild>)AList;
        }
        */

		/*
        public void Reverse()
        {
            myChildern.Reverse();
        }

        public void Reverse(int index, int count)
        {
            myChildern.Reverse(index, count);
        }
		*/
		/*
        public IList<T> RetriveReversed()
        {

            List<T> NewList = new List<T>(myChildern);

            NewList.Reverse();

            return NewList;

        }

        public IList<T> RetriveReversed(int index, int count)
        {

            List<T> NewList = new List<T>(myChildern);

            NewList.Reverse(index, count);

            return NewList;
        }
		*/
		/*
        public void RemoveAll(Predicate<T> match)
        {
            myChildern.RemoveAll(match);
        }
        */
	}
}
