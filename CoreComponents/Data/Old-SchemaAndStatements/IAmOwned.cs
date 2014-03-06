
using System;

namespace CoreComponents.Data.SchemaAndStatements
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
