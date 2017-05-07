using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading.SubThreading.Ids
{

    public abstract class IsolatedTimerGuid : IsolatedTimerWithId<Guid>, IIsolatedThreadWithId<Guid>, IIsolatedThread
    {

        public IsolatedTimerGuid(object lockObject = null)
            : base(Guid.NewGuid(), lockObject)
        {
        }

        public IsolatedTimerGuid(int TheDueTime, int ThePeriod, object lockObject = null)
            : base(Guid.NewGuid(), TheDueTime, ThePeriod, lockObject)
        {
        }

        public IsolatedTimerGuid(long TheDueTime, long ThePeriod, object lockObject = null)
            : base(Guid.NewGuid(), TheDueTime, ThePeriod, lockObject)
        {
        }

        public IsolatedTimerGuid(TimeSpan TheDueTime, TimeSpan ThePeriod, object lockObject = null)
            : base(Guid.NewGuid(), TheDueTime, ThePeriod, lockObject)
        {
        }

        public IsolatedTimerGuid(uint TheDueTime, uint ThePeriod, object lockObject = null)
            : base(Guid.NewGuid(), TheDueTime, ThePeriod, lockObject)
        {
        }

    }

}
