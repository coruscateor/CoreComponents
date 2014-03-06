
using System;
using System.Collections;
using System.Collections.Generic;

namespace CoreComponents.Items
{
	
	//Stores children on behalf of the parent.
	
	public class RO_ParentedList<TParent, TChild> : ConcealedList<TChild>, IRO_ParentedList<TParent, TChild> where TChild : IChild<TParent>
	{
		
		protected TParent myOwner;

        public RO_ParentedList(TParent Owner)
		{

            myOwner = Owner;
			
			Initalise();
			
		}

        public TParent Owner
		{
			get
			{
                return myOwner;
			}
		}
		
	}
}
