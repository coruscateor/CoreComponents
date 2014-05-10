using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Items
{
    
    public interface IListContainer<T> : IHasCount, IToArray<T>, IListSource<T>, IEnumerable<T>
    {

        int IndexOf(T item);

        void Insert(int index, T item);

        public T this[int index]
        {

            get;

        }

        bool Contains(T item);

    }

}
