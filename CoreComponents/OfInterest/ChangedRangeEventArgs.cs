/*
 * Created by SharpDevelop.
 * User: Paul
 * Date: 06/03/2009
 * Time: 5:45 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace TrackingEventsDelegatesAndObjects.Events
{
	/// <summary>
	/// Description of ChangedMultipleEventArgs.
	/// </summary>
	public class ChangedRangeEventArgs<T, R> : EventArgs
	{
		
		IEnumerable<T> Items;

        R Reason;

        int Count;

        public ChangedRangeEventArgs(IEnumerable<T> Items, R Reason, int Count)
		{
			
			this.Items = Items;

            this.Reason = Reason;

            this.Count = Count;
			
		}
		
		public IEnumerable<T> ItemsChanged {
		
			get {
			
				return Items;
			
			}
		
		}

        public R TheReason
        {

            get
            {

                return Reason;

            }

        }

        public int ItemCount
        {

            get
            {

                return Count;

            }

        }
	}
}
