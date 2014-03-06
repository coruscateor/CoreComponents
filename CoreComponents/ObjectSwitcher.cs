/*
 * Created by SharpDevelop.
 * User: Paul
 * Date: 7/8/2010
 * Time: 5:44 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace CoreComponents
{
	/// <summary>
	/// Description of ObjectSwitcher.
	/// </summary>
//	public class ObjectSwitcher<T>
//	{
//		
//		CallMe myBefore;
//		
//		CallMe myAfter;
//		
//		public ObjectSwitcher(CallMe Before, CallMe After)
//		{
//			
//			myBefore = Before;
//		
//			myAfter = After;
//		
//		}
//		
//		public void Switch(T BeforeObject, T AfterObject)
//		{
//			
//			if(!BeforeObject.Equals(AfterObject))
//			{
//				
//				if(!BeforeObject.Equals(default(T)))
//				{
//					
//					myBefore();
//					
//				}
//				
//				BeforeObject = AfterObject;
//			
//				if (!BeforeObject.Equals(default(T)))
//				{
//					
//					myAfter();
//					
//				}
//					
//			
//			}
//			
//		}
//
//	}
	/*
	public interface IApplicationCore
	{
		
	}
	
	public class CoreSwitcher
	{
		
		CallMe myBefore;
		
		CallMe myAfter;
		
		public CoreSwitcher(CallMe Before, CallMe After)
		{
			
			myBefore = Before;
		
			myAfter = After;
		
		}
		
		public void Switch(ref IApplicationCore BeforeObject, ref IApplicationCore AfterObject)
		{
			
			if(BeforeObject != AfterObject)
			{
				
				if(BeforeObject != null)
				{
					
					myBefore();
					
				}
				
				BeforeObject = AfterObject;
			
				if (BeforeObject != null)
				{
					
					myAfter();
					
				}
					
			
			}
			
		}
		

	}
	*/
}
