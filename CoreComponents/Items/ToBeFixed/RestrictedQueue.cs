using System;
using System.Collections;
using System.Collections.Generic;

namespace CoreComponents.Items
{

    public class RestrictedQueue<T> : ICache<T>
	{
		
		public delegate T PushItem(T item); //This is a type declaration not a variable!!!!
        //RestrictedQueue<T>
        public event LimitDelegates<IReadOnlyCache<T>>.LimitReached Filled;

        public event LimitDelegates<IReadOnlyCache<T>>.LimitReached Emptied;

        public event LimitDelegates<IReadOnlyCache<T>>.LimitReached Emptying;

        public event FedDelegate<T, IReadOnlyCache<T>>.Fed Fed;

        //public event LimitDelegates<Sender>.LimitReached Filled;

        //public event LimitDelegates<Sender>.LimitReached Emptied;

        //public event LimitDelegates<Sender>.LimitReached Emptying;

        //public event FedDelegate<T, Sender>.Fed Fed;

        //public new event FedDelegate<T, ICache<T>>.Fed Fed;

        //public event ChangedHandlers<T, ICache<T>>.ChangedHandler Added;

        //public event ChangedHandlers<T, ICache<T>>.ChangedHandler Removed;

        //public event

        protected PushItem myTryPush;

        protected int myMaxSize;
		
		protected Queue<T> myList;

        public RestrictedQueue()
        {

            myList = new Queue<T>();

            myTryPush = PushNotFull;

        }
		
		public RestrictedQueue(int MaxSize)
		{
			
			//Maximum size can never eqate to zero.
			if (MaxSize < 1)
				MaxSize = 1;
			
			myMaxSize = MaxSize;
			
			myList = new Queue<T>(MaxSize);
			
			myTryPush = PushNotFull;
			
		}

        public RestrictedQueue(IEnumerable items)
        {
            myList = new Queue<T>();

            foreach (T item in items)
            {

                myList.Enqueue(item);

            }

            myTryPush = PushNotFull;

        }
		
		public T Feed(T item) {

			return myTryPush(item);
			
		}

        protected T PushNotFull(T item)
        {
			
			myList.Enqueue(item);

            if (Fed != null)
                Fed(new FedEventArgs<T, IReadOnlyCache<T>>(this, item, default(T))); //cannot use null, use default( type ) instead

            //if (Added != null)
            //    Added(new ChangedEventArgs<T, ICache<T>>(this, item));
			
			//If we have now reached the maxcount then we should start kicking stuff out.
            if (IsFilled)
            {
                myTryPush = PushFull;

                if (Filled != null)
                    Filled(new SenderEventArgs<IReadOnlyCache<T>>(this));
            }
			//a simple "return null" does not work here.
			return default(T);
			
		}

        protected T PushFull(T item)
        {
			
			T BottomItem = myList.Dequeue();

            //Fed(

            //if (Removed != null)
            //    Removed(new ChangedEventArgs<T, ICache<T>>(this, BottomItem));
			
			myList.Enqueue(item);


            if (Fed != null)
                Fed(new FedEventArgs<T, IReadOnlyCache<T>>(this, item, BottomItem));

            //if (Added != null)
            //    Added(new ChangedEventArgs<T, ICache<T>>(this, item));
			
			return BottomItem;
			
		}
		
		//Is it full?
		public bool IsFilled { 
		
			get {
				
				return myMaxSize == myList.Count;
				
			}
		
		}
		
		public int MaximumSize { 
			
			get 
			{ 
			
				return myMaxSize;
				
			}
			
		 	set {
				
				Truncate(value);
				
				myMaxSize = value;
				
			} 
		
		}
		
		void Truncate(int NewMaximum) {
			
			//Check if the new maximum ammount is geater than less than or the same as the number currently in the list.
			int Difference = NewMaximum - myList.Count;
			
			//If the difference is positive or neutral, do nothing
			if (Difference < 0) {
			
				//dump excess
				while (Difference < 0) {
				
					myList.Dequeue();
				
					Difference++;
				
				}
				
				myList.TrimExcess();
				
			}
			
		}
		
		//public IEnumerator<T> GetEnumerator()
		//{
	
			//return TheList.GetEnumerator();
			
		//}

        public IEnumerator<T> GetEnumerator()
        {
            return myList.GetEnumerator();

        }


        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
	
			return myList.GetEnumerator();
			
		}

		public void Flush() {

            if (Emptying != null)
                Emptying(new SenderEventArgs<IReadOnlyCache<T>>(this));
			
			myList.Clear();
			
			myTryPush = PushNotFull;

            if (Emptied != null)
                Emptied(new SenderEventArgs<IReadOnlyCache<T>>(this));
			
		}
		
		public int Count { 
			
			get {
				
				return myList.Count;	
				
			} 
		}

        /*
        public virtual object Clone()
        {

            return new RestrictedQueue<T>(myList);

        }
		(
        */
		
		//public T GetAtIndex(int Loc) {
			
			//return TheList[Loc];
			
		//}
	}
}
