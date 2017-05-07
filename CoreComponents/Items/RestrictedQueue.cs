using System;
using System.Collections;
using System.Collections.Generic;

namespace CoreComponents.Items
{

    public class RestrictedQueue<T> : IEnumerable<T>, ICloneable<RestrictedQueue<T>>
	{

        public event EventInfoHandler<T> MaximumReached;

        public event EventInfoHandler<T> Enqueued;

        public event EventInfoHandler<T> Dequeued;

        public event EventHandler Emptying;

        public event EventHandler Emptied;

        protected Func<T, T> myEnqueueDelegate;

        protected int myMaxSize;
		
		protected readonly Queue<T> myQueue;

        protected readonly Func<T, T> myEnqueueMaxDelegate;

        protected readonly Func<T, T> myEnqueueNotMaxDelegate;

        public RestrictedQueue()
        {

            myQueue = new Queue<T>();

            myEnqueueMaxDelegate = EnqueueMax;

            myEnqueueNotMaxDelegate = EnqueueNotMax;

            myEnqueueDelegate = myEnqueueNotMaxDelegate;

        }
		
		public RestrictedQueue(int MaxSize)
		{
			
			//Maximum size can never eqate to zero.
			if(MaxSize < 1)
				MaxSize = 1;
			
			myMaxSize = MaxSize;
			
			myQueue = new Queue<T>(MaxSize);

            myEnqueueMaxDelegate = EnqueueMax;

            myEnqueueNotMaxDelegate = EnqueueNotMax;

            myEnqueueDelegate = myEnqueueNotMaxDelegate;

        }

        public RestrictedQueue(IEnumerable items)
        {

            myQueue = new Queue<T>();

            foreach(T item in items)
            {

                myQueue.Enqueue(item);

            }

            myEnqueueMaxDelegate = EnqueueMax;

            myEnqueueNotMaxDelegate = EnqueueNotMax;

            myEnqueueDelegate = myEnqueueNotMaxDelegate;

        }

		public T Enqueue(T item)
        {

			return myEnqueueDelegate(item);
			
		}

        T EnqueueNotMax(T item)
        {
			
			myQueue.Enqueue(item);

            if(Enqueued != null)
                Enqueued(this, item);

            //If the maximum size has been reached then we should start removing items.

            if(IsAtMaximumSize)
            {

                myEnqueueDelegate = myEnqueueMaxDelegate;

                if(MaximumReached != null)
                    MaximumReached(this, item);

            }

			return default(T);
			
		}

        T EnqueueMax(T item)
        {
			
			T BottomItem = myQueue.Dequeue();

            if(Dequeued != null)
                Dequeued(this, BottomItem);

            myQueue.Enqueue(item);

            if(Enqueued != null)
                Enqueued(this, item);
			
			return BottomItem;
			
		}

        public int Count
        {

            get
            {

                return myQueue.Count;

            }

        }

        public bool IsAtMaximumSize
        { 
		
			get
            {

                return myQueue.Count == myMaxSize;
				
			}
		
		}
		
		public int MaximumSize
        { 
			
			get 
			{ 
			
				return myMaxSize;
				
			}
		 	set
            {
				
				Truncate(value);
				
				myMaxSize = value;
				
			} 
		
		}
		
		void Truncate(int NewMaximum)
        {
			
			//Check if the new maximum ammount is geater than less than or the same as the number currently in the Queue.

			int Difference = NewMaximum - myQueue.Count;
			
			//If the difference is positive or neutral, do nothing

			if(Difference < 0)
            {

                //dump excess

                if(Dequeued != null)
                {

                    while(Difference < 0)
                    {

                        Dequeued(this, myQueue.Dequeue());

                        Difference++;

                    }

                }
                else
                {

                    while(Difference < 0)
                    {

                        myQueue.Dequeue();

                        Difference++;

                    }

                }
				
			}

            if(!IsAtMaximumSize)
                myEnqueueDelegate = myEnqueueNotMaxDelegate;
			
		}

        public void TrimExcess()
        {

            myQueue.TrimExcess();

        }

        public IEnumerator<T> GetEnumerator()
        {

            return myQueue.GetEnumerator();

        }


        System.Collections.IEnumerator IEnumerable.GetEnumerator()
		{
	        
			return myQueue.GetEnumerator();
			
		}

		public void Clear()
        {

            if(Emptying != null)
                Emptying(this);
			
            if(Dequeued != null)
            {

                int count = myQueue.Count;

                while(count > 0)
                {

                    Dequeued(this, myQueue.Dequeue());

                    count--;

                }

            }
            else
            {

                myQueue.Clear();

            }
			
			myEnqueueDelegate = EnqueueNotMax;

            if(Emptied != null)
                Emptied(this);
			
		}

        public RestrictedQueue<T> Clone()
        {

            return new RestrictedQueue<T>(myQueue);

        }

        object ICloneable.Clone()
        {

            return Clone();

        }

    }

}
