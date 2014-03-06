using System;
using System.Data;
using System.Data.Common;
using Npgsql;

namespace CoreComponents.Data.Npgsql.WorkAround
{
	//Works-around the database connection class in Mono Npgsql assembly not inheriting DbConnection.
	
	public class NpgsqlConnectionWrapper : DbConnection, ICloneable 
	{
		
		NpgsqlConnection myNpgsqlConnection;
		
		public NpgsqlConnectionWrapper()
		{
			
			myNpgsqlConnection = new NpgsqlConnection();
			
		}
		
		public NpgsqlConnectionWrapper(bool initalise)
		{
			
			if (initalise)
				myNpgsqlConnection = new NpgsqlConnection();
			
		}
		
		public NpgsqlConnectionWrapper(string ConnectionString)
		{
			
			myNpgsqlConnection = new NpgsqlConnection(ConnectionString);
			
		}
		
		public NpgsqlConnection TheNpgsqlConnection
		{
			
			get {
				
				return myNpgsqlConnection;
				
			} 
			set {
				
				myNpgsqlConnection = value;
				
			}
			
		}
		
		public object Clone()
		{
			
			return myNpgsqlConnection.Clone();
			
		}
		
		public override DataTable GetSchema()
		{
			
			return myNpgsqlConnection.GetSchema();
			
		}
		
		public override void Open()
		{
			
			myNpgsqlConnection.Open();
			
		}
		
		public override void Close()
		{
			
			myNpgsqlConnection.Close();
			
		}

		protected override DbCommand CreateDbCommand()
		{
			
			return null;
			
		}
		
		public override void ChangeDatabase(string databaseName)
		{
			
			myNpgsqlConnection.ChangeDatabase(databaseName);
			
		}
		
		protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel)
		{
			
			return null;
			
		}
		
		public override ConnectionState State { 
			
			get
			{
				
				return myNpgsqlConnection.State;
				
			} 
		
		}
		
		public override string ServerVersion 
		{
			
			get
			{
				
				return myNpgsqlConnection.ServerVersion.ToString();
				
			}
		
		}
		
		public override string DataSource 
		{
			
			get
			{
				
				return " ";
				
			}
			
		}
		
		public override string Database 
		{
			
			get
			{
				
				return myNpgsqlConnection.Database;
				
			}
			
		}
		
		public override string ConnectionString 
		{
			
			get
			{
				
				return myNpgsqlConnection.ConnectionString;
				
			}
			
			set
			{
				
				myNpgsqlConnection.ConnectionString = value;
				
			}
			
		}
	}
	
	//Use "abstract" instead of "virtual" to make inheritance compusory. 
}