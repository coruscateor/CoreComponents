
using System;

namespace CoreComponents.Items
{
	
	
	public class AddingRemovingIndicator
	{
		
		bool myIsRemoving;
		
		bool myIsAdding;
		
		public AddingRemovingIndicator()
		{
		}
		
		public void Removing()
		{
			myIsRemoving = true;
		}
		
		public void Removed()
		{
			myIsRemoving = false;
		}
		
		public void Adding()
		{
			myIsAdding = true;
		}
		
		public void Added()
		{
			myIsAdded = false;
		}
		
		public void IsRemoving
		{
			get
			{
				
				return myIsRemoving;
				
			}
		}
		
		public void IsAdding
		{
			get
			{
				
				return myIsAdding;
				
			}
		}

	}
}
