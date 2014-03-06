using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using CoreComponents;
using CoreComponents.Items;

#pragma warning disable 0162

namespace CoreComponents.Data
{
	
	public enum RetrievalType
	{
		
		Table,
		NonQuery,
		Scalar,
		DataReader,
		DataReaderCB
		
	}
	
	public interface ITransactorQuery
	{
		
		int CommandTimeOut
        {
			
            get;
            set;

        }
				
		string CommandText
		{
			
			get;
			set;
			
		}
		
		
		CommandType CommandType
		{
			
			get;
			set;
			
		}
		
		CommandBehavior CommandBehavior
		{
			
			get;
			set;
			
		}
		
		RetrievalType RetrievalType
		{
			
			get;
			set;

		}
		
		void Execute();
		
		object Result
		{
			get;
		}
		
		T GetResult<T>();
		
	}
	
	public interface IChildTransactorQuery<TParent> : ITransactorQuery, IChild<TParent> where TParent : ITransactor
	{
		
	}

	public abstract class TransactorQuery<TParent> : IChildTransactorQuery<TParent>, IChild<TParent>
		where TParent : ITransactor
	{
		
		protected DbCommand myCommand;

        protected DbDataAdapter myDataAdapter;
		
		protected object myResult;
		
		//protected CallMe myExecute;
		
		protected RetrievalType myRetrievalType;
		
		protected CommandBehavior myCommandBehavior = CommandBehavior.Default;
		
		protected ChildToParentAdapter<TParent, IChildTransactorQuery<TParent>, IParentedList<TParent, IChildTransactorQuery<TParent>>> myAdapter;
		
		
		public TransactorQuery()
		{
			
			myExecute = GetTable;
			
			myAdapter = new ChildToParentAdapter<TParent, IChildTransactorQuery<TParent>, IParentedList<TParent, IChildTransactorQuery<TParent>>>(this, "CommandList");  //(IChild<TParent>)

		}
		
		public TransactorQuery(DbCommand Command)
		{
			
			myCommand = Command;
			
			myExecute = GetTable;
			
			myAdapter = new ChildToParentAdapter<TParent, IChildTransactorQuery<TParent>, IParentedList<TParent, IChildTransactorQuery<TParent>>>(this, "CommandList");  //(IChild<TParent>)
			

		}
		
		public TransactorQuery(DbCommand Command, TParent TheParent)
		{
			
			myCommand = Command;
		
			Parent = TheParent;
			
			myExecute = GetTable;
			
			myAdapter = new ChildToParentAdapter<TParent, IChildTransactorQuery<TParent>, IParentedList<TParent, IChildTransactorQuery<TParent>>>(this, "CommandList");  //(IChild<TParent>)
			

		}
		
		public TParent Parent
        {

            get
			{
				
				return myAdapter.OwnersParent;
				
			}
            set
			{
				
				myAdapter.SetParent(value);
				
				myCommand.Connection = value.Connection;
				
			}

        }

        public bool IsOrphin()
		{
			
			return myAdapter.OwnerIsOrphin();
			
		}

        public int CommandTimeOut
        {


            get
            {

                return myCommand.CommandTimeout;

            }
            set
            {

                myCommand.CommandTimeout = value;

            }

        }
				
		public string CommandText
		{
			
			get
			{
				return myCommand.CommandText;
			}
			set
			{
				myCommand.CommandText = value;
			}
			
		}
		
		
		public CommandType CommandType
		{
			
			get
			{
				
				return myCommand.CommandType;
				
			}
			set
			{
				
				myCommand.CommandType = value;
				
			}
			
		}
		
		public CommandBehavior CommandBehavior
		{
			
			get
			{
				return myCommandBehavior;
			}
			
			set
			{
				myCommandBehavior = value;
			}
			
		}
		
		public RetrievalType RetrievalType
		{
			
			get
			{
				
				return myRetrievalType;
				
			}
			set
			{
				
				switch (value)
				{
					
					case RetrievalType.DataReader:
				
						myExecute = GetDataReader;
					
						break;
					
					case RetrievalType.DataReaderCB:
				
						myExecute = GetDataReaderCB;
					
						break;
					
					case RetrievalType.NonQuery:
					
						myExecute = ExecuteNonQuery;
					
						break;
					
					case RetrievalType.Scalar:
					
						myExecute = ExecuteScalar;
					
						break;
					
					case RetrievalType.Table:
					
						myExecute = GetTable;
					
						break;
				}
				
				myRetrievalType = value;
				
			}
		}
		
		public void Execute()
		{
			
			myExecute();
			
		}

        protected void GetTable()
        {
            
            try
            {
				
				//myResult = null;
				
				myResult = new DataTable();

                myDataAdapter.Fill((DataTable)myResult);

            } catch (Exception ex)
            {

                throw new Exception("GetDataTable: " + ex.Message, ex);

            }

        }

        protected void ExecuteNonQuery()
        {


            try
            {
				
			   //myResult = null;

               myResult = myCommand.ExecuteNonQuery();


            } catch (Exception ex)
            {

                throw new Exception("NonQueryfail: " + ex.Message, ex);

            }

        }

        protected void ExecuteScalar()
        {

            try
            {
				
				//myResult = null;

                myResult = myCommand.ExecuteScalar();


            } catch (Exception ex)
            {

                throw new Exception("NonQueryfail: " + ex.Message, ex);

            }

        }
		
		protected void GetDataReader()
        {

            try
            {

                myResult = myCommand.ExecuteReader();

            } catch (Exception ex)
            {

                throw new Exception("GetDataReader: " + ex.Message, ex);

            }

        }
		
		protected void GetDataReaderCB()
        {

            try
            {

                myResult = myCommand.ExecuteReader(myCommandBehavior);

            } catch (Exception ex)
            {

                throw new Exception("GetDataReaderCB: " + ex.Message, ex);

            }

        }
		
		public object Result
		{
			
			get
			{
				
				return myResult;
				
			}
			
		}
		
		public T GetResult<T>()
		{
			
			return (T)myResult;
			
		}
	}
}
