using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Items
{
    
    public class ListContainer<T> : IListContainer<T>
    {

        protected readonly List<T> myList;

        public ListContainer(List<T> TheList)
        {

            myList = TheList;

        }

        public int IndexOf(T TheItem)
        {

            return myList.IndexOf(TheItem);

        }

        public void Insert(int TheIndex, T TheItem)
        {

            myList.Insert(TheIndex, TheItem);

        }

        public T this[int TheIndex]
        {

            get
            {
                
                return myList[TheIndex];
            
            }

        }

        public bool Contains(T TheItem)
        {
            
            return myList.Contains(TheItem);

        }

        public int Count
        {

            get
            {
                
                return myList.Count;
            
            }

        }

        public T[] ToArray()
        {
            
            return myList.ToArray();

        }

        public List<T> ToList()
        {
            
            return new List<T>(myList);

        }

        public IEnumerator<T> GetEnumerator()
        {

            return myList.GetEnumerator();

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {

            return myList.GetEnumerator();

        }

    }

}
