using System;
using System.Collections.Generic;
using System.Data.Common;
using CoreComponents;
using CoreComponents.Data;
using CoreComponents.Caching;

namespace CoreComponents.Data.Schema
{

	public class DbPrimaryKey : DbEntity
	{

		List<DbColumn> myList = new List<DbColumn>();
		
		public DbPrimaryKey()
		{
		}
		
		public bool IsUnique { get; set; }
		
		
		public List<DbColumn> List
		{
			
			get
			{
				return myList;
			}
			
		}
		
	}

	public class DbPrimaryKeyList
	{
		
		List<DbPrimaryKey> myList = new List<DbPrimaryKey>();

		public DbPrimaryKeyList()
		{
		}
		
		public List<DbPrimaryKey> List
		{
			
			get
			{
				return myList;
			}
			
		}
		
	}
}
