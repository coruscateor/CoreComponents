using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    public interface IInputQueue<T> : IItemSet
    {

        void Enqueue(T TheItem);

    }

}
