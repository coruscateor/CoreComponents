using System;
using System.Text;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace CoreComponents.Data
{
	
	public interface IDataExtractor
	{

        event Gimmie<SenderExceptionEventArgs<IDataExtractor, Exception>>.GimmieSomethin ReadException;

        event Gimmie<SenderExceptionEventArgs<IDataExtractor, Exception>>.GimmieSomethin CountException;
		
		IDataReader Next();
		
		string TableName
		{
			
			get;
			
		}
		
		int Count
		{
			
			get;
			
		}
		
	}
	
	public abstract class DataExtractor : IDataExtractor
	{

        public event Gimmie<ExceptionEventArgs<IDataExtractor, Exception>>.GimmieSomethin ReadException;

        public event Gimmie<ExceptionEventArgs<IDataExtractor, Exception>>.GimmieSomethin CountException;

        public event Gimmie<SenderEventArgs<IDataExtractor>>.GimmieSomethin ReadComplete;

        protected SenderEventArgs<IDataExtractor> myReadCompleteEventArgs;

		protected DbCommand myCommand;
		
		protected DbCommand myCountCommand;
		
		protected int myCount;
		
		protected string myTableName;

        public DataExtractor(string TableName)
		{
			
			myTableName = TableName;

            myReadCompleteEventArgs = new SenderEventArgs<IDataExtractor>(this);
			
		}

        protected void OnReadComplete()
        {

            if (ReadComplete != null)
                ReadComplete(myReadCompleteEventArgs);

        }

		
		protected void OnReadException(Exception e)
		{
			
			if(ReadException != null)
                ReadException(new ExceptionAndMessageEventArgs<IDataExtractor, Exception>(this, e, e.Message));
			
		}

        protected void OnCountException(Exception e)
        {

            if (CountException != null)
                CountException(new ExceptionAndMessageEventArgs<IDataExtractor, Exception>(this, e, e.Message));

        }
		
		public abstract IDataReader Next();

        public virtual string CountCommand()
        {

            StringBuilder SB = new StringBuilder();

            SB.Append("SELECT count(*) FROM ");

            SB.Append(myTableName);

            SB.Append(";");

            return SB.ToString();

        }

        public abstract string SelectCommand();

        public void RefreshCount()
        {

            try
            {

                myCountCommand.Connection.Open();

                myCount = (int)myCountCommand.ExecuteScalar();

            } catch (Exception e)
            {

                OnCountException(e);

            } finally
            {

                myCountCommand.Connection.Close();

            }

        }

        public virtual string TableName
        {

            get
            {

                return myTableName;

            }

        }

        public virtual int Count
        {

            get
            {
                return myCount;
            }

        }
		
	}

    public abstract class IncrementalDataExtractor : DataExtractor
	{
		
		protected int myIncrement;
		
		protected int myCurrentIncrement;
		
		public IncrementalDataExtractor(string TableName) : base(TableName)
		{
			
		}
		
		public override string SelectCommand()
		{
			
			StringBuilder SB = new StringBuilder();
			
			SB.Append("SELECT * FROM ");
			
			SB.Append(myTableName);
			
			SB.Append("LIMIT ");
			
			SB.Append(myIncrement);
			
			SB.Append(" OFFSET ");
			
			SB.Append(myCurrentIncrement);
			
			SB.Append(";");
			
			return SB.ToString();
			
		}
		
		public override IDataReader Next()
		{

            if (myCurrentIncrement <= myCount)
            {

                IDataReader Reader = null;

                try
                {

                    myCommand.Connection.Open();

                    Reader = myCommand.ExecuteReader();

                    myCurrentIncrement += myIncrement;

                    myCommand.CommandText = SelectCommand();

                } catch (Exception e)
                {

                    OnReadException(e);

                } finally
                {

                    myCommand.Connection.Close();
                }


                return Reader;

            } 
            else
            {

                OnReadComplete();

            }
			
			return null;
			
		}
		
		public virtual int Increment
		{
			
			get
			{
				
				return myIncrement;
				
			}
			
			set
			{
				
				myIncrement = value;

                myCommand.CommandText = SelectCommand();

			}
			
		}


	}
}
