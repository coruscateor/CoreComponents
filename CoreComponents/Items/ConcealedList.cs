
using System;
using System.Collections;
using System.Collections.Generic;

namespace CoreComponents.Items
{

	public abstract class ConcealedList<TItem> : IConcealedList<TItem>
	{
		
		protected List<TItem> myChildren;

		public ConcealedList()
		{
			
			Initalise();
			
		}
		
		public ConcealedList(List<TItem> Children)
		{

            myChildren = Children;
			
		}
		
		protected void Initalise()
		{

            myChildren = new List<TItem>();
			
		}

        /*
        public int this[TItem item]
        {
            get
            {
                return myChildren[item];
            }
        }
        */

        public TItem this[int index]
        {
			
            get
            {

                return myChildren[index];
				
            }
			
        }

		public bool Contains(TItem item)
        {

            return myChildren.Contains(item);
			
        }

        public void CopyTo(TItem[] array, int arrayIndex)
        {

            myChildren.CopyTo(array, arrayIndex);
			
        }
		
		public int IndexOf(TItem item)
        {

            return myChildren.IndexOf(item);

        }
		
		public int Count
        {
            get
            {

                return myChildren.Count;
				
            }
        }
		
		public IEnumerator<TItem> GetEnumerator()
        {

            return myChildren.GetEnumerator();
			
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {

            return myChildren.GetEnumerator();
			
        }
		
		
	}
}
