using System;
using System.Collections.Generic;
using System.Data.Common;
using CoreComponents;
using CoreComponents.Data;
using CoreComponents.Items;

namespace CoreComponents.Data.SchemaAndStatements
{

	public class DbForignKey : DbEntity
	{
		
		//List<DbColumn> myList = new List<DbColumn>();
		
		DbColumn myForignKey;
	
		public DbForignKey()
		{
		}
		
		public DbColumn ForignKey
		{
			
			set
			{
				
				myForignKey = value;
				
			}
			get
			{
				
				return myForignKey;
				
			}
			
		}
		
		/*
		public List<DbColumn> List
		{
			
			get
			{
				return myList;
			}
			
		}*/
		
	}
	

	public class DbForignKeyList
	{

		List<DbForignKey> myList = new List<DbForignKey>();
		
		public DbForignKeyList()
		{
		}
		
		public List<DbForignKey> List
		{
			
			get
			{
				return myList;
			}
			
		}
	}
}
