using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreComponents.Threading
{

    public interface IDirectOutputQueue<T> : IDirectCollection
    {

        bool TryDequeue(ref T TheItem);

    }

}
