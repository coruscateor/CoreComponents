using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Items
{

    public interface ILongList<T> : ILongCollection<T>
    {

        T this[long index]
        {
            
            get;
            set;
        
        }

        long IndexOf(T item);

        void Insert(long index, T item);

        void RemoveAt(long index);

    }

}
