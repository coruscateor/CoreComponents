using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Control.Nodes
{

    //public interface IPathNode
    //{

    //    bool GetNext(object TheValue, out IPathNode NextNode);

    //    object Value
    //    {

    //        get;

    //    }
        
    //    int NextCount
    //    {

    //        get;

    //    }

    //    bool IsTerminal
    //    {

    //        get;

    //    }

    //    bool Contains(IPathNode TheNextNode);

    //    void SetNext(IPathNode TheNextNode);

    //    void SetNext(IPathNode[] TheNextNodes);

    //    void SetNextParams(params IPathNode[] TheNextNodes);

    //    void ClearNext();

    //}

    public interface IPathNode<TValue> : IToArray<IPathNode<TValue>>, IEnumerable<IPathNode<TValue>> //: IPathNode
    {

        bool GetNext(TValue TheValue, out IPathNode<TValue> NextNode);

        TValue Value
        {

            get;

        }

        bool ValueIsDefault
        {

            get;

        }

        int NextCount
        {

            get;

        }

        bool IsTerminal
        {

            get;

        }

        bool Contains(IPathNode<TValue> TheNextNode);

        void AddNext(IPathNode<TValue> TheNextNode);

        void RemoveNext(IPathNode<TValue> TheNextNode);

        //void SetNext(params IPathNode<TValue>[] TheNextNodes);

        //void SetNextParams(params IPathNode<TValue>[] TheNextNodes);

        void ClearNext();

    }

}
