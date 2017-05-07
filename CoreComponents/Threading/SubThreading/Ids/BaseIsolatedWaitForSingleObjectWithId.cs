using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading.SubThreading.Ids
{

    public abstract class BaseIsolatedWaitForSingleObjectWithId<TID> : BaseIsolatedWaitForSingleObject, IIsolatedThreadWithId<TID>, IIsolatedThread
    {

        private readonly TID myId;

        public BaseIsolatedWaitForSingleObjectWithId(TID TheId)
            : base()
        {

            myId = TheId;

        }

        public BaseIsolatedWaitForSingleObjectWithId(TID TheId, object LObj)
            : base(LObj)
        {

            myId = TheId;

        }

        public BaseIsolatedWaitForSingleObjectWithId(TID TheId, long TheTimeoutInterval)
            : base(TheTimeoutInterval)
        {

            myId = TheId;

        }

        public BaseIsolatedWaitForSingleObjectWithId(TID TheId, long TheTimeoutInterval, object LObj)
            : base(TheTimeoutInterval, LObj)
        {

            myId = TheId;

        }

        public BaseIsolatedWaitForSingleObjectWithId(TID TheId, long TheTimeoutInterval, bool ExecuteOnce)
            : base(TheTimeoutInterval, ExecuteOnce)
        {

            myId = TheId;

        }

        public BaseIsolatedWaitForSingleObjectWithId(TID TheId, long TheTimeoutInterval, bool ExecuteOnce, object LObj)
            : base(TheTimeoutInterval, ExecuteOnce, LObj)
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
