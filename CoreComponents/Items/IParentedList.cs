
using System;
using System.Collections;
using System.Collections.Generic;

namespace CoreComponents.Items
{
	
	public interface IConcealedList<TItem> : IEnumerable<TItem>
	{
		
				/*
		int this[TChild item]
        {
            get;
        }
         * */

        TItem this[int index]
        {
            get;
        }

        bool Contains(TItem item);

        void CopyTo(TItem[] array, int arrayIndex);

        int IndexOf(TItem item);
		
		int Count
        {
            get;
        }
		
	}	

	public interface IRO_ParentedList<TParent, TChild> : IConcealedList<TChild> //, IChild<TParent>
	{

        TParent Owner
		{
			get;
		}
		
	}

    public interface IParentedList<TParent, TChild> : IRO_ParentedList<TParent, TChild>, IList<TChild>
	{
		
		//event Gimmie<ChangeEventArgs<TChild, IParentedList<TParent, TChild>>>.GimmieSomethin Added;

        //event Gimmie<ChangeEventArgs<TChild, IParentedList<TParent, TChild>>>.GimmieSomethin Adding;

        //event Gimmie<ChangeEventArgs<TChild, IParentedList<TParent, TChild>>>.GimmieSomethin Removed;

        //event Gimmie<ChangeEventArgs<TChild, IParentedList<TParent, TChild>>>.GimmieSomethin Removing;

        //event Gimmie<SenderEventArgs<IParentedList<TParent, TChild>>>.GimmieSomethin Clearing;

        //event Gimmie<SenderEventArgs<IParentedList<TParent, TChild>>>.GimmieSomethin Cleared;
		
        /*
        void Insert(int index, T item);

        void RemoveAt(int index);
        */

        new TChild this[int index]
		{
			get;
			set;
		}
		
        new void Add(TChild item);

        new void Clear();

        new bool Remove(TChild item);

        void RemoveRange(int index, int count);

        TChild FocusedChild();
		
		/*
        TChild FocusedChild
        {

            get;

        }
        */
		
	}
}
