
using System;

namespace CoreComponents.Data.SQL
{
	
	public abstract class SQLArgument<T> : SQLExpression
	{
		
		T myType;
		
		string myArgumentName;
		
		public SQLArgument()
		{
		}
		
		public T Type
		{
			
			get
			{
				return myType; 
			}
			set
			{
				myType = value;
			}
			
		}
		
		public string ArgumentName
		{
			
			get
			{
				return myArgumentName; 
			}
			set
			{
				myArgumentName = value;
			}
			
		}	
		
	}
}
