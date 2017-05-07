using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading.SubThreading.Ids
{

    public abstract class BaseIsolatedTimerGuid : BaseIsolatedTimerWithId<Guid>, IIsolatedThreadWithId<Guid>, IIsolatedThread, IDisposable
    {

        public BaseIsolatedTimerGuid(object lockObject = null)
            : base(Guid.NewGuid(), lockObject)
        {
        }

        public BaseIsolatedTimerGuid(int TheDueTime, int ThePeriod, object lockObject = null)
            : base(Guid.NewGuid(), TheDueTime, ThePeriod, lockObject)
        {
        }

        public BaseIsolatedTimerGuid(long TheDueTime, long ThePeriod, object lockObject = null)
            : base(Guid.NewGuid(), TheDueTime, ThePeriod, lockObject)
        {
        }

        public BaseIsolatedTimerGuid(TimeSpan TheDueTime, TimeSpan ThePeriod, object lockObject = null)
            : base(Guid.NewGuid(), TheDueTime, ThePeriod, lockObject)
        {
        }

        public BaseIsolatedTimerGuid(uint TheDueTime, uint ThePeriod, object lockObject = null)
            : base(Guid.NewGuid(), TheDueTime, ThePeriod, lockObject)
        {
        }

    }

}
