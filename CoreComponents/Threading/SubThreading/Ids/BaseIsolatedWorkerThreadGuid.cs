using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading.SubThreading.Ids
{

    public abstract class BaseIsolatedWorkerThreadGuid : BaseIsolatedWorkerThreadWithId<Guid>, IIsolatedThreadWithId<Guid>, IIsolatedThread
    {

        public BaseIsolatedWorkerThreadGuid()
            : base(Guid.NewGuid())
        {
        }

        public BaseIsolatedWorkerThreadGuid(object LObject)
            : base(Guid.NewGuid(), LObject)
        {
        }

    }

}
