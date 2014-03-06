using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Control.Nodes
{

    public interface ISinglePathNode<TValue>
    {

        TValue Value
        {

            get;
            set;

        }

        //bool HasNextNode
        //{

        //    get;

        //}

        bool IsTerminal
        {

            get;

        }

        ISinglePathNode<TValue> NextNode
        {

            get;
            set;

        }

        bool GetNextNode(TValue TheValue, out ISinglePathNode<TValue> TheNextNode);

        bool GetNextNode(TValue TheValue, Action<ISinglePathNode<TValue>> FoundAction);

        bool GetNextNode(TValue TheValue, Action FoundAction, out ISinglePathNode<TValue> TheNextNode);

        bool GetNextNode(TValue TheValue, Action<TValue> FoundAction, out ISinglePathNode<TValue> TheNextNode);

        bool GetNextNode(TValue TheValue, Action<ISinglePathNode<TValue>> FoundAction, out ISinglePathNode<TValue> TheNextNode);

        //void SetNext(ISinglePathNode<TValue> TheNextNode);

        //bool NextIs(ISinglePathNode<TValue> TheNextNode);

        void ClearNext();

    }

}
