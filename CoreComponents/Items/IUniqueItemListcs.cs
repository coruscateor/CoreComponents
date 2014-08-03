using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Items
{
    
    public interface IUniqueItemList<T> : IList<T>
    {

        bool TryAdd(T item);

        bool TryInsert(int index, T item);

        bool TrySet(int TheIndex, T TheItem);

        bool TryGet(int TheIndex, out T TheItem);

    }

}
