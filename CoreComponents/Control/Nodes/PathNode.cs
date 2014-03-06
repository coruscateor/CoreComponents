using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Control.Nodes
{

    //public class PathNode : IPathNode //BasePathNode,
    //{

    //    protected object myValue;

    //    protected IPathNode[] myNextNodes;

    //    public PathNode()
    //    {

    //        myValue = null;

    //    }

    //    public PathNode(object TheValue)
    //    {

    //        myValue = TheValue;

    //    }

    //    public virtual object Value
    //    {

    //        get
    //        {

    //            return myValue;

    //        }

    //    }

    //    protected virtual bool GetNext(object TheValue, out IPathNode TheNextNode)
    //    {

    //        if(myNextNodes != null && myNextNodes.Length > 0)
    //        {

    //            for(int i = 0; myNextNodes.Length > i; i++)
    //            {

    //                IPathNode Item = myNextNodes[i];

    //                if(TheValue == Item.Value)
    //                {

    //                    TheNextNode = Item;

    //                    return true;

    //                }

    //            }

    //        }

    //        TheNextNode = null;

    //        return false;

    //    }

    //    public int CountNext
    //    {

    //        get
    //        {

    //            if(myNextNodes == null)
    //                return 0;

    //            return myNextNodes.Length;

    //        }

    //    }

    //    public bool IsTerminal
    //    {

    //        get
    //        {

    //            if(myNextNodes == null)
    //                return false;

    //            return myNextNodes.Length > 0;

    //        }

    //    }

    //    public bool Contains(IPathNode TheNextNode)
    //    {

    //        if(myNextNodes != null && myNextNodes.Length > 0)
    //        {

    //            for(int i = 0; i < myNextNodes.Length; i++)
    //            {

    //                if(TheNextNode == myNextNodes[i])
    //                {

    //                    return true;

    //                }

    //            }

    //        }

    //        return false;

    //    }

    //    public virtual void SetNext(IPathNode TheNextNode)
    //    {

    //        if(TheNextNode != null)
    //        {

    //            myNextNodes = new IPathNode[] { TheNextNode };

    //        }

    //    }

    //    public virtual void SetNext(IPathNode[] TheNextNodes)
    //    {

    //        if(TheNextNodes != null && TheNextNodes.Length > 0)
    //        {

    //            IPathNode[] NextNodes = new IPathNode[TheNextNodes.Length];

    //            for(int i = 0; i < TheNextNodes.Length; i++)
    //            {

    //                NextNodes[i] = TheNextNodes[i];

    //            }

    //            myNextNodes = NextNodes;

    //        }

    //    }

    //    public virtual void SetNextParams(params IPathNode[] TheNextNodes)
    //    {

    //        if(TheNextNodes.Length > 0)
    //        {

    //            myNextNodes = TheNextNodes;

    //        }

    //    }

    //    public void ClearNext()
    //    {

    //        if(myNextNodes == null)
    //            myNextNodes = null;

    //    }

    //}

    public class PathNode<TValue> : IPathNode<TValue>
    {

        protected TValue myValue;

        //protected IPathNode<TValue>[] myNextNodes;

        protected LazyObject<SortedSet<IPathNode<TValue>>> myLazyNextSet;

        public PathNode()
        {

            myValue = default(TValue);

        }

        public PathNode(TValue TheValue)
        {

            myValue = TheValue;

        }

        public TValue Value
        {

            get
            {

                return myValue;

            }

        }

        public bool ValueIsDefault
        {

            get
            {

                return myValue.Equals(default(TValue));

            }

        }

        public bool GetNext(TValue TheValue, out IPathNode<TValue> NextNode)
        {

            SortedSet<IPathNode<TValue>> Set;

            if(myLazyNextSet.TryGet(out Set))
            {

                foreach(IPathNode<TValue> Item in Set)
                {

                    if(Item.Value.Equals(TheValue))
                    {

                        NextNode = Item;

                        return true;

                    }

                }

            }

            NextNode = null;

            return false;

            
        }

        public int NextCount
        {

            get
            {

                SortedSet<IPathNode<TValue>> Set;

                if(myLazyNextSet.TryGet(out Set))
                {

                    return Set.Count;

                }
                
                return 0;
            
            }

        }

        public bool IsTerminal
        {

            get
            {

                SortedSet<IPathNode<TValue>> Set;

                if(myLazyNextSet.TryGet(out Set))
                {
 
                    return Set.Count < 1;

                }

                return true;

            }

        }

        public bool Contains(IPathNode<TValue> TheNextNode)
        {

            SortedSet<IPathNode<TValue>> Set;

            if(myLazyNextSet.TryGet(out Set))
            {

                return Set.Contains(TheNextNode);

            }

            return false;

        }

        public void AddNext(IPathNode<TValue> TheNextNode)
        {

            SortedSet<IPathNode<TValue>> Set;

            if(myLazyNextSet.TryGet(out Set))
            {

                Set.Add(TheNextNode);

            }

        }

        public void RemoveNext(IPathNode<TValue> TheNextNode)
        {

            SortedSet<IPathNode<TValue>> Set;

            if(myLazyNextSet.TryGet(out Set))
            {

                Set.Remove(TheNextNode);

            }

        }

        public void CopyTo(IPathNode<TValue>[] array)
        {

            SortedSet<IPathNode<TValue>> Set;

            if(myLazyNextSet.TryGet(out Set))
            {

                Set.CopyTo(array);

            }

        }

        public void CopyTo(IPathNode<TValue>[] array, int index)
        {

            SortedSet<IPathNode<TValue>> Set;

            if(myLazyNextSet.TryGet(out Set))
            {

                Set.CopyTo(array, index);

            }

        }

        public void CopyTo(IPathNode<TValue>[] array, int index, int count)
        {

            SortedSet<IPathNode<TValue>> Set;

            if(myLazyNextSet.TryGet(out Set))
            {

                Set.CopyTo(array, index, count);

            }

        }

        public IPathNode<TValue>[] ToArray()
        {

            SortedSet<IPathNode<TValue>> Set;

            if(myLazyNextSet.TryGet(out Set))
            {

                IPathNode<TValue>[] NewArray = new IPathNode<TValue>[Set.Count];

                Set.CopyTo(NewArray);

                return NewArray;

            }

            return new IPathNode<TValue>[0];

        }

        public void ClearNext()
        {

            SortedSet<IPathNode<TValue>> Set;

            if(myLazyNextSet.TryGet(out Set))
            {

                Set.Clear();

            }

        }

        public IEnumerator<IPathNode<TValue>> GetEnumerator()
        {

            return myLazyNextSet.Object.GetEnumerator();

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {

            return myLazyNextSet.Object.GetEnumerator();

        }

        //protected virtual bool GetNext(TValue TheValue, out IPathNode<TValue> TheNextNode)
        //{

        //    if(myNextNodes != null && myNextNodes.Length > 0)
        //    {

        //        for(int i = 0; myNextNodes.Length > i; i++)
        //        {

        //            IPathNode<TValue> Item = myNextNodes[i];

        //            if(TheValue.Equals(Item.Value))
        //            {

        //                TheNextNode = Item;

        //                return true;

        //            }

        //        }

        //    }

        //    TheNextNode = null;

        //    return false;

        //}

        //public int CountNext
        //{

        //    get
        //    {

        //        if(myNextNodes == null)
        //            return 0;

        //        return myNextNodes.Length;

        //    }

        //}

        //public bool IsTerminal
        //{

        //    get
        //    {

        //        if(myNextNodes == null)
        //            return false;

        //        return myNextNodes.Length > 0;

        //    }

        //}

        //public bool Contains(IPathNode<TValue> TheNextNode)
        //{

        //    if(myNextNodes != null && myNextNodes.Length > 0)
        //    {

        //        for(int i = 0; i < myNextNodes.Length; i++)
        //        {

        //            if(TheNextNode == myNextNodes[i])
        //            {

        //                return true;

        //            }

        //        }

        //    }

        //    return false;

        //}

        //public virtual void SetNext(IPathNode<TValue> TheNextNode)
        //{

        //    if(TheNextNode != null)
        //    {

        //        myNextNodes = new IPathNode<TValue>[] { TheNextNode };

        //    }

        //}

        //public virtual void SetNext(IPathNode<TValue>[] TheNextNodes)
        //{

        //    if(TheNextNodes != null && TheNextNodes.Length > 0)
        //    {

        //        IPathNode<TValue>[] NextNodes = new IPathNode<TValue>[TheNextNodes.Length];

        //        for(int i = 0; i < TheNextNodes.Length; i++)
        //        {

        //            NextNodes[i] = TheNextNodes[i];

        //        }

        //        myNextNodes = NextNodes;

        //    }

        //}

        //public virtual void SetNextParams(params IPathNode<TValue>[] TheNextNodes)
        //{

        //    if(TheNextNodes.Length > 0)
        //    {

        //        myNextNodes = TheNextNodes;

        //    }

        //}

        //public void ClearNext()
        //{

        //    if(myNextNodes == null)
        //        myNextNodes = null;

        //}
        
    }

}
