using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading.SubThreading.Ids
{

    public abstract class BaseIsolatedWorkerThreadWithId<TID> : BaseIsolatedThread, IIsolatedThreadWithId<TID>, IIsolatedThread
    {

        private readonly TID myId;

        public BaseIsolatedWorkerThreadWithId(TID TheId, int TheMaxStackSize = 0)
            : base(TheMaxStackSize)
        {

            myId = TheId;

        }

        public BaseIsolatedWorkerThreadWithId(TID TheId, object lockObject, int TheMaxStackSize = 0)
            : base(lockObject, TheMaxStackSize)
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
