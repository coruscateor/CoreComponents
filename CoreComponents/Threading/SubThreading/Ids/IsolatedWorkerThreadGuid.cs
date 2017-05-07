using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading.SubThreading.Ids
{

    public abstract class IsolatedWorkerThreadGuid : IsolatedWorkerThreadWithId<Guid>, IIsolatedThreadWithId<Guid>, IIsolatedThread
    {

        public IsolatedWorkerThreadGuid(int TheMaxStackSize = 0)
            : base(Guid.NewGuid(), TheMaxStackSize)
        {
        }

        public IsolatedWorkerThreadGuid(object lockObject, int TheMaxStackSize = 0)
            : base(Guid.NewGuid(), lockObject, TheMaxStackSize)
        {
        }

    }

}
