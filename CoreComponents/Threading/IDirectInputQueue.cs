using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    public interface IDirectInputQueue<T> : IDirectCollection
    {

        bool Enqueue(T TheItem);

    }

}
