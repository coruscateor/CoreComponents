using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Text;

namespace CoreComponents.Data.SQL
{
    public abstract class SQLExpression : TextEntity
    {
		/*
		string myAlias;
		
		bool myUsesAlias;
		
		bool myHasUsedAlias;
		
		public event Gimmie<ChangeEventArgs<string, SQLExpression>>.GimmieSomethin ChangingAlias;
		
		public event Gimmie<SenderEventArgs<SQLExpression>>.GimmieSomethin ChangedAlias;
		*/

        protected string myName;

		public SQLExpression()
		{
			
		}

        public virtual string Name
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

		/*
		void OnChangingAlias(string NewAlias)
		{
			
			if(ChangingAlias != null)
				ChangingAlias(new ChangeEventArgs<string, SQLExpression>(this, NewAlias));
				              
		}
		
		void OnChangedAlias()
		{
					
			if(ChangedAlias != null)
				ChangedAlias(new SenderEventArgs<SQLExpression>(this));
						             
		}
		
		public string Alias
		{
			get
			{
				return myAlias;
			}
			set
			{
				myAlias = value;
			}
		}
		
		public virtual bool UsesAlias
		{
			get
			{
				return myUsesAlias;
			}
			set
			{
				myUsesAlias = value;
			}
		}
		
		public virtual bool HasUsedAlias
		{
			get
			{
				return myHasUsedAlias;
			}

		}
		
		public void Reset()
		{
			
			if (myHasUsedAlias)
				myHasUsedAlias = false;
			
		}
		*/
		/*
		public override void AppendTo(StringBuilder SB)
		{
			
			if(myUsesAlias)
			{
				
				if(ActuallyHasAlias())
				{
					
					if(myHasUsedAlias)
					{
					
						SB.Append(myAlias);
				
						SB.Append(" ");
					
					} else 
					{
					
						Append(SB);
						
						SB.Append(" AS ");
					
						SB.Append(myAlias);
					
						SB.Append(" ");
						
						myHasUsedAlias = true;
					
					}
					
				} else {
					
					myUsesAlias = false;
					
				}
				
			} else {
				
				Append(SB);
				
			}
			
		}
		*/
		/*
		protected bool ActuallyHasAlias()
		{
			
			return myAlias.Length > 0;
					
		}
		*/
		/*
        protected abstract void Append(StringBuilder SB);

        #region ITextEntity Members

        public void AppendTo(StringBuilder SB)
        {
            Append(SB);
        }

        #endregion


        public override string ToString()
        {

            StringBuilder SB = new StringBuilder();

            Append(SB);

            return SB.ToString();

        }
        */
        
    }
}
