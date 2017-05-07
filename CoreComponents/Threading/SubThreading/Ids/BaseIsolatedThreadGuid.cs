using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading.SubThreading.Ids
{

    public abstract class BaseIsolatedThreadGuid : BaseIsolatedThreadWithId<Guid>, IIsolatedThreadWithId<Guid>, IIsolatedThread, IDisposable
    {

        public BaseIsolatedThreadGuid(int TheMaxStackSize = 0)
            : base(Guid.NewGuid(), TheMaxStackSize)
        {
        }

        public BaseIsolatedThreadGuid(object LObj, int TheMaxStackSize = 0)
            : base(Guid.NewGuid(), LObj, TheMaxStackSize)
        {
        }

    }

}
