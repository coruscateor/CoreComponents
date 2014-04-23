using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Items.Nodes
{

    public class SinglePathNode<TValue> : ISinglePathNode<TValue>
    {

        protected TValue myValue;

        protected ISinglePathNode<TValue> myNextNode;

        public SinglePathNode()
        {

            myValue = default(TValue);

        }

        public SinglePathNode(TValue TheValue)
        {

            myValue = TheValue;

        }
        
        public virtual TValue Value
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

        public bool HasNextNode
        {

            get
            {

                return myNextNode != null;

            }

        }

        public bool IsTerminal
        {

            get
            {

                return myNextNode == null;

            }

        }

        public ISinglePathNode<TValue> NextNode
        {

            get
            {

                return myNextNode;

            }
            set
            {

                myNextNode = value;

            }

        }

        public bool GetNextNode(TValue TheValue, out ISinglePathNode<TValue> TheNextNode)
        {

            if(myNextNode != null)
            {

                if(myNextNode.Value.Equals(TheValue))
                {

                    TheNextNode = myNextNode;

                    return true;

                }

            }

            TheNextNode = null;

            return false;

        }

        public bool GetNextNode(TValue TheValue, Action<ISinglePathNode<TValue>> FoundAction)
        {

            if(myNextNode != null)
            {

                if(myNextNode.Value.Equals(TheValue))
                {

                    FoundAction(myNextNode);

                    return true;

                }

            }

            return false;

        }

        public bool GetNextNode(TValue TheValue, Action FoundAction, out ISinglePathNode<TValue> TheNextNode)
        {

            if(myNextNode != null)
            {

                if(myNextNode.Value.Equals(TheValue))
                {

                    TheNextNode = myNextNode;

                    FoundAction();

                    return true;

                }

            }

            TheNextNode = null;

            return false;

        }

        public bool GetNextNode(TValue TheValue, Action<TValue> FoundAction, out ISinglePathNode<TValue> TheNextNode)
        {

            if(myNextNode != null)
            {

                if(myNextNode.Value.Equals(TheValue))
                {

                    TheNextNode = myNextNode;

                    FoundAction(myNextNode.Value);

                    return true;

                }

            }

            TheNextNode = null;

            return false;

        }

        public bool GetNextNode(TValue TheValue, Action<ISinglePathNode<TValue>> FoundAction, out ISinglePathNode<TValue> TheNextNode)
        {

            if(myNextNode != null)
            {

                if(myNextNode.Value.Equals(TheValue))
                {

                    TheNextNode = myNextNode;

                    FoundAction(myNextNode);

                    return true;

                }

            }

            TheNextNode = null;

            return false;

        }

        //public void SetNext(ISinglePathNode<TValue> TheNextNode)
        //{

        //    if(myNextNode != TheNextNode)
        //        myNextNode = TheNextNode;

        //}

        //public bool NextIs(ISinglePathNode<TValue> TheNextNode)
        //{

        //    return myNextNode == TheNextNode;

        //}

        public void ClearNext()
        {

            if(myNextNode != null)
                myNextNode = null;

        }

    }

}
