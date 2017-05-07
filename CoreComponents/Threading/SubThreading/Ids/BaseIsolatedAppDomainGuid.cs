using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading.SubThreading.Ids
{

    public abstract class BaseIsolatedAppDomainGuid : BaseIsolatedAppDomainWithId<Guid>, IIsolatedThreadWithId<Guid>, IIsolatedThread
    {

        public BaseIsolatedAppDomainGuid()
            : base(Guid.NewGuid())
        {
        }

        public BaseIsolatedAppDomainGuid(string TheName)
            : base(Guid.NewGuid(), TheName)
        {
        }

        public BaseIsolatedAppDomainGuid(object LObj)
            : base(Guid.NewGuid(), LObj)
        {
        }

        public BaseIsolatedAppDomainGuid(string TheName, object LObj)
            : base(Guid.NewGuid(), TheName, LObj)
        {
        }

    }

}
