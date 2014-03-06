using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Data.SQL
{
	
    public class SQLAlias : SQLExpression
    {

        //string myName;
		
		bool myHasBeenDefined;
		
		SQLExpression mySQLExpression; 

        public SQLAlias(string AliasName)
        {
			
			myName = AliasName;
			
        }

        //public string Name
        //{
        //    get
        //    {

        //        return myName;

        //    }
        //    set
        //    {

        //        myName = value;

        //    }
        //}
		
		public SQLExpression Expression {
			
			get
			{
				
				return mySQLExpression;
				
			}
			set
			{

                if (!IsAlias(value))
                {

                    mySQLExpression = value;

                    if (myHasBeenDefined)
                    {

                        myHasBeenDefined = false;

                    }

                }

			}
			
		}
		
		protected bool IsAlias(SQLExpression TheExpression)
		{
		
			return TheExpression is SQLAlias;
			
		} 
		
		protected override void Append(StringBuilder SB)
		{
			if(HasBeenDefined) {
			
				SB.Append(myName);
			
				return;
			}
			
			mySQLExpression.AppendTo(SB);
						
			SB.Append(" AS ");
					
			SB.Append(myName);
					
			//SB.Append(" ");
						
			myHasBeenDefined = true;
			
		}
		
		public virtual bool HasBeenDefined
		{
			get
			{
				return myHasBeenDefined;
			}

		}
		
		public void Reset()
		{
			
			if (myHasBeenDefined)
				myHasBeenDefined = false;
			
		}

    }

}
