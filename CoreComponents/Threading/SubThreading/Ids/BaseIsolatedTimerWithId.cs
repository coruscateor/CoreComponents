using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreComponents.Threading.SubThreading.Ids
{

    public abstract class BaseIsolatedTimerWithId<TID> : BaseIsolatedTimer, IIsolatedThreadWithId<TID>, IIsolatedThread
    {

        private readonly TID myId;

        public BaseIsolatedTimerWithId(TID TheId, object lockObject = null)
            : base(lockObject)
        {

            myId = TheId;

        }

        public BaseIsolatedTimerWithId(TID TheId, int TheDueTime, int ThePeriod, object lockObject = null)
            : base(TheDueTime, ThePeriod, lockObject)
        {

            myId = TheId;

        }

        public BaseIsolatedTimerWithId(TID TheId, long TheDueTime, long ThePeriod, object lockObject = null)
            : base(TheDueTime, ThePeriod, lockObject)
        {

            myId = TheId;

        }

        public BaseIsolatedTimerWithId(TID TheId, TimeSpan TheDueTime, TimeSpan ThePeriod, object lockObject = null)
            : base(TheDueTime, ThePeriod, lockObject)
        {

            myId = TheId;

        }

        public BaseIsolatedTimerWithId(TID TheId, uint TheDueTime, uint ThePeriod, object lockObject = null)
            : base(TheDueTime, ThePeriod, lockObject)
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
