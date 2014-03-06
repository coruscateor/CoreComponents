using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    public interface IOutputQueue<T> : IItemSet
    {

        bool TryDequeue(out T TheItem);

    }

}
