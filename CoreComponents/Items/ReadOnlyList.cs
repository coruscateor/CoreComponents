
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace CoreComponents.Items
{		
    	
	public class ReadOnlyList<T> : IReadOnlyList<T>
	{

		//protected IList<T> myList; //Does not possess the ToArray method.

        //protected List<T> myList;

        protected readonly T[] myArray;

        /*
		public ReadOnlyList()
		{
			
			myList = new List<T>();
			
		}
        */

        public ReadOnlyList() 
        {

            //myList = new List<T>();

            myArray = new T[0];

        }

        /*
        public ReadOnlyList(IEnumerable<T> TheList)
        {

            myList = new List<T>(TheList);

        }
        */

        public ReadOnlyList(T[] TheArray)
        {

            myArray = ArrayCopier<T>.Clone(TheArray);

        }

        public ReadOnlyList(T[] TheArray, bool Copy)
        {

            if(Copy)
                myArray = ArrayCopier<T>.Clone(TheArray);
            else
                myArray = TheArray;

        }

        public ReadOnlyList(List<T> TheList)
        {

            //myList = TheList;

            myArray = TheList.ToArray();

        }
		
		public T this[int index]
        {

            get
			{

				//return myList[index];

                return myArray[index];

			}

        }

        public int Count
        {

            get
			{

				//return myList.Count;

                return myArray.Length;

			}

        }
		
        //public ReadonlyList<TItem> Select<TItem>()
        //{
	        /*
			if (TItem is T) {
			
			ReadonlyList<TItem> Items = new ReadonlyList<TItem>();
				
			foreach(TItem Item in TheList)
			{
				Items.Add(Item);
			} 
				
			return Items;
				
			}
             */
			
        //    return new ReadonlyList<TItem>();
        //}
		/*
		public ReadonlyList<TItem> Select<TItem>()
        {
	
			ReadonlyList<TItem> Items = new ReadonlyList<TItem>();
				
			foreach(TItem Item in TheList)
			{
				Items.Add(Item);
			} 
				
			return Items;
			
        }*/

        public List<T> ToList()
        {

            //return new List<T>(myList);

            return new List<T>(myArray);

        }
		
		public IEnumerator<T> GetEnumerator()
        {

            //return myList.GetEnumerator();

            return (IEnumerator<T>)myArray.GetEnumerator();

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {

            //return myList.GetEnumerator();

            return myArray.GetEnumerator();

        }

        /*
        public bool ContainsListCollection
        {

            get { 
                
                return false; //Needs to be implemented.
            

            }
        }
        */

        public bool IsNotEmpty 
        {

            get 
            {

                //return myList.Count > 0;

                return myArray.Length > 0;

            }

        }

        public T[] GetArray() 
        {

            //return myList.ToArray();

            return ArrayCopier<T>.Clone(myArray);

        }


        /*
        IList IListSource.ToList()
        {

            return new List<T>(myArray);

        }
        */

    }

}
