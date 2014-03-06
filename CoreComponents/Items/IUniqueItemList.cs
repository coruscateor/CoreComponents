using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Items
{

    public interface IUniqueItemList<T> : IEnumerable<T>, IToArray<T>
    {

        int IndexOf(T item);

        bool Insert(int index, T item);

        void RemoveAt(int index);

        T this[int index]
        {

            get;
            set;

        }

        bool TryGet(int TheIndex, out T TheItem);

        bool Add(T item);

        void Clear();

        bool Contains(T item);

        void CopyTo(T[] array, int arrayIndex);

        int Count
        {

            get;

        }

        bool IsReadOnly
        {

            get;

        }

        bool Remove(T item);

    }

}
