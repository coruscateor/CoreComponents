using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading.SubThreading.Ids
{

    public abstract class BaseIsolatedWaitForSingleObjectGuid : BaseIsolatedWaitForSingleObjectWithId<Guid>, IIsolatedThreadWithId<Guid>, IIsolatedThread
    {

        public BaseIsolatedWaitForSingleObjectGuid()
            : base(Guid.NewGuid())
        {
        }

        public BaseIsolatedWaitForSingleObjectGuid(object LObj)
            : base(Guid.NewGuid(), LObj)
        {
        }

        public BaseIsolatedWaitForSingleObjectGuid(long TheTimeoutInterval)
            : base(Guid.NewGuid(), TheTimeoutInterval)
        {
        }

        public BaseIsolatedWaitForSingleObjectGuid(long TheTimeoutInterval, object LObj)
            : base(Guid.NewGuid(), TheTimeoutInterval, LObj)
        {
        }

        public BaseIsolatedWaitForSingleObjectGuid(long TheTimeoutInterval, bool ExecuteOnce)
            : base(Guid.NewGuid(), TheTimeoutInterval, ExecuteOnce)
        {
        }

        public BaseIsolatedWaitForSingleObjectGuid(long TheTimeoutInterval, bool ExecuteOnce, object LObj)
            : base(Guid.NewGuid(), TheTimeoutInterval, ExecuteOnce, LObj)
        {
        }

    }

}
