using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading.SubThreading.Ids
{

    public abstract class BaseIsolatedTimersTimerGuid : BaseIsolatedTimersTimerWithId<Guid>, IIsolatedThreadWithId<Guid>, IIsolatedThread, IDisposable
    {

        public BaseIsolatedTimersTimerGuid()
            : base(Guid.NewGuid())
        {
        }

        public BaseIsolatedTimersTimerGuid(object LObj)
            : base(Guid.NewGuid(), LObj)
        {
        }

        public BaseIsolatedTimersTimerGuid(double Ival)
            : base(Guid.NewGuid(), Ival)
        {
        }

        public BaseIsolatedTimersTimerGuid(double Ival, object LObj)
            : base(Guid.NewGuid(), Ival, LObj)
        {
        }

    }

}
