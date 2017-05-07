using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading.SubThreading.Ids
{

    public abstract class IsolatedThreadGuid : IsolatedThreadWithId<Guid>, IIsolatedThreadWithId<Guid>, IIsolatedThread
    {
        
        public IsolatedThreadGuid( int TheMaxStackSize = 0)
            : base(Guid.NewGuid(), TheMaxStackSize)
        {
        }

        public IsolatedThreadGuid(object LObj, int TheMaxStackSize = 0)
            : base(Guid.NewGuid(), LObj, TheMaxStackSize)
        {
        }

    }

}
