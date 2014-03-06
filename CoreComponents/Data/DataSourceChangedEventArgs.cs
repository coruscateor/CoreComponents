
using System;

namespace CoreComponents.Data
{


	public class DataSourceChangedEventArgs<TSender, TDataSource> : SenderEventArgs<TSender>
	{

		TDataSource myDataSource;

        public DataSourceChangedEventArgs(TSender sender, TDataSource theDataSource)
            : base(sender)
		{

            myDataSource = theDataSource;

		}
		
		public TDataSource DataSource
		{
		
			get
			{
				
				return myDataSource;
				
			}
			
		}
		
	}
	
}
