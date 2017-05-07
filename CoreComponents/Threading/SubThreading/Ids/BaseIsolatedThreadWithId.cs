using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading.SubThreading.Ids
{

    public abstract class BaseIsolatedThreadWithId<TID> : BaseIsolatedThread, IIsolatedThreadWithId<TID>, IIsolatedThread
    {

        private readonly TID myId;

        public BaseIsolatedThreadWithId(TID TheId, int TheMaxStackSize = 0)
            : base(TheMaxStackSize)
        {

            myId = TheId;

        }

        public BaseIsolatedThreadWithId(TID TheId, object LObj, int TheMaxStackSize = 0)
            : base(LObj, TheMaxStackSize)
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
