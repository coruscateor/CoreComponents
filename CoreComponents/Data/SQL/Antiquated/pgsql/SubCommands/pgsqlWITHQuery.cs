
using System;
using System.Text;
using CoreComponents.Items;

namespace CoreComponents.Data.SQL.pgsql.SubCommands
{
	
	public class pgsqlWITHQuery : SQLQuery
	{
		
		//string myName;
		
		bool myHasBeenDefined;
		
		SubscribeableList<string> myColumnDefinitions;
		
		SQLExpression mySQLExpression;
		
		public pgsqlWITHQuery()
		{
			
			myColumnDefinitions = new SubscribeableList<string>();
			
		}
		
        public new string Name
        {
            get
            {

                return myName;

            }
            set
            {

                myName = value;

            }
        }
		
		public virtual bool HasBeenDefined
		{
			get
			{
				return myHasBeenDefined;
			}

		}
		
		public SQLExpression SQLExpression
		{
			
			get
			{
				
				return mySQLExpression;
				
			}
			set
			{
				
				mySQLExpression = value;
				
			}
			
		}
		
		public void Reset()
		{
			
			if (myHasBeenDefined)
				myHasBeenDefined = false;
			
		}
		
		protected override void Append(StringBuilder SB)
		{
			
			if(HasBeenDefined) {
			
				SB.Append(myName);
			
				return;
				
			}
			
			SB.Append(myName);
			
			if (myColumnDefinitions.Count > 0) {
			
				int Loc = 1;
			
				SB.Append("( ");
				
				foreach(string Def in myColumnDefinitions)
				{
				
					SB.Append(Def);
				
					if (Loc < myColumnDefinitions.Count)
					{
					
						SB.Append(", ");
					
						SB.Append(Def);
					
						Loc++;
					
					}
				
				}
				
				SB.Append(" )");
				
			}
			
			SB.Append(" AS (");
			
			mySQLExpression.AppendTo(SB);

			SB.AppendLine(") ");
			
			myHasBeenDefined = true;
		
		}
		
	}
}
