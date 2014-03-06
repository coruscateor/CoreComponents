
using System;

namespace CoreComponents.Data.Schema
{
	
	public interface IAmOwned
	{
		
		DbOwner Owner
        {

            get;
            set;

        }
		
		bool HasOwner();
		
	}
	
}
