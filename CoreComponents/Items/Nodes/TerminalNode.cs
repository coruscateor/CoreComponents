using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Items.Nodes
{

    public class TerminalNode : IPathNode<object> //BasePathNode, 
    {

        protected object myValue;

        public TerminalNode()
        {

            myValue = null;

        }

        public TerminalNode(object TheValue)
        {

            myValue = TheValue;

        }
        
        public object Value
        {

            get
            {
                
                return myValue;
            
            }

        }


        public bool GetNext(object TheValue, out IPathNode<object> NextNode)
        {
            throw new NotImplementedException();
        }

        public bool ValueIsDefault
        {
            get { throw new NotImplementedException(); }
        }

        public int NextCount
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsTerminal
        {
            get { throw new NotImplementedException(); }
        }

        public bool Contains(IPathNode<object> TheNextNode)
        {
            throw new NotImplementedException();
        }

        public void AddNext(IPathNode<object> TheNextNode)
        {
            throw new NotImplementedException();
        }

        public void RemoveNext(IPathNode<object> TheNextNode)
        {
            throw new NotImplementedException();
        }

        public void ClearNext()
        {
            throw new NotImplementedException();
        }

        public IPathNode<object>[] ToArray()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<IPathNode<object>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class TerminalNode<TValue> : IPathNode<TValue> //BasePathNode,
    {

        protected TValue myValue;

        public TerminalNode()
        {

            myValue = default(TValue);

        }

        public TerminalNode(TValue TheValue)
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


        public bool GetNext(TValue TheValue, out IPathNode<TValue> NextNode)
        {
            throw new NotImplementedException();
        }

        public bool ValueIsDefault
        {
            get { throw new NotImplementedException(); }
        }

        public int NextCount
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsTerminal
        {
            get { throw new NotImplementedException(); }
        }

        public bool Contains(IPathNode<TValue> TheNextNode)
        {
            throw new NotImplementedException();
        }

        public void AddNext(IPathNode<TValue> TheNextNode)
        {
            throw new NotImplementedException();
        }

        public void RemoveNext(IPathNode<TValue> TheNextNode)
        {
            throw new NotImplementedException();
        }

        public void ClearNext()
        {
            throw new NotImplementedException();
        }

        public IPathNode<TValue>[] ToArray()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<IPathNode<TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class TerminalNode<TValue, TFinalValue> : TerminalNode<TValue>
    {

        protected TFinalValue myFinalValue;

        public TerminalNode()
        {

            myValue = default(TValue);

            myFinalValue = default(TFinalValue);

        }

        public TerminalNode(TValue TheValue, TFinalValue TheFinalValue)
        {

            myValue = TheValue;

            myFinalValue = TheFinalValue;

        }

        public TFinalValue FinalValue
        {

            get
            {

                return myFinalValue;

            }

        }

    }

}
