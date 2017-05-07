using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading.SubThreading.Ids
{

    public abstract class IsolatedWaitForSingleObjectGuid : IsolatedWaitForSingleObjectWithId<Guid>, IIsolatedThreadWithId<Guid>, IIsolatedThread
    {

        public IsolatedWaitForSingleObjectGuid()
            : base(Guid.NewGuid())
        {
        }

        public IsolatedWaitForSingleObjectGuid(object LObj)
            : base(Guid.NewGuid(), LObj)
        {
        }

        public IsolatedWaitForSingleObjectGuid(long TheTimeoutInterval)
            : base(Guid.NewGuid(), TheTimeoutInterval)
        {
        }

        public IsolatedWaitForSingleObjectGuid(long TheTimeoutInterval, object LObj)
            : base(Guid.NewGuid(), TheTimeoutInterval, LObj)
        {
        }

        public IsolatedWaitForSingleObjectGuid(long TheTimeoutInterval, bool ExecuteOnce)
            : base(Guid.NewGuid(), TheTimeoutInterval, ExecuteOnce)
        {
        }

    }

}
