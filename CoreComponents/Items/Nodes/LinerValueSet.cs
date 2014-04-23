using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Items.Nodes
{

    public class LinerValueSet<TValue> : IList<TValue>
    {

        protected ulong myCount = 0;

        protected ISinglePathNode<TValue> myRoot;

        protected ISinglePathNode<TValue> myTerminal;

        public LinerValueSet()
        {
        }

        protected void CheckInt32(int TheIndex)
        {

            unchecked
            {

                if(TheIndex < 0 || myCount < (ulong)TheIndex)
                {

                    throw new IndexOutOfRangeException();

                }

            }

        }
        
        public int IndexOf(TValue item)
        {

            if(myRoot != null)
            {

                //int ItemHashCode = item.GetHashCode();

                //myRoot.Value.GetHashCode() == ItemHashCode

                if(myRoot.Value.Equals(item))
                    return 0;

                if(!myRoot.IsTerminal)
                {

                    ISinglePathNode<TValue> CurrentNode = myRoot.NextNode;

                    //CurrentNode.Value.GetHashCode() == ItemHashCode

                    if(CurrentNode.Value.Equals(item))
                        return 1;

                    int i = 2;

                    while(!CurrentNode.IsTerminal)
                    {

                        CurrentNode = CurrentNode.NextNode;

                        //CurrentNode.Value.GetHashCode() != ItemHashCode

                        if(CurrentNode.Value.Equals(item))
                        {

                            //CurrentNode.Value.GetHashCode() == ItemHashCode

                            if(CurrentNode.Value.Equals(item))
                                return i;

                        }

                        try
                        {

                            i++;

                        }
                        catch
                        {
                            
                            break;

                        }

                    }

                }

            }

            return -1;

        }

        public void Replace(int index, TValue item)
        {

            CheckInt32(index);

            if(myRoot == null)
            {

                if(index > -1)
                    throw new IndexOutOfRangeException();

            }

            if(index == 0)
            {

                myRoot.Value = item;

                return;

            }

            if(!myRoot.IsTerminal)
            {

                ISinglePathNode<TValue> CurrentNode = myRoot.NextNode;

                if(index == 1)
                {

                    CurrentNode.Value = item;

                    return;

                }

                int i = 2;

                while(!CurrentNode.IsTerminal)
                {

                    CurrentNode = CurrentNode.NextNode;

                    if(i == index)
                    {

                        CurrentNode.Value = item;
                        
                        return;

                    }

                    i++;

                }

                throw new IndexOutOfRangeException();

            }

        }

        public void Insert(int index, TValue item)
        {

            CheckInt32(index);

            if(myRoot == null)
            {

                if(index > -1)
                    throw new IndexOutOfRangeException();

            }

            if(index == 0)
            {

                ISinglePathNode<TValue> NewNode = new SinglePathNode<TValue>(item);

                NewNode.NextNode = myRoot;

                myRoot = NewNode;

                if(NewNode.NextNode.IsTerminal)
                    myTerminal = NewNode.NextNode;

                myCount++;

                return;

            }

            if(!myRoot.IsTerminal)
            {

                ISinglePathNode<TValue> PreviousNode = myRoot;

                ISinglePathNode<TValue> CurrentNode = myRoot.NextNode;

                if(index == 1)
                {

                    ISinglePathNode<TValue> NewNode = new SinglePathNode<TValue>(item);

                    NewNode.NextNode = CurrentNode;

                    PreviousNode.NextNode = NewNode;

                    if(CurrentNode.NextNode.IsTerminal)
                        myTerminal = CurrentNode.NextNode;

                    myCount++;

                    return;

                }

                int i = 2;

                while(!CurrentNode.IsTerminal)
                {

                    CurrentNode = CurrentNode.NextNode;

                    if(i == index)
                    {

                        ISinglePathNode<TValue> NewNode = new SinglePathNode<TValue>(item);

                        NewNode.NextNode = CurrentNode;

                        PreviousNode.NextNode = NewNode;

                        if(CurrentNode.NextNode.IsTerminal)
                            myTerminal = CurrentNode.NextNode;

                        myCount++;

                        return;

                    }

                    i++;

                }

                throw new IndexOutOfRangeException();

            }

        }

        public void RemoveAt(int index)
        {

            CheckInt32(index);

            if(myRoot == null)
            {

                if(index > -1)
                    throw new IndexOutOfRangeException();

            }

            if(index == 0)
            {

                if(myRoot.IsTerminal)
                {

                    Clear();

                }
                else
                {

                    myRoot = myRoot.NextNode;

                    if(myRoot.IsTerminal)
                        myTerminal = myRoot;

                    myCount--;

                }

                return;

            }

            if(!myRoot.IsTerminal)
            {

                if(index == 1)
                {

                    myRoot = myRoot.NextNode;

                    if(myRoot.IsTerminal)
                        myTerminal = myRoot;

                    myCount--;

                    return;

                }

                ISinglePathNode<TValue> PreviousNode = myRoot;

                ISinglePathNode<TValue> CurrentNode = myRoot.NextNode;

                int i = 2;

                while(!CurrentNode.IsTerminal)
                {

                    PreviousNode = CurrentNode;

                    CurrentNode = CurrentNode.NextNode;

                    if(i == index)
                    {

                        PreviousNode = CurrentNode;

                        if(CurrentNode.IsTerminal)
                            myTerminal = CurrentNode;

                        myCount--;

                        return;

                    }

                    i++;

                }

            }

        }

        public TValue this[int index]
        {

            get
            {

                CheckInt32(index);

                if(myRoot != null)
                {

                    if(index == 0)
                    {

                        return myRoot.Value;

                    }

                    if(!myRoot.IsTerminal)
                    {

                        ISinglePathNode<TValue> CurrentNode = myRoot.NextNode;

                        if(index == 1)
                            return CurrentNode.Value;

                        int CurrentIndex = 2;

                        while(!CurrentNode.IsTerminal)
                        {

                            CurrentNode = CurrentNode.NextNode;

                            if(CurrentIndex == index)
                                return CurrentNode.Value;

                            CurrentIndex++;

                        }

                    }

                }

                throw new IndexOutOfRangeException();

            }
            set
            {

                CheckInt32(index);

                if(myRoot != null)
                {

                    if(index == 0)
                    {

                        myRoot.Value = value;

                        return;

                    }

                    if(!myRoot.IsTerminal)
                    {

                        ISinglePathNode<TValue> CurrentNode = myRoot.NextNode;

                        if(index == 1)
                        {

                            CurrentNode.Value = value;

                            return;

                        }

                        int CurrentIndex = 2;

                        while(!CurrentNode.IsTerminal)
                        {

                            CurrentNode = CurrentNode.NextNode;

                            if(CurrentIndex == index)
                            {

                                CurrentNode.Value = value;

                                return;

                            }

                            CurrentIndex++;

                        }

                    }

                }

            }

        }

        public void Add(TValue item)
        {

            if(myRoot == null)
            {

                myRoot = new SinglePathNode<TValue>(item);

                myTerminal = myRoot;

                myCount++;

            }
            else
            {

                SinglePathNode<TValue> NextNode = new SinglePathNode<TValue>(item);

                myTerminal.NextNode = NextNode;

                myTerminal = NextNode;

                myCount++;

            }


        }

        public void Clear()
        {

            if(myRoot != null)
                myRoot = null;

            if(myTerminal != null)
                myTerminal = null;

            if(myCount != 0)
                myCount = 0;

        }

        public bool Contains(TValue item)
        {

            if(myRoot != null)
            {

                //myRoot.Value.GetHashCode() != item.GetHashCode()

                if(myRoot.Value.Equals(item))
                {

                    if(myRoot.IsTerminal)
                        return false;

                    ISinglePathNode<TValue> CurrentNode = myRoot;

                    while(!CurrentNode.IsTerminal)
                    {

                        CurrentNode = CurrentNode.NextNode;

                        //CurrentNode.Value.GetHashCode() == item.GetHashCode()

                        if(CurrentNode.Value.Equals(item))
                        {

                            return true;

                        }

                    }

                }
                else
                {

                    return true;

                }
                
            }

            return false;

        }

        public void CopyTo(TValue[] array, int arrayIndex = 0)
        {

            if(myRoot == null)
                throw new IndexOutOfRangeException();

            if(arrayIndex > array.Length)
                throw new IndexOutOfRangeException();

            int CurrentIndex = arrayIndex;

            array[CurrentIndex] = myRoot.Value;

            CurrentIndex++;

            if(!myRoot.IsTerminal)
            {

                ISinglePathNode<TValue> CurrentNode = myRoot.NextNode;

                while(CurrentIndex < array.Length)
                {

                    array[CurrentIndex] = CurrentNode.Value;

                    if(CurrentNode.IsTerminal)
                        return;

                    CurrentIndex++;

                }

            }

        }

        public int Count
        {

            get
            {

                unchecked
                {

                    return (int)myCount;

                }

            }

        }

        public long LongCount
        {

            get
            {

                unchecked
                {

                    return (long)myCount;

                }

            }

        }

        public ulong uLongCount
        {

            get
            {

                return myCount;

            }

        }

        public bool IsReadOnly
        {

            get
            {
                
                return false;
            
            }

        }

        public bool Remove(TValue item)
        {

            if(myRoot != null)
            {

                if(myRoot.Value.Equals(item))
                {

                    if(myRoot.IsTerminal)
                    {

                        Clear();

                    }
                    else
                    {

                        myRoot = myRoot.NextNode;

                        myCount--;

                    }

                    return true;

                }

                ISinglePathNode<TValue> PreviousNode = null;

                ISinglePathNode<TValue> CurrentNode = myRoot;

                while(!CurrentNode.IsTerminal)
                {

                    //CurrentNode.Value.GetHashCode() == item.GetHashCode()

                    if(CurrentNode.Value.Equals(item))
                    {

                        if(!CurrentNode.IsTerminal)
                        {

                            if(PreviousNode != null)
                            {

                                PreviousNode.NextNode = CurrentNode.NextNode;

                                if(CurrentNode.IsTerminal)
                                    myTerminal = CurrentNode;

                                myCount--;

                            }
                            else
                            {

                                myRoot = CurrentNode.NextNode;

                                if(CurrentNode.IsTerminal)
                                    myTerminal = CurrentNode;
                                    
                                myCount--;

                            }

                        }

                        return true;

                    }

                    PreviousNode = CurrentNode;

                }

                return true;

            }

            return false;

        }

        public IEnumerator<TValue> GetEnumerator()
        {

            if(myRoot != null)
            {

                ISinglePathNode<TValue> CurrentNode = myRoot;

                yield return CurrentNode.Value;

                while(!CurrentNode.IsTerminal)
                {

                    CurrentNode = CurrentNode.NextNode;

                    yield return CurrentNode.Value;  

                }

                yield break;

            }

            yield break;

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {

            return GetEnumerator();

        }

    }

}
