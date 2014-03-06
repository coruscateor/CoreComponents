
using System;

namespace CoreComponents.Items
{
	
	public class ParentedListManager<TParent, TList>
	{
		
		IParentedList<TParent, TList> myList;
		
		TParent myDirectRefParent;
		
		public ParentedListManager(TParent DirectRefParent, IParentedList<TParent, TList> List)
		{
			if (DirectRefParent != null)
			{
			
				myList = List;
				
				myDirectRefParent = DirectRefParent;
				
			}
			
		}
		
		public void Subscribe(TParent DirectRefParent, IParentedList<TParent, TList> List)
		{
			
			UnSubscribe();

			
		}
		
		public void UnSubscribe()
		{
			
			if(myList != null)
			{
				myList = null;
				
				myDirectRefParent = default(TParent);
			}
			
		}
		
		public TParent DirectRefParent
		{
			get
			{
				return myDirectRefParent;
			}
		}
		
		public IParentedList<TParent, TList> List
		{
			
			get
			{
				return myList;
			}
			
		}
		
		public bool Verfy()
		{
			
			if(myList.Parent != myDirectRefParent)
			{
				
				UnSubscribe();
				
				return false;
				
			}
			
			return true;
			
		}
	}
}
