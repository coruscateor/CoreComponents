
using System;
using CoreComponents.Items.Parameters;

namespace CoreComponents.Data.SQL
{
	
	
	public abstract class SQLQuery : SQLCommand
	{
		
		protected OptionalParamList myIncludeList;
		
		public SQLQuery()
		{
		}
		
	}
}
