using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading.SubThreading.Ids
{

    public abstract class BaseIsolatedAppDomainWithId<TID> : BaseIsolatedAppDomain, IIsolatedThreadWithId<TID>, IIsolatedThread
    {

        private readonly TID myId;

        public BaseIsolatedAppDomainWithId(TID TheId)
            : base()
        {

            myId = TheId;

        }

        public BaseIsolatedAppDomainWithId(TID TheId, string TheName)
            : base(TheName)
        {

            myId = TheId;

        }

        public BaseIsolatedAppDomainWithId(TID TheId, object LObj)
            : base(LObj)
        {

            myId = TheId;

        }

        public BaseIsolatedAppDomainWithId(TID TheId, string TheName, object LObj)
            : base(TheName, LObj)
        {

            myId = TheId;

        }

        public TID Id
        {

            get
            {

                return myId;

            }

        }

    }

}
