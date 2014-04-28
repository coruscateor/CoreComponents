using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CoreComponents.Threading
{

    public interface IWaitableClicker : IClicker
    {
        
        void Wait();

        void Wait(CancellationToken CancellationToken);

        bool Wait(int MillisecondsTimeout);

        bool Wait(TimeSpan Timeout);

        bool Wait(int MillisecondsTimeout, CancellationToken CancellationToken);

        bool Wait(TimeSpan Timeout, CancellationToken CancellationToken);

    }

}
