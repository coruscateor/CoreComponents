using System;
using System.Data.Common;
using CoreComponents;
using CoreComponents.Data;
using CoreComponents.Items;

namespace CoreComponents.Data
{

	public interface ITransactor //: IParent<TChildList> 
	{
		
		DbConnection Connection
		{
			
			get;
			
		}
		
		void Execute();
		
		bool IsActive
		{
			
			get;
			
		}
		
	}
	
	public interface ITransactor<TParent, TChild>  : ITransactor where TChild : IChild<TParent>
	{
	
		ParentedList<TParent, TChild> CommandList
		{
			
			get;
			
		}
		
		
	}
	

	public abstract class Transactor<TParent, TChild> : ITransactor 
		where TParent : ITransactor
		where TChild : IChildTransactorQuery<TParent>
	{

		protected DbConnection myConnection;
		
		protected DbTransaction myTransaction;
		
		protected bool myIsActive;
		
		protected ParentedList<TParent, TChild> myCommandList;
		
		public Transactor(DbConnection Connection)
		{
			
			myConnection = Connection;
			
		}
		
		//CALL THIS!!!!!
		protected void InitaliseList(ParentedList<TParent, TChild> CommandList, TParent Parent) //where TChild : IChild<TParent>
		{
			
			CommandList = new ParentedList<TParent, TChild>(Parent);
			
		}
		
		public ParentedList<TParent, TChild> CommandList
		{
			
			get
			{
				return myCommandList;
			}
			
		}
		
		public bool IsActive
		{
			
			get
			{
				
				return myIsActive;
				
			}
			
		}
		
		void Active()
		{
			
			myConnection.Open();
			
			myIsActive = true;
			
		}
		
		void InActive()
		{
			
			myConnection.Close();
			
			myIsActive = false;
			
		}
		
		public void Execute()
		{
			
			if(!myIsActive)
			{
				
				lock(myCommandList) {
			
					try {
			
						Active();
				
						myTransaction = myConnection.BeginTransaction();
						
						foreach(TChild Statement in myCommandList)
						{
					   
					   		Statement.Execute();
					   
						}
						
						Commit();
						
					} catch(Exception e)
					{
						
						RollBack();
						
						throw new Exception("Transaction failure: " + e.Message, e);
						
					}
					
				}
				
			}
			
		}
		
		void Commit()
		{
		
			myTransaction.Commit();
			
			InActive();
			
		}
		
		void RollBack()
		{
			

			myTransaction.Rollback();
			
			InActive();
			
		}
		
		
		public DbConnection Connection
		{
			
			get
			{
				
				if(!myIsActive) {
				
					return myConnection;
				}
				
				return null;
				
			}
		}
		
	}
}
