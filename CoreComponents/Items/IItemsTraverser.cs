using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Items
{

    public interface IItemsTraverser
    {

        //object[] ToArray();

        long Count
        {

            get;

        }

        long Place
        {

            get;

        }

        //object CurrentItem
        //{

        //    get;

        //}

        bool HasItems
        {

            get;

        }

        bool Next();

        bool Previous();

        void First();

        void Last();

        bool SkipTo(int ThePlace);

        bool SkipTo(long ThePlace);

        bool IsAtBeginning
        {

            get;

        }

        bool IsAtEnd
        {

            get;

        }

        void SetEmpty();

        //void RemoveItems();

        //void SetItems(IEnumerable TheItems);

        //void SetItems(object[] TheItems);

        //void SetItems(IEnumerable<T> TheItems);

        //void SetItems(T[] TheItems);

        //void SetItems(List<T> TheItems);

        //void SetItems(Queue<T> TheItems);

        //void SetItems(Stack<T> TheItems);

        //public PlaceMessageText PlaceMessageText
        //{

        //    get;
        //    set;
        //}

        //string GetMessage();

    }

    public interface IItemsTraverser<T> : IItemsTraverser
    {

        T[] ToArray();

        T CurrentItem
        {

            get;

        }

        void SetItems(IEnumerable<T> TheItems);

        void SetItems(T[] TheItems);

        void SetItems(List<T> TheItems);

        void SetItems(Queue<T> TheItems);

        void SetItems(Stack<T> TheItems);

    }

}
