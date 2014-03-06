using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Items
{

    public interface ILongCollection<T> : IHasLongCount, IEnumerable<T>
    {

        bool IsReadOnly
        {
            
            get;
        
        }

        void Add(T item);

        void AddRange(IEnumerable<T> TheCollection);

        void Clear();
        
        bool Contains(T item);

        void CopyTo(T[] array, long arrayIndex);
        
        bool Remove(T item);

    }

}
