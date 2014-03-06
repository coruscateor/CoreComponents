using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Control.Nodes
{

    public abstract class BasePathNode
    {

        protected IPathNode[] myNextNodes;

        public BasePathNode()
        { 
        }

        protected virtual bool GetNext(object TheValue, out IPathNode TheNextNode)
        {

            if(myNextNodes != null && myNextNodes.Length > 0)
            {

                for(int i = 0; myNextNodes.Length > i; i++)
                {

                    IPathNode Item = myNextNodes[i];

                    if(TheValue == Item.Value)
                    {

                        TheNextNode = Item;

                        return true;

                    }

                }

            }

            TheNextNode = null;

            return false;

        }

        public int CountNext
        {

            get
            {

                if(myNextNodes == null)
                    return 0;

                return myNextNodes.Length;

            }

        }
        
        public bool IsTerminal
        {

            get
            {

                if(myNextNodes == null)
                    return false;

                return myNextNodes.Length > 0;

            }

        }

        public bool Contains(IPathNode TheNextNode)
        {

            if(myNextNodes != null && myNextNodes.Length > 0)
            {

                for(int i = 0; i < myNextNodes.Length; i++)
                {

                    if(TheNextNode == myNextNodes[i])
                    {

                        return true;

                    }

                }

            }

            return false;

        }

        public virtual void SetNext(IPathNode TheNextNode)
        {

            if(TheNextNode != null)
            {

                myNextNodes = new IPathNode[] { TheNextNode };

            }

        }

        public virtual void SetNext(IPathNode[] TheNextNodes)
        {

            if(TheNextNodes != null && TheNextNodes.Length > 0)
            {

                IPathNode[] NextNodes = new IPathNode[TheNextNodes.Length];

                for(int i = 0; i < TheNextNodes.Length; i++)
                {

                    NextNodes[i] = TheNextNodes[i];

                }

                myNextNodes = NextNodes;

            }

        }

        public virtual void SetNextParams(params IPathNode[] TheNextNodes)
        {

            if(TheNextNodes.Length > 0)
            {

                myNextNodes = TheNextNodes;

            }

        }

        public void ClearNext()
        {

            if(myNextNodes == null)
                myNextNodes = null;

        }

    }

}
