using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading.SubThreading.Ids
{

    public abstract class IsolatedAppDomainGuid : IsolatedAppDomainWithId<Guid>
    {

        public IsolatedAppDomainGuid()
            : base(Guid.NewGuid())
        {
        }

        public IsolatedAppDomainGuid(string TheName)
            : base(Guid.NewGuid(), TheName)
        {
        }

        public IsolatedAppDomainGuid(object LObj)
            : base(Guid.NewGuid(), LObj)
        {
        }

        public IsolatedAppDomainGuid( string TheName, object LObj)
            : base(Guid.NewGuid(), TheName, LObj)
        {
        }

    }

}
