using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreComponents;

namespace CoreComponents.Control
{

    public class MultiBranchTreeNode<T> : IList<MultiBranchTreeNode<T>>
    {

        protected LazyObject<List<MultiBranchTreeNode<T>>> myLazyOptions; //= new List<MultiBranchTreeNode>();

        protected T myValue;

        public MultiBranchTreeNode()
        { 
        }

        public T Value
        {

            get
            {

                return myValue;

            }
            set
            {

                myValue = value;

            }
 
        }

        public int IndexOf(MultiBranchTreeNode<T> item)
        {

            if(!myLazyOptions.HasObject)
                return -1;

            return myLazyOptions.Object.IndexOf(item);
            
        }

        public void Insert(int index, MultiBranchTreeNode<T> item)
        {

            myLazyOptions.Object.Insert(index, item);

        }

        public void RemoveAt(int index)
        {

            myLazyOptions.Object.RemoveAt(index);

        }

        public MultiBranchTreeNode<T> this[int index]
        {
            get
            {

                return myLazyOptions.Object[index];

            }
            set
            {

                myLazyOptions.Object[index] = value;

            }

        }

        public void Add(MultiBranchTreeNode<T> item)
        {

            myLazyOptions.Object.Add(item);

        }

        public void Clear()
        {

            myLazyOptions.Object.Clear();

        }

        public bool Contains(MultiBranchTreeNode<T> item)
        {

            return myLazyOptions.Object.Contains(item);

        }

        public void CopyTo(MultiBranchTreeNode<T>[] array, int arrayIndex)
        {

            myLazyOptions.Object.CopyTo(array, arrayIndex);

        }

        public int Count
        {

            get
            {

                if(!myLazyOptions.HasObject)
                    return 0;

                return myLazyOptions.Object.Count;

            }

        }

        public bool IsReadOnly
        {

            get
            { 
                return false;
            
            }

        }

        public bool Remove(MultiBranchTreeNode<T> item)
        {

            return myLazyOptions.Object.Remove(item);

        }

        public IEnumerator<MultiBranchTreeNode<T>> GetEnumerator()
        {

            return myLazyOptions.Object.GetEnumerator();

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {

            return myLazyOptions.Object.GetEnumerator();

        }

    }

}
