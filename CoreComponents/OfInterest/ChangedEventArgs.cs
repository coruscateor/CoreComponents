/*
 * Created by SharpDevelop.
 * User: Paul
 * Date: 06/03/2009
 * Time: 5:07 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TrackingEventsDelegatesAndObjects.Events
{
	/// <summary>
	/// Description of ChangedEventArgs.
	/// </summary>
	public class ChangedEventArgs<T, R> : EventArgs
	{
		T Item;

        R Reason;

        int Count;

        public ChangedEventArgs(T Item, R Reason, int Count)
		{
			
			this.Item = Item;

            this.Reason = Reason;

            this.Count = Count;
		}
		
		public T ItemChanged {
		
			get {
			
				return Item;
			
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
