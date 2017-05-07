using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading.SubThreading.Ids
{

    public abstract class IsolatedTimersTimerGuid : IsolatedTimersTimerWithId<Guid>, IIsolatedThreadWithId<Guid>, IIsolatedThread
    {

        public IsolatedTimersTimerGuid()
            : base(Guid.NewGuid())
        {
        }

        public IsolatedTimersTimerGuid(object LObj)
            : base(Guid.NewGuid(), LObj)
        {
        }

        public IsolatedTimersTimerGuid(double Ival)
            : base(Guid.NewGuid(), Ival)
        {
        }

        public IsolatedTimersTimerGuid(double Ival, object LObj)
            : base(Guid.NewGuid(), Ival, LObj)
        {
        }

    }

}
