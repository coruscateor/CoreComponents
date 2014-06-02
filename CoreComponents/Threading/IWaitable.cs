using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{
    
    public interface IWaitable
    {

        void Reset();

        void Wait();

        void Wait(CancellationToken TheCancellationToken);

        bool Wait(int TheMillisecondsTimeout);

        bool Wait(TimeSpan TheTimeout);

        bool Wait(int TheMillisecondsTimeout, CancellationToken TheCancellationToken);

        bool Wait(TimeSpan TheTimeout, CancellationToken TheCancellationToken);

    }

}
