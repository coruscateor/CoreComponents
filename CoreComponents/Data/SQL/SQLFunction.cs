using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents.Caching.Parameters;

namespace CoreComponents.Data.SQL
{
	
	public interface ISQLFunction
	{
		
		string FunctionName
		{
			
			get;
			
		}
		
		IOptionalList<string, bool> OptionalParamters
		{
			
			get;
			
		}
		
		FunctionType FunctionType
		{
			
			get;
			
		}
		
	}
	
    public abstract class SQLFunction : SQLExpression, ISQLFunction
    {
		
		protected string myFunctionName;
		
		protected IOptionalList<string, bool> myOptionalParamters;
		
		protected FunctionType myFunctionType;
		
		//protected SQLExpression myParameters;

        public SQLFunction()
        {



		}
		
		public string FunctionName
		{
			
			get
			{
				return myFunctionName;
			}
			
		}
		
		public IOptionalList<string, bool> OptionalParamters
		{
			
			get 
			{
			
				return myOptionalParamters;
				
			}
			
		}
		
		public FunctionType FunctionType
		{
			
			get
			{
				
				return myFunctionType;
				
			}
			
		}
		
		/*
		public SQLExpression Parameters
        {

            get
            {
                return myParameters;

            }
            set
            {

                myParameters = value;

            }

        }
        */


    }
}
